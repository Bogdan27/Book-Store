using BookStore.Core.Contracts;
using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Controllers
{
    public class BookGenreManagerController : Controller
    {
        // GET: BookGenreManager
        IRepository<BookGenre> context;

        public BookGenreManagerController(IRepository<BookGenre> context)
        {
            this.context = context;
        }
        // GET: BookManager
        public ActionResult Index()
        {
            List<BookGenre> bookGenres = context.Collection().ToList();
            return View(bookGenres);
        }

        public ActionResult Create()
        {
            BookGenre BookGenre = new BookGenre();
            return View(BookGenre);
        }

        [HttpPost]
        public ActionResult Create(BookGenre BookGenre)
        {
            if (!ModelState.IsValid)
            {
                return View(BookGenre);
            }
            else
            {
                context.Insert(BookGenre);
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string Id)
        {
            BookGenre BookGenre = context.Find(Id);
            if (BookGenre == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(BookGenre);
            }
        }

        [HttpPost]
        public ActionResult Edit(BookGenre book, string Id)
        {
            BookGenre BookGenreToEdit = context.Find(Id);

            if (BookGenreToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(book);
                }

                BookGenreToEdit.Genre = book.Genre;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            BookGenre BookGenreToDelete = context.Find(Id);

            if (BookGenreToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(BookGenreToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            BookGenre BookGenreToDelete = context.Find(Id);

            if (BookGenreToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}