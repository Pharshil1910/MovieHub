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

        public async Task<List<Producer>> ProducerLists()
        {
            var data = _context.Producers.ToList();
            return data;
        }

        public async Task<Producer> GetProducerById(int id)
        {
            var data = _context.Producers.Find(id);
            return data;
        }

        public async Task<Producer> AddProducer(Producer data)
        {
            var producer = await _context.Producers.AddAsync(data);
            await _context.SaveChangesAsync();
            return producer.Entity;
        }

        public async Task<int> UpdateProducer(Producer data)
        {
            _context.Producers.Update(data);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProducer(int id)
        {
            var data = _context.Producers.Find(id);
            
            _context.Producers.Remove(data);
            return await _context.SaveChangesAsync();
        }
    }
}
