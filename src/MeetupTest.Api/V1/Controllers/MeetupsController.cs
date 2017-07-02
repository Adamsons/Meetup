using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MeetupTest.Domain;
using System.Threading.Tasks;
using System.Linq;
using System;

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
        public async Task<IEnumerable<Meetup>> Get()
        {
            var response = await _mediator.Send(new GetAllMeetupsRequest());

            return response.Meetups?.Select(meetup => new Meetup
            {
                Id = meetup.Id,
                Name = meetup.Name,
                Location = meetup.Location,
                StartTime = meetup.StartTime,
                EndTime = meetup.EndTime
            }) ?? Enumerable.Empty<Meetup>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
