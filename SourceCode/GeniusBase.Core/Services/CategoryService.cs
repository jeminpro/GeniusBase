using GeniusBase.Core.Database.Entity.Post;
using GeniusBase.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

// https://stackoverflow.com/a/5049454/587794
//This layer may not be needed
namespace GeniusBase.Core.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
    }

    public class CategoryService: ICategoryService
    {
        IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }
    }
}
