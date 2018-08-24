using System;
using System.Collections.Generic;
using System.Linq;
using GeniusBase.Core.Database;
using GeniusBase.Core.Database.Entity.Post;

namespace GeniusBase.Core
{
    public class Test: ITest
    {
        private readonly GbContext _context;

        public Test(GbContext context)
        {
            _context = context;
        }

        public List<Category> TestMethod()
        {
            return _context.Category.ToList(); ;
        }
    }
}
