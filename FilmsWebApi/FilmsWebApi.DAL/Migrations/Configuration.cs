using FilmsWebApi.DAL.Models;
using System.Data.Entity.Migrations;

namespace FilmsWebApi.DAL.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<FilmsWebApi.DAL.Context.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FilmsWebApi.DAL.Context.AppContext context)
        {
            context.Films.AddOrUpdate(
                new Film
                {
                    Id = 1,
                    Title = "first film",
                    Description = "description"
                },
                new Film
                {
                    Id = 2,
                    Title = "second film",
                    Description = "another description"
                },
                new Film
                {
                    Id = 3,
                    Title = "third film",
                    Description = "desc-n #3"
                }
            );
        }
    }
}
