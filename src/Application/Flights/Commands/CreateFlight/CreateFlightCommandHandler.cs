using Application.Interfaces;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.Flights.Commands.CreateFlight
{
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, string>
    {
        private readonly ITicketsContext _db;

        public CreateFlightCommandHandler(ITicketsContext db) => _db = db;

        public async Task<string> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var departureAirport = await _db.Airports.FindAsync(new object[] { request.DepartureAirportId } ,cancellationToken);
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
            var flight = new Flight
            {
                ScheduledDeparture = request.ScheduledDeparture,
                ScheduledArrival = request.ScheduledArrival,
                DepartureAirportId = request.DepartureAirportId,
                ArrivalAirportId = request.ArrivalAirportId,
                Status = request.Status,
                AircraftId = request.AircraftId,
                ActualDeparture = request.ActualDeparture,
                ActualArrival = request.ActualArrival,
                DepartureAirport = departureAirport,
                ArrivalAirport = arrivalAirport,
                Aircraft = aircraft
            };
            await _db.Flights.AddAsync(flight, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return flight.Id;
        }
    }
}
