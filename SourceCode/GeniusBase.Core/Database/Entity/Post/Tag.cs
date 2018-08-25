using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GeniusBase.Core.Database.Entity.Post
{
    public class Tag : EntityBase
    {
        [Required]
        [StringLength(30)]
        public string TagName { get; set; }
    }
}
