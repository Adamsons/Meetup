namespace MeetupTest.Domain.Messages.Responses
{
    public class GetMeetupResponse
    {
        public readonly Meetup Meetup;

        public GetMeetupResponse(Meetup meetup)
        {
            Meetup = meetup;
        }
    }
}
