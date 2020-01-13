using BLL.ModelsDTO;
using BLL.Services;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WebApi.Providers {

    /// <summary></summary>
    public class AuthServProvider : OAuthAuthorizationServerProvider {

        /// <summary>
        /// 
        /// </summary>
        /// /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) {
            await Task.Run(() => context.Validated());
        }

        /// <summary>
        /// Getting claims for user, who enters the system
        /// </summary>
        /// /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (UserService userService = new UserService()) {
                UserDTO user = await userService.Auth(context.UserName, context.Password);
                if (user == null) {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            context.Validated(identity);
        }

    }
}