using FluentAssertions;
using MediatR;
using MeetupTest.Api.V1.Controllers;
using MeetupTest.Domain;
using Moq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MeetupTest.Api.Tests.UnitTests.V1.Controllers
{
    public class MeetupControllerTests
    {
        private MeetupsController _controller;

        private Mock<IMediator> _mediator = new Mock<IMediator>();

        public MeetupControllerTests()
        {
            _controller = new MeetupsController(_mediator.Object);
        }

        [Fact]
        public void Controller_ThrowsGivenNullMediator()
        {
            Action act = () => new MeetupsController(null);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Get_ReturnsAllMeetups()
        {
            var meetup = new Meetup() { Id = Guid.NewGuid() };
            var meetups = new[] { meetup };
            _mediator.Setup(o => o.Send(It.IsAny<GetAllMeetupsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetMeetupsResponse(meetups));

            var result = await _controller.Get();

            result.Should().NotBeNullOrEmpty();
            result.Any(mapped => meetup.Id == mapped.Id).Should().BeTrue();
        }

        [Fact]
        public async Task Get_ReturnsEmptyListWhenNoMeetupsAreAvailable()
        {
            _mediator.Setup(o => o.Send(It.IsAny<GetAllMeetupsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetMeetupsResponse(null));

            var result = await _controller.Get();

            result.Should().NotBeNull();
            result.Should().HaveCount(0);
        }
    }
}
