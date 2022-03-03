using MovieTickets.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Data.Models
{
    using static Data.DataConstants;
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage =DescriptionError)]
        
        public string Description { get; set; }

        public StatusMovie StatusMovie { get; set; }

        [Required]
        public string Language { get; set; }

        public int Duration { get; set; }

        public Genre Genre { get; set; }

        public Resolution Resolution { get; set; }

        public decimal Price { get; set; }

        public int CinemaId { get; set; }

        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public virtual Producer Producer { get; set; }

        public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

    }
}
