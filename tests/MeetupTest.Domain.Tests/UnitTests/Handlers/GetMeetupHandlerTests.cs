using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MediatR;
using MeetupTest.Domain.Handlers;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using MeetupTest.Persistence;
using Moq;
using System.Threading.Tasks;
using MeetupTest.Domain.Tests.UnitTests.Helpers;
using MeetupTest.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MeetupTest.Domain.Tests.UnitTests.Handlers
{
    public class GetMeetupHandlerTests
    {
        private readonly IAsyncRequestHandler<GetMeetupRequest, GetMeetupResponse> _handler;

        private readonly Mock<IMeetupContext> _db = new Mock<IMeetupContext>();

        public GetMeetupHandlerTests()
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

            var mockSet = new Mock<DbSet<Meetup>>();
            mockSet.Setup(o => o.FindAsync(1)).ReturnsAsync(meetups.FirstOrDefault());

            _db.Setup(o => o.Meetups).Returns(mockSet.Object);
            _handler = new GetMeetupHandler(_db.Object);
        }

        [Fact]
        public async Task Handle_ReturnsMeetup()
        {
            var result = await _handler.Handle(new GetMeetupRequest(1));

            result.Should().NotBeNull();
            result.Meetup.Should().NotBeNull();
        }
    }
}
