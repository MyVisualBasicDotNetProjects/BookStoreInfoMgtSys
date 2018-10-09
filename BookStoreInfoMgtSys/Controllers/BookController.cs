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
    public class BookController : Controller
    {
        private BookStoreDBContext db = new BookStoreDBContext();

        //
        // GET: /Book/

        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        //
        // GET: /Book/Details/5

        public ActionResult Details(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Book/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //
        // GET: /Book/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // Displaying a Search Form
        // Users can search for movies by Genre
        public ActionResult SearchIndex(string BookTitle, string BookAuthor, string BookCategory, string BookISBN, string searchString)
        {
            // Declaring Lists that will be used as criterias
            var lstBookCategory = new List<string>();       // 1st Filtering Criteria
            var lstBookAuthor = new List<string>();         // 2nd Filtering Criteria

            // 1st Filtering Criteria

            // Writing the LINQ query to select and fill the List Box for
            var queryBookCategory = from d in db.Books
                                 orderby d.BookCategory
                                 select d.BookCategory;
            // Filling the ListBox with unique items from the table
            lstBookCategory.AddRange(queryBookCategory.Distinct());
            // Store the value in a variable so it can be Viewed
            ViewBag.BookCategory = new SelectList(lstBookCategory);

            //// 2nd Filtering Criteria

            //// Writing the LINQ query to select and fill the List Box for
            //var queryBookAuthor = from d in db.Books
            //                      orderby d.AuthorName
            //                      select d.AuthorName;
            //// Filling the ListBox with unique items from the table
            //lstBookAuthor.AddRange(queryBookAuthor.Distinct());
            //// Store the value in a variable so it can be Viewed
            //ViewBag.BookAuthor = new SelectList(lstBookAuthor);

            // Searching for the item
            var books = from b in db.Books
                        select b;

            // Main Search item would be written here
            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString));
            }

            if (string.IsNullOrEmpty(BookCategory))
            {
                return View(books);
            }
            else
            {
                // The criteria is written here
                if (!string.IsNullOrEmpty(BookAuthor))
                {
                    return View(books.Where(x => x.BookCategory == BookCategory && x.AuthorName == BookAuthor));
                }
                else
                {
                    return View(books.Where(x => x.BookCategory == BookCategory));
                }


            }

        }

    }
}