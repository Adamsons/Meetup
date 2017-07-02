using MediatR;
using MeetupTest.Api.V1.Models;
using MeetupTest.Domain.Messages.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupTest.Api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class ReservationsController : Controller
    {
        private IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPut]
        public async Task<IActionResult> Put(Reservation reservation)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            var mappedReservations = reservation.Seats.Select(seat => new Domain.Models.Reservation
            {
                EmailAddress = seat.EmailAddress,
                SeatId = seat.SeatId
            });

            var response = await _mediator.Send(new CreateReservationRequest(mappedReservations));

            return new OkResult();
        }
    }
}
