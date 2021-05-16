using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWE.UI.Models.Domain;

namespace SWE.UI.Models.Mapping
{
    public class StudentLogMapping : IEntityTypeConfiguration<StudentLog>
    {
        public void Configure(EntityTypeBuilder<StudentLog> builder)
        {
            //builder.HasKey(f => f.UserName);

            //builder.Property(f => f.UserName).HasMaxLength(200);
        }
    }
}
