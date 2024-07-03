namespace Infrastructure.EntityTypeConfiguration
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Id).HasMaxLength(10);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.Coordinates).IsRequired();
            builder.HasMany(a => a.ArrivalFlights).WithOne(f => f.ArrivalAirport).HasForeignKey(f => f.ArrivalAirportId);
            builder.HasMany(a => a.DepartureFlights).WithOne(f => f.DepartureAirport).HasForeignKey(f => f.DepartureAirportId);
        }
    }
}
