using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeniusBase.Core.Database.Entity.Post
{
    public class Tag : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string TagName { get; set; }

        [Required]
        [StringLength(30)]
        public string TagIdentifier { get; set; }
    }
}
