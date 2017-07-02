using FluentAssertions;
using MediatR;
using System.Threading.Tasks;
using Xunit;

namespace MeetupTest.Domain.Tests.UnitTests.Handlers
{
    public class GetAllMeetupsHandlerTests
    {
        private IAsyncRequestHandler<GetAllMeetupsRequest, GetMeetupsResponse> _handler = new GetAllMeetupsHandler();

        [Fact]
        public async Task Handle_ReturnsMeetups()
        {
            var result = await _handler.Handle(new GetAllMeetupsRequest());
            result.Should().NotBeNull();
            result.Meetups.Should().NotBeNull();
            result.Meetups.Should().HaveCount(0);
        }
    }
}
