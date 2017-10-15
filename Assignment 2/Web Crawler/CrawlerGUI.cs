using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Crawler
{
    public partial class CrawlerGUI : Form
    {
        
        public CrawlerGUI()
        {
            InitializeComponent();
        }


 
        private void SearchButton_Click_1(object sender, EventArgs e)
        {
            int value = int.Parse(depthEntry.Text);
       
            if (string.IsNullOrEmpty(urlEntry1.Text) || string.IsNullOrEmpty(keywordEntry.Text))
            {
                MessageBox.Show("Please enter at least 1 Url & 1 Keyword", "", MessageBoxButtons.OK);

            }
            if (value <= 0 || value > 20)
            {
                MessageBox.Show("Please enter a depth in between 1 and 20", "", MessageBoxButtons.OK);

            }
        }
    }
}
