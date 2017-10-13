
using FilmsWebApi.DAL.Models;

namespace FilmsWebApi.BLL.DTO
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Does fields mapping and returns Film instance
        /// </summary>
        /// <param name="filmDTO"> </param>
        /// <returns> Film instance </returns>
        public static Film GetDomainFilm(FilmDTO filmDTO)
        {
            return new Film
            {
                Id = filmDTO.Id,
                Title = filmDTO.Title,
                Description = filmDTO.Description
            };
        }

        /// <summary>
        /// Does fields mapping and returns FilmDTO instance
        /// </summary>
        /// <param name="film"></param>
        /// <returns> FilmDTO instance </returns>
        public static FilmDTO GetFilmDTO(Film film)
        {
            return new FilmDTO
            {
                Id = film.Id,
                Title = film.Title,
                Description = film.Description
            };
        }
    }
}
