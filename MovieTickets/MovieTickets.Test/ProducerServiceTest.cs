using Microsoft.Extensions.DependencyInjection;
using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.Services;
using MovieTickets.Services.ViewModel.Producers;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MovieTickets.Test
{
    public class ProducerServiceTest:BaseServiceTests
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
                .AddSingleton<IEntityBaseRepository<Producer>, EntityBaseRepository<Producer>>()
                .AddSingleton<IProducerService, ProducerService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IEntityBaseRepository<Producer>>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void AddProducerMustWork()
        {
            var producer = new Producer()
            {
                Id = 1,
                ProfilePicture = "/wwwroot/images/c12.jpg",
                FullName = "Pesho Jolie",
                Age = 42,
                Biography = "Very good producer !"
            };

            var service = serviceProvider.GetService<IProducerService>();

            var producerVM = new ProducerViewModel
            {
                Id = producer.Id,
                ProfilePicture = producer.ProfilePicture,
                FullName = producer.FullName,
                Age = producer.Age,
                Biography = producer.Biography
            };

            Assert.DoesNotThrowAsync(async () => await service.AddNewProducerAsync(producerVM));
        }

        [Test]
        public void UpdateProducerShouldWork()
        {
            var producer = new Producer()
            {
                Id = 1,
                ProfilePicture = "/wwwroot/images/c12.jpg",
                FullName = "Angelina Jolie",
                Age = 42,
                Biography = "Very good producer !"
            };

            var service = serviceProvider.GetService<IProducerService>();

            var producerVM = new ProducerViewModel
            {
                Id = producer.Id,
                ProfilePicture = producer.ProfilePicture,
                FullName = producer.FullName,
                Age = producer.Age,
                Biography = producer.Biography
            };

            Assert.DoesNotThrowAsync(async () => await service.UpdateProducerAsync(producerVM));
        }

        [Test]
        public void GetProducerById()
        {
            MovieTicketsDbContext db = GetDb();


            var producer = new Producer()
            {
                Id = 1,
                ProfilePicture = "/wwwroot/images/c12.jpg",
                FullName = "Pesho Jolie",
                Age = 42,
                Biography = "Very good producer !"
            };

            db.Producers.AddAsync(producer);


            var service = serviceProvider.GetService<IProducerService>();

            var producerVM = new ProducerViewModel
            {
                Id = producer.Id,
                ProfilePicture = producer.ProfilePicture,
                FullName = producer.FullName,
                Age = producer.Age,
                Biography = producer.Biography
            };

            //var result = service.GetProducerByIdAsync(1);
            // Assert.AreEqual(producerVM.Id, result.Id);
            Assert.DoesNotThrowAsync(async () => await service.GetProducerByIdAsync(producerVM.Id));

        }


        [Test]
        public void DeleteProducerShouldWork()
        {
            var producer = new Producer()
            {
                Id = 1,
                ProfilePicture = "/wwwroot/images/c12.jpg",
                FullName = "Pesho Jolie",
                Age = 42,
                Biography = "Very good producer !"
            };

            var service = serviceProvider.GetService<IProducerService>();

            var producerVM = new ProducerViewModel
            {
                Id = producer.Id,
                ProfilePicture = producer.ProfilePicture,
                FullName = producer.FullName,
                Age = producer.Age,
                Biography = producer.Biography
            };

            Assert.DoesNotThrowAsync(async () => await service.DeleteAsync(producerVM.Id));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IEntityBaseRepository<Producer> repo)
        {
            var producer = new Producer()
            {
                Id = 1,
                ProfilePicture = "/wwwroot/images/c12.jpg",
                FullName = "Pesho Jolie",
                Age = 42,
                Biography = "Very good producer !"
            };


            await repo.AddAsync(producer);
        }
    }
}
