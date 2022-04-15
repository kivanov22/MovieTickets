using Microsoft.Extensions.DependencyInjection;
using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.Services;
using MovieTickets.Services.ViewModel.Cinemas;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MovieTickets.Test
{
    public class CinemaServiceTest:BaseServiceTests
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
                .AddSingleton<IEntityBaseRepository<Cinema>, EntityBaseRepository<Cinema>>()
                .AddSingleton<ICinemaService, CinemaService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IEntityBaseRepository<Cinema>>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void AddCinemaMustWork()
        {
            var cinema = new Cinema()
            {
                Id = 1,
                Logo = "/wwwroot/images/c12.jpg",
                CinemaName = "Cinemax",
                City = "Pernik",
                CinemaAddress = "ullica Mladen Stoqnov"
            };

            var service = serviceProvider.GetService<ICinemaService>();

            var cinemaVM = new CinemaViewModel
            {
                Id = cinema.Id,
                Logo = cinema.Logo,
                CinemaName = cinema.CinemaName,
                City = cinema.City,
                CinemaAddress = cinema.CinemaAddress
            };

            Assert.DoesNotThrowAsync(async () => await service.AddNewCinemaAsync(cinemaVM));
        }

        [Test]
        public void UpdateCinemaShouldWork()
        {
            var cinema = new Cinema()
            {
                Id = 1,
                Logo = "/wwwroot/images/c12.jpg",
                CinemaName = "Cinemax",
                City = "Pernik",
                CinemaAddress = "ullica Mladen Stoqnov"
            };

            var service = serviceProvider.GetService<ICinemaService>();

            var cinemaVM = new CinemaViewModel
            {
                Id = cinema.Id,
                Logo = cinema.Logo,
                CinemaName = cinema.CinemaName,
                City = cinema.City,
                CinemaAddress = cinema.CinemaAddress
            };

            Assert.DoesNotThrowAsync(async () => await service.UpdateCinemaAsync(cinemaVM));
        }

        [Test]
        public void GetCinemaById()
        {
            MovieTicketsDbContext db = GetDb();

            var cinema = new Cinema()
            {
                Id = 1,
                Logo = "/wwwroot/images/c12.jpg",
                CinemaName = "Cinemax",
                City = "Pernik",
                CinemaAddress = "ullica Mladen Stoqnov"
            };
            db.Cinemas.AddAsync(cinema);

            var service = serviceProvider.GetService<ICinemaService>();

            var cinemaVM = new CinemaViewModel
            {
                Id = cinema.Id,
                Logo = cinema.Logo,
                CinemaName = cinema.CinemaName,
                City = cinema.City,
                CinemaAddress = cinema.CinemaAddress
            };

            //var result = service.GetCinemaByIdAsync(1);
            //Assert.AreEqual(cinemaVM.Id, result.Id);
            Assert.DoesNotThrowAsync(async () => await service.GetCinemaByIdAsync(cinemaVM.Id));

        }


        [Test]
        public void DeleteCinemaShouldWork()
        {
            var cinema = new Cinema()
            {
                Id = 1,
                Logo = "/wwwroot/images/c12.jpg",
                CinemaName = "Cinemax",
                City = "Pernik",
                CinemaAddress = "ullica Mladen Stoqnov"
            };

            var service = serviceProvider.GetService<ICinemaService>();

            var cinemaVM = new CinemaViewModel
            {
                Id = cinema.Id,
                Logo = cinema.Logo,
                CinemaName = cinema.CinemaName,
                City = cinema.City,
                CinemaAddress = cinema.CinemaAddress
            };

            Assert.DoesNotThrowAsync(async () => await service.DeleteCinemaAsync(cinemaVM.Id));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IEntityBaseRepository<Cinema> repo)
        {
            var cinema = new Cinema()
            {
                Id = 1,
                Logo = "/wwwroot/images/c12.jpg",
                CinemaName = "Cinemax",
                City = "Pernik",
                CinemaAddress = "ullica Mladen Stoqnov"
            };


            await repo.AddAsync(cinema);
        }
    }
}
