using FilmsWebApi.DAL.Context;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace FilmsWebApi.DAL.Repositories
{
    public class FilmsRepository : BaseRepository<Film>, IFilmsRepository
    {
        public FilmsRepository(AppContext context) : base(context)
        {

        }
    }
}
