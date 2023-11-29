using V04_MoviesAPI.Data;

namespace V04_MoviesAPI.Services
{
    public class MoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }
        /*
        ➢ dohvaćanje svih filmova
        ➢ dohvaćanje jednog filma preko ID-a
        ➢ ažuriranje filma
        ➢ brisanje filma
        ➢ dodavanje filma
         */
        public void AddMovie(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Year = movie.Year,
                Genre = movie.Genre,
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }
        public Movie? GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public Movie? UpdateMovieById(int id, MovieVM movieVM)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movie.Name = movieVM.Name;
                movie.Year = movieVM.Year;
                movie.Genre = movieVM.Genre;
                _context.Movies.Update(movie);
                _context.SaveChanges();
            }
            return movie;
        }
        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x =>x.Id == id);
            if (movie != null) return;
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
