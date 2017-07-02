using MediatR;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using System.Threading.Tasks;

namespace MeetupTest.Domain.Handlers
{
    public class GetMeetupHandler : IAsyncRequestHandler<GetMeetupRequest, GetMeetupResponse>
    {
        public Task<GetMeetupResponse> Handle(GetMeetupRequest message)
        {
            return Task.FromResult(new GetMeetupResponse(new Meetup()));
        }
    }
}
