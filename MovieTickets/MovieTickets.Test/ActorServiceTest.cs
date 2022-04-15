using Microsoft.Extensions.DependencyInjection;
using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.Services;
using MovieTickets.Services.ViewModel.Actors;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Test
{
    public class ActorServiceTest:BaseServiceTests
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
                .AddSingleton<IEntityBaseRepository<Actor>, EntityBaseRepository<Actor>>()
                .AddSingleton<IActorService, ActorService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IEntityBaseRepository<Actor>>();
            await SeedDbAsync(repo);
        }


      
        [Test]
        public void AddActorMustWorkNewWay()
        {
            MovieTicketsDbContext db = GetDb();


            var actor = new Actor()
            {
                ProfilePicture = "/wwwroot/images/c12.jpg",
                FullName = "Tom Hardy",
                Age = 32,
                Biography = "Very good biography",
            };

            db.Actors.Add(actor);
            db.SaveChangesAsync();

            var service = serviceProvider.GetService<IActorService>();

            var actorVM = new ActorViewModel
            {
                // Id=1,
                ProfilePicture = actor.ProfilePicture,
                FullName = actor.FullName,
                Age = actor.Age,
                Biography = actor.Biography
            };

            service.AddNewActorAsync(actorVM);

            var result = db.Actors.Where(x => x.FullName == "Tom Hardy")
                .FirstOrDefault();

            Assert.AreEqual(actorVM.FullName, result.FullName);
        }

        [Test]
        public void AddActorShouldWork()
        {

            var actor = new Actor()
            {
                Id = 16,
                ProfilePicture = "/images/" + "c12" + "." + "jpg",
                FullName = "Tom Hardy",
                Age = 32,
                Biography = "Very goood actor!",
            };

            var actorVM = new ActorViewModel();

            actorVM.Id = actor.Id;
            actorVM.ProfilePicture = actor.ProfilePicture;
            actorVM.FullName = actor.FullName;
            actorVM.Age = actor.Age;
            actorVM.Biography = actor.Biography;


            var service = serviceProvider.GetService<IActorService>();

            Assert.DoesNotThrowAsync(async () => await service.AddNewActorAsync(actorVM));
        }

        [Test]
        public void AddActorShouldThrow()
        {

            var actor = new Actor()
            {
                Id = 16,
                ProfilePicture = "/images/" + "c12"+"."+"jpg",
                FullName = "Tom Hardy",
                Age = 32,
                Biography =null,
            };

            var actorVM = new ActorViewModel();

            actorVM.Id = actor.Id;
            actorVM.ProfilePicture = actor.ProfilePicture;
            actorVM.FullName = actor.FullName;
            actorVM.Age = actor.Age;
            actorVM.Biography = actor.Biography;


            var service = serviceProvider.GetService<IActorService>();
          
            Assert.ThrowsAsync<ArgumentException>(async () => await service.AddNewActorAsync(actorVM),"Biography is required");
        }

        [Test]
        public void UpdateActorShouldWork()
        {
            var actor = new Actor()
            {
                Id = 1,
                ProfilePicture = "/wwwroot/images/c12.jpg",
                FullName = "Tom Hardy",
                Age = 32,
                Biography = "Very good biography",
            };

            var service = serviceProvider.GetService<IActorService>();

            var actorVM = new ActorViewModel
            {
                 Id=1,
                ProfilePicture = actor.ProfilePicture,
                FullName = actor.FullName,
                Age = actor.Age,
                Biography = actor.Biography
            };

            Assert.DoesNotThrowAsync(async () => await service.UpdateActorAsync(actorVM));
        }

        [Test]
        public void GetActorById()
        {
            var actor1 = new Actor()
            {
                Id = 2,
                ProfilePicture = "/wwwroot/images/c12.jpg",
                FullName = "Matt Hardy",
                Age = 32,
                Biography = "Very good biography",
            };


            var service = serviceProvider.GetService<IActorService>();

            var actorVM1 = new ActorViewModel
            {
                 Id=1,
                ProfilePicture = actor1.ProfilePicture,
                FullName = actor1.FullName,
                Age = actor1.Age,
                Biography = actor1.Biography
            };
            
            var result = service.GetActorByIdAsync(1);
            Assert.AreEqual(actorVM1.Id, result.Id);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IEntityBaseRepository<Actor> repo)
        {
            var actor = new Actor()
            {
                Id=1,
                ProfilePicture = "/wwwroot/images/c12.jpg",
                FullName = "Angelina Jolie",
                Age = 32,
                Biography = "Very good actress !"
            };

            var actor1 = new Actor()
            {
                Id = 3,
                ProfilePicture = "/wwwroot/images/c12.jpg",
                FullName = "Math Jolie",
                Age = 36,
                Biography = "Very good actress !"
            };

            var actor2 = new Actor()
            {
                Id = 2,
                ProfilePicture = "/wwwroot/images/c12.jpg",
                FullName = "Pesho Jolie",
                Age = 42,
                Biography = "Very good actress !"
            };

            await repo.AddAsync(actor);
        }
    }
}
