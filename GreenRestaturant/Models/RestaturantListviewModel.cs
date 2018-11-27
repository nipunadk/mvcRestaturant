using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenRestaturant.Models
{
    public class RestaturantListviewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //public string Review { get; set; }
        public int CountOfReviews { get; set; }
    }
}