using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuraFlixWebApp.Models;
using AuraFlixWebApp.Services;
using System.Threading.Tasks;

namespace AuraFlixWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ITmdbService _tmdbService;

    public HomeController(ILogger<HomeController> logger, ITmdbService tmdbService)
    {
        _logger = logger;
        _tmdbService = tmdbService;
    }

    /// <summary>
    /// TODO get list of movies 
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        var response = await _tmdbService.GetFeaturedMovies();
        var trendingMovies = await _tmdbService.GetTrendingMovies();

        var model = new IndexViewModel()
        {
            PopularMovies = response.Results,
            TrendingMovies = trendingMovies.Results
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> MovieDetails(int id)
    {
        var movie = await _tmdbService.GetMovieDetailsAsync(id);

        return View(movie);
    }
}
