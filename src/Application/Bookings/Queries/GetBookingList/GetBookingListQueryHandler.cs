using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Bookings.Queries.GetBookingList
{
    public class GetBookingListQueryHandler : IRequestHandler<GetBookingListQuery, BookingListVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetBookingListQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<BookingListVm> Handle(GetBookingListQuery request, CancellationToken cancellationToken)
        {
            var bookingQuery = await _db.Bookings
                .ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new BookingListVm { Bookings = bookingQuery };
        }
    }
}
