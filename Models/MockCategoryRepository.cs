using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class MockCategoryRepository: ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => new List<Category> {
            new Category
            {
                CategoryId = 101,
                Name = "Action/Thriller",
                Description = "Movies with lots of suspense and action!"
            },
            new Category
            {
                CategoryId = 102,
                Name = "Comedy Films",
                Description = "Let's Lauhgh!"
            },
            new Category
            {
                CategoryId = 103,
                Name = "Science Fiction Films",
                Description = "Ready to see the potential of technology!"
            }
        };
    }
}
