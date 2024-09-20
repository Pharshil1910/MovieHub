using MediatR;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Handlers
{
    public class DeleteProducerHandler : IRequestHandler<DeleteProducerQuery, int>
    {
        private readonly IProducerRepository _producerRepository = null;
        public DeleteProducerHandler(IProducerRepository ProducerRepository)
        {
            this._producerRepository = ProducerRepository;
        }

        public async Task<int> Handle(DeleteProducerQuery request, CancellationToken cancellationToken)
        {
            return await _producerRepository.DeleteProducer(request.Id);
        }
    }
}
