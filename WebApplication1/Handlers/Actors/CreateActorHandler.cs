using MediatR;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Handlers
{
    public class CreateActorHandler : IRequestHandler<CreateActorCommand, Actor>
    {
        private readonly IActorRepository _actorRepository = null;
        public CreateActorHandler(IActorRepository _actorRepository) 
        {
            this._actorRepository = _actorRepository;
        }

        public async Task<Actor> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var data = new Actor()
            {
                Name = request.Name,
                Gender = request.Gender,
                Dob = request.Dob,
                Bio = request.Bio
            };
            return await _actorRepository.AddActor(data);
        }
    }
}
