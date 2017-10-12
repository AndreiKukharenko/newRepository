using FilmsWebApi.DAL.Context;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Models;
using FilmsWebApi.DAL.Repositories;

namespace FilmsWebApi.DAL.UnitOfwork
{
    public class UnitOfWork : IUoW
    {
        private AppContext _appContext; // how to use IoC here?
        private IBaseRepository<Film> _filmsRepo;

        public UnitOfWork(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IBaseRepository<Film> FilmsRepository
        {
            get
            {
                if (this._filmsRepo == null)
                {
                    this._filmsRepo = new BaseRepository<Film>(_appContext);
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
