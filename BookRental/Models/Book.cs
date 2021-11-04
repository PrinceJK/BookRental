using System;
using System.ComponentModel.DataAnnotations;

namespace BookRental.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}