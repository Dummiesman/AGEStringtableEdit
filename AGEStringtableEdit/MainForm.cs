using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGEStringtableEdit.Extensions;
using Microsoft.VisualBasic;


namespace AGEStringtableEdit
{
    public partial class MainForm : Form
    {
        // form info
        public const string APPTITLE = "AGE String Table Editor";
        private readonly Dictionary<StringTable.Language, StringTableDataEdit> DataCtrls = new Dictionary<StringTable.Language, StringTableDataEdit>();

        // project info
        private StringTableProject project = null;
        private string projectPath = null;

        // list view selection change counter
        private int lvSelectChangeCount = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateIdentifierList()
        {
            string lastSelection = listViewIdentifiers.SelectedIndices.Count > 0 ? listViewIdentifiers.SelectedItems[0].Text : null;
            listViewIdentifiers.Items.Clear();

            if (project != null)
            {
                foreach (var str in project.Table.Strings.OrderBy(x => x.Key))
                {
                    listViewIdentifiers.Items.Add(str.Key);
                }
            }

            if(lastSelection != null)
            {
                var item = listViewIdentifiers.FindItemWithText(lastSelection);
                if(item != null) item.SelectAndFocus();
            }
        }

        private void UpdateContextMenu()
        {
            contextMenuStrip1.Enabled = (project != null);
            deleteSelectedStringToolStripMenuItem.Enabled = (project != null && listViewIdentifiers.SelectedIndices.Count > 0);
            renameToolStripMenuItem.Enabled = (project != null && listViewIdentifiers.SelectedIndices.Count > 0);
        }

        private void UpdateToolbar()
        {
            saveToolStripButton.Enabled = (project != null);
            toolStrip2.Enabled = (project != null);
            toolStripButtonImport.Enabled = (project != null);
            toolStripButtonExport.Enabled = (project != null);
        }

        private void UpdateTitleBar()
        {
            if (project != null)
            {
                if (projectPath != null)
                {
                    this.Text = $"{APPTITLE} - {Path.GetFileNameWithoutExtension(projectPath)}{(project.IsDirty() ? "*" : "")}";
                }
                else
                {
                    this.Text = $"{APPTITLE} - Untitled{(project.IsDirty() ? "*" : "")}";
                }
            }
            else
            {
                this.Text = $"{APPTITLE}";
            }
        }

        private void UpdateTabControl()
        {
            tabControl1.Enabled = (project != null && listViewIdentifiers.SelectedIndices.Count > 0);
        }

        private void UpdateEverything()
        {
            UpdateIdentifierList();
            UpdateToolbar();
            UpdateTitleBar();
            UpdateTabControl();
            UpdateContextMenu();
        }

        private void LoadStringTable(string path)
        {
            // read table
            projectPath = path;
            project = new StringTableProject();
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                project.Table.Read(reader);
            }
            project.Table.MergeDownRedundantTranslations();
            UpdateEverything();
        }

        private void NewStringTable()
        {
            projectPath = null;
            project = new StringTableProject();

            UpdateEverything();
        }

        private void SaveStringTable()
        {
            if(projectPath != null)
            {
                if (File.Exists(projectPath)) File.Delete(projectPath);
                using (var writer = new BinaryWriter(File.OpenWrite(projectPath)))
                {
                    project.Table.Save(writer);
                    project.ClearDirtyFlag();
                }
            }
            else
            {
                saveFileDialog.ShowDialog();
            }

            UpdateToolbar();
            UpdateTitleBar();
        }

        /// <summary>
        /// Shows the unsafed changes dialog. If the user requests to cancel, FALSE is returned. Otherwise TRUE is reeturned.
        /// </summary>
        /// <returns>A boolean indicating if the program can proceed</returns>
        private bool ShowUnsavedChangesDialog()
        {
            if (project == null || !project.IsDirty()) return true;
            var res = MessageBox.Show(Properties.Resources.UnsavedChangesStr,
                                      "Unsaved Changes",
                                      MessageBoxButtons.YesNoCancel,
                                      MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                SaveStringTable();
            }
            else if (res == DialogResult.Cancel)
            {
                return false;
            }
            return true;
        }

        private void ExportStringTable(string path)
        {
            project.Table.ExportToTextFile(path);
        }

        private void ImportStringTable(string path)
        {
            var importTable = new StringTable();
            importTable.ImportFromTextFile(path);
            importTable.MergeDownRedundantTranslations();
            foreach(var item in importTable.Strings)
            {
                if(project.Table.Strings.ContainsKey(item.Key))
                {
                    var res = MessageBox.Show($"The current stringtable already contains the identifier '{item.Key}', do you want to overwrite it?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.Cancel) break;
                    if (res == DialogResult.No) continue;
                }
                project.Table.Strings[item.Key] = item.Value;
                project.MarkDirty();
            }
            UpdateIdentifierList();
        }

        private void UserActionDeleteString()
        {
            string key = listViewIdentifiers.SelectedIndices.Count > 0 ? listViewIdentifiers.SelectedItems[0].Text : null;
            if (key != null)
            {
                if (project.Table.Strings.ContainsKey(key))
                {
                    var result = MessageBox.Show($"Are you sure you want to remove '{key}' from the string table?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        project.MarkDirty();
                        project.Table.Strings.Remove(key);
                        UpdateIdentifierList();
                        UpdateTabControl();
                        UpdateTitleBar();
                    }
                }
            }
        }

        private void UserActionAddString()
        {
            string identifier = Interaction.InputBox("Enter Identifier", "Input");
            if (!string.IsNullOrWhiteSpace(identifier))
            {
                if (project.Table.Strings.ContainsKey(identifier))
                {
                    MessageBox.Show($"Identifier '{identifier}' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    project.Table.Strings.Add(identifier, new StringTable.StringDataContainer());
                    project.MarkDirty();
                    UpdateIdentifierList();
                    UpdateTitleBar();

                    var item = listViewIdentifiers.FindItemWithText(identifier);
                    if (item != null) item.SelectAndFocus();
                }
            }
        }

        private void UserActionRename()
        {
            if(listViewIdentifiers.SelectedIndices.Count > 0)
            {
                var item = listViewIdentifiers.SelectedItems[0];
                item.BeginEdit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Create the language tabs
            for(int i=0; i < (int)StringTable.Language.LanguageCount; i++)
            {
                string name = Enum.GetName(typeof(StringTable.Language), i);
                var tab = new TabPage() { Padding = new Padding(3, 3, 3, 3), Text = name, BackColor = Color.White };
                
                var control = new StringTableDataEdit() { Name = $"stringDataEdit_{i}", Dock = DockStyle.Fill };
                tab.Controls.Add(control);

                tabControl1.TabPages.Add(tab);
                DataCtrls.Add((StringTable.Language)i, control);
            }

            UpdateEverything();

            // Open from command line if present
            var args = Environment.GetCommandLineArgs();
            if(args.Length > 1 && File.Exists(args[1]))
            {
                LoadStringTable(args[1]);
            }
        }

        private void toolStripButtonDelStr_Click(object sender, EventArgs e)
        {
            UserActionDeleteString();
        }

        private void toolStripButtonAddStr_Click(object sender, EventArgs e)
        {
            UserActionAddString();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (!ShowUnsavedChangesDialog()) return;
            openFileDialog.ShowDialog();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveStringTable();
        }

        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            projectPath = saveFileDialog.FileName;
            SaveStringTable();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (!ShowUnsavedChangesDialog()) return;
            NewStringTable();
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                LoadStringTable(openFileDialog.FileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Stringtable load failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            string firstLine = $"{APPTITLE} (Beta version) - Built {Properties.Resources.BuildDate}\n";
            MessageBox.Show($"{firstLine}{Properties.Resources.AboutStr}", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserActionAddString();
        }

        private void deleteSelectedStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserActionDeleteString();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateContextMenu();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserActionRename();
        }

        private void listViewIdentifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = listViewIdentifiers.SelectedIndices.Count > 0 ? listViewIdentifiers.SelectedItems[0].Text : null;
            if (key != null)
            {
                var container = project.Table.Strings[key];
                for (int i = 0; i < (int)StringTable.Language.LanguageCount; i++)
                {
                    StringTable.Language language = (StringTable.Language)i;
                    if (DataCtrls.TryGetValue(language, out var control))
                    {
                        control.Init(project, container, language);
                    }
                }
            }
            UpdateTabControl();
        }

        private void listViewIdentifiers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                UserActionDeleteString();
            }
            else if (e.KeyCode == Keys.F2)
            {
                UserActionRename();
            }
        }

        private void listViewIdentifiers_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.CancelEdit || e.Label == null || e.Label.Trim().Length == 0)
            {
                e.CancelEdit = true;
                return;
            }
            
            e.CancelEdit = true;
            string newName = e.Label.Trim();

            if (project.Table.Strings.ContainsKey(newName))
            {
                MessageBox.Show($"Identifier '{newName}' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string prevName = listViewIdentifiers.Items[e.Item].Text;
            var data = project.Table.Strings[prevName];
            project.Table.Strings.Remove(prevName);
            project.Table.Strings.Add(newName, data);

            project.MarkDirty();
            UpdateIdentifierList();
            UpdateTitleBar();

            var item = listViewIdentifiers.FindItemWithText(newName);
            if (item != null) item.SelectAndFocus();
        }

        private void toolStripButtonExport_Click(object sender, EventArgs e)
        {
            saveFileDialogExport.ShowDialog();
        }

        private void saveFileDialogExport_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ExportStringTable(saveFileDialogExport.FileName);
        }

        private void openFileDialogImport_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                ImportStringTable(openFileDialogImport.FileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Stringtable import failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonImport_Click(object sender, EventArgs e)
        {
            openFileDialogImport.ShowDialog();
        }

        private void titleBarTimer_Tick(object sender, EventArgs e)
        {
            UpdateTitleBar();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ShowUnsavedChangesDialog()) e.Cancel = true;
        }
    }
}
