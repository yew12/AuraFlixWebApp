namespace AuraFlixWebApp.Models;

/// <summary>
/// Wrapper class for getting response from tmdb api
/// </summary>
public class TmdbResponse
{
    public int Page { get; set; }
    public List<Movie> Results { get; set; } = new List<Movie>();
    public int Total_Pages { get; set; }
    public int Total_Results { get; set; }
}