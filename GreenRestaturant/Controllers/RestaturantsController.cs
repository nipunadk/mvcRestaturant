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
    public class RestaturantsController : Controller
    {
        private GreenRestaturantDb db = new GreenRestaturantDb();

        // GET: Restaturants
        public async Task<ActionResult> Index()
        {
            return View(await db.Restaturants.ToListAsync());
        }

        // GET: Restaturants/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
               // return View("NotFound");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaturant restaturant = await db.Restaturants.FindAsync(id);

            if (restaturant == null)
            {
                return HttpNotFound();
            }
            return View(restaturant);
        }

        // GET: Restaturants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaturants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,City,Country")] Restaturant restaturant)
        {
            if (ModelState.IsValid)
            {
                db.Restaturants.Add(restaturant);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(restaturant);
        }

        // GET: Restaturants/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaturant restaturant = await db.Restaturants.FindAsync(id);
            if (restaturant == null)
            {
                return HttpNotFound();
            }
            return View(restaturant);
        }

        // POST: Restaturants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,City,Country")] Restaturant restaturant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaturant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(restaturant);
        }

        // GET: Restaturants/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaturant restaturant = await db.Restaturants.FindAsync(id);
            if (restaturant == null)
            {
                return HttpNotFound();
            }
            return View(restaturant);
        }

        // POST: Restaturants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Restaturant restaturant = await db.Restaturants.FindAsync(id);
            db.Restaturants.Remove(restaturant);
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
