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
            //condition statements if required input is not there
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
            //A list containing the urls
            List<string> urls = new List<string>();
            urls.Add(urlEntry1.Text);
            urls.Add(urlEntry2.Text);
            urls.Add(urlEntry3.Text);
            //displays the urls in the textbox
            foreach (string url in urls)
            {
                if (!string.IsNullOrEmpty(url))
                {
                    DisplayBox.Text += url + Environment.NewLine;
                }
            }
            DisplayBox.Text += keywordEntry.Text;
            //uses the spider to search the pages for the keyword
            Spider spider = new Spider(urls, keywordEntry.Text, value);
            spider.crawl();
            HashSet<string> visitedUrls = spider.getVisitedUrls();
            foreach(string visitedUrl in visitedUrls)
            {
                DisplayBox.Text += visitedUrl;

                if(visitedUrls == null)
                {
                    MessageBox.Show("No results found", "", MessageBoxButtons.OK);
                }
            }
        }

         static void Main(string[] args)
        {
            var guiForm = new CrawlerGUI();
            //This "opens" the GUI on your screen
            guiForm.ShowDialog();
        }
        //Button to clear text
        private void clearBtn_Click(object sender, EventArgs e)
        {
            DisplayBox.Clear();
        }
    }
}
