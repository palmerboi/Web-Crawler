using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Web_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cbl_items = new List<string>();
            List<string> imgList = new List<string>();
            var html = @"https://420chan.org/";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            Console.WriteLine(htmlDoc.DocumentNode.OuterHtml);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

            Console.WriteLine("Node Name: " + node.Name + "\n" + node.InnerHtml);
            Console.WriteLine();

            foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//a"))
            {
                // Get the value of the HREF attribute
                string hrefValue = link.GetAttributeValue("href", string.Empty);
                cbl_items.Add(hrefValue);
                Console.WriteLine(hrefValue);
            }

            
            foreach (HtmlNode img in htmlDoc.DocumentNode.SelectNodes("//img[@src]"))
            {
                string src = img.GetAttributeValue("src", string.Empty);
                string widoltski = img.GetAttributeValue("width", string.Empty);
                string hidolfski = img.GetAttributeValue("height", string.Empty);
                imgList.Add(src);
                Console.WriteLine(src+", width:"+widoltski+ ", height:"+hidolfski);
            }

            var urls = htmlDoc.DocumentNode.Descendants("img")
                                .Select(e => e.GetAttributeValue("src", null))
                                .Where(s => !String.IsNullOrEmpty(s));

            var meta = htmlDoc.DocumentNode.SelectNodes("/ html[1] / head[1] / meta[5]");

            Console.WriteLine(meta);
        }

        public string getTitle(string url)
        {

        }

        public List<string> getHyperlink(string url)
        {

        } 

        public List<Image> getImages(string url)
        {

        }

        public List<Metadata> getMeta(string url)
        {

        }

        class Image
        {
            string name;
            string width;
            string height;
            string alt;
        }

        class Metadata
        {
            string description;
            List<string> keywords;
        }
    }
}
