using FluentAssertions;
using MediatR;
using MeetupTest.Api.V1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MeetupTest.Api.Tests.UnitTests.V1.Controllers
{
    public class ReservationsControllerTests
    {
        private ReservationsController _controller;

        private Mock<IMediator> _mediator = new Mock<IMediator>();

        public ReservationsControllerTests()
        {
            _controller = new ReservationsController(_mediator.Object);
        }

        [Fact]
        public void Controller_ThrowsGivenNullMediator()
        {
            Action act = () => new ReservationsController(null);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Put_ReturnsBadRequestIfBodyIsNull()
        {
            var result = await _controller.Put(null);
            result.Should().NotBeNull();
            result.Should().BeOfType<OkResult>();
        }
    }
}
