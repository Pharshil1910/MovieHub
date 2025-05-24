using MediatR;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Handlers
{
    public class GetProducerByIdHandler : IRequestHandler<GetProducerByIdQuery, Producer>
    {
        private readonly IProducerRepository _producerRepository = null;
        public GetProducerByIdHandler(IProducerRepository ProducerRepository)
        {
            this._producerRepository = ProducerRepository;
        }

        public async Task<Producer> Handle(GetProducerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _producerRepository.GetProducerById(request.Id);
        }
    }
}
