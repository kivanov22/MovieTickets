using Microsoft.Extensions.DependencyInjection;
using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.Contracts;
using MovieTickets.Services.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MovieTickets.Test
{
    public class OrderServiceTest
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

        }

        [Test]
        public void GetOrdersByUserIdAndRoleShouldWork()
        {

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}
