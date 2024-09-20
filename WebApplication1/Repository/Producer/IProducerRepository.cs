using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IProducerRepository
    {
        public Task<List<Producer>> ProducerLists();
        public Task<Producer> GetProducerById(int id);
        public Task<Producer> AddProducer(Producer data);
        public Task<int> UpdateProducer(Producer data);
        public Task<int> DeleteProducer(int id);
    }
}
