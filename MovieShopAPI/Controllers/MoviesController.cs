using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [Route("toprevenue")]
        [HttpGet]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.Get30HighestGrossingMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found");
            }
            return Ok(movies);
        }
    }
}
