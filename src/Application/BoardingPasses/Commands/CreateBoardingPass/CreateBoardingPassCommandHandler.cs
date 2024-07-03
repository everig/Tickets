using Application.Interfaces;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.BoardingPasses.Commands.CreateBoardingPass
{
    public class CreateBoardingPassCommandHandler : IRequestHandler<CreateBoardingPassCommand, Guid>
    {
        private readonly ITicketsContext _db;

        public CreateBoardingPassCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(CreateBoardingPassCommand request, CancellationToken cancellationToken)
        {
            var passenger = await _db.Passengers.FindAsync(new object[] { request.PassengerContactData }, cancellationToken);
            if (passenger == null || passenger.ContactData != request.PassengerContactData)
            {
                throw new NotFoundException(nameof(Passenger), request.PassengerContactData);
            }
            var flight = await _db.Flights.FindAsync(new object[] { request.FlightId }, cancellationToken);
            if (flight == null || flight.Id != request.FlightId)
            {
                throw new NotFoundException(nameof(Flight), request.FlightId);
            }
            var booking = await _db.Bookings.FindAsync(new object[] { request.BookingId }, cancellationToken);
            if (booking == null || booking.Id != request.BookingId)
            {
                throw new NotFoundException(nameof(Booking), request.BookingId);
            }
            var ticketFlight = await _db.TicketsFlight.FindAsync(new object[] { request.TicketFlightId }, cancellationToken);
            if (ticketFlight == null || ticketFlight.Id != request.TicketFlightId)
            {
                throw new NotFoundException(nameof(TicketFlight), request.TicketFlightId);
            }
            ticketFlight.Amount += 1;
            var boardingPass = new BoardingPass
            {
                BookingId = request.BookingId,
                FlightId = request.FlightId,
                TicketFlightId = request.TicketFlightId,
                ScheduledDeparture = request.ScheduledDeparture,
                BoardingNo = request.BoardingNo,
                SeatNo = request.SeatNo,
                FareConditious = request.FareConditious,
                PassengerContactData = request.PassengerContactData,
                PassengerName = request.PassengerName,
                Passenger = passenger,
                Booking = booking,
                TicketFlight = ticketFlight,
                Flight = flight
            };
            await _db.BoardingPasses.AddAsync(boardingPass, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return boardingPass.Id;
        }
    }
}
