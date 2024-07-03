using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Flights.Queries.GetFlightList
{
    public class GetFlightListQueryHandler : IRequestHandler<GetFlightListQuery, FlightListVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetFlightListQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<FlightListVm> Handle(GetFlightListQuery request, CancellationToken cancellationToken)
        {
            var flightQuery = await _db.Flights
                .ProjectTo<FlightDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new FlightListVm { Flights = flightQuery };
        }
    }
}
