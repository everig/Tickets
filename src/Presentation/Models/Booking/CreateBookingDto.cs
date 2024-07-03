using Application.Bookings.Commands.CreateBooking;
using Application.Common.Mappings;
using AutoMapper;

namespace Presentation.Models.Booking
{
    public class CreateBookingDto : IMapWith<CreateBookingCommand>
    {
        public DateTime BookDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookingDto, CreateBookingCommand>();
        }
    }
}
