using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<IEnumerable<MovieCardResponseModel>> Get30HighestGrossingMovies()
        {
            
            var movies = await _movieRepository.Get30HighestGrossingMovies();
            var moviesCardResponseModel = new List<MovieCardResponseModel>();
            foreach(var movie in movies)
            {
                moviesCardResponseModel.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl });
            }
            return moviesCardResponseModel; 
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            var movieDetails = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Budget = movie.Budget,
                Overview = movie.Overview,
                Price = movie.Price,
                PosterUrl = movie.PosterUrl,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                Rating = movie.Rating,
                Tagline = movie.Tagline,
                Title = movie.Title,
                RunTime = movie.RunTime,
                BackdropUrl = movie.BackdropUrl,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                
            };

            foreach (var movieGenre in movie.MovieGenres)
            {
                movieDetails.Genres.Add(new GenreModel
                    {
                        Id=movieGenre.Genre.Id,
                        Name=movieGenre.Genre.Name
                    });
            }

            foreach (var movieCast in movie.MovieCasts)
            {
                movieDetails.Casts.Add(new CastResponseModel
                {
                        Id=movieCast.Cast.Id,
                        Name=movieCast.Cast.Name,
                        Gender=movieCast.Cast.Gender,
                        ProfilePath=movieCast.Cast.ProfilePath,
                        TmdbUrl=movieCast.Cast.TmdbUrl

                    });
            }

            foreach (var trailer in movie.Trailers)
            {
                movieDetails.Trailers.Add(new TrailerResponseModel
                {
                        Id=trailer.Id,
                        Name=trailer.Name,
                        TrailerUrl=trailer.TrailerUrl,
                        MovieId=trailer.MovieId
                    });
            }


            return movieDetails;

        }
    }
}
