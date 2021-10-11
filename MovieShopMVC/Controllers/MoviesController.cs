using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //public IActionResult Details(int id)
        //{
        //    return View();
        //}

        public async Task<IActionResult> Details(int id)
        {
            var movies = await _movieService.GetMovieDetails(id);
            return View(movies);
        }

        //public IActionResult GetTopRevenueMovies()
        //{
        //    var movies = _movieService.Get30HighestGrossingMovies();
        //    return View(movies);
        //}
    }
}