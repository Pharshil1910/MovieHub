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

        public List<Actor> ActorLists()
        {
            var data = _context.Actors.ToList();
            return data;
        }

        public Actor GetActorById(int id)
        {
            var data = _context.Actors.FirstOrDefault(x => x.Id == id);
            return data;
        }

        public async Task AddActor(Actor data)
        {
            await _context.Actors.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateActor(Actor data)
        {
            _context.Actors.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteActor(int id)
        {
            var actorData = _context.Actors.Find(id);
            if (actorData != null)
            {
                _context.Actors.Remove(actorData);
                await _context.SaveChangesAsync();
            }

        }
    }
}
