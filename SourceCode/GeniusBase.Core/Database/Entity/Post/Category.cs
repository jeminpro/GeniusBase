﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeniusBase.Core.Database.Entity.Post
{
    public class Category : EntityBase
    {
        [Required]
        [StringLength(30)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(30)]
        public string CategoryIdentifier { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
