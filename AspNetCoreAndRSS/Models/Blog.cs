using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAndRSS.Models
{
    public class Blog
    {
        public string Title { get; set; }

        public string Path { get; set; }

        public string PreviewText { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
