using FluentAssertions;
using MediatR;
using MeetupTest.Domain.Handlers;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using System.Threading.Tasks;
using Xunit;

namespace MeetupTest.Domain.Tests.UnitTests.Handlers
{
    public class GetMeetupsHandlerTests
    {
        private IAsyncRequestHandler<GetMeetupsRequest, GetMeetupsResponse> _handler = new GetMeetupsHandler();

        [Fact]
        public async Task Handle_ReturnsMeetups()
        {
            var result = await _handler.Handle(new GetMeetupsRequest());

            result.Should().NotBeNull();
            result.Meetups.Should().NotBeNull();
            result.Meetups.Should().HaveCount(0);
        }
    }
}
