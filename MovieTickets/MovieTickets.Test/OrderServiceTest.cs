using Microsoft.Extensions.DependencyInjection;
using MovieTickets.Data;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.Services;
using MovieTickets.Services.ViewModel.Orders;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieTickets.Test
{
    public class OrderServiceTest:BaseServiceTests
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
                .AddSingleton<IOrderService, OrderService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IOrderService>();
           
        }

        [Test]
        public void StoreOrderShouldWork()
        {
            MovieTicketsDbContext db = GetDb();

            var movie = new Movie()
            {
                Id = 15,
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
            db.Movies.Add(movie);
            db.SaveChangesAsync();

            var listShopping = new List<ShoppingCartItem>();


            //string userId = "563557f3-5a03-5g20-8d16-9d8c378c47d6";
            //string email = "kriskopk@abv.bg";
            var order = new Order
            {
                UserId = "563557f3-5a03-4d20-8d16-9d8c378c47d6",
                Email = "user@etickets.com"
            };
            db.Orders.Add(order);
            db.SaveChangesAsync();

            var shoppingCart = new ShoppingCartItem
            {
                Id = 5,
                Movie = movie,
                Quantity = 1,
                ShoppingCartId = "e42ee070-2842-4822-b30b-50e458e23bc7",
            };
            db.ShoppingCartItems.Add(shoppingCart);
            listShopping.Add(shoppingCart);
            db.SaveChangesAsync();


            var service = serviceProvider.GetService<IOrderService>();
            var result = service.StoreOrderAsync(listShopping, order.UserId, order.Email);
            Assert.IsNotNull(result);
            //Assert.DoesNotThrowAsync(async () => await service.StoreOrderAsync(listShopping, order.UserId,order.Email));

        }

        [Test]
        public void GetOrdersByUserIdAndRoleShouldWork()
        {
            MovieTicketsDbContext db = GetDb();
            string userId = "401b5912-92ca-422f-ae13-5b6a2f26d1e1";
            string userId2 = "563557f3-5a03-4d20-8d16-9d8c378c47d6";
            

            string role = "admin";
            string role2 = "user";
            var service = serviceProvider.GetService<IOrderService>();

            Assert.DoesNotThrowAsync(async () => await service.GetOrdersByUserIdAndRoleAsync(userId,role));
            Assert.DoesNotThrowAsync(async () => await service.GetOrdersByUserIdAndRoleAsync(userId2,role2));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}
