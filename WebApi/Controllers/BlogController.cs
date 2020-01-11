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

    [RoutePrefix("api/blog")]
    [Authorize]
    public class BlogController : ApiController {
        private readonly IBlogService blogService;

        public BlogController() {
            this.blogService = new BlogService();
        }

        [HttpGet]
        public IHttpActionResult GetAllBlogs() {
            IEnumerable<BlogDTO> resultList = blogService.GetAll();
            return Ok(resultList);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBlogById(int id) {
            BlogDTO resultBlog = blogService.GetById(id);
            return Ok(resultBlog);
        }

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
