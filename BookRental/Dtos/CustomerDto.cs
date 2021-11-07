using BookRental.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookRental.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubScribedToNewsLetter { get; set; }
        
        public byte MembershipTypeId { get; set; }
        
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}