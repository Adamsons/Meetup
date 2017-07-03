using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System.Linq;
using System;
using MeetupTest.Domain.Messages.Requests;
using MeetupTest.Api.V1.Models;

namespace MeetupTest.Api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class MeetupsController : Controller
    {
        private IMediator _mediator;

        public MeetupsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Meetup>), 200)]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetMeetupsRequest());

            return new OkObjectResult(response.Meetups?.Select(meetup => new Meetup
            {
                Name = meetup.Name,
                Location = meetup.Location,
                StartTime = meetup.StartTime,
                EndTime = meetup.EndTime
            }) ?? Enumerable.Empty<Meetup>());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(Meetup), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetMeetupRequest(id));

            if (response.Meetup == null)
                return new NotFoundResult();

            return new OkObjectResult(new Meetup
            {
                Name = response.Meetup.Name,
                StartTime = response.Meetup.StartTime,
                EndTime = response.Meetup.EndTime,
                Location = response.Meetup.Location
            });
        }
    }
}
