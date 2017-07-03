using MediatR;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using MeetupTest.Domain.Models;
using MeetupTest.Persistence;
using System;
using System.Threading.Tasks;

namespace MeetupTest.Domain.Handlers
{
    public class GetMeetupHandler : IAsyncRequestHandler<GetMeetupRequest, GetMeetupResponse>
    {
        private readonly IMeetupContext _context;

        public GetMeetupHandler(IMeetupContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<GetMeetupResponse> Handle(GetMeetupRequest message)
        {
            var meetup = await _context.Meetups.FindAsync(message.Id);

            if (meetup != null)
            {
                return new GetMeetupResponse(new Meetup
                {
                    Id = meetup.Id,
                    Name = meetup.Name,
                    Location = meetup.Location,
                    StartTime = meetup.StartTime,
                    EndTime = meetup.EndTime
                });
            }

            return new GetMeetupResponse(null);
        }
    }
}
