using Application.Passengers.Commands.CreatePassenger;
using Application.Passengers.Commands.DeletePassenger;
using Application.Passengers.Commands.UpdatePassenger;
using Application.Passengers.Queries.GetPassenger;
using Application.Passengers.Queries.GetPassengerList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Passenger;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class PassengerController : BaseController
    {
        private readonly IMapper _mapper;

        public PassengerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PassengerListVm>> GetAll()
        {
            var query = new GetPassengerListQuery { };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{ContactData}")]
        public async Task<ActionResult<PassengerVm>> Get(int contactData)
        {
            var query = new GetPassengerQuery { ContactData = contactData };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePassengerDto createPassenger)
        {
            var command = _mapper.Map<CreatePassengerCommand>(createPassenger);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromBody] UpdatePassengerDto updatePassenger)
        {
            var command = _mapper.Map<UpdatePassengerCommand>(updatePassenger);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{ContactData}")]
        public async Task<ActionResult<int>> Delete(int contactData)
        {
            var command = new DeletePassengerCommand { ContactData = contactData };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
