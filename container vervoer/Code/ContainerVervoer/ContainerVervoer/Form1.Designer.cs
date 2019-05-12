namespace ContainerVervoer {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TbTarget = new System.Windows.Forms.TextBox();
            this.LbResult = new System.Windows.Forms.ListBox();
            this.LblTarget = new System.Windows.Forms.Label();
            this.TbNumbers = new System.Windows.Forms.TextBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.LblResultSum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TbTarget
            // 
            this.TbTarget.Location = new System.Drawing.Point(457, 177);
            this.TbTarget.Name = "TbTarget";
            this.TbTarget.Size = new System.Drawing.Size(100, 22);
            this.TbTarget.TabIndex = 0;
            this.TbTarget.Text = "12";
            // 
            // LbResult
            // 
            this.LbResult.FormattingEnabled = true;
            this.LbResult.ItemHeight = 16;
            this.LbResult.Location = new System.Drawing.Point(176, 76);
            this.LbResult.Name = "LbResult";
            this.LbResult.Size = new System.Drawing.Size(135, 228);
            this.LbResult.TabIndex = 1;
            // 
            // LblTarget
            // 
            this.LblTarget.AutoSize = true;
            this.LblTarget.Location = new System.Drawing.Point(454, 108);
            this.LblTarget.Name = "LblTarget";
            this.LblTarget.Size = new System.Drawing.Size(58, 17);
            this.LblTarget.TabIndex = 2;
            this.LblTarget.Text = "Target: ";
            // 
            // TbNumbers
            // 
            this.TbNumbers.Location = new System.Drawing.Point(457, 219);
            this.TbNumbers.Name = "TbNumbers";
            this.TbNumbers.Size = new System.Drawing.Size(100, 22);
            this.TbNumbers.TabIndex = 3;
            this.TbNumbers.Text = "1;3;5;5;14";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(457, 264);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(100, 44);
            this.BtnStart.TabIndex = 4;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LblResultSum
            // 
            this.LblResultSum.AutoSize = true;
            this.LblResultSum.Location = new System.Drawing.Point(197, 325);
            this.LblResultSum.Name = "LblResultSum";
            this.LblResultSum.Size = new System.Drawing.Size(56, 17);
            this.LblResultSum.TabIndex = 5;
            this.LblResultSum.Text = "Result: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 450);
            this.Controls.Add(this.LblResultSum);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.TbNumbers);
            this.Controls.Add(this.LblTarget);
            this.Controls.Add(this.LbResult);
            this.Controls.Add(this.TbTarget);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbTarget;
        private System.Windows.Forms.ListBox LbResult;
        private System.Windows.Forms.Label LblTarget;
        private System.Windows.Forms.TextBox TbNumbers;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label LblResultSum;
    }
}

