using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeniusBase.Core.Services;
using GeniusBase.Core.Services.ServiceModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeniusBase.Web.Api
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;

        }

        // GET api/<controller>/5
        [HttpGet("GetArticle/{id}")]
        public string GetArticle(int id)
        {
            _postService.GetAllCategories();
            return "value";
        }

        [HttpPost]
        public void SaveArticle([FromBody]ArticleDal articleDal)
        {
            if (articleDal.ArticleId.HasValue)
                _postService.AddArticle(articleDal);
            else
                _postService.UpdateArticle(articleDal);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
