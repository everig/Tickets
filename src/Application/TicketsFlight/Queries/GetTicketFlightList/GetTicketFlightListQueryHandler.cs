using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TicketsFlight.Queries.GetTicketFlightList
{
    public class GetTicketFlightListQueryHandler : IRequestHandler<GetTicketFlightListQuery, TicketFlightListVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetTicketFlightListQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TicketFlightListVm> Handle(GetTicketFlightListQuery request, CancellationToken cancellationToken)
        {
            var ticketFlightQuery = await _db.TicketsFlight
                .ProjectTo<TicketFlightDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new TicketFlightListVm { TicketsFlight = ticketFlightQuery };
        }
    }
}
