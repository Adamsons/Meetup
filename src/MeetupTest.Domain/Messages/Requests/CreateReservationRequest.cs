using System.Collections.Generic;
using MediatR;
using MeetupTest.Domain.Messages.Responses;
using MeetupTest.Domain.Models;

namespace MeetupTest.Domain.Messages.Requests
{
    public class CreateReservationRequest : IRequest<CreateReservationResponse>
    {
        public IEnumerable<SeatReservation> Reservation { get; }

        public CreateReservationRequest(IEnumerable<SeatReservation> reservation)
        {
            Reservation = reservation;
        }
    }
}
