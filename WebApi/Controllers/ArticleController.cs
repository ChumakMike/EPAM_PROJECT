using BLL.Interfaces;
using BLL.ModelsDTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers {

    [RoutePrefix("api/article")]
    public class ArticleController : ApiController {

        private readonly IArticleService ArticleService;

        public ArticleController() {
            this.ArticleService = new ArticleService();
        }

        [HttpGet]
        public IHttpActionResult getAllArticles() {
            return Ok();
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
            return Ok(articleDTO);
        }
    }
}
