using GeniusBase.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusBase.Core.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly GbContext _context;

        public UnitOfWork(GbContext context)
        {
            _context = context;
            Articles = new ArticleRepository(_context);
        }

        public IArticleRepository Articles { get; private set; }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
