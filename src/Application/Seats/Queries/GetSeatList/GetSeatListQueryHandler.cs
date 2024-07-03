using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Seats.Queries.GetSeatList
{
    public class GetSeatListQueryHandler : IRequestHandler<GetSeatListQuery, SeatListVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetSeatListQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<SeatListVm> Handle(GetSeatListQuery request, CancellationToken cancellationToken)
        {
            var seatQuery = await _db.Seats
                .ProjectTo<SeatDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new SeatListVm { Seats = seatQuery };
        }
    }
}
