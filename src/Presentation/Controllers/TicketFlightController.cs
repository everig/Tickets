using Application.TicketsFlight.Commands.CreateTicketFlight;
using Application.TicketsFlight.Commands.DeleteTicketFlight;
using Application.TicketsFlight.Commands.UpdateTicketFlight;
using Application.TicketsFlight.Queries.GetTicketFlight;
using Application.TicketsFlight.Queries.GetTicketFlightList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.TicketFlight;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class TicketFlightController : BaseController
    {
        private readonly IMapper _mapper;

        public TicketFlightController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<TicketFlightListVm>> GetAll()
        {
            var query = new GetTicketFlightListQuery { };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketFlightVm>> Get(Guid Id)
        {
            var query = new GetTicketFlightQuery { Id = Id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTicketFlightDto createTicketFlight)
        {
            var command = _mapper.Map<CreateTicketFlightCommand>(createTicketFlight);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateTicketFlightDto updateTicketFlight)
        {
            var command = _mapper.Map<UpdateTicketFlightCommand>(updateTicketFlight);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Guid>> Delete(Guid Id)
        {
            var command = new DeleteTicketFlightCommand { Id = Id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
