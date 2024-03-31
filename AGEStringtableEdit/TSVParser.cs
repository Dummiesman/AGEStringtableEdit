using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGEStringtableEdit
{
    internal class TSVParser
    {
        private string content;
        private int currentPosition = 0;

        private Dictionary<string, int> columnMap;
        private string[] currentLineTokens;
        
        private StringBuilder lineBuilder = new StringBuilder(1024);
        public bool EOF => currentPosition == content.Length;

        
        public bool ParseLine()
        {
            if (EOF) return false;

            lineBuilder.Clear();
            for (int i = currentPosition; i < content.Length - 1; i++)
            {
                if (content[i] == '\r' && content[i+1] == '\n')
                {
                    // found newline
                    currentPosition += 2;
                    break;
                }
                lineBuilder.Append(content[i]);
                currentPosition++;
            }

            currentLineTokens = lineBuilder.ToString().Split('\t');
            return true;
        }

        public void ReadHeader()
        {
            ParseLine();
            columnMap = currentLineTokens.Select((value, index) => new { Value = value, Index = index })
                                         .ToDictionary(item => item.Value.ToLowerInvariant(), item => item.Index);
        }

        public bool TryGetColumn(string name, out string value)
        {
            value = null;
            if(!columnMap.TryGetValue(name.ToLowerInvariant(), out int columIndex))
            {
                return false;
            }
            if (columIndex >= currentLineTokens.Length)
            {
                return false;
            }
            value = currentLineTokens[columIndex];
            return true;
        }
        
        public TSVParser(string content)
        {
            this.content = content;
        }
    }
}
