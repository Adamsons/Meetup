using MediatR;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using MeetupTest.Domain.Validators;
using System;
using System.Linq;
using System.Threading.Tasks;
using MeetupTest.Persistence;
using MeetupTest.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetupTest.Domain.Handlers
{
    public class CreateReservationHandler : IAsyncRequestHandler<CreateReservationRequest, CreateReservationResponse>
    {
        private readonly IRequestValidator<CreateReservationRequest> _validator;
        private readonly IMeetupContext _context;

        public CreateReservationHandler(IRequestValidator<CreateReservationRequest> validator, IMeetupContext context)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CreateReservationResponse> Handle(CreateReservationRequest message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            if (!message.Reservation.Any())
                throw new ArgumentException("No reserved entities.");

            if (_validator.Validate(message))
            {
                var reservations = message.Reservation.Select(o => o.SeatId);

                var seats = await _context.Seats.Where(seat => reservations.Contains(seat.Id)).ToListAsync();

                await _context.Reservations.AddAsync(new Reservation { Seats = seats });
            }

            // switch to command
            return new CreateReservationResponse();
        }
    }
}
