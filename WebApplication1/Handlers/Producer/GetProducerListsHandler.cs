using MediatR;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Handlers
{
    public class GetProducerListsHandler : IRequestHandler<GetProducerListsQuery, List<Producer>>
    {
        private readonly IProducerRepository _producerRepository = null;
        public GetProducerListsHandler(IProducerRepository ProducerRepository) 
        {
            this._producerRepository = ProducerRepository;
        }

        public async Task<List<Producer>> Handle(GetProducerListsQuery request, CancellationToken cancellationToken)
        {
            return await _producerRepository.ProducerLists();
        }
    }
}
