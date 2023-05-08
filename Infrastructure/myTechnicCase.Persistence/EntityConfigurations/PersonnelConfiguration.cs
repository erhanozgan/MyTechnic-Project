using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using myTechnicCase.Domain.Entity;

namespace myTechnicCase.Persistence.EntityConfigurations;

public class PersonnelConfiguration : IEntityTypeConfiguration<Personnel>
{
    public void Configure(EntityTypeBuilder<Personnel> builder)
    {
        builder.Property(a => a.PersonnelCode).IsRequired();
        builder.Property(a => a.Name).IsRequired();
        builder.Property(a => a.Surname).IsRequired();
        builder.Property(a => a.UserName).IsRequired();
        builder.Property(a => a.Email).IsRequired();
        builder.Property(a => a.Phone).IsRequired();
        builder.Property(a => a.Address).IsRequired();
        builder.Property(a => a.Title).IsRequired();
        builder.Property(a => a.Active).IsRequired();
        builder.Property(a => a.Active).HasDefaultValue(true);
    }
}