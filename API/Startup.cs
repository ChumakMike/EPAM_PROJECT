using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using System.Web.Http;
using System.Web;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Jwt;

[assembly: OwinStartup(typeof(API.Startup))]

namespace API {
    public class Startup {

        public void Configuration(IAppBuilder app) {

            //AddJwtAuth(app);

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }


        /*  private void AddJwtAuth(IAppBuilder app) {
            string audience = JwtHelper.Audience;
            string issuer = JwtHelper.Issuer;

            var signingCredentials = JwtHelper.CreateCredentials();
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions {
                TokenValidationParameters = new TokenValidationParameters {
                    IssuerSigningKey = signingCredentials.Key,

                    ValidIssuer = issuer,
                    ValidateIssuer = true,

                    ValidAudience = audience,
                    ValidateAudience = true,

                    ValidateLifetime = true
                },
            });
        }
        */
    }
}
