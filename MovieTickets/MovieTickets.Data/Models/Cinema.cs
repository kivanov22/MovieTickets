using MovieTickets.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.Models
{
    public class Cinema
    {
        [Key]
        public int CinemaId { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        public string CinemaName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string CinemaAddress { get; set; }
       
        public DateTime Schedule { get; set; }//Movies ?

        public StatusMovie StatusMovie { get; set; }//Movies ?

        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
