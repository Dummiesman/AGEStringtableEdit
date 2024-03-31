using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AGEStringtableEdit
{
    public class StringTable
    {
        public static int Hash(string str)
        {
            uint hash = 0;
            for(int i=0; i < str.Length; i++)
            {
                hash = (byte)str[i] + 16 * hash;
                if ((hash & 0xF0000000) != 0)
                    hash ^= (hash & 0xF0000000) ^ ((hash & 0xF0000000) >> 24);
            }
            return (int)hash;
        }

        public enum Language
        {
            Invalid=-1,
            English,
            Spanish,
            French,
            German,
            Italian,
            Portuguese,
            Japanese,
            Chinese,
            Korean,
            Norwegian,
            LanguageCount // DONOTUSE
        }

        private static Dictionary<string, Language> prefixToLanguage = new Dictionary<string, Language>()
        {
            {"en", Language.English},
            {"es", Language.Spanish},
            {"fr", Language.French},
            {"de", Language.German},
            {"it", Language.Italian},
            {"pt", Language.Portuguese},
            {"jp", Language.Japanese},
            {"ch", Language.Chinese},
            {"ko", Language.Korean},
            {"no", Language.Norwegian}
        };

        private static Dictionary<Language, string> languageToPrefix = new Dictionary<Language, string>()
        {
            {Language.English, "en"},
            {Language.Spanish, "es"},
            {Language.French, "fr"},
            {Language.German, "de"},
            {Language.Italian, "it"},
            {Language.Portuguese, "pt"},
            {Language.Japanese, "jp"},
            {Language.Chinese, "ch"},
            {Language.Korean, "ko"},
            {Language.Norwegian, "no"}
        };

        public static string GetLanguagePrefix(Language language)
        {
            if (languageToPrefix.TryGetValue(language, out string prefix)) return prefix;
            return null;
        }

        public static Language GetLanguageFromPrefix(string prefix)
        {
            if (prefixToLanguage.TryGetValue(prefix, out var language)) return language;
            return Language.Invalid;
        }

        public class StringData : ICloneable
        {
            public string Text;
            public string Font;
            public int OffsetX;
            public int OffsetY;
            public float ScaleX = 1f;
            public float ScaleY = 1f;
            public int Flags;

            /// <summary>
            /// Gets the text with all \r\n replaced with just \n, or all \r replaced with \n
            /// This should be used when exporting to txt or writing to the stringtable file
            /// </summary>
            public string GetProcessedText()
            {
                return Text.Replace("\r\n", "\n").Replace("\r", "\n");
            }

            public object Clone()
            {
                return new StringData()
                {
                    Text = this.Text,
                    Font = this.Font,
                    OffsetX = this.OffsetX,
                    OffsetY = this.OffsetY,
                    ScaleX = this.ScaleX,
                    ScaleY = this.ScaleY,
                    Flags = this.Flags
                };
            }

            public override bool Equals(object obj)
            {
                return (obj is StringData other) &&
                    other.Text.Equals(this.Text) &&
                    other.Font.Equals(this.Font) &&
                    other.OffsetX == this.OffsetX &&
                    other.OffsetY == this.OffsetY &&
                    other.ScaleX == this.ScaleX &&
                    other.ScaleY == this.ScaleY;
            }
        }

        public class StringDataContainer
        {
            public StringData[] LanguageData = new StringData[(int)Language.LanguageCount];

            public StringDataContainer()
            {
                LanguageData[(int)Language.English] = new StringData(); // Create default English entry
            }
        }


        public readonly Dictionary<string, StringDataContainer> Strings = new Dictionary<string, StringDataContainer>();

        public void Save(BinaryWriter writer)
        {
            // write header (store the offset to each language, we'll write them later)
            writer.Write((int)Language.LanguageCount);

            long languageOffsetsOffset = writer.BaseStream.Position;
            long[] languageOffsets = new long[(int)Language.LanguageCount];
            for(int i=0; i < (int)Language.LanguageCount; i++)
            {
                writer.Write(0);
            }

            // write version
            writer.Write(0x00000200);

            // write identifiers
            writer.Write(Strings.Count);
            foreach(string str in Strings.OrderBy(x => x.Key).Select(x => x.Key))
            {
                writer.Write(str.Length);
                writer.Write(Encoding.ASCII.GetBytes(str));
                writer.Write((byte)0);
            }

            // write individual language tables
            for(int i=0; i < (int)Language.LanguageCount; i++)
            {
                // check if there are any entries for this language, if not, then we don't write it
                if (Strings.Count(x => x.Value.LanguageData[i] != null) == 0)
                {
                    languageOffsets[i] = 0;
                    continue;
                }

                // write the language data
                languageOffsets[i] = writer.BaseStream.Position;
                
                writer.Write(Strings.Count); 
                foreach(string identifier in Strings.OrderBy(x => x.Key).Select(x => x.Key))
                {
                    var container = Strings[identifier];
                    var data = container.LanguageData[i];
                    if (data == null)
                    {
                        // fall back to English, which should always exist
                        data = container.LanguageData[(int)Language.English];
                    }

                    writer.Write(Hash(identifier));
                    writer.Write((ushort)data.Flags);

                    writer.Write(data.Font?.Length ?? 0);
                    if(data.Font != null)
                    {
                        writer.Write(Encoding.ASCII.GetBytes(data.Font));
                    }

                    string processedText = data.GetProcessedText();
                    writer.Write(processedText.Length + 1);
                    writer.Write(Encoding.Unicode.GetBytes(processedText));
                    writer.Write((ushort)0x00); // write terminator

                    writer.Write(data.ScaleX);
                    writer.Write(data.ScaleY);
                    writer.Write((sbyte)data.OffsetX);
                    writer.Write((sbyte)data.OffsetY);
                }
            }

            // go back and write the language offsets
            writer.BaseStream.Seek(languageOffsetsOffset, SeekOrigin.Begin);
            for(int i=0; i < (int)Language.LanguageCount; i++)
            {
                writer.Write((uint)languageOffsets[i]);
            }
        }

        public void Read(BinaryReader reader)
        {
            // Read in language support
            int numLanguages = reader.ReadInt32();
            int[] languageOffsets = new int[numLanguages];
            for(int i=0; i < numLanguages; i++)
            {
                languageOffsets[i] = reader.ReadInt32();
            }

            // Version check
            int version = reader.ReadInt32();
            if(version != 0x00000200)
            {
                throw new Exception("Bad string table version.");
            }
            if(numLanguages != (int)Language.LanguageCount)
            {
                throw new Exception("Mismatched language count (String table may be too old/too new)");
            }

            // Read identifiers
            int numIdentifiers = reader.ReadInt32();
            string[] identifiers = new string[numIdentifiers];
            for(int i=0; i < numIdentifiers; i++)
            {
                int identLen = reader.ReadInt32();
                string identifier = new string(reader.ReadChars(identLen));
                identifiers[i] = identifier;
                reader.ReadByte(); // terminator
            }

            // Precompute hash->identifier
            Dictionary<int, string> hashToIdentifier = new Dictionary<int, string>();
            for(int i=0; i < numIdentifiers; i++)
            {
                hashToIdentifier[Hash(identifiers[i])] = identifiers[i];
            }
            
            // Read strings
            for (int langid = 0; langid < numLanguages; langid++)
            {
                reader.BaseStream.Seek(languageOffsets[langid], SeekOrigin.Begin);
                if(languageOffsets[langid] == 0 || languageOffsets[langid] == reader.BaseStream.Length)
                {
                    continue;
                }
                
                int numStrings = reader.ReadInt32();
                for (int i = 0; i < numStrings; i++)
                {
                    int hash = reader.ReadInt32();
                    int flags = reader.ReadUInt16();

                    int fontLen = reader.ReadInt32();
                    string font = null;
                    if (fontLen > 0)
                    {
                         font = Encoding.ASCII.GetString(reader.ReadBytes(fontLen));
                    }

                    int strLen = reader.ReadInt32() - 1;
                    string text = Encoding.Unicode.GetString(reader.ReadBytes(strLen * 2));
                    text = text.Replace("\r\n", Environment.NewLine).Replace("\r", Environment.NewLine).Replace("\n", Environment.NewLine);
                    reader.ReadUInt16(); // terminator

                    float scaleX = reader.ReadSingle();
                    float scaleY = reader.ReadSingle();
                    int offsetX = reader.ReadSByte();
                    int offsetY = reader.ReadSByte();

                    string identifier = hashToIdentifier.ContainsKey(hash) ? hashToIdentifier[hash] : $"unknown_str_{hash:X8}";
                 
                    if(!Strings.TryGetValue(identifier, out var container))
                    {
                        container = new StringDataContainer();
                        Strings.Add(identifier, container);
                    }

                    container.LanguageData[langid] = new StringData()
                    {
                        Font = font,
                        ScaleX = scaleX,
                        ScaleY = scaleY,
                        Flags = flags,
                        OffsetX = offsetX,
                        OffsetY = offsetY,
                        Text = text
                    };
                    
                }
            }
            
        }

        public void ExportToTextFile(string path)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("identifier\tfont\tlanguage\tstring\tscale x\tscale y\toffset x\toffset y\tflags\tNotes");
            foreach (var item in Strings.OrderBy(x => x.Key))
            {
                for (int i = 0; i < (int)StringTable.Language.LanguageCount; i++)
                {
                    if (item.Value.LanguageData[i] == null) continue;
                    var languageData = item.Value.LanguageData[i];
                    string languagePrefix = GetLanguagePrefix((Language)i);
                    string text = languageData.GetProcessedText();
                    if (text.Contains('\n')) text = $"\"{text}\"";

                    builder.Append($"{item.Key}\t");
                    builder.Append($"{languageData.Font}\t");
                    builder.Append($"{languagePrefix}\t");
                    builder.Append($"{text}\t");
                    builder.Append($"{languageData.ScaleX}\t");
                    builder.Append($"{languageData.ScaleY}\t");
                    builder.Append($"{languageData.OffsetX}\t");
                    builder.Append($"{languageData.OffsetY}\t");
                    builder.Append($"{languageData.Flags}\t");
                    builder.AppendLine();
                }
            }
            File.WriteAllText(path, builder.ToString());
        }

        public void ImportFromTextFile(string path)
        {
            string fileContents = File.ReadAllText(path);
            var parser = new TSVParser(fileContents);
            parser.ReadHeader();

            // parse contents
            while (parser.ParseLine())
            {
                float scaleX = 1.0f; float scaleY = 1.0f;
                int offsetX = 0; int offsetY = 0;
                int flags = 0;
                Language language = Language.Invalid;

                // extract the values
                if (!parser.TryGetColumn("identifier", out string identifier)) throw new Exception($"Identifier column missing on entry");
                if (!parser.TryGetColumn("font", out string font)) throw new Exception($"Font column missing on entry");
                if (!parser.TryGetColumn("language", out string languageStr)) throw new Exception($"Language column missing on entry");
                if (!parser.TryGetColumn("string", out string text)) throw new Exception($"String column missing on entry");
                if (parser.TryGetColumn("scale x", out string scaleXstr)) scaleX = float.Parse(scaleXstr, CultureInfo.InvariantCulture);
                if (parser.TryGetColumn("scale y", out string scaleYstr)) scaleY = float.Parse(scaleYstr, CultureInfo.InvariantCulture);
                if (parser.TryGetColumn("offset x", out string offsetXStr)) offsetX = int.Parse(offsetXStr);
                if (parser.TryGetColumn("offset y", out string offsetYStr)) offsetY = int.Parse(offsetYStr);
                if (parser.TryGetColumn("flags", out string flagsStr)) flags = int.Parse(flagsStr);
                language = StringTable.GetLanguageFromPrefix(languageStr);

                if (text.Contains('\n') && text.StartsWith("\"") && text.EndsWith("\"")) text = text.Substring(1, text.Length - 2);
                text = text.Replace("\r\n", Environment.NewLine).Replace("\r", Environment.NewLine).Replace("\n", Environment.NewLine);

                if (!Strings.TryGetValue(identifier, out var container))
                {
                    container = new StringTable.StringDataContainer();
                    Strings.Add(identifier, container);
                }

                if (language != StringTable.Language.Invalid)
                {
                    container.LanguageData[(int)language] = new StringTable.StringData()
                    {
                        ScaleX = scaleX,
                        ScaleY = scaleY,
                        Flags = flags,
                        Font = font,
                        OffsetX = offsetX,
                        OffsetY = offsetY,
                        Text = text
                    };
                }
            }
        }

        public void MergeDownRedundantTranslations()
        {
            // merge down redundant translations for editing purposes 
            foreach (var container in Strings.Values)
            {
                for (int i = (int)Language.LanguageCount - 1; i >= 1; i--)
                {
                    if (container.LanguageData[i] != null
                        && container.LanguageData[i].Equals(container.LanguageData[(int)Language.English]))
                    {
                        container.LanguageData[i] = null;
                    }
                }
            }
        }
    }
}
