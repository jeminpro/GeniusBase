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

        [HttpGet("GetArticle/{id}")]
        public string GetArticle(int id)
        {
            _postService.GetAllCategories();
            return "value";
        }

        [HttpPost("AddArticle")]
        public IActionResult AddArticle([FromBody]ArticleDal articleDal)
        {
            var articleId = _postService.AddArticle(articleDal);
            return Ok(articleId);
        }

        [HttpPost("UpdateArticle/{articleId}")]
        public IActionResult UpdateArticle(int articleId, [FromBody]ArticleDal articleDal)
        {
            _postService.UpdateArticle(articleId, articleDal);
            return Ok();
        }

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
