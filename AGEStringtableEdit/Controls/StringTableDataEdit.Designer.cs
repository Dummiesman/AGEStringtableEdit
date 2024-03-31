namespace AGEStringtableEdit
{
    partial class StringTableDataEdit
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFont = new System.Windows.Forms.TextBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxBF4096 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF32768 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF16384 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF8192 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF2048 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF1024 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF512 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF256 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF128 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF64 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF32 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF16 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF8 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF4 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF2 = new System.Windows.Forms.CheckBox();
            this.checkBoxBF1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOffsetY = new System.Windows.Forms.TextBox();
            this.textBoxScaleY = new System.Windows.Forms.TextBox();
            this.textBoxScaleX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxOffsetX = new System.Windows.Forms.TextBox();
            this.panelNoTxBlock = new System.Windows.Forms.Panel();
            this.buttonCreateTx = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDeleteTranslation = new System.Windows.Forms.Button();
            this.checkBoxWordWrap = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panelNoTxBlock.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Font";
            // 
            // textBoxFont
            // 
            this.textBoxFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFont.Location = new System.Drawing.Point(92, 12);
            this.textBoxFont.Name = "textBoxFont";
            this.textBoxFont.Size = new System.Drawing.Size(291, 20);
            this.textBoxFont.TabIndex = 1;
            this.textBoxFont.TextChanged += new System.EventHandler(this.textBoxFont_TextChanged);
            // 
            // textBoxText
            // 
            this.textBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxText.Location = new System.Drawing.Point(92, 38);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxText.Size = new System.Drawing.Size(291, 92);
            this.textBoxText.TabIndex = 3;
            this.textBoxText.WordWrap = false;
            this.textBoxText.TextChanged += new System.EventHandler(this.textBoxText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Text";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.checkBoxBF4096);
            this.groupBox1.Controls.Add(this.checkBoxBF32768);
            this.groupBox1.Controls.Add(this.checkBoxBF16384);
            this.groupBox1.Controls.Add(this.checkBoxBF8192);
            this.groupBox1.Controls.Add(this.checkBoxBF2048);
            this.groupBox1.Controls.Add(this.checkBoxBF1024);
            this.groupBox1.Controls.Add(this.checkBoxBF512);
            this.groupBox1.Controls.Add(this.checkBoxBF256);
            this.groupBox1.Controls.Add(this.checkBoxBF128);
            this.groupBox1.Controls.Add(this.checkBoxBF64);
            this.groupBox1.Controls.Add(this.checkBoxBF32);
            this.groupBox1.Controls.Add(this.checkBoxBF16);
            this.groupBox1.Controls.Add(this.checkBoxBF8);
            this.groupBox1.Controls.Add(this.checkBoxBF4);
            this.groupBox1.Controls.Add(this.checkBoxBF2);
            this.groupBox1.Controls.Add(this.checkBoxBF1);
            this.groupBox1.Location = new System.Drawing.Point(10, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 59);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flags";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(321, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "32768";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "1";
            // 
            // checkBoxBF4096
            // 
            this.checkBoxBF4096.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF4096.AutoSize = true;
            this.checkBoxBF4096.Location = new System.Drawing.Point(269, 19);
            this.checkBoxBF4096.Name = "checkBoxBF4096";
            this.checkBoxBF4096.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF4096.TabIndex = 15;
            this.checkBoxBF4096.Tag = "4096";
            this.checkBoxBF4096.UseVisualStyleBackColor = true;
            this.checkBoxBF4096.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF32768
            // 
            this.checkBoxBF32768.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF32768.AutoSize = true;
            this.checkBoxBF32768.Location = new System.Drawing.Point(332, 19);
            this.checkBoxBF32768.Name = "checkBoxBF32768";
            this.checkBoxBF32768.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF32768.TabIndex = 14;
            this.checkBoxBF32768.Tag = "32768";
            this.checkBoxBF32768.UseVisualStyleBackColor = true;
            this.checkBoxBF32768.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF16384
            // 
            this.checkBoxBF16384.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF16384.AutoSize = true;
            this.checkBoxBF16384.Location = new System.Drawing.Point(311, 19);
            this.checkBoxBF16384.Name = "checkBoxBF16384";
            this.checkBoxBF16384.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF16384.TabIndex = 13;
            this.checkBoxBF16384.Tag = "16384";
            this.checkBoxBF16384.UseVisualStyleBackColor = true;
            this.checkBoxBF16384.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF8192
            // 
            this.checkBoxBF8192.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF8192.AutoSize = true;
            this.checkBoxBF8192.Location = new System.Drawing.Point(290, 19);
            this.checkBoxBF8192.Name = "checkBoxBF8192";
            this.checkBoxBF8192.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF8192.TabIndex = 12;
            this.checkBoxBF8192.Tag = "8192";
            this.checkBoxBF8192.UseVisualStyleBackColor = true;
            this.checkBoxBF8192.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF2048
            // 
            this.checkBoxBF2048.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF2048.AutoSize = true;
            this.checkBoxBF2048.Location = new System.Drawing.Point(248, 19);
            this.checkBoxBF2048.Name = "checkBoxBF2048";
            this.checkBoxBF2048.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF2048.TabIndex = 11;
            this.checkBoxBF2048.Tag = "2048";
            this.checkBoxBF2048.UseVisualStyleBackColor = true;
            this.checkBoxBF2048.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF1024
            // 
            this.checkBoxBF1024.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF1024.AutoSize = true;
            this.checkBoxBF1024.Location = new System.Drawing.Point(227, 19);
            this.checkBoxBF1024.Name = "checkBoxBF1024";
            this.checkBoxBF1024.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF1024.TabIndex = 10;
            this.checkBoxBF1024.Tag = "1024";
            this.checkBoxBF1024.UseVisualStyleBackColor = true;
            this.checkBoxBF1024.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF512
            // 
            this.checkBoxBF512.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF512.AutoSize = true;
            this.checkBoxBF512.Location = new System.Drawing.Point(206, 19);
            this.checkBoxBF512.Name = "checkBoxBF512";
            this.checkBoxBF512.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF512.TabIndex = 9;
            this.checkBoxBF512.Tag = "512";
            this.checkBoxBF512.UseVisualStyleBackColor = true;
            this.checkBoxBF512.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF256
            // 
            this.checkBoxBF256.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF256.AutoSize = true;
            this.checkBoxBF256.Location = new System.Drawing.Point(185, 19);
            this.checkBoxBF256.Name = "checkBoxBF256";
            this.checkBoxBF256.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF256.TabIndex = 8;
            this.checkBoxBF256.Tag = "256";
            this.checkBoxBF256.UseVisualStyleBackColor = true;
            this.checkBoxBF256.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF128
            // 
            this.checkBoxBF128.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF128.AutoSize = true;
            this.checkBoxBF128.Location = new System.Drawing.Point(164, 19);
            this.checkBoxBF128.Name = "checkBoxBF128";
            this.checkBoxBF128.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF128.TabIndex = 7;
            this.checkBoxBF128.Tag = "128";
            this.checkBoxBF128.UseVisualStyleBackColor = true;
            this.checkBoxBF128.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF64
            // 
            this.checkBoxBF64.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF64.AutoSize = true;
            this.checkBoxBF64.Location = new System.Drawing.Point(143, 19);
            this.checkBoxBF64.Name = "checkBoxBF64";
            this.checkBoxBF64.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF64.TabIndex = 6;
            this.checkBoxBF64.Tag = "64";
            this.checkBoxBF64.UseVisualStyleBackColor = true;
            this.checkBoxBF64.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF32
            // 
            this.checkBoxBF32.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF32.AutoSize = true;
            this.checkBoxBF32.Location = new System.Drawing.Point(122, 19);
            this.checkBoxBF32.Name = "checkBoxBF32";
            this.checkBoxBF32.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF32.TabIndex = 5;
            this.checkBoxBF32.Tag = "32";
            this.checkBoxBF32.UseVisualStyleBackColor = true;
            this.checkBoxBF32.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF16
            // 
            this.checkBoxBF16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF16.AutoSize = true;
            this.checkBoxBF16.Location = new System.Drawing.Point(101, 19);
            this.checkBoxBF16.Name = "checkBoxBF16";
            this.checkBoxBF16.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF16.TabIndex = 4;
            this.checkBoxBF16.Tag = "16";
            this.checkBoxBF16.UseVisualStyleBackColor = true;
            this.checkBoxBF16.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF8
            // 
            this.checkBoxBF8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF8.AutoSize = true;
            this.checkBoxBF8.Location = new System.Drawing.Point(80, 19);
            this.checkBoxBF8.Name = "checkBoxBF8";
            this.checkBoxBF8.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF8.TabIndex = 3;
            this.checkBoxBF8.Tag = "8";
            this.checkBoxBF8.UseVisualStyleBackColor = true;
            this.checkBoxBF8.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF4
            // 
            this.checkBoxBF4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF4.AutoSize = true;
            this.checkBoxBF4.Location = new System.Drawing.Point(59, 19);
            this.checkBoxBF4.Name = "checkBoxBF4";
            this.checkBoxBF4.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF4.TabIndex = 2;
            this.checkBoxBF4.Tag = "4";
            this.checkBoxBF4.UseVisualStyleBackColor = true;
            this.checkBoxBF4.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF2
            // 
            this.checkBoxBF2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF2.AutoSize = true;
            this.checkBoxBF2.Location = new System.Drawing.Point(38, 19);
            this.checkBoxBF2.Name = "checkBoxBF2";
            this.checkBoxBF2.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF2.TabIndex = 1;
            this.checkBoxBF2.Tag = "2";
            this.checkBoxBF2.UseVisualStyleBackColor = true;
            this.checkBoxBF2.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // checkBoxBF1
            // 
            this.checkBoxBF1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBF1.AutoSize = true;
            this.checkBoxBF1.Location = new System.Drawing.Point(17, 19);
            this.checkBoxBF1.Name = "checkBoxBF1";
            this.checkBoxBF1.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBF1.TabIndex = 0;
            this.checkBoxBF1.Tag = "1";
            this.checkBoxBF1.UseVisualStyleBackColor = true;
            this.checkBoxBF1.CheckedChanged += new System.EventHandler(this.BitFlagCheckboxChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Offset (pixels)";
            // 
            // textBoxOffsetY
            // 
            this.textBoxOffsetY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOffsetY.Location = new System.Drawing.Point(240, 138);
            this.textBoxOffsetY.Name = "textBoxOffsetY";
            this.textBoxOffsetY.Size = new System.Drawing.Size(143, 20);
            this.textBoxOffsetY.TabIndex = 7;
            this.textBoxOffsetY.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxSByteValidate);
            this.textBoxOffsetY.Validated += new System.EventHandler(this.textBoxOffsetY_Validated);
            // 
            // textBoxScaleY
            // 
            this.textBoxScaleY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScaleY.Location = new System.Drawing.Point(240, 164);
            this.textBoxScaleY.Name = "textBoxScaleY";
            this.textBoxScaleY.Size = new System.Drawing.Size(143, 20);
            this.textBoxScaleY.TabIndex = 10;
            this.textBoxScaleY.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxFloatValidate);
            this.textBoxScaleY.Validated += new System.EventHandler(this.textBoxScaleY_Validated);
            // 
            // textBoxScaleX
            // 
            this.textBoxScaleX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScaleX.Location = new System.Drawing.Point(92, 164);
            this.textBoxScaleX.Name = "textBoxScaleX";
            this.textBoxScaleX.Size = new System.Drawing.Size(142, 20);
            this.textBoxScaleX.TabIndex = 9;
            this.textBoxScaleX.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxFloatValidate);
            this.textBoxScaleX.Validated += new System.EventHandler(this.textBoxScaleX_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Scale";
            // 
            // textBoxOffsetX
            // 
            this.textBoxOffsetX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOffsetX.Location = new System.Drawing.Point(92, 138);
            this.textBoxOffsetX.Name = "textBoxOffsetX";
            this.textBoxOffsetX.Size = new System.Drawing.Size(142, 20);
            this.textBoxOffsetX.TabIndex = 6;
            this.textBoxOffsetX.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxSByteValidate);
            this.textBoxOffsetX.Validated += new System.EventHandler(this.textBoxOffsetX_Validated);
            // 
            // panelNoTxBlock
            // 
            this.panelNoTxBlock.Controls.Add(this.buttonCreateTx);
            this.panelNoTxBlock.Controls.Add(this.label7);
            this.panelNoTxBlock.Location = new System.Drawing.Point(10, 261);
            this.panelNoTxBlock.Name = "panelNoTxBlock";
            this.panelNoTxBlock.Size = new System.Drawing.Size(179, 89);
            this.panelNoTxBlock.TabIndex = 11;
            this.panelNoTxBlock.Visible = false;
            // 
            // buttonCreateTx
            // 
            this.buttonCreateTx.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCreateTx.Location = new System.Drawing.Point(-29, 37);
            this.buttonCreateTx.Name = "buttonCreateTx";
            this.buttonCreateTx.Size = new System.Drawing.Size(237, 27);
            this.buttonCreateTx.TabIndex = 12;
            this.buttonCreateTx.Text = "Create Translation";
            this.buttonCreateTx.UseVisualStyleBackColor = true;
            this.buttonCreateTx.Click += new System.EventHandler(this.buttonCreateTx_Click);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 89);
            this.label7.TabIndex = 13;
            this.label7.Text = "This translation does not exist";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeleteTranslation
            // 
            this.btnDeleteTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTranslation.Location = new System.Drawing.Point(216, 275);
            this.btnDeleteTranslation.Name = "btnDeleteTranslation";
            this.btnDeleteTranslation.Size = new System.Drawing.Size(167, 27);
            this.btnDeleteTranslation.TabIndex = 12;
            this.btnDeleteTranslation.Text = "Delete Translation";
            this.btnDeleteTranslation.UseVisualStyleBackColor = true;
            this.btnDeleteTranslation.Click += new System.EventHandler(this.btnDeleteTranslation_Click);
            // 
            // checkBoxWordWrap
            // 
            this.checkBoxWordWrap.AutoSize = true;
            this.checkBoxWordWrap.Location = new System.Drawing.Point(5, 64);
            this.checkBoxWordWrap.Name = "checkBoxWordWrap";
            this.checkBoxWordWrap.Size = new System.Drawing.Size(81, 30);
            this.checkBoxWordWrap.TabIndex = 13;
            this.checkBoxWordWrap.Text = "Word Wrap\r\n(Preview)";
            this.checkBoxWordWrap.UseVisualStyleBackColor = true;
            this.checkBoxWordWrap.CheckedChanged += new System.EventHandler(this.checkBoxWordWrap_CheckedChanged);
            // 
            // StringTableDataEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panelNoTxBlock);
            this.Controls.Add(this.textBoxScaleY);
            this.Controls.Add(this.textBoxScaleX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxOffsetY);
            this.Controls.Add(this.textBoxOffsetX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFont);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteTranslation);
            this.Controls.Add(this.checkBoxWordWrap);
            this.Name = "StringTableDataEdit";
            this.Size = new System.Drawing.Size(398, 363);
            this.Load += new System.EventHandler(this.StringTableDataEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelNoTxBlock.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFont;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOffsetY;
        private System.Windows.Forms.TextBox textBoxScaleY;
        private System.Windows.Forms.TextBox textBoxScaleX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxBF4096;
        private System.Windows.Forms.CheckBox checkBoxBF32768;
        private System.Windows.Forms.CheckBox checkBoxBF16384;
        private System.Windows.Forms.CheckBox checkBoxBF8192;
        private System.Windows.Forms.CheckBox checkBoxBF2048;
        private System.Windows.Forms.CheckBox checkBoxBF1024;
        private System.Windows.Forms.CheckBox checkBoxBF512;
        private System.Windows.Forms.CheckBox checkBoxBF256;
        private System.Windows.Forms.CheckBox checkBoxBF128;
        private System.Windows.Forms.CheckBox checkBoxBF64;
        private System.Windows.Forms.CheckBox checkBoxBF32;
        private System.Windows.Forms.CheckBox checkBoxBF16;
        private System.Windows.Forms.CheckBox checkBoxBF8;
        private System.Windows.Forms.CheckBox checkBoxBF4;
        private System.Windows.Forms.CheckBox checkBoxBF2;
        private System.Windows.Forms.CheckBox checkBoxBF1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxOffsetX;
        private System.Windows.Forms.Panel panelNoTxBlock;
        private System.Windows.Forms.Button buttonCreateTx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDeleteTranslation;
        private System.Windows.Forms.CheckBox checkBoxWordWrap;
    }
}
