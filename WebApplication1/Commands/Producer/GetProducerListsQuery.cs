using MediatR;
using WebApplication1.Models;

namespace WebApplication1.Commands
{
    public class GetProducerListsQuery : IRequest<List<Producer>>
    {
    }
}
