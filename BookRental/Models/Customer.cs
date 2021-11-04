using System;
using System.ComponentModel.DataAnnotations;

namespace BookRental.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSubScribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public string MembershipTypeId { get; set; }
    }
}