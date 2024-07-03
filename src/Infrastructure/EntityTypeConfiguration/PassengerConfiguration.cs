namespace Infrastructure.EntityTypeConfiguration
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(p => p.ContactData);
            builder.HasIndex(p => p.ContactData);
            builder.Property(p => p.ContactData).HasMaxLength(10);
            builder.Property(p => p.ContactData).IsRequired();
            builder.Property(p => p.PassengerName).IsRequired();
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasMany(p => p.BoardingPasess).WithOne(bp => bp.Passenger).HasForeignKey(bp => bp.PassengerContactData);
        }
    }
}
