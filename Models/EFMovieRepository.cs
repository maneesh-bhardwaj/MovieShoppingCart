using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class EFMovieRepository: IMovieRepository
    {
        private readonly MovieDBContext _movieDBContext;
        public EFMovieRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public IEnumerable<Movie> AllMovies
        {
            get
            {
                return _movieDBContext.Movies.Include(c => c.Category);
            }
        }

        public IEnumerable<Movie> DiscountedMovies => throw new NotImplementedException();

        public Movie GetMovieById(int movieId)
        {
            return _movieDBContext.Movies.Include(c => c.Category).FirstOrDefault(m => m.MovieId == movieId);
        }
    }
}
