using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieStore.Models;

namespace MovieStore.ViewModels
{
    public class MovieListVM
    {
        public IEnumerable<Movie> Movies { get; set; }
        public string SelectedCategoryName { get; set; }
    }
}
