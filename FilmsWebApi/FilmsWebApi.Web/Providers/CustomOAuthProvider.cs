using FilmsWebApi.Web.Validators;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace FilmsWebApi.Web.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {

        public CustomOAuthProvider()
        {
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
           
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var username = context.UserName;
            var password = context.Password; 

            // validation
            if (!CredentialsValidator.ValidateCredentials(username, password))
            {
                context.SetError("username or password is incorrect");
                return;
            }

            ClaimsIdentity identity = new ClaimsIdentity(); 

            // todo: set properties as second argument
            var ticket = new AuthenticationTicket(identity, null);
            context.Validated(ticket);

        }

        /// <summary>
        /// add properties (to the Dictionary) wich will be used for AuthenticationTicket
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static AuthenticationProperties AddAuthentificationProperties(string property)
        {
            throw new NotImplementedException();
            return new AuthenticationProperties();
        }

    }
}