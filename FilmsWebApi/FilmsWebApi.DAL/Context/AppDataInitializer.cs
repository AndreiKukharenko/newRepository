﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using FilmsWebApi.DAL.Models;

namespace FilmsWebApi.DAL.Context
{

    // TODO: delete 
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

            };
        }
    }
}
