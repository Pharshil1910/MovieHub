using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IProducerRepository
    {
        public List<Producer> ProducerLists();
        public Producer GetProducerById(int id);
        public Task AddProducer(Producer data);
        public Task UpdateProducer(Producer data);
        public Task DeleteProducer(int id);
    }
}
