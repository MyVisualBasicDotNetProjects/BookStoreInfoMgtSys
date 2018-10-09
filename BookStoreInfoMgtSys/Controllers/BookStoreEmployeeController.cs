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
    public class BookStoreEmployeeController : Controller
    {
        private BookStoreDBContext db = new BookStoreDBContext();

        //
        // GET: /BookStoreEmployee/

        public ActionResult Index()
        {
            return View(db.BookStoreEmployees.ToList());
        }

        //
        // GET: /BookStoreEmployee/Details/5

        public ActionResult Details(int id = 0)
        {
            BookStoreEmployee bookstoreemployee = db.BookStoreEmployees.Find(id);
            if (bookstoreemployee == null)
            {
                return HttpNotFound();
            }
            return View(bookstoreemployee);
        }

        //
        // GET: /BookStoreEmployee/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BookStoreEmployee/Create

        [HttpPost]
        public ActionResult Create(BookStoreEmployee bookstoreemployee)
        {
            if (ModelState.IsValid)
            {
                db.BookStoreEmployees.Add(bookstoreemployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookstoreemployee);
        }

        //
        // GET: /BookStoreEmployee/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BookStoreEmployee bookstoreemployee = db.BookStoreEmployees.Find(id);
            if (bookstoreemployee == null)
            {
                return HttpNotFound();
            }
            return View(bookstoreemployee);
        }

        //
        // POST: /BookStoreEmployee/Edit/5

        [HttpPost]
        public ActionResult Edit(BookStoreEmployee bookstoreemployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookstoreemployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookstoreemployee);
        }

        //
        // GET: /BookStoreEmployee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BookStoreEmployee bookstoreemployee = db.BookStoreEmployees.Find(id);
            if (bookstoreemployee == null)
            {
                return HttpNotFound();
            }
            return View(bookstoreemployee);
        }

        //
        // POST: /BookStoreEmployee/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BookStoreEmployee bookstoreemployee = db.BookStoreEmployees.Find(id);
            db.BookStoreEmployees.Remove(bookstoreemployee);
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