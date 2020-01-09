using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.ModelsDTO;
using BLL.Services;
using BLL.Interfaces;

namespace API.Controllers {

    [RoutePrefix("api/article")]
    public class ArticleController : ApiController {
        private readonly IArticleService ArticleService;

        public ArticleController(ArticleService articleService) {
            this.ArticleService = articleService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> getAllArticles() {
            var articles = await ArticleService.GetAll();
            return Ok(articles);
        }

        [HttpPost]
        public IHttpActionResult CreateArticle([FromBody] ArticleDTO articleDTO) {
            if (articleDTO == null) {
                return BadRequest($"{articleDTO} must be passed");
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            ArticleService.Create(articleDTO);
            return Created("api/article" + articleDTO.ArticleId, articleDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetArticleById(int id) {
            var articleToGet = ArticleService.GetById(id);
            return articleToGet == null ? NotFound() : (IHttpActionResult)Ok(articleToGet);
        }


    }
}
