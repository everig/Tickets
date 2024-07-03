using Application.Seats.Commands;
using Application.Seats.Commands.CreateSeat;
using Application.Seats.Commands.DeleteSeat;
using Application.Seats.Commands.UpdateSeat;
using Application.Seats.Queries.GetSeat;
using Application.Seats.Queries.GetSeatList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Seats;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class SeatController : BaseController
    {
        private readonly IMapper _mapper;

        public SeatController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<SeatListVm>> GetAll()
        {
            var query = new GetSeatListQuery { };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{AircraftId}, {SeatNo}")]
        public async Task<ActionResult<SeatId>> Get(SeatId seatId)
        {
            var query = new GetSeatQuery
            {
                AircraftId = seatId.AircraftId,
                SeatNo = seatId.SeatNo
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<SeatId>> Create([FromBody] CreateSeatDto createSeat)
        {
            var command = _mapper.Map<CreateSeatCommand>(createSeat);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<SeatId>> Update([FromBody] UpdateSeatDto updateSeat)
        {
            var command = _mapper.Map<UpdateSeatCommand>(updateSeat);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{AircraftId}, {SeatNo}")]
        public async Task<ActionResult<SeatId>> Delete(SeatId seatId)
        {
            var command = new DeleteSeatCommand
            {
                AircraftId = seatId.AircraftId,
                SeatNo = seatId.SeatNo
            };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
