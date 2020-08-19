using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MoviesMoo.Models
{
    [MetadataType(typeof(MetaDataRentals))]
    public partial class Rentals
    {
    }

    public  class MetaDataRentals
    {
        public int Id { get; set; }

        public System.DateTime DateRented { get; set; }

        public Nullable<System.DateTime> DateReturn { get; set; }

        [Required]
        public int Custmer_id { get; set; }

        [Required]
        public int Movie_id { get; set; }

        public Customers Customers { get; set; }
        public Movies Movies { get; set; }
    }
}