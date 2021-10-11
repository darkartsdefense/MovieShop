using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext):base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> Get30HighestGrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        //public override async Task<Movie> GetByIdAsync(int id)
        //{
        //    var moviedetails = await _dbContext.Movies.Include(m => m.Genres).ThenInclude(m => m.Genre)
        //        .Include(m => m.Trailers).FirstOrDefaultAsync(m => m.Id == id);
        //    if (moviedetails == null) throw new Exception($"NO Movie Found for this {id}");
        //    // get average rating
        //    //  var rating = await _dbContext.Reviews.where(r => r.MovieId == id).DefaultIfEmpty().AverageAsync( r => r==null? 0: r.Rating);
        //    // moviedetails.Rating = rating;

        //    return moviedetails;
        //}

        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.MovieGenres).ThenInclude(m => m.Genre).Include(m => m.Trailers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) throw new Exception($"NO Movie Found for this {id}");

            var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
                .AverageAsync(r => r == null ? 0 : r.Rating);
            if (movieRating > 0) movie.Rating = movieRating;

            return movie;
        }

    }
}