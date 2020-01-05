using BookStore.Core.Contracts;
using BookStore.Core.Models;
using BookStore.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Book> context;
        IRepository<BookGenre> bookGenres;

        public HomeController(IRepository<Book> bookContext, IRepository<BookGenre> bookGenreContext)
        {
            context = bookContext;
            bookGenres = bookGenreContext;
        }

        public ActionResult Index(String Genre = null)
        {
            List<Book> books;
            List<BookGenre> genres = bookGenres.Collection().ToList();

            if (Genre == null)
            {
               books= context.Collection().ToList();
            }
            else
            {
                books = context.Collection().Where(p => p.Genre == Genre).ToList();
            }

            BookListViewModel model = new BookListViewModel();
            model.Books = books;
            model.BookGenres = genres;

            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Book book = context.Find(Id);
            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(book);
            }
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
    }
}