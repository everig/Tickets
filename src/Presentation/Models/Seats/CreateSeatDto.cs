using Application.Common.Mappings;
using Application.Seats.Commands.CreateSeat;
using AutoMapper;

namespace Presentation.Models.Seats
{
    public class CreateSeatDto : IMapWith<CreateSeatCommand>
    {
        public Guid AircraftId { get; set; }
        public string SeatNo { get; set; }
        public string FareCondition { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSeatDto, CreateSeatCommand>();
        }
    }
}
