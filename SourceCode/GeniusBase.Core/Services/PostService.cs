﻿using GeniusBase.Core.Database.Entity.Post;
using GeniusBase.Core.Repository;
using GeniusBase.Core.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusBase.Core.Services
{
    public interface IPostService
    {
        IEnumerable<Category> GetAllCategories();
        int AddArticle(ArticleDal articleDal);
        void UpdateArticle(ArticleDal articleDal);
    }

    public class PostService: IPostService
    {
        IRepository<Database.Entity.Post.Article> _articleRepository;
        IRepository<Category> _categoryRepository;
        IUnitOfWork _unitOfWork;

        public PostService(
            IRepository<Database.Entity.Post.Article> articleRepository,
            IRepository<Category> categoryRepository,
            IUnitOfWork unitOfWork
        )
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public int AddArticle(ArticleDal articleDal)
        {
            var article = new Article
            {
                Title = articleDal.Title,
                Content = articleDal.Content,
                PlainContent = articleDal.Content,
                CategoryId = articleDal.CategoryId,               
                IsDraft = articleDal.IsDraft,
                UrlIdentifier = articleDal.Title
            };
            
            if (!articleDal.IsDraft)
            {
                article.FirstPublishedDate = DateTime.Now;
            }
            
            _unitOfWork.Articles.Add(article);
            
            return _unitOfWork.SaveChanges();
        }

        public void UpdateArticle(ArticleDal articleDal)
        {
            var article = _unitOfWork.Articles.Get(articleDal.ArticleId.Value);

            article.Title = articleDal.Title;
            article.Content = articleDal.Content;
            article.PlainContent = articleDal.Content;
            article.CategoryId = articleDal.CategoryId;
            article.IsDraft = articleDal.IsDraft;
            article.UrlIdentifier = articleDal.Title;

            if (article.FirstPublishedDate == null && !articleDal.IsDraft)
            {
                article.FirstPublishedDate = DateTime.Now;
            }

            _unitOfWork.SaveChanges();
        }

    }
}
