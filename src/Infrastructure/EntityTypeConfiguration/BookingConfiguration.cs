namespace Infrastructure.EntityTypeConfiguration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Id).HasMaxLength(8);
            builder.Property(a => a.BookDate).IsRequired();
            builder.HasOne(b => b.BoardingPass).WithOne(bp => bp.Booking).HasForeignKey<BoardingPass>(bp => bp.BookingId);
        }
    }
}
