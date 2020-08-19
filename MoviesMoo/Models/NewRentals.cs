using System.Collections.Generic;

namespace MoviesMoo.Models
{
    public class NewRentals
    {
        public int Custmerid { get; set; }

        public List<int> Movieids { get; set; }
    }
}