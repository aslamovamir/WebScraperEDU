using System.Collections.Generic;
using HtmlAgilityPack;

namespace Scraper
{
    public class ScrapingLogic
    {
        public List<string> getInfo(string url)
        {
            List<string> items = new List<string>();

            HtmlWeb web = new HtmlWeb();

            var doc = web.Load(url);

            var nodes = doc.DocumentNode.SelectNodes("//*[@id=\"content\"]");

            foreach (var node in nodes)
            {
                items.Add(node.InnerText);
            }

            return items;
        }
    }
}
