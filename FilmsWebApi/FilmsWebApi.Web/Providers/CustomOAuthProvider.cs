using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using FilmsWebApi.Web.Validators;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace FilmsWebApi.Web.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public CustomOAuthProvider()
        {
        }

        // this and other methods must be overridden
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var username = context.UserName;
            var password = context.Password; 

            // validation
            if (!CredentialsValidator.ValidateCredentials(username, password))
            {
                context.SetError("username or password is incorrect");
                return Task.FromResult<object>(null);
            }
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, username));

            //ClaimsIdentity identity = new ClaimsIdentity(claims); //this code causes "Value cannot be null. 
            //Parameter name: value" error while token is generating
            // authentication type setting prevents this error
            ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);

            AuthenticationProperties authProperties = CreateAuthentificationProperties(username);
            var ticket = new AuthenticationTicket(identity, authProperties);
            context.Validated(ticket);
            // or: context.Validated(identity);

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// add properties (to the Dictionary) wich will be used for AuthenticationTicket
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static AuthenticationProperties CreateAuthentificationProperties(string userName)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}