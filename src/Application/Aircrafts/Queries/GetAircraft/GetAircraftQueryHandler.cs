

using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Aircrafts.Queries.GetAircraft
{
    public class GetAircraftQueryHandler : IRequestHandler<GetAircraftQuery, AircraftVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetAircraftQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<AircraftVm> Handle(GetAircraftQuery request, CancellationToken cancellationToken)
        {
            var aircraft = await _db.Aircrafts.FindAsync(new object[] { request.Id }, cancellationToken);
            if (aircraft == null || aircraft.Id != request.Id)
            {
                throw new NotFoundException(nameof(Aircraft), request.Id);
            }

            return _mapper.Map<AircraftVm>(aircraft);
        }
    }
}
