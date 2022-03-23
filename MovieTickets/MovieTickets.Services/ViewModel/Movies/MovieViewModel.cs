using MovieTickets.Data.Models;
using MovieTickets.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Services.ViewModel.Movies
{
    using static Data.DataConstants;
    public class MovieViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = DescriptionError)]

        public string Description { get; set; }


        [Required]
        public string Language { get; set; }

        public int Duration { get; set; }

        public Genre Genre { get; set; }

        public Resolution Resolution { get; set; }

        public double Price { get; set; }

        public int CinemaId { get; set; }

        [ForeignKey("CinemaId")]
        public virtual Cinema Cinema { get; set; }

        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public virtual Producer Producer { get; set; }

        public virtual IEnumerable<MovieActor> MovieActors { get; set; }
    }
}
