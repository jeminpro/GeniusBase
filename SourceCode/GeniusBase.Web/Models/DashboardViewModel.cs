using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeniusBase.Web.Models
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            Categories = new List<CategoryViewModel>();
            Tags = new List<TagViewModel>();
        }

        public List<CategoryViewModel> Categories { get; set; }
        public List<TagViewModel> Tags { get; set; }
    }
}
