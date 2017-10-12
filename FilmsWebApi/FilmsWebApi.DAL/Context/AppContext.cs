using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsWebApi.DAL.Context
{
    public class AppContext : IdentityDbContext<AppUser>, IAppContext
    {
        public AppContext() : base ("FilmsWebApi") //connectionString
        {
        }

        public DbSet<Film> Films { get; set; }
        public static AppContext Create()
        {
            return new AppContext();
        }
    }
}
