namespace Infrastructure.EntityTypeConfiguration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.Id);
            builder.HasIndex(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(f => f.Id).HasMaxLength(10);
            builder.Property(f => f.ScheduledDeparture).IsRequired();
            builder.Property(f => f.ScheduledArrival).IsRequired();
            builder.Property(f => f.DepartureAirportId).IsRequired();
            builder.Property(f => f.ArrivalAirportId).IsRequired();
            builder.Property(f => f.Status).IsRequired();
            builder.Property(f => f.AircraftId).IsRequired();
            builder.HasOne(f => f.ArrivalAirport).WithMany(a => a.ArrivalFlights).HasForeignKey(f => f.ArrivalAirportId);
            builder.HasOne(f => f.DepartureAirport).WithMany(a => a.DepartureFlights).HasForeignKey(f => f.DepartureAirportId);
            builder.HasOne(f => f.Aircraft).WithMany(a => a.Flights).HasForeignKey(f => f.AircraftId);
            builder.HasMany(f => f.TicketsFlight).WithOne(tf => tf.Flight).HasForeignKey(tf => tf.FlightId);
        }
    }
}
