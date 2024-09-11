using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly FilmIndustryDBContext _context;
        public ProducerRepository(FilmIndustryDBContext context)
        {
            this._context = context;
        }

        public List<Producer> ProducerLists()
        {
            var data = _context.Producers.ToList();
            return data;
        }

        public Producer GetProducerById(int id)
        {
            var data = _context.Producers.Find(id);
            return data;
        }

        public async Task AddProducer(Producer data)
        {
            await _context.Producers.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProducer(Producer data)
        {
            _context.Producers.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProducer(int id)
        {
            var data = _context.Producers.Find(id);
            if (data != null)
            {
                _context.Producers.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
