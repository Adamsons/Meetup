using MediatR;
using MeetupTest.Domain.Handlers;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using MeetupTest.Domain.Validators;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetupTest.Domain.Tests.UnitTests.Handlers
{
    public class CreateReservationHandlerTests
    {
        private IAsyncRequestHandler<CreateReservationRequest, CreateReservationResponse> _handler;

        private Mock<IRequestValidator<CreateReservationRequest>> _validator = new Mock<IRequestValidator<CreateReservationRequest>>();
        private Mock<IDistributedCache> _cache = new Mock<IDistributedCache>();

        public CreateReservationHandlerTests()
        {
            _handler = new CreateReservationHandler(_validator.Object, _cache.Object);
        }
    }
}
