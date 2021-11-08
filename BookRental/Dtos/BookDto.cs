using System;
using System.ComponentModel.DataAnnotations;

namespace BookRental.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Published Date")]
        public DateTime Publisheddate { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}