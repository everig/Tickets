using Application.Airports.Commands.CreateAirport;
using Application.Airports.Commands.DeleteAirport;
using Application.Airports.Commands.UpdateAirport;
using Application.Airports.Queries.GetAirport;
using Application.Airports.Queries.GetAirportList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Airport;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AirportController : BaseController
    {
        private readonly IMapper _mapper;

        public AirportController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<AirportListVm>> GetAll()
        {
            var query = new GetAirportListQuery { };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AirportVm>> Get(Guid id)
        {
            var query = new GetAirportQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAirportDto createAirport)
        {
            var command = _mapper.Map<CreateAirportCommand>(createAirport);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateAirportDto updateAirport)
        {
            var command = _mapper.Map<UpdateAirportCommand>(updateAirport);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteAirportCommand { Id = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
