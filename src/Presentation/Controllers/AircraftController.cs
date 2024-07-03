using Application.Aircrafts.Commands.CreateAircraft;
using Application.Aircrafts.Commands.DeleteAircraft;
using Application.Aircrafts.Commands.UpdateAircraft;
using Application.Aircrafts.Queries.GetAircraft;
using Application.Aircrafts.Queries.GetAircraftList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Aircraft;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AircraftController : BaseController
    {
        private readonly IMapper _mapper;

        public AircraftController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<AircraftListVm>> GetAll()
        {
            var query = new GetAircraftListQuery { };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<AircraftVm>> Get(Guid Id)
        {
            var query = new GetAircraftQuery { Id = Id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAircraftDto createAircraft)
        {
            var command = _mapper.Map<CreateAircraftCommand>(createAircraft);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateAircraftDto updateAircraft)
        {
            var command = _mapper.Map<UpdateAircraftCommand>(updateAircraft);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Guid>> Delete(Guid Id)
        {
            var command = new DeleteAircraftCommand { Id = Id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
