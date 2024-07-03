namespace Infrastructure.EntityTypeConfiguration
{
    public class BoardingPassConfiguration : IEntityTypeConfiguration<BoardingPass>
    {
        public void Configure(EntityTypeBuilder<BoardingPass> builder)
        {
            builder.HasKey(bp => bp.Id);
            builder.HasIndex(bp => bp.Id);
            builder.Property(bp => bp.Id).ValueGeneratedOnAdd();
            builder.Property(bp => bp.Id).HasMaxLength(10);
            builder.Property(bp => bp.BookingId).IsRequired();
            builder.Property(bp => bp.FlightId).IsRequired();
            builder.Property(bp => bp.TicketFlightId).IsRequired();
            builder.Property(bp => bp.ScheduledDeparture).IsRequired();
            builder.Property(bp => bp.BoardingNo).IsRequired();
            builder.Property(bp => bp.SeatNo).IsRequired();
            builder.Property(bp => bp.PassengerContactData).IsRequired();
            builder.Property(bp => bp.PassengerName).IsRequired();
            builder.HasOne(bp => bp.Passenger).WithMany(p => p.BoardingPasess).HasForeignKey(bp => bp.PassengerContactData);
            builder.HasOne(bp => bp.TicketFlight).WithMany(tf => tf.BoardingPasess).HasForeignKey(bp => bp.TicketFlightId);
            builder.HasOne(bp => bp.Flight).WithMany().HasForeignKey(bp => bp.FlightId);
            builder.HasOne(bp => bp.Booking).WithOne(b => b.BoardingPass).HasForeignKey<BoardingPass>(bp => bp.BookingId);
            
        }
    }
}
