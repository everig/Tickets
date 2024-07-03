using Application.Common.Mappings;
using Application.TicketsFlight.Commands.CreateTicketFlight;
using AutoMapper;

namespace Presentation.Models.TicketFlight
{
    public class CreateTicketFlightDto : IMapWith<CreateTicketFlightCommand>
    {
        public string FlightId { get; set; }
        public Guid AircraftId { get; set; }
        public TimeSpan ScheduledDeparture { get; set; }
        public TimeSpan ScheduledArrival { get; set; }
        public int Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTicketFlightDto, CreateTicketFlightCommand>();
        }
    }
}
