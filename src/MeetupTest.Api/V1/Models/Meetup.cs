using System;

namespace MeetupTest.Api.V1.Models
{
    public class Meetup
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
