using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using FilmsWebApi.Web.Models;

namespace FilmsWebApi.Web.Controllers
{
    //[Authorize]
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
