using BookRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRental.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get;set;}

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Published Date")]
        [Required]
        public DateTime? PublishedDate { set; get; }

        [Display(Name="Number in Stock")]
        [Range(1,20)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Book" : "New Book";
            }
        }

        public BookFormViewModel()
        {
            Id = 0;
        }

        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            PublishedDate = book.Publisheddate;
            NumberInStock = book.NumberInStock;
            GenreId = book.GenreId;
        }
    }
}
