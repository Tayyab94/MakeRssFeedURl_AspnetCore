using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAndRSS.Models.Service
{
    public interface IBlogRepository
    {

        List<Blog> Blogs { get; }
    }
}
