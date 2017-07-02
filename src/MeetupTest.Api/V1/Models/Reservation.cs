using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetupTest.Api.V1.Models
{
    public class Reservation
    {
        [Required]
        [Range(1, 4)]
        public readonly List<SeatReservation> Seats;

        public Reservation(List<SeatReservation> seats)
        {
            Seats = seats;
        }
    }

    public class SeatReservation
    {
        [Required]
        public int SeatId { get; }

        [EmailAddress]
        public string EmailAddress { get; }

        public SeatReservation(int seatId, string emailAddress)
        {
            seatId = SeatId;
            EmailAddress = emailAddress;
        }
    }
}
