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
    [Authorize]
    public class ArticleController : ApiController {

        private readonly IArticleService ArticleService;
        private readonly ICommentService CommentService;

        public ArticleController() {
            this.ArticleService = new ArticleService();
            this.CommentService = new CommentService();
        }

        [HttpGet]
        public IHttpActionResult getAllArticles() {
            List<ArticleDTO> allArticles = ArticleService.GetAll().ToList();
            return Ok(allArticles);
        }

        [HttpPost]
        [Route("new")]
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

        [HttpPut]
        [Route("update")]
        public IHttpActionResult UpdateArticle([FromBody] ArticleDTO articleDTO) {
            ArticleDTO existingArticle = ArticleService.GetById(articleDTO.ArticleId);

            if (existingArticle == null) return NotFound();
            if (articleDTO == null) {
                return BadRequest($"{articleDTO} must be passed");
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            ArticleService.Update(articleDTO);
            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult DeleteArticle([FromBody] ArticleDTO articleDTO) {
            ArticleDTO existingArticle = ArticleService.GetById(articleDTO.ArticleId);

            if (existingArticle == null) return NotFound();
            if (articleDTO == null) {
                return BadRequest($"{articleDTO} must be passed");
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            ArticleService.Remove(articleDTO);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetArticleWithCommentsById(int id) {
            ArticleDTO resultArticle = ArticleService.GetById(id);
            if (resultArticle == null) return NotFound();
            resultArticle.CommentDTOs = CommentService.GetByArticleId(id).ToList();
            return Ok(resultArticle);
        }

        [HttpPost]
        [Route("{id}/addcomment")]
        public IHttpActionResult CreateCommentForCurrentArticle(int id, [FromBody] CommentDTO commentDTO) {

            if (commentDTO == null) {
                return BadRequest($"{commentDTO} must be passed");
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            } 
            commentDTO.ArticleRefId = id;
            CommentService.Create(commentDTO);
            return Ok();
        }
    }
}
