using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Web_Crawler
{
    class SpiderLeg
    {
        private string url;
        private HtmlWeb web;
        private HtmlDocument htmlDoc;
        List<string> URLs;
        List<Image> imgList;
        Metadata metaData;

        public SpiderLeg(string url)
        {
            this.url = url;
            web = new HtmlWeb();
            try
            {
                htmlDoc = web.Load(url);
            }
            catch (Exception)
            {
                //Console.WriteLine("You suck");
            }
            URLs = new List<string>();
            metaData = new Metadata();
            imgList = new List<Image>();
        }

        //static void Main(string[] args)
        //{
        //    SpiderLeg leg = new SpiderLeg("https://www.w3schools.com/tags/tag_meta.asp");

        //    Console.WriteLine(leg.htmlDoc.DocumentNode.OuterHtml);
        //    Console.WriteLine();

        //    Console.WriteLine(leg.getTitle());
        //    Console.WriteLine();

        //    leg.getHyperlink();
        //    foreach(String url in leg.URLs)
        //    {
        //        Console.WriteLine(url);
        //    }
        //    Console.WriteLine();

        //    leg.getImages();
        //    foreach(Image img in leg.imgList)
        //    {
        //        Console.WriteLine(img.name+" width: "+img.width+" height: "+img.height);
        //    }
        //    Console.WriteLine();

        //    leg.getMeta();
        //    Console.WriteLine("Description: "+leg.metaData.description);
        //    foreach(string keyword in leg.metaData.keywords)
        //    {
        //        Console.WriteLine(keyword);
        //    }
        //}

        public HtmlDocument getDocument()
        {
            return this.htmlDoc;
        }

        public string getTitle()
        {
            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");
            var title = node.InnerHtml;
            return title;
        }

        public List<string> getHyperlinks()
        {
            try
            {
                foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//a"))
                {
                    // Get the link text in the href attribute
                    string hrefValue = link.GetAttributeValue("href", string.Empty);
                    if (hrefValue.Contains("http")) // make sure its a URL
                    {
                        URLs.Add(hrefValue);
                    }
                }
            }
            catch
            {
            }

            return URLs;
        }

        public void getImages()
        {
            foreach (HtmlNode img in htmlDoc.DocumentNode.SelectNodes("//img[@src]"))
            {
                string imgSource = img.GetAttributeValue("src", string.Empty);
                string imgWidth = img.GetAttributeValue("width", string.Empty);
                string imgHeight = img.GetAttributeValue("height", string.Empty);
                Image image = new Image { name = imgSource, width = imgWidth, height = imgHeight};
                imgList.Add(image);
            }
        }

        public List<string> getMeta()
        {
            string description = string.Empty;
            string keywords = string.Empty;

            foreach (HtmlNode meta in htmlDoc.DocumentNode.SelectNodes("//meta"))
            {
                if (meta.GetAttributeValue("name", string.Empty).ToLower().Equals("description"))
                {
                    description = meta.GetAttributeValue("name", string.Empty);
                }
                if (meta.GetAttributeValue("name", string.Empty).ToLower().Equals("keywords"))
                {
                    keywords = meta.GetAttributeValue("content", string.Empty);
                }
            }

            metaData.description = description;
            string[] keywordsarray = keywords.Split(',');
            foreach(string keyword in keywordsarray)
            {
                metaData.keywords.Add(keyword.ToLower());
            }

            return metaData.keywords;
        }

        //represents an image file from a html document
        public class Image
        {
            public string name { get; set; }
            public string width { get; set; }
            public string height { get; set; }
        }

        //represents the metadata from a html document
        public class Metadata
        {
            public string description;
            public List<string> keywords;

            public Metadata()
            {
                keywords = new List<string>();
            }
        }

        public void loadNewURL(string url)
        {
            this.url = url;
            try
            {
                htmlDoc = web.Load(url);
            }
            catch (Exception)
            {
                //Console.WriteLine("You suck");
            }
        }
    }
}
