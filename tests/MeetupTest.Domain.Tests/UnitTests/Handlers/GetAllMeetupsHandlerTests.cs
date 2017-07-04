using System;
using System.Collections.Generic;
using FluentAssertions;
using MediatR;
using MeetupTest.Domain.Handlers;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using MeetupTest.Persistence;
using Moq;
using System.Threading.Tasks;
using MeetupTest.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using MeetupTest.Persistence.Tests.Helpers;

namespace MeetupTest.Domain.Tests.UnitTests.Handlers
{
    public class GetMeetupsHandlerTests
    {
        private readonly IAsyncRequestHandler<GetMeetupsRequest, GetMeetupsResponse> _handler;

        private readonly Mock<IMeetupContext> _db = new Mock<IMeetupContext>();

        public GetMeetupsHandlerTests()
        {
            var meetups = new List<Meetup>
            {
                new Meetup
                {
                    Id = 1,
                    Name = "React London",
                    Location = "London",
                    StartTime = DateTime.Today,
                    EndTime = DateTime.Today
                }
            };

            var mockSet = DbSetHelper.MockDbSet(meetups);
            _db.Setup(o => o.Meetups).Returns(mockSet.Object);
            _handler = new GetMeetupsHandler(_db.Object);
        }

        [Fact]
        public async Task Handle_ReturnsMeetups()
        {
            var result = await _handler.Handle(new GetMeetupsRequest());

            result.Should().NotBeNull();
            result.Meetups.Should().NotBeNull();
            result.Meetups.Should().HaveCount(1);
        }
    }
}
