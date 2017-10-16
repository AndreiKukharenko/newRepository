using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using FilmsWebApi.Web.Providers;

namespace FilmsWebApi.Web
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new CustomOAuthProvider(),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            //app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}
