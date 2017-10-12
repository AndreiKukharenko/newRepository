using System;
using System.Collections.Generic;
using System.Data.Entity;
using FilmsWebApi.DAL.Models;

namespace FilmsWebApi.DAL.Context
{
    public class AppDataInitializer: DropCreateDatabaseIfModelChanges<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            GetFilms().ForEach(e => context.Films.Add(e));
        }

        private static List<Film> GetFilms()
        {
            return new List<Film>
            {
                new Film
                {
                    Title = "first film",
                    Description = "description"
                },
                new Film
                {
                    Title = "second film",
                    Description = "another description"
                },
                new Film
                {
                    Title = "third film",
                    Description = "desc-n #3"
                }

            };
        }
    }
}
