using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IActorRepository
    {
        public List<Actor> ActorLists ();
        public Actor GetActorById(int id);
        public Task AddActor(Actor data);
        public Task UpdateActor(Actor data);
        public Task DeleteActor(int id);
    }
}
