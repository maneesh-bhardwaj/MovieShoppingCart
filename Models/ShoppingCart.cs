using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class ShoppingCart
    {
        private readonly MovieDBContext _movieDBContext;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext.Session;

            string ShoppingCartId = session.GetString("ShoppingCartId") ??
                                        Guid.NewGuid().ToString();

            session.SetString("ShoppingCartId", ShoppingCartId);
            var context = services.GetService<MovieDBContext>();
            return new ShoppingCart(context) { ShoppingCartId = ShoppingCartId };
        }
        public void AddItemsToCart(Movie movie, decimal amount)
        {
            var ShoppingCartItem = _movieDBContext.ShoppingCartItems.SingleOrDefault(
                i => i.Movie.MovieId == movie.MovieId
                &&
                i.ShoppingCartId == this.ShoppingCartId);
            if(ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = this.ShoppingCartId,
                    Movie = movie,
                    Price = amount
                };
                _movieDBContext.ShoppingCartItems.Add(ShoppingCartItem);
            }
            _movieDBContext.SaveChanges();
        }
        public void RemoveItemFromCart(Movie movie)
        {
            var ShoppingCartItem = _movieDBContext.ShoppingCartItems.SingleOrDefault(
               i => i.Movie.MovieId == movie.MovieId
               &&
               i.ShoppingCartId == this.ShoppingCartId);

            if (ShoppingCartItem != null)
            {
                _movieDBContext.ShoppingCartItems.Remove(ShoppingCartItem);
            }
            _movieDBContext.SaveChanges();
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return _movieDBContext.ShoppingCartItems.Where(i => i.ShoppingCartId == this.ShoppingCartId)
                .Include(m=>m.Movie)
                .ToList();
        }
        public decimal GetShoppingCartTotal()
        {
            return _movieDBContext.ShoppingCartItems.Where(i => i.ShoppingCartId == this.ShoppingCartId)
                .Select(p => p.Price).Sum();
        }

        public void ClearShoppingCart()
        {
            _movieDBContext.ShoppingCartItems.RemoveRange(
                _movieDBContext.ShoppingCartItems.Where(i => i.ShoppingCartId == this.ShoppingCartId)
                );
            _movieDBContext.SaveChanges();
        }
    }
}
