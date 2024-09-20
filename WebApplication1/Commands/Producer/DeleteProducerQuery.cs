using MediatR;

namespace WebApplication1.Commands
{
    public class DeleteProducerQuery : IRequest<int>
    {
        public int Id { get; set; }
    }
}
