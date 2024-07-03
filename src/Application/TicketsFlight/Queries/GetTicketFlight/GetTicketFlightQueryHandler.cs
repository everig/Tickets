using Application.Interfaces;
using AutoMapper;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.TicketsFlight.Queries.GetTicketFlight
{
    public class GetTicketFlightQueryHandler : IRequestHandler<GetTicketFlightQuery, TicketFlightVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetTicketFlightQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TicketFlightVm> Handle(GetTicketFlightQuery request, CancellationToken cancellationToken)
        {
            var ticketFlight = await _db.TicketsFlight.FindAsync(new object[] { request.Id }, cancellationToken);
            if (ticketFlight == null || ticketFlight.Id != request.Id)
            {
                throw new NotFoundException(nameof(TicketFlight), request.Id);
            }
            return _mapper.Map<TicketFlightVm>(ticketFlight);
        }
    }
}
