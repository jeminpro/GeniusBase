using GeniusBase.Core.Database;
using GeniusBase.Core.Database.Entity.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusBase.Core.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {

    }

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(GbContext context) : base(context)
        {

        }

        public GbContext GbContext
        {
            get { return Context as GbContext; }
        }
    }
}
