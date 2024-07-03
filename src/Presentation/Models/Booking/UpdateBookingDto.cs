using Application.Bookings.Commands.UpdateBooking;
using Application.Common.Mappings;
using AutoMapper;

namespace Presentation.Models.Booking
{
    public class UpdateBookingDto : IMapWith<UpdateBookingCommand>
    {
        public Guid Id { get; set; }
        public DateTime BookDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookingDto, UpdateBookingCommand>();
        }
    }
}
