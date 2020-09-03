using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal  Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDiscounted { get; set; }
        public Category Category { get; set; }

    }
}
