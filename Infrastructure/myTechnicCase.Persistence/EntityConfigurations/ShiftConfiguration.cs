using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using myTechnicCase.Domain.Entity;

namespace myTechnicCase.Persistence.EntityConfigurations;

public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
{
    public void Configure(EntityTypeBuilder<Shift> builder)
    {
        builder.Property(a => a.Name).IsRequired();
        builder.Property(a => a.Type).IsRequired();
        builder.Property(a => a.StartDate).IsRequired();
        builder.Property(a => a.EndDate).IsRequired();
    }
}