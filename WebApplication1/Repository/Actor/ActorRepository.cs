using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly FilmIndustryDBContext _context;

        public ActorRepository(FilmIndustryDBContext context)
        {
            this._context = context;
        }

        public Task<List<Actor>> ActorLists()
        {
            var data = _context.Actors.ToListAsync();
            return data;
        }

        public Task<Actor> GetActorById(int id)
        {
            var data = _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<Actor> AddActor(Actor data)
        {
            var actor = await _context.Actors.AddAsync(data);
            await _context.SaveChangesAsync();
            return actor.Entity;
        }

        public async Task<int> UpdateActor(Actor data)
        {
            _context.Actors.Update(data);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteActor(int id)
        {
            var actorData = _context.Actors.Find(id);
            _context.Actors.Remove(actorData);
            return await _context.SaveChangesAsync();
        }
    }
}
