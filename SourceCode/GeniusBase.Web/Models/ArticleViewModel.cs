using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeniusBase.Web.Models
{
    public class ArticleViewModel
    {
        public long ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CategorySef { get; set; }
        public string CategoryName { get; set; }
        public List<string> Tags { get; set; }
    }
}
