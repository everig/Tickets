using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Airports.Queries.GetAirportList
{
    public class GetAirportListQueryHandler : IRequestHandler<GetAirportListQuery, AirportListVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetAirportListQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<AirportListVm> Handle(GetAirportListQuery request, CancellationToken cancellationToken)
        {
            var airportQuery = await _db.Airports
                .ProjectTo<AirportDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new AirportListVm { Airports = airportQuery };
        }
    }
}
