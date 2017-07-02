using System.Collections.Generic;

namespace MeetupTest.Domain
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
