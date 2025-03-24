namespace AuraFlixWebApp.Models;

public class TVShow
{
    /// <summary>
    /// TMDB: series_id
    /// </summary>
    public int SeriesId { get; set; }
    public string? Title { get; set; }
    /// <summary>
    /// TMDB: number_of_seasons
    /// </summary>
    public int Seasons { get; set; }
    /// <summary>
    /// TMDB: number_of_episodes
    /// </summary>
    public int Episodes { get; set; }

    /// <summary>
    /// TMDB: tagline - shorter than description
    /// </summary>
    public string? Tagline { get; set; }
    /// <summary>
    /// TMDB: overview
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// TV Poster
    /// TMDB: poster_path
    /// </summary>
    public string? TVPoster { get; set; }
    /// <summary>
    /// TMDB: release_date
    /// </summary>
    public string? ReleaseDate { get; set; }
    /// <summary>
    /// TMDB: popularity
    /// </summary>
    public double Rating { get; set; }
    /// <summary>
    /// TMDB: vote_count
    /// </summary>
    public int TotalRatings { get; set; }
}