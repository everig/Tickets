using Application.Interfaces;
using AutoMapper;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.Bookings.Queries.GetBooking
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetBookingQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<BookingVm> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var booking = await _db.Bookings.FindAsync(new object[] { request.Id },cancellationToken);
            if (booking == null || booking.Id != request.Id)
            {
                throw new NotFoundException(nameof(Booking), request.Id);
            }
            return _mapper.Map<BookingVm>(booking);
        }
    }
}
