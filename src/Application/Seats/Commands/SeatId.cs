using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Seats.Commands
{
    public class SeatId : IMapWith<Seat>
    {
        public Guid AircraftId { get; set; }
        public string SeatNo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seat, SeatId>();
        }
    }
}
