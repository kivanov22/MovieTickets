using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.ViewModel.Producers;

namespace MovieTickets.Services.Contracts
{
    public interface IProducerService : IEntityBaseRepository<Producer>
    {
        Task<Producer> GetProducerByIdAsync(int id);
        Task AddNewProducerAsync(ProducerViewModel data);
        Task UpdateProducerAsync(ProducerViewModel data);
    }
}