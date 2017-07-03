namespace MeetupTest.Persistence.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public Meetup Meetup { get; set; }
    }
}
