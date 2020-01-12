using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Interfaces;
using BLL.ModelsDTO;
using BLL.Services;

namespace WebApi.Controllers {
    /// <summary>
    /// Comment api
    /// </summary>
    [RoutePrefix("api/comment")]
    [Authorize]
    public class CommentController : ApiController {

        private readonly ICommentService CommentService;
        /// <summary>
        /// Comments Controller constructor
        /// </summary>
        /// <param name="service">Service for crud projects</param>
        public CommentController(ICommentService commentService) {
            this.CommentService = commentService;
        }

        // POST: api/comment/delete
        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <param name="commentDTO">Comment for deletion</param>
        /// <returns>
        /// <response code="200">Comment deleted</response>
        /// <response code="400">Bad request</response>
        /// </returns>
        [HttpPost]
        [Route("delete")]
        public IHttpActionResult RemoveComment([FromBody] CommentDTO commentDTO) {
            CommentDTO existingComment = CommentService.GetById(commentDTO.CommentId);

            if (existingComment == null) return NotFound();
            if (commentDTO == null) {
                return BadRequest($"{commentDTO} must be passed");
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            CommentService.Remove(commentDTO);
            return Ok();
        }

    }
}
