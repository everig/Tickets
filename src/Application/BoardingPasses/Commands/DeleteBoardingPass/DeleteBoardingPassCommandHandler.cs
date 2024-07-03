using Application.Interfaces;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.BoardingPasses.Commands.DeleteBoardingPass
{
    public class DeleteBoardingPassCommandHandler : IRequestHandler<DeleteBoardingPassCommand, Guid>
    {
        private readonly ITicketsContext _db;

        public DeleteBoardingPassCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(DeleteBoardingPassCommand request, CancellationToken cancellationToken)
        {
            var ticketFlight = await _db.TicketsFlight.FindAsync(new object[] { request.TicketFlightId }, cancellationToken);
            if (ticketFlight == null || ticketFlight.Id != request.TicketFlightId)
            {
                throw new NotFoundException(nameof(TicketsFlight), request.TicketFlightId);
            }
            var boardingPass = await _db.BoardingPasses.FindAsync(new object[] { request.Id }, cancellationToken);
            if (boardingPass == null || boardingPass.Id != request.Id) 
            {
                throw new NotFoundException(nameof(BoardingPass), request.Id);
            }
            ticketFlight.Amount -= 1;
            _db.BoardingPasses.Remove(boardingPass);
            await _db.SaveChangesAsync(cancellationToken);
            return boardingPass.Id;
        }
    }
}
