using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGEStringtableEdit
{
    public partial class StringTableDataEdit : UserControl
    {
        private bool surpressFlagUpdateEvent = false;
        private bool surpressDirtyEvents = false;

        private StringTableProject project;
        private StringTable.StringDataContainer dataContainer;
        private StringTable.Language language;
        private StringTable.StringData data => dataContainer.LanguageData[(int)language];
        public StringTableDataEdit()
        {
            InitializeComponent();
        }

        private void UpdateBitflagUI()
        {
            surpressFlagUpdateEvent = true;
            var boxes = new[] {checkBoxBF1, checkBoxBF2, checkBoxBF4, checkBoxBF8, checkBoxBF16, checkBoxBF32, checkBoxBF64, checkBoxBF128,
                               checkBoxBF256, checkBoxBF512, checkBoxBF1024, checkBoxBF2048, checkBoxBF4096, checkBoxBF8192, checkBoxBF16384, checkBoxBF32768 };
            for(int i=0; i < 16; i++)
            {
                boxes[i].Checked = (data.Flags & (1 << i)) != 0;
            }
            surpressFlagUpdateEvent = false;
        }

        private void UpdateFlagsFromUI()
        {
            var boxes = new[] {checkBoxBF1, checkBoxBF2, checkBoxBF4, checkBoxBF8, checkBoxBF16, checkBoxBF32, checkBoxBF64, checkBoxBF128,
                               checkBoxBF256, checkBoxBF512, checkBoxBF1024, checkBoxBF2048, checkBoxBF4096, checkBoxBF8192, checkBoxBF16384, checkBoxBF32768 };

            int flags = 0;
            for (int i = 0; i < 16; i++)
            {
                if (boxes[i].Checked) flags |= 1 << i;
            }
            data.Flags = flags;
            project.MarkDirty();
        }

        public void Init(StringTableProject project, StringTable.StringDataContainer dataContainer, StringTable.Language language)
        {
            this.project = project;
            this.dataContainer = dataContainer;
            this.language = language;
            btnDeleteTranslation.Enabled = (language != StringTable.Language.English);
            if(this.data == null ) 
            {
                panelNoTxBlock.Visible = true;
                panelNoTxBlock.Dock = DockStyle.Fill;
            }
            else
            {
                panelNoTxBlock.Visible = false;

                surpressDirtyEvents = true;
                textBoxFont.Text = data.Font;
                textBoxText.Text = data.Text;
                textBoxOffsetX.Text = data.OffsetX.ToString();
                textBoxOffsetY.Text = data.OffsetY.ToString();
                textBoxScaleX.Text = data.ScaleX.ToString(CultureInfo.InvariantCulture);
                textBoxScaleY.Text = data.ScaleY.ToString(CultureInfo.InvariantCulture);
                UpdateBitflagUI();
                surpressDirtyEvents = false;
            }
        }

        private void buttonCreateTx_Click(object sender, EventArgs e)
        {
            this.dataContainer.LanguageData[(int)this.language] = (StringTable.StringData)this.dataContainer.LanguageData[(int)StringTable.Language.English].Clone();
            project.MarkDirty();
            Init(this.project, this.dataContainer, this.language); // reinit
        }

        private void StringTableDataEdit_Load(object sender, EventArgs e)
        {

        }

        private void textBoxFont_TextChanged(object sender, EventArgs e)
        {
            data.Font = textBoxFont.Text;
            if(!surpressDirtyEvents) project.MarkDirty();
        }

        private void textBoxText_TextChanged(object sender, EventArgs e)
        {
            data.Text = textBoxText.Text;
            if (!surpressDirtyEvents) project.MarkDirty();
        }

        private void BitFlagCheckboxChanged(object sender, EventArgs e)
        {
            if(!surpressFlagUpdateEvent) UpdateFlagsFromUI();
        }

        private void TextBoxFloatValidate(object sender, CancelEventArgs e)
        {
            e.Cancel = !float.TryParse(((TextBox)sender).Text, NumberStyles.Float, CultureInfo.InvariantCulture, out _);
        }

        private void TextBoxSByteValidate(object sender, CancelEventArgs e)
        {
            e.Cancel = !sbyte.TryParse(((TextBox)sender).Text, out _);
        }

        private void textBoxScaleY_Validated(object sender, EventArgs e)
        {
            data.ScaleY = float.Parse(textBoxScaleY.Text, CultureInfo.InvariantCulture);
            if (!surpressDirtyEvents) project.MarkDirty();
        }

        private void textBoxScaleX_Validated(object sender, EventArgs e)
        {
            data.ScaleX = float.Parse(textBoxScaleX.Text, CultureInfo.InvariantCulture);
            if (!surpressDirtyEvents) project.MarkDirty();
        }

        private void textBoxOffsetX_Validated(object sender, EventArgs e)
        {
            data.OffsetX = sbyte.Parse(textBoxOffsetX.Text);
            if (!surpressDirtyEvents) project.MarkDirty();
        }

        private void textBoxOffsetY_Validated(object sender, EventArgs e)
        {
            data.OffsetY = sbyte.Parse(textBoxOffsetY.Text);
            if (!surpressDirtyEvents) project.MarkDirty();
        }

        private void btnDeleteTranslation_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to delete this translation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                this.dataContainer.LanguageData[(int)this.language] = null;
                project.MarkDirty();
                Init(this.project, this.dataContainer, this.language); // reinit
            }
        }

        private void checkBoxWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            textBoxText.WordWrap = checkBoxWordWrap.Checked;
            textBoxText.ScrollBars = (checkBoxWordWrap.Checked) ? ScrollBars.None : ScrollBars.Both;
        }
    }
}
