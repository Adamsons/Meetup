namespace MeetupTest.Persistence.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public Seat Seat { get; set; }
        public string EmailAddress { get; set; }
    }
}
