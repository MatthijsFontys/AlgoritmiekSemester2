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
            this.BtnClear = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.NumContainerAmount = new System.Windows.Forms.NumericUpDown();
            this.PnlRight = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblWeightDifference = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LblCoolCount = new System.Windows.Forms.Label();
            this.LblValuableCount = new System.Windows.Forms.Label();
            this.LblRegularCount = new System.Windows.Forms.Label();
            this.PnlLegend = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumShipWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumShipLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumContainerWeight)).BeginInit();
            this.PnlInfo.SuspendLayout();
            this.PnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumContainerAmount)).BeginInit();
            this.PnlRight.SuspendLayout();
            this.PnlLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
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
            this.PnlInfo.Size = new System.Drawing.Size(297, 58);
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
            this.PnlResult.Location = new System.Drawing.Point(213, 37);
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
            this.PnlLeft.Controls.Add(this.LblRegularCount);
            this.PnlLeft.Controls.Add(this.LblValuableCount);
            this.PnlLeft.Controls.Add(this.LblCoolCount);
            this.PnlLeft.Controls.Add(this.label11);
            this.PnlLeft.Controls.Add(this.label10);
            this.PnlLeft.Controls.Add(this.label9);
            this.PnlLeft.Controls.Add(this.lblWeightDifference);
            this.PnlLeft.Controls.Add(this.label8);
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
            this.PnlLeft.Size = new System.Drawing.Size(415, 711);
            this.PnlLeft.TabIndex = 17;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Amount";
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
            // PnlRight
            // 
            this.PnlRight.Controls.Add(this.PnlLegend);
            this.PnlRight.Controls.Add(this.PnlInfo);
            this.PnlRight.Controls.Add(this.PnlResult);
            this.PnlRight.Location = new System.Drawing.Point(433, 12);
            this.PnlRight.Name = "PnlRight";
            this.PnlRight.Size = new System.Drawing.Size(684, 711);
            this.PnlRight.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(216, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Weight difference %";
            // 
            // lblWeightDifference
            // 
            this.lblWeightDifference.AutoSize = true;
            this.lblWeightDifference.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeightDifference.Location = new System.Drawing.Point(276, 444);
            this.lblWeightDifference.Name = "lblWeightDifference";
            this.lblWeightDifference.Size = new System.Drawing.Size(28, 17);
            this.lblWeightDifference.TabIndex = 21;
            this.lblWeightDifference.Text = "0%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(230, 478);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Valuable count";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(246, 529);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Cool count";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(230, 582);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 17);
            this.label11.TabIndex = 24;
            this.label11.Text = "Regular count";
            // 
            // LblCoolCount
            // 
            this.LblCoolCount.AutoSize = true;
            this.LblCoolCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCoolCount.Location = new System.Drawing.Point(281, 546);
            this.LblCoolCount.Name = "LblCoolCount";
            this.LblCoolCount.Size = new System.Drawing.Size(16, 17);
            this.LblCoolCount.TabIndex = 25;
            this.LblCoolCount.Text = "0";
            // 
            // LblValuableCount
            // 
            this.LblValuableCount.AutoSize = true;
            this.LblValuableCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValuableCount.Location = new System.Drawing.Point(281, 495);
            this.LblValuableCount.Name = "LblValuableCount";
            this.LblValuableCount.Size = new System.Drawing.Size(16, 17);
            this.LblValuableCount.TabIndex = 26;
            this.LblValuableCount.Text = "0";
            // 
            // LblRegularCount
            // 
            this.LblRegularCount.AutoSize = true;
            this.LblRegularCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegularCount.Location = new System.Drawing.Point(281, 599);
            this.LblRegularCount.Name = "LblRegularCount";
            this.LblRegularCount.Size = new System.Drawing.Size(16, 17);
            this.LblRegularCount.TabIndex = 27;
            this.LblRegularCount.Text = "0";
            // 
            // PnlLegend
            // 
            this.PnlLegend.Controls.Add(this.label16);
            this.PnlLegend.Controls.Add(this.pictureBox4);
            this.PnlLegend.Controls.Add(this.pictureBox3);
            this.PnlLegend.Controls.Add(this.pictureBox2);
            this.PnlLegend.Controls.Add(this.pictureBox1);
            this.PnlLegend.Controls.Add(this.label15);
            this.PnlLegend.Controls.Add(this.label14);
            this.PnlLegend.Controls.Add(this.label13);
            this.PnlLegend.Controls.Add(this.label12);
            this.PnlLegend.Location = new System.Drawing.Point(18, 40);
            this.PnlLegend.Name = "PnlLegend";
            this.PnlLegend.Size = new System.Drawing.Size(154, 453);
            this.PnlLegend.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(49, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 17);
            this.label12.TabIndex = 28;
            this.label12.Text = "Legend";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 17);
            this.label13.TabIndex = 29;
            this.label13.Text = "Cooled";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(15, 166);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 17);
            this.label14.TabIndex = 30;
            this.label14.Text = "Regular";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 213);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 17);
            this.label15.TabIndex = 31;
            this.label15.Text = "Valuable";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pictureBox1.Location = new System.Drawing.Point(86, 109);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Silver;
            this.pictureBox2.Location = new System.Drawing.Point(86, 158);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.SandyBrown;
            this.pictureBox3.Location = new System.Drawing.Point(86, 250);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.pictureBox4.Location = new System.Drawing.Point(86, 208);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(25, 25);
            this.pictureBox4.TabIndex = 35;
            this.pictureBox4.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(15, 258);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 17);
            this.label16.TabIndex = 36;
            this.label16.Text = "Empty";
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
            ((System.ComponentModel.ISupportInitialize)(this.NumContainerAmount)).EndInit();
            this.PnlRight.ResumeLayout(false);
            this.PnlLegend.ResumeLayout(false);
            this.PnlLegend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
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
        private System.Windows.Forms.Label LblRegularCount;
        private System.Windows.Forms.Label LblValuableCount;
        private System.Windows.Forms.Label LblCoolCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblWeightDifference;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel PnlLegend;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}

