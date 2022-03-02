using MovieTickets.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Data.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string TrailerPath { get; set; }

        public string ImgdbLink { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Language { get; set; }

        public int Duration { get; set; }

        public Genre Genre { get; set; }

        public Resolution Resolution { get; set; }

        public Actor Actor { get; set; }

        public Producer Producer { get; set; }

    }
}
