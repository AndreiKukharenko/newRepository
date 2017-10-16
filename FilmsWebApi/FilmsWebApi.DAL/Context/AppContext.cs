using System.Data.Entity;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FilmsWebApi.DAL.Context
{
    public class AppContext : IdentityDbContext<AppUser>
    {
        public AppContext() : base ("Films") //connectionString
        {
            Database.SetInitializer(new AppDataInitializer());
        }

        public DbSet<Film> Films { get; set; }

    }
}
