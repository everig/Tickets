using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.TicketsFlight.Queries.GetTicketFlight
{
    public class TicketFlightVm : IMapWith<TicketFlight>
    {
        public Guid Id { get; set; }
        public Guid FlightId { get; set; }
        public string Aircraft { get; set; }
        public TimeSpan ScheduledDeparture { get; set; }
        public TimeSpan ScheduledArrival { get; set; }
        public int Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TicketFlight, TicketFlightVm>()
                .ForMember(tf => tf.Aircraft, opt => opt.MapFrom(tf => tf.Aircraft.Model));
        }
    }
}
