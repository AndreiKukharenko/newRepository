
using FilmsWebApi.BLL.DTO;
using System.Collections.Generic;

namespace FilmsWebApi.BLL.Infrastructure
{
    public interface IAppService
    {
        IEnumerable<FilmDTO> GetAll();

        FilmDTO GetFilmById(int id);

        bool AddFilm(FilmDTO filmDTO);

        IEnumerable<FilmDTO> SearchFilmsByTitle(string searchString);
    }
}
