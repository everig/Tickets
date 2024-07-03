using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Application.Common.Exceptions;
using AutoMapper;

namespace Application.Seats.Commands.CreateSeat
{
    public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, SeatId>
    {
        private readonly ITicketsContext _db;
        private readonly IMapper _mapper;

        public CreateSeatCommandHandler(ITicketsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<SeatId> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            var aircraft = await _db.Aircrafts.FindAsync(new object[] { request.AircraftId } ,cancellationToken);
            
            if (aircraft == null)
            {
                throw new NotFoundException(nameof(Aircraft), request.AircraftId);
            }

            var seat = new Seat
            {
                AircraftId = request.AircraftId,
                SeatNo = request.SeatNo,
                FareCondition = request.FareCondition,
                Aircraft = aircraft
            };

            await _db.Seats.AddAsync(seat);
            await _db.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SeatId>(seat);
        }
    }
}
