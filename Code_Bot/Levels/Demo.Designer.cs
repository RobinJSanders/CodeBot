namespace Code_Bot.Levels
{
    partial class Demo
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
        private new void InitializeComponent()
        {
            this.grpQuick = new System.Windows.Forms.GroupBox();
            this.btnLoop = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.lblTurn = new System.Windows.Forms.Label();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.grpQuick.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowInstructions
            // 
            this.btnShowInstructions.FlatAppearance.BorderSize = 0;
            this.btnShowInstructions.Location = new System.Drawing.Point(1041, 637);
            this.btnShowInstructions.Visible = false;
            // 
            // btnGo
            // 
            this.btnGo.FlatAppearance.BorderSize = 0;
            // 
            // grpQuick
            // 
            this.grpQuick.Controls.Add(this.btnLoop);
            this.grpQuick.Controls.Add(this.btnMove);
            this.grpQuick.Controls.Add(this.lblTurn);
            this.grpQuick.Controls.Add(this.btnLeft);
            this.grpQuick.Controls.Add(this.btnRight);
            this.grpQuick.Location = new System.Drawing.Point(744, 664);
            this.grpQuick.Name = "grpQuick";
            this.grpQuick.Size = new System.Drawing.Size(365, 145);
            this.grpQuick.TabIndex = 22;
            this.grpQuick.TabStop = false;
            this.grpQuick.Text = "Quick Commands";
            // 
            // btnLoop
            // 
            this.btnLoop.Location = new System.Drawing.Point(6, 66);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(75, 23);
            this.btnLoop.TabIndex = 20;
            this.btnLoop.Text = "Loop";
            this.btnLoop.UseVisualStyleBackColor = true;
            this.btnLoop.Click += new System.EventHandler(this.btnLoop_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(6, 19);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 3;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Location = new System.Drawing.Point(87, 24);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(32, 13);
            this.lblTurn.TabIndex = 19;
            this.lblTurn.Text = "Turn:";
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(125, 19);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 5;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(206, 19);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 6;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Blue;
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(139, 637);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 25);
            this.btnImport.TabIndex = 34;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1349, 812);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.grpQuick);
            this.Name = "Demo";
            this.Load += new System.EventHandler(this.Demo_Load);
            this.Controls.SetChildIndex(this.btnGo, 0);
            this.Controls.SetChildIndex(this.btnShowInstructions, 0);
            this.Controls.SetChildIndex(this.RtfOutput, 0);
            this.Controls.SetChildIndex(this.rtfInputLineNumbers, 0);
            this.Controls.SetChildIndex(this.RtfOutputLineNumbers, 0);
            this.Controls.SetChildIndex(this.rtfInput, 0);
            this.Controls.SetChildIndex(this.grpQuick, 0);
            this.Controls.SetChildIndex(this.btnImport, 0);
            this.grpQuick.ResumeLayout(false);
            this.grpQuick.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpQuick;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Button btnImport;
    }
}
