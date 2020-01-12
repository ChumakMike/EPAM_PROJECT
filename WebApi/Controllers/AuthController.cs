using BLL.Interfaces;
using BLL.ModelsDTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    /// <summary>
    /// Auth api
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController {

        private IUserService userService;
        /// <summary>
        /// Auth Controller constructor
        /// </summary>
        /// <param name="service">Service for crud users</param>
        public AuthController(IUserService userService) {
            this.userService = userService;
        }

        // POST: api/auth/register
        /// <summary>
        /// Create(Register) a new user
        /// </summary>
        /// <param name="UserDTO">User for creation</param>
        /// <returns>
        /// <response code="200">Comment created</response>
        /// <response code="400">Bad request</response>
        /// </returns>
        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register([FromBody] UserDTO userToBeCreated) {

            if (userToBeCreated == null) return BadRequest($"{nameof(userToBeCreated)} must be passed");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await userService.Create(userToBeCreated);
            return Ok();
        }


    }
}
