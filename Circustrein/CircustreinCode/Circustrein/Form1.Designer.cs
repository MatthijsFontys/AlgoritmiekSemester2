namespace Circustrein {
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
            this.LbAnimals = new System.Windows.Forms.ListBox();
            this.LbWagons = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblWagonCount = new System.Windows.Forms.Label();
            this.BtnDivideAnimals = new System.Windows.Forms.Button();
            this.CbSize = new System.Windows.Forms.ComboBox();
            this.CbDiet = new System.Windows.Forms.ComboBox();
            this.BtnAddAnimals = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NumAmount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // LbAnimals
            // 
            this.LbAnimals.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbAnimals.FormattingEnabled = true;
            this.LbAnimals.ItemHeight = 18;
            this.LbAnimals.Location = new System.Drawing.Point(16, 219);
            this.LbAnimals.Name = "LbAnimals";
            this.LbAnimals.Size = new System.Drawing.Size(178, 274);
            this.LbAnimals.TabIndex = 0;
            // 
            // LbWagons
            // 
            this.LbWagons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbWagons.FormattingEnabled = true;
            this.LbWagons.ItemHeight = 18;
            this.LbWagons.Location = new System.Drawing.Point(239, 219);
            this.LbWagons.Name = "LbWagons";
            this.LbWagons.Size = new System.Drawing.Size(166, 274);
            this.LbWagons.TabIndex = 1;
            this.LbWagons.SelectedIndexChanged += new System.EventHandler(this.LbWagons_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dieren";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(234, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wagons";
            // 
            // LblWagonCount
            // 
            this.LblWagonCount.AutoSize = true;
            this.LblWagonCount.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWagonCount.Location = new System.Drawing.Point(353, 191);
            this.LblWagonCount.Name = "LblWagonCount";
            this.LblWagonCount.Size = new System.Drawing.Size(25, 25);
            this.LblWagonCount.TabIndex = 4;
            this.LblWagonCount.Text = "0";
            // 
            // BtnDivideAnimals
            // 
            this.BtnDivideAnimals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDivideAnimals.Location = new System.Drawing.Point(174, 105);
            this.BtnDivideAnimals.Name = "BtnDivideAnimals";
            this.BtnDivideAnimals.Size = new System.Drawing.Size(111, 53);
            this.BtnDivideAnimals.TabIndex = 5;
            this.BtnDivideAnimals.Text = "Divide";
            this.BtnDivideAnimals.UseVisualStyleBackColor = true;
            this.BtnDivideAnimals.Click += new System.EventHandler(this.BtnDivideAnimals_Click);
            // 
            // CbSize
            // 
            this.CbSize.FormattingEnabled = true;
            this.CbSize.Location = new System.Drawing.Point(27, 47);
            this.CbSize.Name = "CbSize";
            this.CbSize.Size = new System.Drawing.Size(136, 26);
            this.CbSize.TabIndex = 15;
            this.CbSize.Text = "Choose";
            // 
            // CbDiet
            // 
            this.CbDiet.FormattingEnabled = true;
            this.CbDiet.Items.AddRange(new object[] {
            "Carnivore",
            "Herbivore"});
            this.CbDiet.Location = new System.Drawing.Point(188, 47);
            this.CbDiet.Name = "CbDiet";
            this.CbDiet.Size = new System.Drawing.Size(136, 26);
            this.CbDiet.TabIndex = 16;
            this.CbDiet.Text = "Choose";
            // 
            // BtnAddAnimals
            // 
            this.BtnAddAnimals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddAnimals.Location = new System.Drawing.Point(450, 33);
            this.BtnAddAnimals.Name = "BtnAddAnimals";
            this.BtnAddAnimals.Size = new System.Drawing.Size(111, 53);
            this.BtnAddAnimals.TabIndex = 17;
            this.BtnAddAnimals.Text = "Add animal(s)";
            this.BtnAddAnimals.UseVisualStyleBackColor = true;
            this.BtnAddAnimals.Click += new System.EventHandler(this.BtnAddAnimals_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(70, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Size";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(235, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Diet";
            // 
            // NumAmount
            // 
            this.NumAmount.Location = new System.Drawing.Point(358, 50);
            this.NumAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumAmount.Name = "NumAmount";
            this.NumAmount.Size = new System.Drawing.Size(66, 24);
            this.NumAmount.TabIndex = 20;
            this.NumAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(355, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Amount";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(612, 544);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.NumAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnAddAnimals);
            this.Controls.Add(this.CbDiet);
            this.Controls.Add(this.CbSize);
            this.Controls.Add(this.BtnDivideAnimals);
            this.Controls.Add(this.LblWagonCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbWagons);
            this.Controls.Add(this.LbAnimals);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NumAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LbAnimals;
        private System.Windows.Forms.ListBox LbWagons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblWagonCount;
        private System.Windows.Forms.Button BtnDivideAnimals;
        private System.Windows.Forms.ComboBox CbSize;
        private System.Windows.Forms.ComboBox CbDiet;
        private System.Windows.Forms.Button BtnAddAnimals;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NumAmount;
        private System.Windows.Forms.Label label9;
    }
}

