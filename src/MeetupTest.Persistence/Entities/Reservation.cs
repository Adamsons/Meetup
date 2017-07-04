using System.Collections.Generic;

namespace MeetupTest.Persistence.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
