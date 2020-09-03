using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using MovieStore.ViewModels;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MovieController(IMovieRepository movieRepository, ICategoryRepository categoryRepository)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public ViewResult List()
        {
            //return View(_movieRepository.AllMovies);
            MovieListVM movieListVM = new MovieListVM()
            {
                Movies = _movieRepository.AllMovies,
                SelectedCategoryName = _categoryRepository.AllCategories.ToList()[0].Name
            };
            return View(movieListVM);
        }

        public IActionResult Details(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            return View(movie);
        }
    }
}
