using MovieTickets.Data.Data.Common;
using MovieTickets.Data.Models;
using MovieTickets.Services.ViewModel.Actors;

namespace MovieTickets.Services.Contracts
{
    public interface IActorService : IEntityBaseRepository<Actor>
    {
        Task<Actor> GetActorByIdAsync(int id);
        Task AddNewActorAsync(ActorViewModel data);
        Task UpdateActorAsync(ActorViewModel data);
    }
}
