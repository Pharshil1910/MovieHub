using MediatR;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Handlers
{
    public class CreateProducerHandler : IRequestHandler<CreateProducerCommand, Producer>
    {
        private readonly IProducerRepository _producerRepository = null;
        public CreateProducerHandler(IProducerRepository ProducerRepository)
        {
            this._producerRepository = ProducerRepository;
        }

        public async Task<Producer> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
        {
            var data = new Producer()
            {
                Name = request.Name,
                Gender = request.Gender,
                Dob = request.Dob,
                Bio = request.Bio
            };
            return await _producerRepository.AddProducer(data);
        }
    }
}
