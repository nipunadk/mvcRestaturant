using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenRestaturant.Models;

namespace GreenRestaturant.Controllers
{
    public class RestaturantReviewsController : Controller
    {
        private GreenRestaturantDb db = new GreenRestaturantDb();

        // GET: RestaturantReviews
        public async Task<ActionResult> Index()
        {
           IEnumerable<Restaturant> test = db.Restaturants.ToList();

            return View(await db.Reviews
                .OrderBy(r=> r.RestaturantId )  
                .ToListAsync());
        }

        // GET: RestaturantReviews/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RestaturantReview restaturantReview = await db.Reviews.FindAsync(id);
            if (restaturantReview == null)
            {
                return HttpNotFound();
            }
            return View(restaturantReview);
        }

        // GET: RestaturantReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaturantReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Rating,Body,RestaturantId")] RestaturantReview restaturantReview)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(restaturantReview);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(restaturantReview);
        }

        // GET: RestaturantReviews/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaturantReview restaturantReview = await db.Reviews.FindAsync(id);
            if (restaturantReview == null)
            {
                return HttpNotFound();
            }
            return View(restaturantReview);
        }

        // POST: RestaturantReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Rating,Body,RestaturantId")] RestaturantReview restaturantReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaturantReview).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(restaturantReview);
        }

        // GET: RestaturantReviews/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaturantReview restaturantReview = await db.Reviews.FindAsync(id);
            if (restaturantReview == null)
            {
                return HttpNotFound();
            }
            return View(restaturantReview);
        }

        // POST: RestaturantReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RestaturantReview restaturantReview = await db.Reviews.FindAsync(id);
            db.Reviews.Remove(restaturantReview);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
