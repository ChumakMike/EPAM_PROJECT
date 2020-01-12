using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WebApi.Providers;
using Ninject;
using Ninject.Web.Common.OwinHost;
using WebApi.Ninject;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(WebApi.Startup))]

namespace WebApi {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            
            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app) {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions() {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthServProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        private static StandardKernel CreateKernel() {
            return new StandardKernel(new NinjectBindings());
        }
    }
}
