using MediatR;
using MeetupTest.Api.V1.Models;
using MeetupTest.Api.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpPut]
        [ValidateModel]
        [ProducesResponseType(204), ProducesResponseType(400), ProducesResponseType(409)]
        public async Task<IActionResult> Put([FromBody]Booking booking)
        {
            await Task.FromResult(0);
            return new OkResult();
        }
    }
}
