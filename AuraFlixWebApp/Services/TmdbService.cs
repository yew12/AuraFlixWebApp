using System.Text.Json;
using AuraFlixWebApp.Models;

namespace AuraFlixWebApp.Services;

public sealed class TmdbService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<TmdbService> logger) : ITmdbService
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly IConfiguration _configuration = configuration;
    private readonly ILogger<TmdbService> _logger = logger;

    public async Task<Movie> GetMovieDetailsAsync(int movieId)
    {
        var client = _httpClientFactory.CreateClient("TmdbClient");
        var accessToken = _configuration["TmdbAccessToken"];

        var request = new HttpRequestMessage() {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://api.themoviedb.org/3/movie/{movieId}?language=en-US"),
            Headers = {
                { "accept", "application/json" },
                { "Authorization", $"Bearer {accessToken}" }
            }
        };

        try
        {
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode(); // throws if not success 200-299
            var movie = await response.Content.ReadFromJsonAsync<Movie>(
                new JsonSerializerOptions(JsonSerializerDefaults.Web)
            );

            return movie ?? throw new Exception("Failed to deserialize movie data.");
        }
       catch (HttpRequestException ex)
        {
            _logger.LogError("TMDB API request failed for movie {MovieId}: {Error}", movieId, ex.Message);
            throw; // Re-throw to let controller handle
        }
        catch (Exception ex)
        {
            _logger.LogError("Error fetching movie details for {MovieId}: {Error}", movieId, ex.Message);
            throw;
        }
    }

    public Task<TVShow> GetTVShowDetailsAsync(int tvshowId)
    {
        throw new NotImplementedException();
    }

    public async Task<TmdbResponse> GetTrendingMovies()
    {
        var client = _httpClientFactory.CreateClient("TmdbHttpClientName");
        var accessToken = _configuration["TmdbAccessToken"];

        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://api.themoviedb.org/3/trending/movie/day?language=en-US"),
            Headers = {
                { "accept", "application/json" },
                { "Authorization", $"Bearer {accessToken}" }
            }
        };
        
        try
        {
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<TmdbResponse>(json, new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return data ?? throw new Exception("Failed to deserialize movie list data.");
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError("TMDB API request failed for fetching popular movies: {Error}", ex.Message);
            throw; // Re-throw to let controller handle
        }
        catch(Exception ex)
        {
            _logger.LogError("Error fetching movie details for popular movies: {Error}", ex.Message);
            throw;
        }
    }

    public async Task<TmdbResponse> GetFeaturedMovies()
    {
        var client = _httpClientFactory.CreateClient("TmdbHttpClientName");
        var accessToken = _configuration["TmdbAccessToken"];

        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://api.themoviedb.org/3/movie/popular?language=en-US&page=1"),
            Headers = {
                { "accept", "application/json" },
                { "Authorization", $"Bearer {accessToken}" }
            }
        };

        try
        {
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<TmdbResponse>(json, new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return data ?? throw new Exception("Failed to deserialize movie list data.");
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError("TMDB API request failed for fetching popular movies: {Error}", ex.Message);
            throw; // Re-throw to let controller handle
        }
        catch(Exception ex)
        {
            _logger.LogError("Error fetching movie details for popular movies: {Error}", ex.Message);
            throw;
        }
    }
}