

using System.Text.Json.Serialization;

namespace AuraFlixWebApp.Models
{
    public class Movie
    {
        /// <summary>
        /// TMDB: movie_id
        /// </summary>
        [JsonPropertyName("movie_id")]
        public int MovieId { get; set; }
        public string? Title { get; set; }
          /// <summary>
        /// TMDB: tagline - shorter than description
        /// </summary>
        [JsonPropertyName("tagline")]
        public string? Tagline { get; set; }
        /// <summary>
        /// TMDB: overview
        /// </summary>
        [JsonPropertyName("overview")]
        public string? Description { get; set; }
        /// <summary>
        /// Movie Poster
        /// TMDB: poster_path
        /// </summary>
        [JsonPropertyName("poster_path")]
        public string? MoviePoster { get; set; }
        public string PosterUrl => $"https://image.tmdb.org/t/p/w200{MoviePoster}"; // Computed property
        /// <summary>
        /// TMDB: release_date
        /// </summary>
        [JsonPropertyName("release_date")]
        public string? ReleaseDate { get; set; }
        /// <summary>
        /// TMDB: popularity
        /// </summary>
        [JsonPropertyName("popularity")]
        public double Rating { get; set; }
        /// <summary>
        /// TMDB: vote_count
        /// </summary>
        [JsonPropertyName("vote_count")]
        public int TotalRatings { get; set; }
    }
}