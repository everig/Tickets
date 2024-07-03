using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Seats.Queries.GetSeat
{
    public class SeatVm : IMapWith<Seat>
    {
        public string AircraftModel { get; set; }
        public string SeatNo { get; set; }
        public string FareCondition { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seat, SeatVm>()
                .ForMember(seatVm => seatVm.AircraftModel, opt => opt.MapFrom(seat => seat.Aircraft.Model));
        }
    }
}
