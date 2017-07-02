namespace MeetupTest.Domain.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int MeetupId { get; set; }
        public string Alias { get; set; }
        public string EmailAddress { get; set; }
    }
}
