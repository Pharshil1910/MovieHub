using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IActorRepository
    {
        public Task<List<Actor>> ActorLists ();
        public Task<Actor> GetActorById(int id);
        public Task<Actor> AddActor(Actor data);
        public Task<int> UpdateActor(Actor data);
        public Task<int> DeleteActor(int id);
    }
}
