using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class MockMovieRepository : IMovieRepository
    {
        private readonly ICategoryRepository _categoryRepository;
        public MockMovieRepository(ICategoryRepository repo)
        {
            _categoryRepository = repo;
        }
        public IEnumerable<Movie> AllMovies => new List<Movie> {
         new Movie{
                MovieId=1, Title="SKYSCRAPER", Description="After Will Sawyer, who assesses security for skyscrapers, is accused of a blaze in the safest building in the world, he must prove himself innocent and save his family from the burning building.",
                Price=56,IsDiscounted=false,ImageUrl="https://tinyurl.com/y62zpt6q",
                Category = _categoryRepository.AllCategories.ToList()[0]
            },
         new Movie{
                MovieId=1, Title="FREAKS-YOU'RE ONE OF US", Description="Tipped by a mysterious tramp, a meek fry cook discovers she has superpowers -- and uncovers an unsavory, vast conspiracy.",
                Price=56,IsDiscounted=false,ImageUrl="https://tinyurl.com/y6tyfznk",
                Category = _categoryRepository.AllCategories.ToList()[2]
            }
        };

        public IEnumerable<Movie> DiscountedMovies { get; }

        public Movie GetMovieById(int movieId)
        {
            return AllMovies.FirstOrDefault(m => m.MovieId == movieId);
        }
    }
}
