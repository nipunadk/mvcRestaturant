using GreenRestaturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenRestaturant.Controllers
{
    public class HomeController : Controller
    {
        GreenRestaturantDb _db = new GreenRestaturantDb();


        public ActionResult Index( string searchTerm = null)
        {

            var model = _db.Restaturants
                           .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                           .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                           .Take(10)
                           .Select( r=> new RestaturantListviewModel
                           {
                               Id = r.Id,
                               Name = r.Name,
                               City = r.City,
                               Country = r.Country,
                               CountOfReviews = r.Reviews.Count()
                           });

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing); 
        }

    }
}