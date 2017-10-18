using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Crawler
{
    class Spider
    {
        private List<string> unvisitedURLs;
        private HashSet<string> visitedURLs;
        private int maxSearchDepth;
        string keyword;

        //spider constructor
        public Spider(List<string> seedURLs, string keyword, int depth)
        {
            unvisitedURLs = new List<string>();
            visitedURLs = new HashSet<string>();
            this.keyword = keyword;
            maxSearchDepth = depth;

            foreach (string seed in seedURLs)
            {
                unvisitedURLs.Add(seed);
            }
        }

        public void crawl()
        {   
            //keeps track of what depth the urls are located at, relative to seed urls
            int currentDepthLevel = 0;
            int urlsAtCurrrentDepthLevel = unvisitedURLs.Count;
            int urlsAtNextDepthLevel = 0;

            //while list of unvisited urls is not empty
            while (unvisitedURLs.Count > 0)
            {
                //take URL from unvisited list and put in visited set
                var URL = unvisitedURLs.ElementAt(0);
                unvisitedURLs.RemoveAt(0);
                visitedURLs.Add(URL);

                //decrement the number of urls remaining at this depth level
                urlsAtCurrrentDepthLevel--;

                //use SpiderLeg to fetch content
                var leg = new SpiderLeg(URL);

                //if content loaded from url is HTML
                if (leg.getDocument() != null)
                {
                    //use SpiderLeg to parse out URLs from links
                    var links = leg.getHyperlinks();

                    //load keywords from current url html
                    List<string> keywords = leg.getMeta();
                    
                    //check if it contains the keyword you requested
                    if (keywords.Contains(" "+keyword))
                    {
                        //write to file if it does
                        using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@"C:\Users\Public\RelevantURLs.txt", true))
                        {
                            file.WriteLine(URL + ", " + currentDepthLevel);
                        }
                    }

                    //iterate through the links in current url to see if they should be added to unvisited list
                    foreach (string link in links)
                    {
                        //if not deeper than max search depth and not already in visited or unvisited list
                        if (currentDepthLevel + 1 <= maxSearchDepth
                            && !visitedURLs.Contains(link)
                            && !unvisitedURLs.Contains(link))
                        {
                            //add it to the unvisited list
                            unvisitedURLs.Add(link);
                            urlsAtNextDepthLevel++;
                        }
                    }
                }
            
                //change the depth level once all the urls from the current one have been searched
                if (urlsAtCurrrentDepthLevel == 0)
                {
                    currentDepthLevel++;
                    urlsAtCurrrentDepthLevel = urlsAtNextDepthLevel;
                    urlsAtNextDepthLevel = 0;
                }
            }
        }

        static void Main(string[] args)
        {
            //var guiForm = new CrawlerGUI();
            //////This "opens" the GUI on your screen
            //guiForm.ShowDialog();

            List<string> list = new List<string>();
            list.Add("http://www.newworld.co.nz/");

            Spider spider = new Spider(list, "grocery", 3);

            spider.crawl();

            foreach (string url in spider.visitedURLs)
            {
                Console.WriteLine(url);
            }
        }

        public HashSet<string> getVisitedUrls()
        {
            return visitedURLs;
        }
    }
}

