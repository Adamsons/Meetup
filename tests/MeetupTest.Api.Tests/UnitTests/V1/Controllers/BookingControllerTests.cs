using FluentAssertions;
using MediatR;
using MeetupTest.Api.V1.Controllers;
using Moq;
using System;
using Xunit;

namespace MeetupTest.Api.Tests.UnitTests.V1.Controllers
{
    public class BookingsControllerTests
    {
        private BookingsController _controller;

        private Mock<IMediator> _mediator = new Mock<IMediator>();

        public BookingsControllerTests()
        {
            _controller = new BookingsController(_mediator.Object);
        }

        [Fact]
        public void Controller_ThrowsGivenNullMediator()
        {
            Action act = () => new BookingsController(null);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Controller_DoesNotThrowGivenValidArguments()
        {
            Action act = () => new BookingsController(_mediator.Object);
            act.ShouldNotThrow();
        }
    }
}
