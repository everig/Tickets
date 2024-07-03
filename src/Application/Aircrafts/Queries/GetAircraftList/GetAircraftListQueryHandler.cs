using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Aircrafts.Queries.GetAircraftList
{
    public class GetAircraftListQueryHandler : IRequestHandler<GetAircraftListQuery, AircraftListVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetAircraftListQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<AircraftListVm> Handle(GetAircraftListQuery request, CancellationToken cancellationToken)
        {
            var aircraftQuery = await _db.Aircrafts
                .ProjectTo<AircraftDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new AircraftListVm { Aircrafts = aircraftQuery }; 
        }
    }
}
