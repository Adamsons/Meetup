using FluentAssertions;
using MediatR;
using MeetupTest.Api.V1.Controllers;
using Moq;
using System;
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
        public void Controller_DoesNotThrowGivenValidArguments()
        {
            Action act = () => new ReservationsController(_mediator.Object);
            act.ShouldNotThrow();
        }

        [Fact]
        public void Put_ThrowsIfReservationIsNull()
        {
            Action act = () => _controller.Put(null).Wait();
            act.ShouldThrow<ArgumentNullException>();
        }
    }
}
