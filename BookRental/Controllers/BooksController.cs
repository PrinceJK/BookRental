using BookRental.Models;
using BookRental.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookRental.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books/Random
        public ActionResult Random()
        {
            var book = new Book()
            {
                Name = "The Lords!"
            };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 1"}
            };

            var viewModel = new RandomBookViewModel
            {
                Book = book,
                Customers = customers
            };
            return View(viewModel);
        }

        //public ActionResult Edit(string bookId)
        //{
        //    return Content("Id=" + bookId);
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex,sortBy));

        //}

        //[Route("books/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}