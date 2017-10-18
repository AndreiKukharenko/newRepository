using FilmsWebApi.DAL.Context;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Models;
using FilmsWebApi.DAL.Repositories;

namespace FilmsWebApi.DAL.UnitOfwork
{
    public class UnitOfWork : IUoW
    {
        private readonly AppContext _appContext;
        private IGenericRepository<Film> _filmsRepo;

        public UnitOfWork(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IGenericRepository<Film> FilmsRepository
        {
            get
            {
                if (this._filmsRepo == null)
                {
                    this._filmsRepo = new GenericRepository<Film>(_appContext);
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
