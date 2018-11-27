using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GreenRestaturant.Models
{
    public class GreenRestaturantDb : DbContext  
    {   
        public DbSet<Restaturant> Restaturants { get; set; }
        public DbSet<RestaturantReview> Reviews { get; set; }
    }
}