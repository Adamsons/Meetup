using MediatR;
using MeetupTest.Domain.Messages.Responses;
using MeetupTest.Domain.Models;
using System.Collections.Generic;

namespace MeetupTest.Domain.Messages.Requests
{
    public class CreateReservationRequest : IRequest<CreateReservationResponse>
    {
        public IEnumerable<Reservation> Reservations { get; }

        public CreateReservationRequest(IEnumerable<Reservation> reservations)
        {
            Reservations = Reservations;
        }
    }
}
