using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Airports.Queries.GetAirport
{
    public class GetAirportQueryHandler : IRequestHandler<GetAirportQuery, AirportVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetAirportQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<AirportVm> Handle(GetAirportQuery request, CancellationToken cancellationToken)
        {
            var airport = await _db.Airports.FindAsync(new object[] { request.Id }, cancellationToken);
            if (airport == null || airport.Id != request.Id)
            {
                throw new NotFoundException(nameof(Airport), request.Id);
            }
            return _mapper.Map<AirportVm>(airport);
        }
    }
}
