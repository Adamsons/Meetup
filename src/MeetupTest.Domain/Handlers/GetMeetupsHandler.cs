using MediatR;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using MeetupTest.Domain.Models;
using MeetupTest.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MeetupTest.Domain.Handlers
{
    public class GetMeetupsHandler : IAsyncRequestHandler<GetMeetupsRequest, GetMeetupsResponse>
    {
        private readonly IMeetupContext _context;

        public GetMeetupsHandler(IMeetupContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<GetMeetupsResponse> Handle(GetMeetupsRequest message)
        {
            var meetups = await _context.Meetups.Take(10).ToListAsync();

            if (meetups.Any())
            {
                return new GetMeetupsResponse(meetups.Select(meetup => new Meetup
                {
                    Id = meetup.Id,
                    Name = meetup.Name,
                    Location = meetup.Location,
                    StartTime = meetup.StartTime,
                    EndTime = meetup.EndTime
                }));
            }

            return new GetMeetupsResponse(Enumerable.Empty<Meetup>());
        }
    }
}
