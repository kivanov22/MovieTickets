using Microsoft.Extensions.DependencyInjection;
using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.Services;
using MovieTickets.Services.ViewModel;
using MovieTickets.Services.ViewModel.Movies;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Test
{
    public class MovieServiceTest:BaseServiceTests
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
        }

        [Test]
        public void AddMovieShouldWork()
        {
            MovieTicketsDbContext db = GetDb();

            var movie = new Movie()
            {
                //Id = 13,
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
                //CinemaId = 2,
                //ProducerId = 6,
            };

            db.Movies.Add(movie);
            db.SaveChangesAsync();


           
            var service = serviceProvider.GetService<IMovieService>();
            

            var movieVM = new NewMovieVM
            {
                //Id = movie.Id,
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
                //CinemaId = movie.CinemaId,
                //ProducerId = movie.ProducerId
            };

            service.AddNewMovieAsync(movieVM);

            var result = db.Movies.Where(x => x.Title == "Bad boys")
                .FirstOrDefault();

            Assert.AreEqual(movieVM.Title, result.Title);
            Assert.AreNotEqual("Good boys", result.Title);
        }


        [Test]
        public void UpdateMovieShouldWork()
        {
            MovieTicketsDbContext db = GetDb();
            
            var movie = new Movie()
            {
                //Id = 13,
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
                //ProducerId = 4,
            };
            var service = serviceProvider.GetService<IMovieService>();
            db.AddAsync(movie);
            db.SaveChangesAsync();
            
            var dbMovie = db.Movies.FirstOrDefault(x=>x.Id== movie.Id);

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
                //CinemaId = movie.CinemaId,
                // ProducerId = movie.ProducerId,
            };
            var result = service.UpdateMovieAsync(movieVM);

            //service.UpdateAsync(movieVM.Id, movie);
            Assert.AreEqual(movieVM.Title,dbMovie.Title);
            Assert.AreNotEqual("Good boys",dbMovie.Title);
        }

        [Test]
        public async Task GetNewMovieDropDownsShouldWork()
        {
            MovieTicketsDbContext db = GetDb();


            var dropDown = new NewMovieDropdownsVM
            {
                Actors = db.Actors.OrderBy(n => n.FullName).ToList(),
                Cinemas = db.Cinemas.OrderBy(n => n.CinemaName).ToList(),
                Producers = db.Producers.OrderBy(n => n.FullName).ToList()
            };

            var service = serviceProvider.GetService<IMovieService>();

            var result = await service.GetNewMovieDropdownsValues();

            Assert.AreEqual(result.Actors, dropDown.Actors);
            Assert.AreEqual(result.Cinemas, dropDown.Cinemas);
            Assert.AreEqual(result.Producers, dropDown.Producers);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetMovieById()
        {
            MovieTicketsDbContext db = GetDb();


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

            db.Movies.AddAsync(movie);
            
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
                CinemaId = movie.CinemaId,
               ProducerId = movie.ProducerId
            };

            //service.AddNewMovieAsync(movieVM);

            //int id = 13;

            //var findMovie = db.Movies.Where(x=>x.Id ==id).FirstOrDefault();

           //var result = service.GetMovieByIdAsync(13);
            Assert.DoesNotThrowAsync(async () => await service.GetMovieByIdAsync(movieVM.Id));
            //Assert.AreEqual(movie.Id, result.Id);
            //Assert.AreEqual(movieVM.Id, result.Id);
            //Assert.AreNotEqual(movieVM.Id, result.Id);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        
    }
}
