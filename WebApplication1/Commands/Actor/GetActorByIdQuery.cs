using MediatR;
using WebApplication1.Models;

namespace WebApplication1.Commands
{
    public class GetActorByIdQuery : IRequest<Actor>
    {
        public int Id { get; set; }
    }
}
