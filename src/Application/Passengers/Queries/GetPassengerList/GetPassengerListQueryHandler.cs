using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Passengers.Queries.GetPassengerList
{
    public class GetPassengerListQueryHandler : IRequestHandler<GetPassengerListQuery, PassengerListVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetPassengerListQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PassengerListVm> Handle(GetPassengerListQuery request, CancellationToken cancellationToken)
        {
            var passengerQuery = await _db.Passengers
                .ProjectTo<PassengerDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new PassengerListVm { Passengers = passengerQuery };
        }
    }
}
