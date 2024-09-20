using MediatR;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Handlers
{
    public class GetActorByIdHandler : IRequestHandler<GetActorByIdQuery, Actor>
    {
        private readonly IActorRepository _actorRepository = null;
        public GetActorByIdHandler(IActorRepository _actorRepository) 
        {
            this._actorRepository = _actorRepository;
        }

        public async Task<Actor> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _actorRepository.GetActorById(request.Id);
        }
    }
}
