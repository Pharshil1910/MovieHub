using MediatR;
using WebApplication1.Commands;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Handlers
{
    public class UpdateActorHandler : IRequestHandler<UpdateActorCommand, int>
    {
        private readonly IActorRepository _actorRepository = null;
        public UpdateActorHandler(IActorRepository _actorRepository) 
        {
            this._actorRepository = _actorRepository;
        }

        public async Task<int> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            var data = new Actor()
            {
                Id = request.Id,
                Name = request.Name,
                Gender = request.Gender,
                Dob = request.Dob,
                Bio = request.Bio
            };
            return await _actorRepository.UpdateActor(data);
        }
    }
}
