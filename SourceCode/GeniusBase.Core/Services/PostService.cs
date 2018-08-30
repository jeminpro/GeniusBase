using GeniusBase.Core.Database.Entity.Post;
using GeniusBase.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

// https://stackoverflow.com/a/5049454/587794
//This layer may not be needed
namespace GeniusBase.Core.Services
{
    public interface IPostService
    {
        IEnumerable<Category> GetAllCategories();

    }

    public class PostService: IPostService
    {
        IRepository<Article> _articleRepository;
        IRepository<Category> _categoryRepository;
        IUnitOfWork _unitOfWork;

        public PostService(
            IRepository<Article> articleRepository,
            IRepository<Category> categoryRepository,
            IUnitOfWork unitOfWork
        )
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public void SaveArticle(Article article)
        {
            _unitOfWork.Articles.Add(article);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }
    }
}
