using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IMovieRepository movieRepository, ShoppingCart shoppingCart)
        {
            _movieRepository = movieRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            return View(_shoppingCart);
        }
        public RedirectToActionResult AddToShoppingCart(int movieId)
        {
            var selectedMovie = _movieRepository.GetMovieById(movieId);
            _shoppingCart.AddItemsToCart(selectedMovie, selectedMovie.Price);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int movieId)
        {
            var selectedMovie = _movieRepository.GetMovieById(movieId);
            _shoppingCart.RemoveItemFromCart(selectedMovie);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult ClearShoppingCart()
        {
            _shoppingCart.ClearShoppingCart();
            return RedirectToAction("Index");
        }
    }
}
