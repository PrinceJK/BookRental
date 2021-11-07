using BookRental.Models;
using BookRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BookRental.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var books = _context.Books.Include(m => m.Genre).ToList();
            return View(books);
        }
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new BookFormViewModel
            {
                
                Genres = genres
            };

            return View("BookForm", viewModel);
        }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel(book)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("BookForm", viewModel);
            }

            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Single(x => x.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.Publisheddate = book.Publisheddate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Books");


        }

        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BookFormViewModel(book)
            {
                Genres = _context.Genres.ToList()
            };
            return View("BookForm", viewModel);
        }

        public ActionResult Details(int id)
        {
           var book = _context.Books.Include(b => b.Genre).SingleOrDefault(x => x.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

    }


}
