using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.TicketsFlight.Commands.UpdateTicketFlight
{
    public class UpdateTicketFlightCommandHandler : IRequestHandler<UpdateTicketFlightCommand, Guid>
    {
        private readonly ITicketsContext _db;

        public UpdateTicketFlightCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(UpdateTicketFlightCommand request, CancellationToken cancellationToken)
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
            var ticketFlight = await _db.TicketsFlight.FindAsync(new object[] { request.Id } ,cancellationToken);
            if (ticketFlight == null || ticketFlight.Id != request.Id)
            {
                throw new NotFoundException(nameof(TicketFlight), request.Id);
            }
            ticketFlight.FlightId = request.FlightId;
            ticketFlight.AircraftId = request.AircraftId;
            ticketFlight.ScheduledDeparture = request.ScheduledDeparture;
            ticketFlight.ScheduledArrival = request.ScheduledArrival;
            ticketFlight.Amount = request.Amount;
            ticketFlight.Flight = flight;
            ticketFlight.Aircraft = aircraft;
            await _db.SaveChangesAsync(cancellationToken);
            return ticketFlight.Id;
        }
    }
}
