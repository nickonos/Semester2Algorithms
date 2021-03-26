
namespace CircusTrein
{
    partial class Form1
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
        private void InitializeComponent()
        {
            this.SmallHerbivore = new System.Windows.Forms.NumericUpDown();
            this.MediumHerbivore = new System.Windows.Forms.NumericUpDown();
            this.BigHerbivore = new System.Windows.Forms.NumericUpDown();
            this.SmallCarnivore = new System.Windows.Forms.NumericUpDown();
            this.MediumCarnivore = new System.Windows.Forms.NumericUpDown();
            this.BigCarnivore = new System.Windows.Forms.NumericUpDown();
            this.Herbivore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.SmallHerbivore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediumHerbivore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BigHerbivore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmallCarnivore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediumCarnivore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BigCarnivore)).BeginInit();
            this.SuspendLayout();
            // 
            // SmallHerbivore
            // 
            this.SmallHerbivore.Location = new System.Drawing.Point(47, 67);
            this.SmallHerbivore.Name = "SmallHerbivore";
            this.SmallHerbivore.Size = new System.Drawing.Size(120, 20);
            this.SmallHerbivore.TabIndex = 0;
            // 
            // MediumHerbivore
            // 
            this.MediumHerbivore.Location = new System.Drawing.Point(47, 124);
            this.MediumHerbivore.Name = "MediumHerbivore";
            this.MediumHerbivore.Size = new System.Drawing.Size(120, 20);
            this.MediumHerbivore.TabIndex = 1;
            this.MediumHerbivore.ValueChanged += new System.EventHandler(this.MediumHerbivore_ValueChanged);
            // 
            // BigHerbivore
            // 
            this.BigHerbivore.Location = new System.Drawing.Point(47, 173);
            this.BigHerbivore.Name = "BigHerbivore";
            this.BigHerbivore.Size = new System.Drawing.Size(120, 20);
            this.BigHerbivore.TabIndex = 2;
            // 
            // SmallCarnivore
            // 
            this.SmallCarnivore.Location = new System.Drawing.Point(203, 67);
            this.SmallCarnivore.Name = "SmallCarnivore";
            this.SmallCarnivore.Size = new System.Drawing.Size(120, 20);
            this.SmallCarnivore.TabIndex = 3;
            // 
            // MediumCarnivore
            // 
            this.MediumCarnivore.Location = new System.Drawing.Point(203, 124);
            this.MediumCarnivore.Name = "MediumCarnivore";
            this.MediumCarnivore.Size = new System.Drawing.Size(120, 20);
            this.MediumCarnivore.TabIndex = 4;
            // 
            // BigCarnivore
            // 
            this.BigCarnivore.Location = new System.Drawing.Point(203, 173);
            this.BigCarnivore.Name = "BigCarnivore";
            this.BigCarnivore.Size = new System.Drawing.Size(120, 20);
            this.BigCarnivore.TabIndex = 5;
            // 
            // Herbivore
            // 
            this.Herbivore.AutoSize = true;
            this.Herbivore.Location = new System.Drawing.Point(44, 9);
            this.Herbivore.Name = "Herbivore";
            this.Herbivore.Size = new System.Drawing.Size(53, 13);
            this.Herbivore.TabIndex = 6;
            this.Herbivore.Text = "Herbivore";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Carnivore";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Small";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Medium";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Big";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Small";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Medium";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Big";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Fill Train";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(360, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(359, 251);
            this.listBox1.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 279);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Herbivore);
            this.Controls.Add(this.BigCarnivore);
            this.Controls.Add(this.MediumCarnivore);
            this.Controls.Add(this.SmallCarnivore);
            this.Controls.Add(this.BigHerbivore);
            this.Controls.Add(this.MediumHerbivore);
            this.Controls.Add(this.SmallHerbivore);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SmallHerbivore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediumHerbivore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BigHerbivore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmallCarnivore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediumCarnivore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BigCarnivore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown SmallHerbivore;
        private System.Windows.Forms.NumericUpDown MediumHerbivore;
        private System.Windows.Forms.NumericUpDown BigHerbivore;
        private System.Windows.Forms.NumericUpDown SmallCarnivore;
        private System.Windows.Forms.NumericUpDown MediumCarnivore;
        private System.Windows.Forms.NumericUpDown BigCarnivore;
        private System.Windows.Forms.Label Herbivore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

