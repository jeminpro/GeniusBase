using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusBase.Core.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        IArticleRepository Articles { get; }

        int SaveChanges();
    }
}
