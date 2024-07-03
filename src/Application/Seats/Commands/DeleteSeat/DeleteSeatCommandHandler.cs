using Application.Interfaces;
using AutoMapper;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.Seats.Commands.DeleteSeat
{
    public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand, SeatId>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public DeleteSeatCommandHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<SeatId> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            var seat = await _db.Seats.FindAsync(new object[] { request.AircraftId, request.SeatNo}, cancellationToken);

            if (seat == null || seat.SeatNo != request.SeatNo || seat.AircraftId != request.AircraftId)
            {
                throw new NotFoundException(nameof(Seat), new object[] { request.AircraftId, request.SeatNo});
            }

            _db.Seats.Remove(seat);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SeatId>(seat);
        }
    }
}
