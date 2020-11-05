using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoGreen.Models;

namespace GoGreen.Views
{
    public class PickupPoint_Controller : Controller
    {
        private GoGreenDatabaseEntities2 db = new GoGreenDatabaseEntities2();

        // GET: PickupPoint_
        public async Task<ActionResult> Index()
        {
            return View(await db.PickupPoint_.ToListAsync());
        }

        // GET: PickupPoint_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupPoint_ pickupPoint_ = await db.PickupPoint_.FindAsync(id);
            if (pickupPoint_ == null)
            {
                return HttpNotFound();
            }
            return View(pickupPoint_);
        }

        // GET: PickupPoint_/Create
        public ActionResult Create()
        {
            ViewBag.PkPoint_ID = new SelectList(db.PickupPoint_, "PkPoint_ID", "PkPoint_Name");
            ViewBag.PkPoint_ID = new SelectList(db.PickupPoint_, "PkPoint_ID", "PkPoint_Address");

            return View();
        }

        // POST: PickupPoint_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PkPoint_ID,PkPoint_Name,PkPoint_Address")] PickupPoint_ pickupPoint_)
        {
            if (ModelState.IsValid)
            {
                db.PickupPoint_.Add(pickupPoint_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pickupPoint_);
        }

        // GET: PickupPoint_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupPoint_ pickupPoint_ = await db.PickupPoint_.FindAsync(id);
            if (pickupPoint_ == null)
            {
                return HttpNotFound();
            }
            return View(pickupPoint_);
        }

        // POST: PickupPoint_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PkPoint_ID,PkPoint_Name,PkPoint_Address")] PickupPoint_ pickupPoint_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickupPoint_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pickupPoint_);
        }

        // GET: PickupPoint_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupPoint_ pickupPoint_ = await db.PickupPoint_.FindAsync(id);
            if (pickupPoint_ == null)
            {
                return HttpNotFound();
            }
            return View(pickupPoint_);
        }

        // POST: PickupPoint_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PickupPoint_ pickupPoint_ = await db.PickupPoint_.FindAsync(id);
            db.PickupPoint_.Remove(pickupPoint_);
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
