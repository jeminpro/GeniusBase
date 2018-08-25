using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeniusBase.Core.Database.Entity.Post
{
    public class ArticleTag : EntityBase
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        public int TagId { get; set; }
        
        [ForeignKey("ArticleId")]
        public virtual Article Category { get; set; }
        
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
