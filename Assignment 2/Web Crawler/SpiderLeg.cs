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

        //Spiderleg constructor
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
                //Dont actually need to do anything with the exception, if the document is null or url was invalid that will get checked later
            }
            URLs = new List<string>();
            metaData = new Metadata();
            imgList = new List<Image>();
        }

        //getter method for document
        public HtmlDocument getDocument()
        {
            return this.htmlDoc;
        }

        //getter method for document title
        public string getTitle()
        {
            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");
            var title = node.InnerHtml;
            return title;
        }

        //getter method for urls on the page
        public List<string> getHyperlinks()
        {
            //if document is null it will return empty list
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

        //getter method for list of images
        public List<Image> getImages()
        {
            foreach (HtmlNode img in htmlDoc.DocumentNode.SelectNodes("//img[@src]"))
            {
                string imgSource = img.GetAttributeValue("src", string.Empty);
                string imgWidth = img.GetAttributeValue("width", string.Empty);
                string imgHeight = img.GetAttributeValue("height", string.Empty);
                Image image = new Image { name = imgSource, width = imgWidth, height = imgHeight};
                imgList.Add(image);
            }

            return imgList;
        }

        //getter method for metatag keywords
        public List<string> getMeta()
        {
            string description = string.Empty;
            string keywords = string.Empty;

            try
            {
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
                foreach (string keyword in keywordsarray)
                {
                    metaData.keywords.Add(keyword.ToLower());
                }
            }
            catch
            {
            }

            return metaData.keywords;
        }

        //innerclass represents an image file from a html document
        public class Image
        {
            public string name { get; set; }
            public string width { get; set; }
            public string height { get; set; }
        }

        //innerclass represents the metadata from a html document
        public class Metadata
        {
            public string description;
            public List<string> keywords;

            public Metadata()
            {
                keywords = new List<string>();
            }
        }
    }
}
