namespace AuraFlixWebApp.Models;

public class IndexViewModel
{

    public List<Movie> PopularMovies { get; set; } = new List<Movie>(); // initialize so they're never null
    public List<Movie> TrendingMovies { get; set; } = new List<Movie>();
    public List<TVShow> TVShows { get; set; } = new List<TVShow>();
}