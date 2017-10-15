using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Crawler
{
    class Spider
    {
        private List<URL> unvisitedURLs;
        private SortedSet<URL> visitedURLs;
        private int maxSearchDepth;
        string keyword;

        public Spider(List<string> seedURLs, string keyword, int depth)
        {
            unvisitedURLs = new List<URL>();
            visitedURLs = new SortedSet<URL>();
            this.keyword = keyword;
            maxSearchDepth = depth;

            foreach (string seed in seedURLs)
            {
                URL url = new URL { url = seed, distance = 0 };
                unvisitedURLs.Add(url);
            }
        }

        public void crawl()
        {   
            //while list of unvisited urls is not empty
            while (unvisitedURLs.Count > 0) 
            {
                //take URL from list
                var url = unvisitedURLs.ElementAt(unvisitedURLs.Count);
                unvisitedURLs.RemoveAt(unvisitedURLs.Count);
                //use SpiderLeg to fetch content
                var leg = new SpiderLeg(url.url);
                //if content of url is HTML
                if (leg.getDocument().Equals(null)) 
                {
                    //use SpiderLeg to parse out URLs from links
                    var links = leg.getHyperlinks();
                    foreach (string link in links) 
                    {   
                        //it matches the rules and not already visited or in the unvisited list
                        if ()
                        {
                            //add it to the unvisited list

                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("http://www.newworld.co.nz/");

            Spider spider = new Spider(list, "chicken", 10);

            spider.crawl();

            foreach(URL url in spider.visitedURLs)
            {
                Console.WriteLine(url.url);
            }
        }

        public class URL
        {
            public string url { get; set; }
            public int distance { get; set; }
        }

    }
}
