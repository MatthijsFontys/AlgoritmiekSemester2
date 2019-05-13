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
            this.LbStartContainers = new System.Windows.Forms.ListBox();
            this.CbContainerType = new System.Windows.Forms.ComboBox();
            this.NumShipWidth = new System.Windows.Forms.NumericUpDown();
            this.NumShipLength = new System.Windows.Forms.NumericUpDown();
            this.LbLeftSide = new System.Windows.Forms.ListBox();
            this.LbRightSide = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NumContainerWeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnAddContainer = new System.Windows.Forms.Button();
            this.BtnDivideContainers = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.NumShipWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumShipLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumContainerWeight)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbStartContainers
            // 
            this.LbStartContainers.FormattingEnabled = true;
            this.LbStartContainers.ItemHeight = 16;
            this.LbStartContainers.Location = new System.Drawing.Point(18, 124);
            this.LbStartContainers.Name = "LbStartContainers";
            this.LbStartContainers.Size = new System.Drawing.Size(119, 244);
            this.LbStartContainers.TabIndex = 0;
            // 
            // CbContainerType
            // 
            this.CbContainerType.FormattingEnabled = true;
            this.CbContainerType.Location = new System.Drawing.Point(291, 156);
            this.CbContainerType.Name = "CbContainerType";
            this.CbContainerType.Size = new System.Drawing.Size(121, 24);
            this.CbContainerType.TabIndex = 1;
            // 
            // NumShipWidth
            // 
            this.NumShipWidth.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumShipWidth.Location = new System.Drawing.Point(189, 57);
            this.NumShipWidth.Name = "NumShipWidth";
            this.NumShipWidth.Size = new System.Drawing.Size(96, 22);
            this.NumShipWidth.TabIndex = 2;
            // 
            // NumShipLength
            // 
            this.NumShipLength.Location = new System.Drawing.Point(291, 57);
            this.NumShipLength.Name = "NumShipLength";
            this.NumShipLength.Size = new System.Drawing.Size(96, 22);
            this.NumShipLength.TabIndex = 3;
            // 
            // LbLeftSide
            // 
            this.LbLeftSide.FormattingEnabled = true;
            this.LbLeftSide.ItemHeight = 16;
            this.LbLeftSide.Location = new System.Drawing.Point(446, 124);
            this.LbLeftSide.Name = "LbLeftSide";
            this.LbLeftSide.Size = new System.Drawing.Size(119, 244);
            this.LbLeftSide.TabIndex = 4;
            // 
            // LbRightSide
            // 
            this.LbRightSide.FormattingEnabled = true;
            this.LbRightSide.ItemHeight = 16;
            this.LbRightSide.Location = new System.Drawing.Point(602, 124);
            this.LbRightSide.Name = "LbRightSide";
            this.LbRightSide.Size = new System.Drawing.Size(119, 244);
            this.LbRightSide.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Length";
            // 
            // NumContainerWeight
            // 
            this.NumContainerWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumContainerWeight.Location = new System.Drawing.Point(171, 158);
            this.NumContainerWeight.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumContainerWeight.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumContainerWeight.Name = "NumContainerWeight";
            this.NumContainerWeight.Size = new System.Drawing.Size(96, 22);
            this.NumContainerWeight.TabIndex = 8;
            this.NumContainerWeight.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ship";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Container";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Weight";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Type";
            // 
            // BtnAddContainer
            // 
            this.BtnAddContainer.Location = new System.Drawing.Point(189, 218);
            this.BtnAddContainer.Name = "BtnAddContainer";
            this.BtnAddContainer.Size = new System.Drawing.Size(75, 23);
            this.BtnAddContainer.TabIndex = 13;
            this.BtnAddContainer.Text = "Add";
            this.BtnAddContainer.UseVisualStyleBackColor = true;
            this.BtnAddContainer.Click += new System.EventHandler(this.BtnAddContainer_Click);
            // 
            // BtnDivideContainers
            // 
            this.BtnDivideContainers.Location = new System.Drawing.Point(316, 218);
            this.BtnDivideContainers.Name = "BtnDivideContainers";
            this.BtnDivideContainers.Size = new System.Drawing.Size(75, 23);
            this.BtnDivideContainers.TabIndex = 14;
            this.BtnDivideContainers.Text = "Divide";
            this.BtnDivideContainers.UseVisualStyleBackColor = true;
            this.BtnDivideContainers.Click += new System.EventHandler(this.BtnDivideContainers_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(24, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 435);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CbContainerType);
            this.tabPage1.Controls.Add(this.BtnDivideContainers);
            this.tabPage1.Controls.Add(this.LbStartContainers);
            this.tabPage1.Controls.Add(this.BtnAddContainer);
            this.tabPage1.Controls.Add(this.NumShipWidth);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.NumShipLength);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.LbLeftSide);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.LbRightSide);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.NumContainerWeight);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 71);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NumShipWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumShipLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumContainerWeight)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbStartContainers;
        private System.Windows.Forms.ComboBox CbContainerType;
        private System.Windows.Forms.NumericUpDown NumShipWidth;
        private System.Windows.Forms.NumericUpDown NumShipLength;
        private System.Windows.Forms.ListBox LbLeftSide;
        private System.Windows.Forms.ListBox LbRightSide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumContainerWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnAddContainer;
        private System.Windows.Forms.Button BtnDivideContainers;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

