using MediatR;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Handlers
{
    public class UpdateProducerHandler : IRequestHandler<UpdateProducerCommand, int>
    {
        private readonly IProducerRepository _producerRepository = null;
        public UpdateProducerHandler(IProducerRepository ProducerRepository)
        {
            this._producerRepository = ProducerRepository;
        }

        public async Task<int> Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
        {
            var data = new Producer()
            {
                Id = request.Id,
                Name = request.Name,
                Gender = request.Gender,
                Dob = request.Dob,
                Bio = request.Bio
            };
            return await _producerRepository.UpdateProducer(data);
        }
    }
}
