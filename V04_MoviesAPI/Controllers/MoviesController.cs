using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using V04_MoviesAPI.Data;
using V04_MoviesAPI.Services;

namespace V04_MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesService _moviesService;
        public MoviesService MoviesService { get; set; }
        public MoviesController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            _moviesService.AddMovie(movie);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = _moviesService.GetAllMovies();
            return Ok(allMovies);
        }
        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie = _moviesService.GetMovieById(id);
            return Ok(movie);
        }
        [HttpPut("id")]
        public IActionResult UpdateMovie([FromQuery] int id, [FromBody] MovieVM movie)
        {
            var updatedMovie = _moviesService.UpdateMovieById(id, movie);
            return Ok(updatedMovie);
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie(int id)
        {
            _moviesService?.DeleteMovie(id);
            return Ok();
        }
    }
}
