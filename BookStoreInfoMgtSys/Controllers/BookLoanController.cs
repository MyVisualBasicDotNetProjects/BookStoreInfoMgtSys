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
    public class BookLoanController : Controller
    {
        private BookStoreDBContext db = new BookStoreDBContext();

        //
        // GET: /BookLoan/

        public ActionResult Index()
        {
            return View(db.BookLoans.ToList());
        }

        //
        // GET: /BookLoan/Details/5

        public ActionResult Details(int id = 0)
        {
            BookLoan bookloan = db.BookLoans.Find(id);
            if (bookloan == null)
            {
                return HttpNotFound();
            }
            return View(bookloan);
        }

        //
        // GET: /BookLoan/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BookLoan/Create

        [HttpPost]
        public ActionResult Create(BookLoan bookloan)
        {
            if (ModelState.IsValid)
            {
                db.BookLoans.Add(bookloan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookloan);
        }

        //
        // GET: /BookLoan/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BookLoan bookloan = db.BookLoans.Find(id);
            if (bookloan == null)
            {
                return HttpNotFound();
            }
            return View(bookloan);
        }

        //
        // POST: /BookLoan/Edit/5

        [HttpPost]
        public ActionResult Edit(BookLoan bookloan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookloan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookloan);
        }

        //
        // GET: /BookLoan/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BookLoan bookloan = db.BookLoans.Find(id);
            if (bookloan == null)
            {
                return HttpNotFound();
            }
            return View(bookloan);
        }

        //
        // POST: /BookLoan/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BookLoan bookloan = db.BookLoans.Find(id);
            db.BookLoans.Remove(bookloan);
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