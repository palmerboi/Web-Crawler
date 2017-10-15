namespace Web_Crawler
{
    partial class CrawlerGUI
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
            this.urlEntry1 = new System.Windows.Forms.TextBox();
            this.keywordEntry = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.urlEntry2 = new System.Windows.Forms.TextBox();
            this.urlEntry3 = new System.Windows.Forms.TextBox();
            this.depthEntry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // urlEntry1
            // 
            this.urlEntry1.Location = new System.Drawing.Point(37, 26);
            this.urlEntry1.Name = "urlEntry1";
            this.urlEntry1.Size = new System.Drawing.Size(207, 20);
            this.urlEntry1.TabIndex = 1;
            // 
            // keywordEntry
            // 
            this.keywordEntry.Location = new System.Drawing.Point(37, 126);
            this.keywordEntry.Name = "keywordEntry";
            this.keywordEntry.Size = new System.Drawing.Size(132, 20);
            this.keywordEntry.TabIndex = 2;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(37, 152);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(267, 26);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(464, 149);
            this.textBox2.TabIndex = 4;
            // 
            // urlEntry2
            // 
            this.urlEntry2.Location = new System.Drawing.Point(37, 52);
            this.urlEntry2.Name = "urlEntry2";
            this.urlEntry2.Size = new System.Drawing.Size(207, 20);
            this.urlEntry2.TabIndex = 5;
            // 
            // urlEntry3
            // 
            this.urlEntry3.Location = new System.Drawing.Point(37, 78);
            this.urlEntry3.Name = "urlEntry3";
            this.urlEntry3.Size = new System.Drawing.Size(207, 20);
            this.urlEntry3.TabIndex = 6;
            // 
            // depthEntry
            // 
            this.depthEntry.Location = new System.Drawing.Point(175, 126);
            this.depthEntry.Name = "depthEntry";
            this.depthEntry.Size = new System.Drawing.Size(69, 20);
            this.depthEntry.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Urls:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "3:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Keyword:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Depth:";
            // 
            // CrawlerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 208);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.depthEntry);
            this.Controls.Add(this.urlEntry3);
            this.Controls.Add(this.urlEntry2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.keywordEntry);
            this.Controls.Add(this.urlEntry1);
            this.Name = "CrawlerGUI";
            this.Text = "CrawlerGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox urlEntry1;
        private System.Windows.Forms.TextBox keywordEntry;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox urlEntry2;
        private System.Windows.Forms.TextBox urlEntry3;
        private System.Windows.Forms.TextBox depthEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}