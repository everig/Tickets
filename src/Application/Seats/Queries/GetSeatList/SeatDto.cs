using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Seats.Queries.GetSeatList
{
    public class SeatDto : IMapWith<Seat>
    {
        public string AircraftModel { get; set; }
        public string SeatNo { get; set; }
        public string FareCondition { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seat, SeatDto>()
                .ForMember(seatVm => seatVm.AircraftModel, opt => opt.MapFrom(seat => seat.Aircraft.Model));
        }
    }
}
