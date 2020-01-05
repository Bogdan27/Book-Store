using BookStore.Core.Contracts;
using BookStore.Core.Models;
using BookStore.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web
{
    public class BookManagerController : Controller
    {

        IRepository<Book> context;
        IRepository<BookGenre> bookGenres;

        public BookManagerController(IRepository<Book> bookContext, IRepository<BookGenre> bookGenreContext)
        {
            context = bookContext;
            bookGenres = bookGenreContext;
        }
        // GET: BookManager
        public ActionResult Index()
        {
            List<Book> books = context.Collection().ToList();
            return View(books);
        }

        public ActionResult Create()
        {
            BookManagerViewModel viewModel = new BookManagerViewModel();

            viewModel.Book = new Book();
            viewModel.BookGenres = bookGenres.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            else
            {

                context.Insert(book);
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string Id)
        {
            Book book = context.Find(Id);
            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                BookManagerViewModel viewModel = new BookManagerViewModel();
                viewModel.Book = book;
                viewModel.BookGenres = bookGenres.Collection();

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Book book, string Id)
        {
            Book bookToEdit = context.Find(Id);

            if (bookToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(book);
                }


                bookToEdit.Genre = book.Genre;
                bookToEdit.Description = book.Description;
                bookToEdit.Name = book.Name;
                bookToEdit.Price = book.Price;
                bookToEdit.Image = book.Image;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Book bookToDelete = context.Find(Id);

            if (bookToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(bookToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Book bookToDelete = context.Find(Id);

            if (bookToDelete == null)
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