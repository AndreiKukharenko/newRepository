using FilmsWebApi.DAL.Context;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsWebApi.DAL.UnitOfwork
{
    public class UnitOfWork : IUoW
    {
        private AppContext _appContext; // how to use IoC here?
        private IFilmsRepository _filmsRepo;

        public UnitOfWork(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IFilmsRepository FilmsRepository
        {
            get
            {
                if (this._filmsRepo == null)
                {
                    this._filmsRepo = new FilmsRepository(_appContext);
                }
                return _filmsRepo;
            }
        }
        public void SaveChanges()
        {
            _appContext.SaveChanges();
        }
    }
}
