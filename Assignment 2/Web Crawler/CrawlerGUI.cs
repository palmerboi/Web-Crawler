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
            int value = 0;
            if (string.IsNullOrEmpty(urlEntry1.Text) || string.IsNullOrEmpty(keywordEntry.Text) || string.IsNullOrEmpty(depthEntry.Text))
            {
                MessageBox.Show("Please enter at least 1 Url & 1 Keyword & depth value ", "", MessageBoxButtons.OK);
            }
            else
            {
                value = int.Parse(depthEntry.Text);
                if (value <= 0 || value > 20)
                {
                    MessageBox.Show("Please enter a depth in between 1 and 20", "", MessageBoxButtons.OK);
                }
            }
            List<string> urls = new List<string>();
            urls.Add(urlEntry1.Text);
            urls.Add(urlEntry2.Text);
            urls.Add(urlEntry3.Text);

            foreach (string url in urls)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    DisplayBox.Text += url + Environment.NewLine;
                }
            }
            DisplayBox.Text += keywordEntry.Text;
            
            Spider spider = new Spider(urls, keywordEntry.Text, value);
            spider.crawl();
            HashSet<string> visitedUrls = spider.getVisitedUrls();

        }
    }
}
