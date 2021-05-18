using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWE.UI.Models.Domain;

namespace SWE.UI.Models.Mapping
{
    public class DepartmentMapping : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            //builder.Property(f => f.IsDelete).HasDefaultValue(false);
        }
    }
}
