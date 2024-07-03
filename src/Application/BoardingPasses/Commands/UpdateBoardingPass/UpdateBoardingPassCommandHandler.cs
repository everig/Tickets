using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.BoardingPasses.Commands.UpdateBoardingPass
{
    public class UpdateBoardingPassCommandHandler : IRequestHandler<UpdateBoardingPassCommand, Guid>
    {
        private readonly ITicketsContext _db;

        public UpdateBoardingPassCommandHandler(ITicketsContext db) => _db = db;

        public async Task<Guid> Handle(UpdateBoardingPassCommand request, CancellationToken cancellationToken)
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
            var boardingPass = await _db.BoardingPasses.FindAsync(new object[] { request.Id }, cancellationToken);
            if (boardingPass == null || boardingPass.Id != request.Id)
            {
                throw new NotFoundException(nameof(BoardingPass), request.Id);
            }
            if (boardingPass.TicketFlight != ticketFlight)
            {
                boardingPass.TicketFlight.Amount -= 1;
                ticketFlight.Amount += 1;
            }
            boardingPass.BookingId = request.BookingId;
            boardingPass.FlightId = request.FlightId;
            boardingPass.TicketFlightId = request.TicketFlightId;
            boardingPass.ScheduledDeparture = request.ScheduledDeparture;
            boardingPass.BoardingNo = request.BoardingNo;
            boardingPass.SeatNo = request.SeatNo;
            boardingPass.FareConditious = request.FareConditious;
            boardingPass.PassengerContactData = request.PassengerContactData;
            boardingPass.PassengerName = request.PassengerName;
            boardingPass.Booking = booking;
            boardingPass.Passenger = passenger;
            boardingPass.TicketFlight = ticketFlight;
            boardingPass.Flight = flight;
            await _db.SaveChangesAsync(cancellationToken);
            return boardingPass.Id;
        }
    }
}
