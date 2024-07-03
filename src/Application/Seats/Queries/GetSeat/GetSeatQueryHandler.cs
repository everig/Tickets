using Application.Interfaces;
using AutoMapper;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.Seats.Queries.GetSeat
{
    public class GetSeatQueryHandler : IRequestHandler<GetSeatQuery, SeatVm>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public GetSeatQueryHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<SeatVm> Handle(GetSeatQuery request, CancellationToken cancellationToken)
        {
            var seat = await _db.Seats.FindAsync(new object[] { request.AircraftId, request.SeatNo } ,cancellationToken);
            if (seat == null || seat.SeatNo != request.SeatNo || seat.AircraftId != request.AircraftId)
            {
                throw new NotFoundException(nameof(Seat), new object[] { request.AircraftId, request.SeatNo });
            }
            return _mapper.Map<SeatVm>(seat);
        }
    }
}
