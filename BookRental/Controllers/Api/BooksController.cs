using AutoMapper;
using BookRental.Dtos;
using BookRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookRental.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<BookDto> GetBooks()
        {
            return _context.Books.ToList().Select(Mapper.Map<Book, BookDto>);
        }

        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            if (book is null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Book, BookDto>(book));
        }

        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var book = Mapper.Map<BookDto, Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();

            bookDto.Id = book.Id;
            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var bookinDb = _context.Books.SingleOrDefault(c => c.Id == id);
            if (bookinDb == null)
            {
                return NotFound();
            }
            _context.Books.Remove(bookinDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
            {
                return NotFound();
            }
            _context.Books.Remove(bookInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
