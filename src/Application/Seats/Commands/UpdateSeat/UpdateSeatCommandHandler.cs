using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Seats.Commands.UpdateSeat
{
    public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand, SeatId>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public UpdateSeatCommandHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<SeatId> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            var seat = await _db.Seats.FindAsync(new object[] { request.AircraftId, request.SeatNo }, cancellationToken);

            if (seat == null || seat.SeatNo != request.SeatNo || seat.AircraftId != request.AircraftId)
            {
                throw new NotFoundException(nameof(Seat), new object[] { request.AircraftId, request.SeatNo });
            }

            seat.FareCondition = request.FareCondition;
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SeatId>(seat);
        }
    }
}
