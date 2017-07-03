using FluentAssertions;
using MediatR;
using MeetupTest.Api.V1.Controllers;
using MeetupTest.Domain;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using MeetupTest.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
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
        public void Controller_DoesNotThrowGivenValidArguments()
        {
            Action act = () => new MeetupsController(_mediator.Object);
            act.ShouldNotThrow();
        }

        [Fact]
        public async Task Get_ReturnsAllMeetups()
        {
            var meetup = new Meetup() { Name = "12345" };
            var meetups = new[] { meetup };
            _mediator.Setup(o => o.Send(It.IsAny<GetMeetupsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetMeetupsResponse(meetups));

            var result = await _controller.Get();

            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult.Value.Should().NotBeNull();

            var resultMeetups = okResult.Value as IEnumerable<Api.V1.Models.Meetup>;
            resultMeetups.Any(mapped => meetup.Name == mapped.Name).Should().BeTrue();
        }

        [Fact]
        public async Task Get_ReturnsEmptyListWhenNoMeetupsAreAvailable()
        {
            _mediator.Setup(o => o.Send(It.IsAny<GetMeetupsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetMeetupsResponse(null));

            var result = await _controller.Get();

            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult.Value.Should().NotBeNull();

            var resultMeetups = okResult.Value as Api.V1.Models.Meetup[];
            resultMeetups.Should().HaveCount(0);
        }
    }
}
