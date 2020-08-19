using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MoviesMoo.Models
{
    [MetadataType(typeof(MetaDataMemberShipType))]
    public partial class MemberShipType
    {

    }

    public class MetaDataMemberShipType
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Member Type")]
        public string Name { get; set; }
        public Nullable<int> SignUPFree { get; set; }
        public Nullable<int> DurationInMenths { get; set; }
        public Nullable<int> DiscountRate { get; set; }

    }

}