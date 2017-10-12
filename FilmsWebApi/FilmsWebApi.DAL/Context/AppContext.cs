using System.Data.Entity;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FilmsWebApi.DAL.Context
{
    public class AppContext : IdentityDbContext<AppUser>
    {
        public AppContext() : base ("FilmsWebApi") //connectionString
        {
            Database.SetInitializer(new AppDataInitializer());
        }

        public DbSet<Film> Films { get; set; }

    }
}
