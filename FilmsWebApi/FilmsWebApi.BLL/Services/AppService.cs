using System;
using System.Collections.Generic;
using System.Linq;
using FilmsWebApi.BLL.Infrastructure;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.BLL.DTO;
using FilmsWebApi.DAL.Models;

namespace FilmsWebApi.BLL.Services
{
    public class AppService : IAppService
    {
        private IUoW _unitOfWork;

        public AppService(IUoW UoW)
        {
            _unitOfWork = UoW;
        }

        public IEnumerable<FilmDTO> GetAll()
        {
            var films = _unitOfWork.FilmsRepository.GetAll();

            return films.Select(film => new FilmDTO
            {
                Id = film.Id,
                Title = film.Title,
                Description = film.Description,
            }).ToList();
        }

        public FilmDTO GetFilmById(int id)
        {
            var film = _unitOfWork.FilmsRepository.GetById(id);

            //if (film != null) is it possible?
            var filmDTO = new FilmDTO
            {
                Id = film.Id,
                Title = film.Title,
                Description = film.Description
            };
            return filmDTO;
        }

        public bool AddFilm(FilmDTO filmDTO)
        {
            try
            {
                var film = new Film
                {
                    Id = filmDTO.Id,
                    Title = filmDTO.Title,
                    Description = filmDTO.Description
                };
                _unitOfWork.FilmsRepository.Add(film);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
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
