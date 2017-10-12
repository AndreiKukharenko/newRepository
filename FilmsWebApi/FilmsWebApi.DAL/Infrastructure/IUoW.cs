using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Models;


namespace FilmsWebApi.DAL.Infrastructure
{
    public interface IUoW
    {
        IGenericRepository<Film> FilmsRepository { get; }

        void SaveChanges();
    }
}
