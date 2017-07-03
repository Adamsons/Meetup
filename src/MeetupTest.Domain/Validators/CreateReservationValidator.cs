using System;
using MediatR;
using MeetupTest.Domain.Messages.Requests;

namespace MeetupTest.Domain.Validators
{
    public interface IRequestValidator<T>
    {
        bool Validate(T request);
    }


    public class CreateReservationValidator : IRequestValidator<CreateReservationRequest>
    {
        public bool Validate(CreateReservationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
