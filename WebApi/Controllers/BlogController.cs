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
    /// Blog api
    /// </summary>
    [RoutePrefix("api/blog")]
    [Authorize]
    public class BlogController : ApiController {
        private readonly IBlogService blogService;
        private readonly IArticleService articleService;

        /// <summary>
        /// Blog Controller constructor
        /// </summary>
        /// <param name="articleService">Service for crud articles</param>
        /// <param name="blogService">Service for crud blogs</param>
        public BlogController(IBlogService blogService, IArticleService articleService) {
            this.blogService = blogService;
            this.articleService = articleService;
        }
        // GET: api/blog
        /// <summary>
        /// Get all blogs
        /// </summary>
        /// <returns>
        /// <response code="200">Blogs found</response>
        /// <response code="404">Blogs not found</response>
        /// </returns>
        [HttpGet]
        public IHttpActionResult GetAllBlogs() {
            IEnumerable<BlogDTO> resultList = blogService.GetAll();
            return Ok(resultList);
        }

        // GET: api/blog/{id}
        /// <summary>
        /// Get blog by id
        /// </summary>
        /// <remarks>
        /// Get blog with all it's articles
        /// </remarks>
        /// /// <param name="id">Id for search</param>
        /// <returns>
        /// <response code="200">Blog found</response>
        /// <response code="404">Blog was not found</response>
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBlogById(int id) {
            BlogDTO resultBlog = blogService.GetById(id);
            if (resultBlog == null) return NotFound();
            resultBlog.ArticleDTOs = articleService.GetByBlogId(id).ToList();
            return Ok(resultBlog);
        }

        // POST: api/blog/new
        /// <summary>
        /// Create a new blog
        /// </summary>
        /// <param name="blogDTO">Blog for creation</param>
        /// <returns>
        /// <response code="200">Blog created</response>
        /// <response code="400">Bad request</response>
        /// </returns>
        [HttpPost]
        [Route("new")]
        public IHttpActionResult CreateBlog([FromBody] BlogDTO blogDTO) {
            if (blogDTO == null) {
                return BadRequest($"{blogDTO} must be passed");
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            blogService.Create(blogDTO);
            return Ok();
        }

        // PUT api/blog/update
        /// <summary>
        /// Update an existing blog
        /// </summary>
        /// <param name="blogDTO">Blog to update</param>
        /// <returns>
        /// <response code="200">Blog updated</response>
        /// <response code="404">Blog not found</response>
        /// </returns>
        [HttpPut]
        [Route("update")]
        public IHttpActionResult UpdateBlog([FromBody] BlogDTO blogDTO) {
            BlogDTO existingBlog = blogService.GetById(blogDTO.BlogId);

            if (existingBlog == null) return NotFound();
            if (blogDTO == null) {
                return BadRequest($"{blogDTO} must be passed");
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            blogService.Update(blogDTO);
            return Ok();
        }

        // POST api/blog/delete
        /// <summary>
        /// Delete an existing Blog
        /// </summary>
        /// <param name="blogDTO">Blog to delete</param>
        /// <returns>
        /// <response code="200">Blog deleted</response>
        /// <response code="404">Blog not found</response>
        /// </returns>
        [HttpPost]
        [Route("delete")]
        public IHttpActionResult DeleteBlog([FromBody] BlogDTO blogDTO) {
            BlogDTO existingBlog = blogService.GetById(blogDTO.BlogId);

            if (existingBlog == null) return NotFound();
            if (blogDTO == null) {
                return BadRequest($"{blogDTO} must be passed");
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            blogService.Remove(blogDTO);
            return Ok();
        }
    }
}
