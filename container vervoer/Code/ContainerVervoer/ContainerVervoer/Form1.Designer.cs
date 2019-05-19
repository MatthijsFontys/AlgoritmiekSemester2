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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NumContainerWeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnAddContainer = new System.Windows.Forms.Button();
            this.BtnDivideContainers = new System.Windows.Forms.Button();
            this.PnlInfo = new System.Windows.Forms.Panel();
            this.LblLayerCount = new System.Windows.Forms.Label();
            this.BtnLayerDown = new System.Windows.Forms.Button();
            this.BtnLayerUp = new System.Windows.Forms.Button();
            this.PnlResult = new System.Windows.Forms.Panel();
            this.BtnRemoveContainer = new System.Windows.Forms.Button();
            this.PnlLeft = new System.Windows.Forms.Panel();
            this.PnlRight = new System.Windows.Forms.Panel();
            this.NumContainerAmount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumShipWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumShipLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumContainerWeight)).BeginInit();
            this.PnlInfo.SuspendLayout();
            this.PnlLeft.SuspendLayout();
            this.PnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumContainerAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // LbStartContainers
            // 
            this.LbStartContainers.FormattingEnabled = true;
            this.LbStartContainers.ItemHeight = 16;
            this.LbStartContainers.Location = new System.Drawing.Point(20, 37);
            this.LbStartContainers.Name = "LbStartContainers";
            this.LbStartContainers.Size = new System.Drawing.Size(119, 356);
            this.LbStartContainers.TabIndex = 0;
            // 
            // CbContainerType
            // 
            this.CbContainerType.FormattingEnabled = true;
            this.CbContainerType.Location = new System.Drawing.Point(279, 190);
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
            this.NumShipWidth.Location = new System.Drawing.Point(172, 82);
            this.NumShipWidth.Name = "NumShipWidth";
            this.NumShipWidth.Size = new System.Drawing.Size(96, 22);
            this.NumShipWidth.TabIndex = 2;
            this.NumShipWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // NumShipLength
            // 
            this.NumShipLength.Location = new System.Drawing.Point(274, 82);
            this.NumShipLength.Name = "NumShipLength";
            this.NumShipLength.Size = new System.Drawing.Size(96, 22);
            this.NumShipLength.TabIndex = 3;
            this.NumShipLength.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 59);
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
            this.NumContainerWeight.Location = new System.Drawing.Point(159, 192);
            this.NumContainerWeight.Maximum = new decimal(new int[] {
            120,
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
            30,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(246, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ship";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(230, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Container";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Weight";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Type";
            // 
            // BtnAddContainer
            // 
            this.BtnAddContainer.Location = new System.Drawing.Point(174, 347);
            this.BtnAddContainer.Name = "BtnAddContainer";
            this.BtnAddContainer.Size = new System.Drawing.Size(95, 46);
            this.BtnAddContainer.TabIndex = 13;
            this.BtnAddContainer.Text = "Add";
            this.BtnAddContainer.UseVisualStyleBackColor = true;
            this.BtnAddContainer.Click += new System.EventHandler(this.BtnAddContainer_Click);
            // 
            // BtnDivideContainers
            // 
            this.BtnDivideContainers.Location = new System.Drawing.Point(299, 347);
            this.BtnDivideContainers.Name = "BtnDivideContainers";
            this.BtnDivideContainers.Size = new System.Drawing.Size(95, 46);
            this.BtnDivideContainers.TabIndex = 14;
            this.BtnDivideContainers.Text = "Start";
            this.BtnDivideContainers.UseVisualStyleBackColor = true;
            this.BtnDivideContainers.Click += new System.EventHandler(this.BtnDivideContainers_Click);
            // 
            // PnlInfo
            // 
            this.PnlInfo.Controls.Add(this.LblLayerCount);
            this.PnlInfo.Controls.Add(this.BtnLayerDown);
            this.PnlInfo.Controls.Add(this.BtnLayerUp);
            this.PnlInfo.Location = new System.Drawing.Point(144, 593);
            this.PnlInfo.Name = "PnlInfo";
            this.PnlInfo.Size = new System.Drawing.Size(312, 58);
            this.PnlInfo.TabIndex = 0;
            // 
            // LblLayerCount
            // 
            this.LblLayerCount.AutoSize = true;
            this.LblLayerCount.Font = new System.Drawing.Font("Arial Narrow", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLayerCount.Location = new System.Drawing.Point(75, 3);
            this.LblLayerCount.Name = "LblLayerCount";
            this.LblLayerCount.Size = new System.Drawing.Size(115, 44);
            this.LblLayerCount.TabIndex = 0;
            this.LblLayerCount.Text = "Layer: ";
            // 
            // BtnLayerDown
            // 
            this.BtnLayerDown.Location = new System.Drawing.Point(0, 4);
            this.BtnLayerDown.Name = "BtnLayerDown";
            this.BtnLayerDown.Size = new System.Drawing.Size(53, 43);
            this.BtnLayerDown.TabIndex = 1;
            this.BtnLayerDown.Text = "<==";
            this.BtnLayerDown.UseVisualStyleBackColor = true;
            this.BtnLayerDown.Click += new System.EventHandler(this.BtnLayerDown_Click);
            // 
            // BtnLayerUp
            // 
            this.BtnLayerUp.Location = new System.Drawing.Point(239, 4);
            this.BtnLayerUp.Name = "BtnLayerUp";
            this.BtnLayerUp.Size = new System.Drawing.Size(53, 43);
            this.BtnLayerUp.TabIndex = 2;
            this.BtnLayerUp.Text = "==>";
            this.BtnLayerUp.UseVisualStyleBackColor = true;
            this.BtnLayerUp.Click += new System.EventHandler(this.BtnLayerUp_Click);
            // 
            // PnlResult
            // 
            this.PnlResult.Location = new System.Drawing.Point(91, 40);
            this.PnlResult.Name = "PnlResult";
            this.PnlResult.Size = new System.Drawing.Size(601, 499);
            this.PnlResult.TabIndex = 0;
            // 
            // BtnRemoveContainer
            // 
            this.BtnRemoveContainer.Location = new System.Drawing.Point(29, 409);
            this.BtnRemoveContainer.Name = "BtnRemoveContainer";
            this.BtnRemoveContainer.Size = new System.Drawing.Size(100, 40);
            this.BtnRemoveContainer.TabIndex = 16;
            this.BtnRemoveContainer.Text = "Remove";
            this.BtnRemoveContainer.UseVisualStyleBackColor = true;
            this.BtnRemoveContainer.Click += new System.EventHandler(this.BtnRemoveContainer_Click);
            // 
            // PnlLeft
            // 
            this.PnlLeft.Controls.Add(this.BtnClear);
            this.PnlLeft.Controls.Add(this.label7);
            this.PnlLeft.Controls.Add(this.NumContainerAmount);
            this.PnlLeft.Controls.Add(this.label1);
            this.PnlLeft.Controls.Add(this.BtnRemoveContainer);
            this.PnlLeft.Controls.Add(this.label2);
            this.PnlLeft.Controls.Add(this.NumContainerWeight);
            this.PnlLeft.Controls.Add(this.CbContainerType);
            this.PnlLeft.Controls.Add(this.label3);
            this.PnlLeft.Controls.Add(this.BtnDivideContainers);
            this.PnlLeft.Controls.Add(this.label4);
            this.PnlLeft.Controls.Add(this.LbStartContainers);
            this.PnlLeft.Controls.Add(this.label5);
            this.PnlLeft.Controls.Add(this.BtnAddContainer);
            this.PnlLeft.Controls.Add(this.NumShipLength);
            this.PnlLeft.Controls.Add(this.NumShipWidth);
            this.PnlLeft.Controls.Add(this.label6);
            this.PnlLeft.Location = new System.Drawing.Point(12, 12);
            this.PnlLeft.Name = "PnlLeft";
            this.PnlLeft.Size = new System.Drawing.Size(415, 539);
            this.PnlLeft.TabIndex = 17;
            // 
            // PnlRight
            // 
            this.PnlRight.Controls.Add(this.PnlInfo);
            this.PnlRight.Controls.Add(this.PnlResult);
            this.PnlRight.Location = new System.Drawing.Point(433, 32);
            this.PnlRight.Name = "PnlRight";
            this.PnlRight.Size = new System.Drawing.Size(684, 691);
            this.PnlRight.TabIndex = 18;
            // 
            // NumContainerAmount
            // 
            this.NumContainerAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumContainerAmount.Location = new System.Drawing.Point(212, 248);
            this.NumContainerAmount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.NumContainerAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumContainerAmount.Name = "NumContainerAmount";
            this.NumContainerAmount.Size = new System.Drawing.Size(96, 22);
            this.NumContainerAmount.TabIndex = 17;
            this.NumContainerAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Amount";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(29, 455);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(100, 40);
            this.BtnClear.TabIndex = 19;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 735);
            this.Controls.Add(this.PnlRight);
            this.Controls.Add(this.PnlLeft);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.NumShipWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumShipLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumContainerWeight)).EndInit();
            this.PnlInfo.ResumeLayout(false);
            this.PnlInfo.PerformLayout();
            this.PnlLeft.ResumeLayout(false);
            this.PnlLeft.PerformLayout();
            this.PnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumContainerAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbStartContainers;
        private System.Windows.Forms.ComboBox CbContainerType;
        private System.Windows.Forms.NumericUpDown NumShipWidth;
        private System.Windows.Forms.NumericUpDown NumShipLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumContainerWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnAddContainer;
        private System.Windows.Forms.Button BtnDivideContainers;
        private System.Windows.Forms.Panel PnlResult;
        private System.Windows.Forms.Button BtnLayerDown;
        private System.Windows.Forms.Label LblLayerCount;
        private System.Windows.Forms.Button BtnLayerUp;
        private System.Windows.Forms.Panel PnlInfo;
        private System.Windows.Forms.Button BtnRemoveContainer;
        private System.Windows.Forms.Panel PnlLeft;
        private System.Windows.Forms.Panel PnlRight;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NumContainerAmount;
    }
}

