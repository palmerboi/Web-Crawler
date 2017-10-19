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
        private readonly System.Threading.SynchronizationContext synchronizationContext;

        public CrawlerGUI()
        {
            InitializeComponent();
            synchronizationContext = System.Threading.SynchronizationContext.Current;
        }

        //event handler if search button is clicked
        private async void SearchButton_Click_1(object sender, EventArgs e)
        {
            //condition statements if required input is not there
            int value = 0;
            if ((string.IsNullOrEmpty(urlEntry1.Text) && string.IsNullOrEmpty(urlEntry2.Text) && string.IsNullOrEmpty(urlEntry3.Text)) 
                || string.IsNullOrEmpty(keywordEntry.Text) || string.IsNullOrEmpty(depthEntry.Text))
            {
                MessageBox.Show("Please enter at least one Url, keyword and search depth value", "", MessageBoxButtons.OK);
            }
            else if (int.Parse(depthEntry.Text) < 1 || int.Parse(depthEntry.Text) > 10)
            {
                MessageBox.Show("Please enter a search depth between 1 and 10", "", MessageBoxButtons.OK);
            }
            else
            {

                DisplayBox.Text += "Beginning Search, Please wait..." + Environment.NewLine;
                //A list containing the urls
                List<string> urls = new List<string>();
                urls.Add(urlEntry1.Text);
                urls.Add(urlEntry2.Text);
                urls.Add(urlEntry3.Text);

                value = int.Parse(depthEntry.Text);

                //uses the spider to search for pages containing the keyword
                Spider spider = new Spider(urls, keywordEntry.Text, value);

                //enables gui to remain responsive during search for relevant URLs
                await Task.Run(() =>
                {
                    spider.crawl();
                    //retrieve search results and display them in display box
                    HashSet<string> visitedUrls = spider.getVisitedRelevantUrls();
                    if (visitedUrls.Count == 0)
                    {
                        MessageBox.Show("No results found", "", MessageBoxButtons.OK);
                    }
                    else
                    {
                        foreach (string visitedUrl in visitedUrls)
                        {
                            updateUI(visitedUrl);
                        }
                    }
                });
            }
        }

        //update gui via separate thread
        public void updateUI(string visitedUrl)
        {
            synchronizationContext.Post(new System.Threading.SendOrPostCallback(o =>
            {
                DisplayBox.Text += visitedUrl + Environment.NewLine;
            }), visitedUrl);
        }

        //event handler to clear text
        private void clearBtn_Click(object sender, EventArgs e)
        {
            DisplayBox.Clear();
        }

        //entry point for program, launches gui
        static void Main(string[] args)
        {
            var guiForm = new CrawlerGUI();
            guiForm.ShowDialog();
        }

        
    }
}
