using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWE.UI.Models.Domain;

namespace SWE.UI.Models.Mapping
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

           // builder.Property(f => f.IsDelete).HasDefaultValue(false);
        }
    }
}
