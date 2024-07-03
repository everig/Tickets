using Application.Flights.Commands.CreateFlight;
using Application.Flights.Commands.DeleteFlight;
using Application.Flights.Commands.UpdateFlight;
using Application.Flights.Queries.GetFlight;
using Application.Flights.Queries.GetFlightList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Flight;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class FlightController : BaseController
    {
        private readonly IMapper _mapper;

        public FlightController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<FlightListVm>> GetAll()
        {
            var query = new GetFlightListQuery { };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightVm>> Get(string Id)
        {
            var query = new GetFlightQuery { Id = Id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateFlightDto createFlight)
        {
            var command = _mapper.Map<CreateFlightCommand>(createFlight);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<string>> Update([FromBody] UpdateFlightDto updateFlight)
        {
            var command = _mapper.Map<UpdateFlightCommand>(updateFlight);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(string Id)
        {
            var command = new DeleteFlightCommand { Id = Id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
