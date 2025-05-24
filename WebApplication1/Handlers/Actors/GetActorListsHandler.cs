using MediatR;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Handlers
{
    public class GetActorListsHandler : IRequestHandler<GetActorListsQuery, List<Actor>>
    {
        private readonly IActorRepository _actorRepository = null;
        public GetActorListsHandler(IActorRepository _actorRepository) 
        {
            this._actorRepository = _actorRepository;
        }

        public async Task<List<Actor>> Handle(GetActorListsQuery request, CancellationToken cancellationToken)
        {
            return await _actorRepository.ActorLists();
        }
    }
}
