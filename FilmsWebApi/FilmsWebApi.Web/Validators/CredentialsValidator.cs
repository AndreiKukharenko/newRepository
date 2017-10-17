using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmsWebApi.Web.Validators
{
    public static class CredentialsValidator
    {
        public static bool ValidateCredentials(string username, string password)
        {
            if (username == "admin" && password == "admin1")
            {
                return true;

            }
            else
            {
                return false;
            }

        }
    }
}