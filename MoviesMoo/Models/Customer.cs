using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace MoviesMoo.Models
{
    [MetadataType(typeof(MetaDateCusomers))]
    public partial class Customers
    {
    }
    
    public class MetaDateCusomers
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Is Subscribed")]
        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Member Ship Type")]
        public Nullable<int> MembershipID { get; set; }

        [Display(Name="Birth of date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [MinAge18YearsOld]
        public Nullable<System.DateTime> Birthdate { get; set; }

        public virtual MemberShipType MemberShipType { get; set; }
    }
}