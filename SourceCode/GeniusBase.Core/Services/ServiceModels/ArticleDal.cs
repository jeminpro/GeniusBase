using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusBase.Core.Services.ServiceModels
{
    public class ArticleDal
    {
        public int? ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public List<int> TagItems { get; set; }
        public bool IsDraft { get; set; }
        public int UserId { get; set; }
        public string UrlIdentifier { get; set; }
    }
}
