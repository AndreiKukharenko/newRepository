using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using FilmsWebApi.DAL.Context;
using FilmsWebApi.DAL.Models;
using FilmsWebApi.BLL.Infrastructure;
using FilmsWebApi.BLL.DTO;

namespace FilmsWebApi.Web.Controllers
{
    [Authorize]
    public class FilmsController : ApiController
    {
        private IFilmService _filmService;

        public FilmsController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        
        // GET: api/Films
        public IEnumerable<FilmDTO> GetFilms()
        {
            return _filmService.GetAll();
        }

        // GET: api/Films/5
        [ResponseType(typeof(FilmDTO))]
        public IHttpActionResult GetFilm(int id)
        {
            FilmDTO film = _filmService.GetFilmById(id);
            if (film == null)
            {
                return NotFound();
            }

            return Ok(film);
        }

        // POST: api/Films
        [ResponseType(typeof(FilmDTO))]
        public IHttpActionResult PostFilm(FilmDTO film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _filmService.AddFilm(film);

            return CreatedAtRoute("DefaultApi", new { id = film.Id }, film);
        }

    }
}
