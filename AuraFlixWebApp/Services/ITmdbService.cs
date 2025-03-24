using AuraFlixWebApp.Models;

namespace AuraFlixWebApp.Services;

public interface ITmdbService
{
    public Task<Movie> GetMovieDetailsAsync(int movieId);
    public Task<TVShow> GetTVShowDetailsAsync(int tvshowId);
    public Task<TmdbResponse> GetFeaturedMovies();
    public Task<TmdbResponse> GetTrendingMovies();

}