using System;
using System.Web.Http;
using Microsoft.Owin.Security;
using FilmsWebApi.Web.Models;

namespace FilmsWebApi.Web.Controllers
{
    public class AccountController : ApiController
    {
        public AccountController()
        {
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //  ToDo: register

            return Ok();
        }

        //TODO: AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),

    }
}
