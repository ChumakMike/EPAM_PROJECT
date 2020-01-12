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

    /// <summary>
    /// Article api
    /// </summary>
    [RoutePrefix("api/article")]
    [Authorize]
    public class ArticleController : ApiController {

        private readonly IArticleService ArticleService;
        private readonly ICommentService CommentService;

        /// <summary>
        /// Article Controller constructor
        /// </summary>
        /// <param name="articleService">Service for crud articles</param>
        /// <param name="commentService">Service for crud comments</param>
        public ArticleController(IArticleService articleService, ICommentService commentService) {
            this.ArticleService = articleService;
            this.CommentService = commentService;
        }

        // GET: api/article
        /// <summary>
        /// Get all articles
        /// </summary>
        /// <returns>
        /// <response code="200">Articles found</response>
        /// <response code="404">Articles not found</response>
        /// </returns>
        [HttpGet]
        public IHttpActionResult getAllArticles() {
            List<ArticleDTO> allArticles = ArticleService.GetAll().ToList();
            return Ok(allArticles);
        }

        // POST: api/article/new
        /// <summary>
        /// Create a new article
        /// </summary>
        /// <param name="articleDTO">Article for creation</param>
        /// <returns>
        /// <response code="200">Article created</response>
        /// <response code="400">Bad request</response>
        /// </returns>
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

        // PUT api/article/update
        /// <summary>
        /// Update an existing article
        /// </summary>
        /// <param name="articleDTO">Article to update</param>
        /// <returns>
        /// <response code="200">Article updated</response>
        /// <response code="404">Article not found</response>
        /// </returns>
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

        // POST api/article/delete
        /// <summary>
        /// Delete an existing article
        /// </summary>
        /// <param name="articleDTO">Article to delete</param>
        /// <returns>
        /// <response code="200">Article deleted</response>
        /// <response code="404">Article not found</response>
        /// </returns>
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

        // GET: api/article/{id}
        /// <summary>
        /// Get article by id
        /// </summary>
        /// <returns>
        /// <response code="200">Article found</response>
        /// <response code="404">Article was not found</response>
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetArticleWithCommentsById(int id) {
            ArticleDTO resultArticle = ArticleService.GetById(id);
            if (resultArticle == null) return NotFound();
            resultArticle.CommentDTOs = CommentService.GetByArticleId(id).ToList();
            return Ok(resultArticle);
        }

        // POST api/article/{id}/addcomment
        /// <summary>
        /// Create a comment for an existing article
        /// </summary>
        /// <remarks>
        /// Create comment to current article
        /// </remarks>
        /// <param name="id">Id of an existing article</param>
        /// <param name="commentDTO">Comment to create</param>
        /// <returns>
        /// <response code="200">Comment created</response>
        /// <response code="404">Bad request</response>
        /// </returns>
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
