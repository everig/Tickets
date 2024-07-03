using Application.Interfaces;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;


namespace Application.TicketsFlight.Commands.CreateTicketFlight
{
    public class CreateTicketFlightCommandHandler : IRequestHandler<CreateTicketFlightCommand, Guid>
    {
        private readonly ITicketsContext _db;

        public CreateTicketFlightCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(CreateTicketFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = await _db.Flights.FindAsync(new object[] { request.FlightId }, cancellationToken);
            if (flight == null || flight.Id != request.FlightId)
            {
                throw new NotFoundException(nameof(Flight), request.FlightId);
            }
            var aircraft = await _db.Aircrafts.FindAsync(new object[] { request.AircraftId }, cancellationToken);
            if (aircraft == null || aircraft.Id != request.AircraftId)
            {
                throw new NotFoundException(nameof(Aircraft), request.AircraftId);
            }
            var ticketFlight = new TicketFlight
            {
                FlightId = request.FlightId,
                AircraftId = request.AircraftId,
                ScheduledDeparture = request.ScheduledDeparture,
                ScheduledArrival = request.ScheduledArrival,
                Amount = request.Amount,
                Flight = flight,
                Aircraft = aircraft
            };
            await _db.TicketsFlight.AddAsync(ticketFlight, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return ticketFlight.Id;
        }
    }
}
