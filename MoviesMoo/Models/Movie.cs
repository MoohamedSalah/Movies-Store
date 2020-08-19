using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MoviesMoo.Models
{
    [MetadataType(typeof(MeataDataMovies))]
    public partial class Movies
    {
    }

    public class MeataDataMovies
    {
        public int Id { get; set; }

        [Remote("IsUserNameAvailableMov", "Movies", ErrorMessage = "Movies Name already in use.")]
        [Required]
        [MaxLength(50)]
        [Display(Name ="Movies Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Genre")]
        public string Genre { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ReleasDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateAdd { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        [Range(1, 10, ErrorMessage = @"the max in stock 1-10 Movie(s)")]
        public Nullable<double> NumberInStock { get; set; }

        public Nullable<int> MemberAvalible { get; set; }
    }

}