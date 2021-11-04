using System;
using System.ComponentModel.DataAnnotations;

namespace BookRental.Models
{
    public class MembershipType
    {
        [Key]
        public Guid Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}