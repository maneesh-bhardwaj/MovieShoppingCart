using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly MovieDBContext _movieDBContext;
        public EFCategoryRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public IEnumerable<Category> AllCategories => _movieDBContext.Categories;
    }
}
