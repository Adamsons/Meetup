using MeetupTest.Domain.Models;
using System.Collections.Generic;

namespace MeetupTest.Domain.Messages.Responses
{
    public class GetMeetupsResponse
    {
        public readonly IEnumerable<Meetup> Meetups;

        public GetMeetupsResponse(IEnumerable<Meetup> meetups)
        {
            Meetups = meetups;
        }
    }
}
