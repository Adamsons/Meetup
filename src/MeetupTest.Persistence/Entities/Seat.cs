namespace MeetupTest.Persistence.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public virtual Meetup Meetup { get; set; }
    }
}
