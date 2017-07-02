using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MeetupTest.Api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class BookingsController : Controller
    {
        private IMediator _mediator;

        public BookingsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
