using MovieTickets.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        public string MovieName { get; set; }

        public Resolution Resolution { get; set; }

        public decimal Price { get; set; }

        public TicketType TicketType { get; set; }

        public int Quantity { get; set; }

        public int Row { get; set; }

        [Required]
        public int Seat { get; set; }

        public int Hall { get; set; }
    }
}