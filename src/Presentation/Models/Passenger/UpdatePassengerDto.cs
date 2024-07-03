using Application.Common.Mappings;
using Application.Passengers.Commands.UpdatePassenger;
using AutoMapper;

namespace Presentation.Models.Passenger
{
    public class UpdatePassengerDto : IMapWith<UpdatePassengerCommand>
    {
        public int ContactData { get; set; }
        public string PassengerName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePassengerDto, UpdatePassengerCommand>();
        }
    }
}
