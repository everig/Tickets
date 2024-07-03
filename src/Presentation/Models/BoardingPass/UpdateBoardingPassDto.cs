﻿using Application.BoardingPasses.Commands.UpdateBoardingPass;
using Application.Common.Mappings;
using AutoMapper;

namespace Presentation.Models.BoardingPass
{
    public class UpdateBoardingPassDto : IMapWith<UpdateBoardingPassCommand>
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public string FlightId { get; set; }
        public Guid TicketFlightId { get; set; }
        public TimeSpan ScheduledDeparture { get; set; }
        public string BoardingNo { get; set; }
        public string SeatNo { get; set; }
        public string FareConditious { get; set; }
        public int PassengerContactData { get; set; }
        public string PassengerName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBoardingPassDto, UpdateBoardingPassCommand>();
        }
    }
}
