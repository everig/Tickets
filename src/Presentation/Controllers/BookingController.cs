using Application.Bookings.Commands.CreateBooking;
using Application.Bookings.Commands.DeleteBooking;
using Application.Bookings.Commands.UpdateBooking;
using Application.Bookings.Queries.GetBooking;
using Application.Bookings.Queries.GetBookingList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Booking;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class BookingController : BaseController
    {
        private readonly IMapper _mapper;

        public BookingController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BookingListVm>> GetAll()
        {
            var query = new GetBookingListQuery { };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingVm>> Get(Guid id)
        {
            var query = new GetBookingQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookingDto createBooking)
        {
            var command = _mapper.Map<CreateBookingCommand>(createBooking);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateBookingDto updateBooking)
        {
            var command = _mapper.Map<UpdateBookingCommand>(updateBooking);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteBookingCommand { Id = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
