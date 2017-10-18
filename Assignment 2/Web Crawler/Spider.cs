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
        private SortedSet<string> visitedURLs;
        private int maxSearchDepth;
        string keyword;

        public Spider(List<string> seedURLs, string keyword, int depth)
        {
            unvisitedURLs = new List<string>();
            visitedURLs = new SortedSet<string>();
            this.keyword = keyword;
            maxSearchDepth = depth;

            foreach (string seed in seedURLs)
            {
                unvisitedURLs.Add(seed);
            }
        }

        public void crawl()
        {
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
                urlsAtCurrrentDepthLevel--;
                //use SpiderLeg to fetch content
                var leg = new SpiderLeg(URL);
                //if content of url is HTML
                if (!leg.getDocument().Equals(null)) 
                {
                    //use SpiderLeg to parse out URLs from links
                    var links = leg.getHyperlinks();
                    
                    foreach (string link in links)
                    { 
                        //it matches the rules and not already visited or in the unvisited list
                        if (currentDepthLevel+1 <= maxSearchDepth && !visitedURLs.Contains(link) && !unvisitedURLs.Contains(link))
                        {
                            //add it to the unvisited list
                            unvisitedURLs.Add(link);
                            urlsAtNextDepthLevel++;
                        }
                    }
                }
                if(urlsAtCurrrentDepthLevel == 0)
                {
                    currentDepthLevel++;
                    urlsAtCurrrentDepthLevel = urlsAtNextDepthLevel;
                    urlsAtNextDepthLevel = 0;
                }
            }
        }

        static void Main(string[] args)
        {
            var guiForm = new CrawlerGUI();
            ////This "opens" the GUI on your screen
            guiForm.ShowDialog();

            List<string> list = new List<string>();
            list.Add("http://www.newworld.co.nz/");

            Spider spider = new Spider(list, "chicken", 3);

            spider.crawl();

            foreach(string url in spider.visitedURLs)
            {
                Console.WriteLine(url);
            }
        }

        //public class URL
        //{
        //    public string url { get; set; }
        //    public int distance { get; set; }
        //}

    }
}
