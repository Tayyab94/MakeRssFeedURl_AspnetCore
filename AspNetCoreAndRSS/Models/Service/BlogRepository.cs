using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAndRSS.Models.Service
{
    public class BlogRepository : IBlogRepository
    {
        public List<Blog> Blogs => new List<Blog>
        {
            new Blog
            {
                 Path="Path1",
                  PreviewText="This is Text",
                   PublishDate=DateTime.Now,
                    Title="Simpel Title"
            },
            new Blog
            {
                 Path="Path2",
                  PreviewText="This is Text 2",
                   PublishDate=DateTime.Now,
                    Title="Simpel Title 2"
            },
            new Blog
            {
                 Path="Path3",
                  PreviewText="This is Text 3",
                   PublishDate=DateTime.Now,
                    Title="Simpel Title 3"
            },
            new Blog
            {
                 Path="Path4",
                  PreviewText="This is Text 4",
                   PublishDate=DateTime.Now,
                    Title="Simpel Title 4"
            },
        };
    }
}
