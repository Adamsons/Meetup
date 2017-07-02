using MediatR;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Domain.Messages.Responses;
using MeetupTest.Domain.Validators;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace MeetupTest.Domain.Handlers
{
    public class CreateReservationHandler : IAsyncRequestHandler<CreateReservationRequest, CreateReservationResponse>
    {
        private IRequestValidator<CreateReservationRequest> _validator;
        private IDistributedCache _cache;

        public CreateReservationHandler(IRequestValidator<CreateReservationRequest> validator, IDistributedCache cache)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public Task<CreateReservationResponse> Handle(CreateReservationRequest message)
        {
            return Task.FromResult(new CreateReservationResponse());
        }
    }
}
