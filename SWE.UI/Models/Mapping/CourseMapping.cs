using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWE.UI.Models.Domain;

namespace SWE.UI.Models.Mapping
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            //builder.HasKey(c => c.Id);
            //builder
            //    .HasMany(s => s.Students)
            //    .WithMany(b => b.Courses)
            //    .UsingEntity<CourseStudent>
            //    (bs => bs.HasOne<Student>().WithMany(),
            //     bs => bs.HasOne<Course>().WithMany())
            //    .Property(bs => bs.JoinDate)
            //    .HasDefaultValueSql("GETDATE()")
            //    ;
            //builder
            //    .HasMany(s => s.Professores)
            //    .WithMany(b => b.Courses)
            //    .UsingEntity<CourseProfessor>
            //    (bs => bs.HasOne<Professor>().WithMany(),
            //     bs => bs.HasOne<Course>().WithMany())
            //    .Property(bs => bs.JoinDate)
            //    .HasDefaultValueSql("GETDATE()")
            //    ;
        }
    }
}
