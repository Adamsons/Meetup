using FluentAssertions;
using MeetupTest.Api.V1.Controllers;
using Xunit;

namespace MeetupTest.Api.Tests.V1.Controllers
{
    public class MeetupControllerTests
    {
        private MeetupsController _controller = new MeetupsController();

        [Fact]
        public void Get_ReturnsAllMeetups()
        {
            var meetups = _controller.Get();
            meetups.Should().NotBeNullOrEmpty();
        }
    }
}
