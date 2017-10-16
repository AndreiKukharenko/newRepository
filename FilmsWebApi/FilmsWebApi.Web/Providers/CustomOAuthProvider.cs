using FilmsWebApi.Web.Validators;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace FilmsWebApi.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {

        public CustomOAuthProvider(string publicClientId)
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
            if (CredentialsValidator.ValidateCredentials(username, password))
            {
                ClaimsIdentity identity = new ClaimsIdentity(); 
                var ticket = new AuthenticationTicket(identity, null);
                context.Validated(ticket);
            }


        }


    }
}