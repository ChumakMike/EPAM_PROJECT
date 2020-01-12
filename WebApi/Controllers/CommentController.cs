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

    [RoutePrefix("api/comment")]
    [Authorize]
    public class CommentController : ApiController {

        private readonly ICommentService CommentService;

        public CommentController() {
            this.CommentService = new CommentService();
        }

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
