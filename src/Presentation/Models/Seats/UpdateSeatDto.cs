using Application.Common.Mappings;
using Application.Seats.Commands.UpdateSeat;
using AutoMapper;

namespace Presentation.Models.Seats
{
    public class UpdateSeatDto : IMapWith<UpdateSeatCommand>
    {
        public Guid AircraftId { get; set; }
        public string SeatNo { get; set; }
        public string FareCondition { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSeatDto, UpdateSeatCommand>();
        }
    }
}
