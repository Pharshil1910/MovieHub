using MediatR;

namespace WebApplication1.Commands
{
    public class DeleteActorQuery : IRequest<int>
    {
        public int Id { get; set; }
    }
}
