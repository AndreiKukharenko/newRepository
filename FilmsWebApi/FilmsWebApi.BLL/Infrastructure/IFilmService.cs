
using FilmsWebApi.BLL.DTO;
using System.Collections.Generic;

namespace FilmsWebApi.BLL.Infrastructure
{
    public interface IFilmService
    {
        IEnumerable<FilmDTO> GetAll();

        FilmDTO GetFilmById(int id);

        void AddFilm(FilmDTO filmDTO);

        IEnumerable<FilmDTO> SearchFilmsByTitle(string searchString);
    }
}
