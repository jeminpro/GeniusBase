using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeniusBase.Core.Database.Entity.Post
{
    public class ArticleHistory : BaseEntity
    {
        [Required]
        public int ArticleId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public bool IsDraft { get; set; }
        
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
