using System;
using System.Collections.Generic;
using System.Linq;
using FilmsWebApi.BLL.Infrastructure;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.BLL.DTO;

namespace FilmsWebApi.BLL.Services
{
    public class FilmService : IFilmService
    {
        private IUoW _unitOfWork;

        public FilmService(IUoW UoW)
        {
            _unitOfWork = UoW;
        }

        public IEnumerable<FilmDTO> GetAll()
        {
            var films = _unitOfWork.FilmsRepository.GetAll();

            return films.Select(film => FilmDTO.GetFilmDTO(film)).ToList();
        }

        public FilmDTO GetFilmById(int id)
        {
            var film = _unitOfWork.FilmsRepository.GetById(id);

            if (film != null)
            {
                return FilmDTO.GetFilmDTO(film);
            }
            else return null;
        }

        public void AddFilm(FilmDTO filmDTO)
        {
            var film = FilmDTO.GetDomainFilm(filmDTO);
            _unitOfWork.FilmsRepository.Add(film);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<FilmDTO> SearchFilmsByTitle(string searchString)
        {
            var films = GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                films = films.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            return films;
        }
    }
}
