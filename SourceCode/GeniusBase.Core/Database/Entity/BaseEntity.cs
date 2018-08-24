using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusBase.Core.Database.Entity
{
    public class BaseEntity
    {
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }
    }
}
