using FluentAssertions;
using MediatR;
using MeetupTest.Domain.Handlers;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using System.Threading.Tasks;
using Xunit;

namespace MeetupTest.Domain.Tests.UnitTests.Handlers
{
    public class GetMeetupHandlerTests
    {
        private IAsyncRequestHandler<GetMeetupRequest, GetMeetupResponse> _handler = new GetMeetupHandler();

        [Fact]
        public async Task Handle_ReturnsMeetup()
        {
            var result = await _handler.Handle(new GetMeetupRequest(12345));
            result.Should().NotBeNull();
            result.Meetup.Should().NotBeNull();
        }
    }
}
