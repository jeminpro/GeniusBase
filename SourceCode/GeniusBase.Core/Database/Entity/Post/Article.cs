﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeniusBase.Core.Database.Entity.Post
{
    public class Article : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ArticleId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string UrlIdentifier { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string PlainContent { get; set; }

        public bool IsDraft { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int Views { get; set; }
        
        public DateTime FirstPublishedDate { get; set; }

        public DateTime ArchivedDate { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
