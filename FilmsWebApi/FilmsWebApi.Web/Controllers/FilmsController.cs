using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FilmsWebApi.DAL.Context;
using FilmsWebApi.DAL.Models;
using FilmsWebApi.BLL.Infrastructure;
using FilmsWebApi.BLL.DTO;

namespace FilmsWebApi.Web.Controllers
{
    //[Authorize]
    public class FilmsController : ApiController
    {
        private AppContext db = new AppContext();

        private IFilmService _filmService;

        public FilmsController()
        {
                
        }
        
        // GET: api/Films
        public IEnumerable<Film> GetFilms()
        {
            return db.Films.ToList();
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
