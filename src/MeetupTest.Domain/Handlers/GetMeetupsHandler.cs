using MediatR;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupTest.Domain.Handlers
{
    public class GetMeetupsHandler : IAsyncRequestHandler<GetMeetupsRequest, GetMeetupsResponse>
    {
        Task<GetMeetupsResponse> IAsyncRequestHandler<GetMeetupsRequest, GetMeetupsResponse>.Handle(GetMeetupsRequest message)
        {
            return Task.FromResult(new GetMeetupsResponse(Enumerable.Empty<Meetup>()));
        }
    }
}
