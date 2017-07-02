using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

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
    }
}
