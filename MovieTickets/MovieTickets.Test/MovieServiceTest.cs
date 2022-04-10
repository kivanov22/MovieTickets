using Microsoft.Extensions.DependencyInjection;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.Services;
using MovieTickets.Services.ViewModel;
using MovieTickets.Services.ViewModel.Movies;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MovieTickets.Test
{
    public class MovieServiceTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IEntityBaseRepository<Movie>, EntityBaseRepository<Movie>>()
                .AddSingleton<IMovieService, MovieService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IEntityBaseRepository<Movie>>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void AddMovieShouldWork()
        {
            var movie = new Movie()
            {
                Id = 1,
                Title = "Bad boys",
                Description = "Baddest boys on the planet",
                Language = "English",
                Duration = 180,
                Price = 40,
                ImageUrl = "/images/c12.jpg",
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10),
                Genre = Data.Models.Enums.Genre.Action,
                Resolution = Data.Models.Enums.Resolution.ThreeD,
                CinemaId = 3,
                ProducerId = 4
            };

            var movieActor = new MovieActor
            {
                MovieId = movie.Id,
                ActorId = 9,
            };

            var service = serviceProvider.GetService<IMovieService>();

            var movieVM = new NewMovieVM
            {
                Id = 1,
                Title = movie.Title,
                Description = movie.Description,
                Language = movie.Language,
                Duration = movie.Duration,
                Price = movie.Price,
                ImageUrl = movie.ImageUrl,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                Genre = Data.Models.Enums.Genre.Action,
                Resolution = Data.Models.Enums.Resolution.ThreeD,
                CinemaId = movie.CinemaId,
                ProducerId = movie.ProducerId
            };

            //var movieVM2 = new NewMovieVM
            //{
            //    Title = movie.Title,
            //    Description = movie.Description,
            //    Language = movie.Language,
            //    Duration = movie.Duration,
            //    Price = movie.Price,
            //    ImageUrl = movie.ImageUrl,
            //    StartDate = movie.StartDate,
            //    EndDate = movie.EndDate,
            //    Genre = Data.Models.Enums.Genre.Action,
            //    Resolution = Data.Models.Enums.Resolution.ThreeD,
            //    CinemaId = movie.CinemaId,
            //    ProducerId = movie.ProducerId
            //};
            //service.AddNewMovieAsync(movieVM);
            //Assert.AreEqual(movieVM, movie);
            Assert.DoesNotThrowAsync(async () => await service.AddNewMovieAsync(movieVM));
        }


        [Test]
        public void UpdateMovieShouldWork()
        {
            var movie = new Movie()
            {
                Id = 1,
                Title = "Bad boys",
                Description = "Baddest boys on the planet",
                Language = "English",
                Duration = 180,
                Price = 40,
                ImageUrl = "/images/c12.jpg",
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10),
                Genre = Data.Models.Enums.Genre.Action,
                Resolution = Data.Models.Enums.Resolution.ThreeD,
                CinemaId = 3,
                ProducerId = 3
            };

            var service = serviceProvider.GetService<IMovieService>();

            var movieVM = new NewMovieVM
            {
                Id = 1,
                Title = movie.Title,
                Description = movie.Description,
                Language = movie.Language,
                Duration = movie.Duration,
                Price = movie.Price,
                ImageUrl = movie.ImageUrl,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                Genre = Data.Models.Enums.Genre.Action,
                Resolution = Data.Models.Enums.Resolution.ThreeD,
                CinemaId = movie.CinemaId,
                ProducerId = movie.ProducerId
            };

            Assert.DoesNotThrowAsync(async () => await service.UpdateMovieAsync(movieVM));
        }


        [Test]
        public void GetMovieById()
        {
            var movie = new Movie()
            {
                Id = 1,
                Title = "Bad boys",
                Description = "Baddest boys on the planet",
                Language = "English",
                Duration = 180,
                Price = 40,
                ImageUrl = "/images/c12.jpg",
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10),
                Genre = Data.Models.Enums.Genre.Action,
                Resolution = Data.Models.Enums.Resolution.ThreeD,
                //CinemaId = 3,
                //ProducerId = 3
            };

            var service = serviceProvider.GetService<IMovieService>();

            var movieVM = new NewMovieVM
            {
                Id =movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Language = movie.Language,
                Duration = movie.Duration,
                Price = movie.Price,
                ImageUrl = movie.ImageUrl,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                Genre = Data.Models.Enums.Genre.Action,
                Resolution = Data.Models.Enums.Resolution.ThreeD,
               // CinemaId = movie.CinemaId,
               // ProducerId = movie.ProducerId
            };

            var result = service.GetMovieByIdAsync(1);
            Assert.AreEqual(movieVM.Id, result.Id);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IEntityBaseRepository<Movie> repo)
        {
            var movie = new Movie()
            {
                Id = 1,
                Title = "Bad boys",
                Description = "Baddest boys on the planet",
                Language = "English",
                Duration = 180,
                Price = 40,
                ImageUrl = "/images/c12.jpg",
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(10),
                Genre = Data.Models.Enums.Genre.Action,
                Resolution = Data.Models.Enums.Resolution.ThreeD,
                CinemaId = 1,
                ProducerId = 1
            };

            await repo.AddAsync(movie);
        }
    }
}
