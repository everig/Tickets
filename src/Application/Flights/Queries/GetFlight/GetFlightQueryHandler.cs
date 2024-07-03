using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Flights.Queries.GetFlight
{
    public class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, FlightVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetFlightQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<FlightVm> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            var flight = await _db.Flights.FindAsync(new object[] { request.Id }, cancellationToken);
            if (flight == null || flight.Id != request.Id)
            {
                throw new NotFoundException(nameof(flight), request.Id);
            }
            return _mapper.Map<FlightVm>(flight);
        }
    }
}
