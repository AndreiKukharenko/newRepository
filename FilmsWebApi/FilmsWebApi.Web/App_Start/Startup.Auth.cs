using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using FilmsWebApi.Web.Providers;

namespace FilmsWebApi.Web
{
    public partial class Startup
    {
        private static OAuthAuthorizationServerOptions _OAuthOptions;

        static Startup()
        {
            // Configure the application for OAuth based flow
            _OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new CustomOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),

                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };
        }
        public static OAuthAuthorizationServerOptions OAuthOptions
        {
            get
            {
                return _OAuthOptions;
            }
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            //app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}
