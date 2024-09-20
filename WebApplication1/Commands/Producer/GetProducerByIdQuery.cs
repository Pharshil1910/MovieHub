using MediatR;
using WebApplication1.Models;

namespace WebApplication1.Commands
{
    public class GetProducerByIdQuery : IRequest<Producer>
    {
        public int Id { get; set; }
    }
}
