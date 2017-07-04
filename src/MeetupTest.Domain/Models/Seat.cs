namespace MeetupTest.Domain.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public Meetup Meetup { get; set; }
        public Booking Booking { get; set; }
    }
}
