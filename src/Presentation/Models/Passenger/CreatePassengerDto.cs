using Application.Common.Mappings;
using Application.Passengers.Commands.CreatePassenger;
using AutoMapper;

namespace Presentation.Models.Passenger
{
    public class CreatePassengerDto : IMapWith<CreatePassengerCommand>
    {
        public int ContactData { get; set; }
        public string PassengerName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePassengerDto, CreatePassengerCommand>();
        }
    }
}
