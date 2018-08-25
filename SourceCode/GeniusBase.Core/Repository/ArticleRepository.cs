using GeniusBase.Core.Database;
using GeniusBase.Core.Database.Entity.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusBase.Core.Repository
{
    public interface IArticleRepository: IRepository<Article>
    {

    }

    public class ArticleRepository: Repository<Article>, IArticleRepository
    {
        public ArticleRepository(GbContext context): base(context)
        {
         
        }

        public GbContext GbContext
        {
            get { return Context as GbContext; }
        }
    }
}
