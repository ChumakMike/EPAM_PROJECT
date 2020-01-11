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
    [AllowAnonymous]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController {

        private IUserService userService;

        public AuthController() {
            userService = new UserService();
        }

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
