using MediatR;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Handlers
{
    public class DeleteActorHandler : IRequestHandler<DeleteActorQuery, int>
    {
        private readonly IActorRepository _actorRepository = null;
        public DeleteActorHandler(IActorRepository _actorRepository) 
        {
            this._actorRepository = _actorRepository;
        }

        public async Task<int> Handle(DeleteActorQuery request, CancellationToken cancellationToken)
        {
            return await _actorRepository.DeleteActor(request.Id);
        }
    }
}
