using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetupTest.Api.V1.Models
{
    public class CreateReservation
    {
        [Required]
        [Range(1, 4)]
        public List<SeatReservation> Seats { get; set; }
    }

    public class SeatReservation
    {
        [Required]
        public int SeatId { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
