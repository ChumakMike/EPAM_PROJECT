using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using API.Models;
using BLL.Services;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers {

    [RoutePrefix("api/auth")]
    public class AuthController : ApiController {

        private UserService UserService;

        private static SignInModel user = new SignInModel {
            UserName = "username",
            Password = "password"
        };

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> Register([FromBody] SignInModel signInModel) {

            if (signInModel == null) return BadRequest($"{nameof(signInModel)} must be passed");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            IdentityResult result = await UserService.Register(signInModel.UserName, signInModel.Password);
            var ErrorResult = GetErrorResult(result);

            if (ErrorResult != null) return ErrorResult;

            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IHttpActionResult Login([FromBody] SignInModel signInModel) {


            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result) {
            if (result == null) return InternalServerError();
            if (!result.Succeeded) {
                if (result.Errors != null) {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError("", error.ToString());
                    }
                }

                if (ModelState.IsValid) return BadRequest();

                return BadRequest(ModelState);
            }

            return null;
        }
        
    }
}
