using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupTest.Domain
{
    public class GetAllMeetupsHandler : IAsyncRequestHandler<GetAllMeetupsRequest, GetMeetupsResponse>
    {
        Task<GetMeetupsResponse> IAsyncRequestHandler<GetAllMeetupsRequest, GetMeetupsResponse>.Handle(GetAllMeetupsRequest message)
        {
            return Task.FromResult(new GetMeetupsResponse(Enumerable.Empty<Meetup>()));
        }
    }
}
