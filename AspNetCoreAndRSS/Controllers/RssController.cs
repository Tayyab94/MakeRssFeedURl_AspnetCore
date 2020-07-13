using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAndRSS.Models.Service;
using Microsoft.AspNetCore.Mvc;


using System.Xml.Linq;
using System.Text.Encodings.Web;
using System.Globalization;

namespace AspNetCoreAndRSS.Controllers
{
    [Produces("application/xml")]
    public class RssController : Controller
    {
        private readonly IBlogRepository blogRepository;

        public RssController(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }
        public IActionResult Index()
        {
            XNamespace ns = "https://www.w3.org/2005/Atom";
            var rss = new XElement("rss", new XAttribute("version", "2.0"), new XAttribute(XNamespace.Xmlns + "atom", ns));


            var channel = new XElement("channel",
                new XElement("title", ".Net Concept of the RSS"),
                new XElement("link", "https://1blogonline.com"),
                new XElement("description", ".net Videos"),
                new XElement("language", "en-us"),
                new XElement("Copyright", $"Copy right {DateTime.UtcNow.Year} Tayyab Bhatti"),
                new XElement("lastBuilTDate", blogRepository.Blogs.OrderBy(s => s.PublishDate).First().PublishDate.ToUniversalTime().ToString("r")),
                new XElement("Category", "Software Engineering"),
                new XElement(ns + "link", new XAttribute("href", $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/Rss"),
                new XAttribute("rel", "self"), new XAttribute("type", "application/rss+xml")),
                new XElement("title","40")
                );



            foreach (var post in blogRepository.Blogs)
            {
                var postInRss = new XElement("item");
                postInRss.Add(new XElement("title", post.Title));
                postInRss.Add(new XElement("description",HtmlEncoder.Default.Encode(post.PreviewText)));
                postInRss.Add(new XElement("link",
                    $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/Blog/ShowPost/"+post.Path));

                postInRss.Add(new XElement("author","Tayyab Bhatti"));
                postInRss.Add(new XElement("pubDate", post.PublishDate.ToUniversalTime().ToString("r")));
                postInRss.Add(new XElement("guid", post.Path+"#when"+post.PublishDate.ToUniversalTime().ToString(CultureInfo.InvariantCulture).Replace(" ",string.Empty)
                    ,new XAttribute("isPermalink","false")));

                channel.Add(postInRss);

            }
            rss.Add(channel);
            return Ok(rss);
        }
    }
}
