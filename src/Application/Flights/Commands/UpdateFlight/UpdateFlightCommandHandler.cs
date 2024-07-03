using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Flights.Commands.UpdateFlight
{
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand, string>
    {
        private readonly ITicketsContext _db;

        public UpdateFlightCommandHandler(ITicketsContext db) => _db = db;

        public async Task<string> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var departureAirport = await _db.Airports.FindAsync(new object[] { request.DepartureAirportId }, cancellationToken);
            if (departureAirport == null || departureAirport.Id != request.DepartureAirportId)
            {
                throw new NotFoundException(nameof(Airport), request.DepartureAirportId);
            }
            var arrivalAirport = await _db.Airports.FindAsync(new object[] { request.ArrivalAirportId }, cancellationToken);
            if (arrivalAirport == null || arrivalAirport.Id != request.ArrivalAirportId)
            {
                throw new NotFoundException(nameof(Airport), request.ArrivalAirportId);
            }
            var aircraft = await _db.Aircrafts.FindAsync(new object[] { request.AircraftId }, cancellationToken);
            if (aircraft == null || aircraft.Id != request.AircraftId)
            {
                throw new NotFoundException(nameof(Aircraft), request.AircraftId);
            }
            var flight = await _db.Flights.FindAsync(new object[] { request.Id }, cancellationToken);
            if (flight == null || flight.Id != request.Id)
            {
                throw new NotFoundException(nameof(Flight), request.Id);
            }
            flight.ScheduledDeparture = request.ScheduledDeparture;
            flight.ScheduledArrival = request.ScheduledArrival;
            flight.DepartureAirportId = request.DepartureAirportId;
            flight.ArrivalAirportId = request.ArrivalAirportId;
            flight.Status = request.Status;
            flight.AircraftId = request.AircraftId;
            flight.ActualDeparture = request.ActualDeparture;
            flight.ActualArrival = request.ActualArrival;
            flight.DepartureAirport = departureAirport;
            flight.ArrivalAirport = arrivalAirport;
            flight.Aircraft = aircraft;
            await _db.SaveChangesAsync(cancellationToken);
            return flight.Id;
        }
    }
}
