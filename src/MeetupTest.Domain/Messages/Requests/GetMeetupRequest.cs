using MediatR;
using MeetupTest.Domain.Messages.Responses;

namespace MeetupTest.Domain.Messages.Requests
{
    public class GetMeetupRequest : IRequest<GetMeetupResponse>
    {
        public readonly int Id;

        public GetMeetupRequest(int id)
        {
            Id = id;
        }
    }
}
