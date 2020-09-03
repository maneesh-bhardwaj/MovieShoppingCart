using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> AllMovies { get; }
        IEnumerable<Movie> DiscountedMovies { get; }
        Movie GetMovieById(int movieId);
    }
}
