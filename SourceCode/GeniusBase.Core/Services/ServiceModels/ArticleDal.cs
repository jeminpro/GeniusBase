using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusBase.Core.Services.ServiceModels
{
    public class ArticleDal
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public bool IsDraft { get; set; }
        public int UserId { get; set; }
        public string UrlIdentifier { get; set; }
    }
}
