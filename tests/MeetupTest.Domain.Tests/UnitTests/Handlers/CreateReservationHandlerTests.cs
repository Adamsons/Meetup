using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using MeetupTest.Domain.Handlers;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using MeetupTest.Domain.Models;
using MeetupTest.Domain.Validators;
using Moq;
using MeetupTest.Persistence;
using MeetupTest.Persistence.Entities;
using Xunit;

namespace MeetupTest.Domain.Tests.UnitTests.Handlers
{
    public class CreateReservationHandlerTests
    {
        private IAsyncRequestHandler<CreateReservationRequest, CreateReservationResponse> _handler;

        private readonly Mock<IRequestValidator<CreateReservationRequest>> _validator = new Mock<IRequestValidator<CreateReservationRequest>>();
        private readonly Mock<IMeetupContext> _db = new Mock<IMeetupContext>();

        public CreateReservationHandlerTests()
        {
            _handler = new CreateReservationHandler(_validator.Object, _db.Object);
        }

        [Fact]
        public void Constructor_GivenNullValidatorThenThrow()
        {
            Action act = () => new CreateReservationHandler(null, _db.Object);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_GivenNullContextThenThrow()
        {
            Action act = () => new CreateReservationHandler(_validator.Object, null);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Handle_GivenNullMessageThenThrow()
        {
            Action act = () => _handler.Handle(null).Wait();
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Handle_NoReservationsShouldThrow()
        {
            var request = new CreateReservationRequest(Enumerable.Empty<SeatReservation>());

            Action act = () => _handler.Handle(request).Wait();
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public async Task Handle_IfRequestIsInvalidDoNotCreateReservation()
        {
            var req = new CreateReservationRequest(new []
            {
                new SeatReservation { EmailAddress = "sean@sean.com", SeatId = 1}
            });

            _validator.Setup(o => o.Validate(req)).Returns(false);

            await _handler.Handle(req);

            _db.Verify(o => o.Reservations.AddAsync(It.IsAny<Reservation>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
