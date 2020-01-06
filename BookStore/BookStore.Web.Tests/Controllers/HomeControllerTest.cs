using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.Web;
using BookStore.Web.Controllers;
using BookStore.Core.Contracts;
using BookStore.Core.Models;
using BookStore.Core.ViewModels;

namespace BookStore.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexPageDoesReturnBooks()
        {
            IRepository<Book> bookContext = new Mocks.MockContext<Book>();
            IRepository<BookGenre> bookGenreContext = new Mocks.MockContext<BookGenre>();

            bookContext.Insert(new Book());

            HomeController controller = new HomeController(bookContext, bookGenreContext);

            var result = controller.Index() as ViewResult;
            var viewModel = (BookListViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Books.Count());
        }


    }
}
