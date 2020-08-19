using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoviesMoo.Models;

namespace MoviesMoo.ViewModel
{
    public class VMCustomerMemberType
    {
        public IEnumerable<MemberShipType> MemberShipType { get; set; }
        public Customers Customers { get; set; }
    }
}