namespace Code_Bot.Levels
{
    partial class ParentLevel
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.rtfInput = new System.Windows.Forms.RichTextBox();
            this.lblFacing = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.RtfOutput = new System.Windows.Forms.RichTextBox();
            this.rtfInputLineNumbers = new System.Windows.Forms.RichTextBox();
            this.RtfOutputLineNumbers = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkTooltips = new System.Windows.Forms.CheckBox();
            this.pbxXaxis = new System.Windows.Forms.PictureBox();
            this.pbxYaxis = new System.Windows.Forms.PictureBox();
            this.btnShowInstructions = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.pbxBoard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxXaxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxYaxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.Blue;
            this.btnGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGo.FlatAppearance.BorderSize = 0;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.Color.White;
            this.btnGo.Location = new System.Drawing.Point(3, 637);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 25);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go!";
            this.toolTip1.SetToolTip(this.btnGo, "Run the code");
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.BackColor = System.Drawing.Color.Transparent;
            this.lblX.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.ForeColor = System.Drawing.Color.Yellow;
            this.lblX.Location = new System.Drawing.Point(542, 636);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(24, 19);
            this.lblX.TabIndex = 10;
            this.lblX.Text = "X:";
            this.toolTip1.SetToolTip(this.lblX, "X coordinates (row number) of the bot on the grid");
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.BackColor = System.Drawing.Color.Transparent;
            this.lblY.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.ForeColor = System.Drawing.Color.Yellow;
            this.lblY.Location = new System.Drawing.Point(635, 636);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(23, 19);
            this.lblY.TabIndex = 11;
            this.lblY.Text = "Y:";
            this.toolTip1.SetToolTip(this.lblY, "Y coordinates (colomn number) of the bot on the grid");
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.BackColor = System.Drawing.Color.Transparent;
            this.lblInput.Font = new System.Drawing.Font("Corbel", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.ForeColor = System.Drawing.Color.Yellow;
            this.lblInput.Location = new System.Drawing.Point(16, 19);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(100, 39);
            this.lblInput.TabIndex = 13;
            this.lblInput.Text = "Input:";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.BackColor = System.Drawing.Color.Transparent;
            this.lblOutput.Font = new System.Drawing.Font("Corbel", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.ForeColor = System.Drawing.Color.Yellow;
            this.lblOutput.Location = new System.Drawing.Point(951, 19);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(79, 39);
            this.lblOutput.TabIndex = 14;
            this.lblOutput.Text = "Log:";
            // 
            // rtfInput
            // 
            this.rtfInput.BackColor = System.Drawing.Color.Black;
            this.rtfInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfInput.ForeColor = System.Drawing.Color.White;
            this.rtfInput.Location = new System.Drawing.Point(23, 61);
            this.rtfInput.Name = "rtfInput";
            this.rtfInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtfInput.Size = new System.Drawing.Size(272, 570);
            this.rtfInput.TabIndex = 16;
            this.rtfInput.Text = "";
            this.toolTip1.SetToolTip(this.rtfInput, "Enter code here");
            this.rtfInput.VScroll += new System.EventHandler(this.RtfInput_VScroll);
            this.rtfInput.TextChanged += new System.EventHandler(this.rtfInput_TextChanged);
            // 
            // lblFacing
            // 
            this.lblFacing.AutoSize = true;
            this.lblFacing.BackColor = System.Drawing.Color.Transparent;
            this.lblFacing.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacing.ForeColor = System.Drawing.Color.Yellow;
            this.lblFacing.Location = new System.Drawing.Point(749, 636);
            this.lblFacing.Name = "lblFacing";
            this.lblFacing.Size = new System.Drawing.Size(59, 19);
            this.lblFacing.TabIndex = 17;
            this.lblFacing.Text = "Facing:";
            this.toolTip1.SetToolTip(this.lblFacing, "The direction the bot is facing");
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Blue;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(220, 637);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.toolTip1.SetToolTip(this.btnClear, "Clear input text box");
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // RtfOutput
            // 
            this.RtfOutput.BackColor = System.Drawing.Color.Black;
            this.RtfOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RtfOutput.Cursor = System.Windows.Forms.Cursors.Default;
            this.RtfOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RtfOutput.ForeColor = System.Drawing.Color.White;
            this.RtfOutput.Location = new System.Drawing.Point(958, 61);
            this.RtfOutput.Name = "RtfOutput";
            this.RtfOutput.ReadOnly = true;
            this.RtfOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RtfOutput.Size = new System.Drawing.Size(388, 570);
            this.RtfOutput.TabIndex = 25;
            this.RtfOutput.Text = "";
            this.RtfOutput.VScroll += new System.EventHandler(this.RtfOutput_VScroll);
            // 
            // rtfInputLineNumbers
            // 
            this.rtfInputLineNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtfInputLineNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfInputLineNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfInputLineNumbers.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.rtfInputLineNumbers.Location = new System.Drawing.Point(3, 61);
            this.rtfInputLineNumbers.Name = "rtfInputLineNumbers";
            this.rtfInputLineNumbers.ReadOnly = true;
            this.rtfInputLineNumbers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtfInputLineNumbers.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfInputLineNumbers.Size = new System.Drawing.Size(21, 570);
            this.rtfInputLineNumbers.TabIndex = 26;
            this.rtfInputLineNumbers.Text = "";
            this.toolTip1.SetToolTip(this.rtfInputLineNumbers, "Line numbers for input textbox");
            // 
            // RtfOutputLineNumbers
            // 
            this.RtfOutputLineNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RtfOutputLineNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RtfOutputLineNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RtfOutputLineNumbers.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.RtfOutputLineNumbers.Location = new System.Drawing.Point(935, 61);
            this.RtfOutputLineNumbers.Name = "RtfOutputLineNumbers";
            this.RtfOutputLineNumbers.ReadOnly = true;
            this.RtfOutputLineNumbers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RtfOutputLineNumbers.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.RtfOutputLineNumbers.Size = new System.Drawing.Size(24, 570);
            this.RtfOutputLineNumbers.TabIndex = 28;
            this.RtfOutputLineNumbers.Text = "";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 100;
            // 
            // chkTooltips
            // 
            this.chkTooltips.AutoSize = true;
            this.chkTooltips.BackColor = System.Drawing.Color.Transparent;
            this.chkTooltips.Checked = true;
            this.chkTooltips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTooltips.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTooltips.ForeColor = System.Drawing.Color.Yellow;
            this.chkTooltips.Location = new System.Drawing.Point(301, 637);
            this.chkTooltips.Name = "chkTooltips";
            this.chkTooltips.Size = new System.Drawing.Size(133, 23);
            this.chkTooltips.TabIndex = 29;
            this.chkTooltips.Text = "Enable Tooltips";
            this.toolTip1.SetToolTip(this.chkTooltips, "Uncheck this box to disable tooltips (like this one)");
            this.chkTooltips.UseVisualStyleBackColor = false;
            this.chkTooltips.CheckedChanged += new System.EventHandler(this.chkTooltips_CheckedChanged);
            // 
            // pbxXaxis
            // 
            this.pbxXaxis.Image = global::Code_Bot.Properties.Resources.XAxis;
            this.pbxXaxis.Location = new System.Drawing.Point(329, 1);
            this.pbxXaxis.Name = "pbxXaxis";
            this.pbxXaxis.Size = new System.Drawing.Size(600, 30);
            this.pbxXaxis.TabIndex = 33;
            this.pbxXaxis.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxXaxis, "X-Axis");
            // 
            // pbxYaxis
            // 
            this.pbxYaxis.Image = global::Code_Bot.Properties.Resources.YAxis;
            this.pbxYaxis.Location = new System.Drawing.Point(301, 31);
            this.pbxYaxis.Name = "pbxYaxis";
            this.pbxYaxis.Size = new System.Drawing.Size(30, 600);
            this.pbxYaxis.TabIndex = 32;
            this.pbxYaxis.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxYaxis, "Y-Axis");
            // 
            // btnShowInstructions
            // 
            this.btnShowInstructions.BackColor = System.Drawing.Color.Blue;
            this.btnShowInstructions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowInstructions.FlatAppearance.BorderSize = 0;
            this.btnShowInstructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowInstructions.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowInstructions.ForeColor = System.Drawing.Color.White;
            this.btnShowInstructions.Location = new System.Drawing.Point(935, 637);
            this.btnShowInstructions.Name = "btnShowInstructions";
            this.btnShowInstructions.Size = new System.Drawing.Size(117, 25);
            this.btnShowInstructions.TabIndex = 30;
            this.btnShowInstructions.Text = "Instructions";
            this.btnShowInstructions.UseVisualStyleBackColor = false;
            this.btnShowInstructions.Click += new System.EventHandler(this.btnShowInstructions_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.BackColor = System.Drawing.Color.Transparent;
            this.lblHint.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.ForeColor = System.Drawing.Color.Yellow;
            this.lblHint.Location = new System.Drawing.Point(2, 662);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(217, 19);
            this.lblHint.TabIndex = 31;
            this.lblHint.Text = "Stuck? Click here to reveal hint";
            this.lblHint.Visible = false;
            this.lblHint.Click += new System.EventHandler(this.lblHint_Click);
            // 
            // pbxBoard
            // 
            this.pbxBoard.BackColor = System.Drawing.SystemColors.Info;
            this.pbxBoard.BackgroundImage = global::Code_Bot.Properties.Resources.Grid;
            this.pbxBoard.Location = new System.Drawing.Point(329, 31);
            this.pbxBoard.Name = "pbxBoard";
            this.pbxBoard.Size = new System.Drawing.Size(600, 600);
            this.pbxBoard.TabIndex = 1;
            this.pbxBoard.TabStop = false;
            // 
            // ParentLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 681);
            this.Controls.Add(this.pbxXaxis);
            this.Controls.Add(this.pbxYaxis);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnShowInstructions);
            this.Controls.Add(this.chkTooltips);
            this.Controls.Add(this.RtfOutputLineNumbers);
            this.Controls.Add(this.rtfInputLineNumbers);
            this.Controls.Add(this.RtfOutput);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblFacing);
            this.Controls.Add(this.rtfInput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.pbxBoard);
            this.Name = "ParentLevel";
            this.Text = "CodeBot";
            this.Load += new System.EventHandler(this.ParentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxXaxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxYaxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxBoard;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnClear;
        protected System.Windows.Forms.RichTextBox rtfInput;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkTooltips;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblFacing;
        public System.Windows.Forms.RichTextBox RtfOutputLineNumbers;
        protected System.Windows.Forms.RichTextBox rtfInputLineNumbers;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.PictureBox pbxYaxis;
        private System.Windows.Forms.PictureBox pbxXaxis;
        protected System.Windows.Forms.Button btnShowInstructions;
        public System.Windows.Forms.RichTextBox RtfOutput;
        protected System.Windows.Forms.Button btnGo;
    }
}

