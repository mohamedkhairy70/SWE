using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWE.UI.Models.Domain;

namespace SWE.UI.Models.Mapping
{
    public class FacultieMapping : IEntityTypeConfiguration<Facultie>
    {
        public void Configure(EntityTypeBuilder<Facultie> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name).HasMaxLength(250);
        }
    }
}
