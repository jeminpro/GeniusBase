using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeniusBase.Web.Models
{
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public string CategoryIdentifier { get; set; }
        public int CategoryArticleCount { get; set; }
    }
}
