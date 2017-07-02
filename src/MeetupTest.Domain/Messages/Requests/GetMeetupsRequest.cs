using MediatR;
using MeetupTest.Domain.Messages.Responses;

namespace MeetupTest.Domain.Messages.Requests
{
    public class GetMeetupsRequest : IRequest<GetMeetupsResponse> { }
}
