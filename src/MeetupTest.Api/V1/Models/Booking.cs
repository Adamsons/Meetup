namespace MeetupTest.Api.V1.Models
{
    public class Booking
    {
        public int ReservationId { get; }

        public Booking(int reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
