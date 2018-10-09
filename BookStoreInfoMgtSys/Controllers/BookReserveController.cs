using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreInfoMgtSys.Models;

namespace BookStoreInfoMgtSys.Controllers
{
    public class BookReserveController : Controller
    {
        private BookStoreDBContext db = new BookStoreDBContext();

        //
        // GET: /BookReserve/

        public ActionResult Index()
        {
            return View(db.BookReserves.ToList());
        }

        //
        // GET: /BookReserve/Details/5

        public ActionResult Details(int id = 0)
        {
            BookReserve bookreserve = db.BookReserves.Find(id);
            if (bookreserve == null)
            {
                return HttpNotFound();
            }
            return View(bookreserve);
        }

        //
        // GET: /BookReserve/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BookReserve/Create

        [HttpPost]
        public ActionResult Create(BookReserve bookreserve)
        {
            if (ModelState.IsValid)
            {
                db.BookReserves.Add(bookreserve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookreserve);
        }

        //
        // GET: /BookReserve/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BookReserve bookreserve = db.BookReserves.Find(id);
            if (bookreserve == null)
            {
                return HttpNotFound();
            }
            return View(bookreserve);
        }

        //
        // POST: /BookReserve/Edit/5

        [HttpPost]
        public ActionResult Edit(BookReserve bookreserve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookreserve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookreserve);
        }

        //
        // GET: /BookReserve/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BookReserve bookreserve = db.BookReserves.Find(id);
            if (bookreserve == null)
            {
                return HttpNotFound();
            }
            return View(bookreserve);
        }

        //
        // POST: /BookReserve/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BookReserve bookreserve = db.BookReserves.Find(id);
            db.BookReserves.Remove(bookreserve);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}