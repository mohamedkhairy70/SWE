using Microsoft.EntityFrameworkCore;
using SWE.UI.Models.Domain;
using SWE.UI.Models.Mapping;
using System.Reflection;

namespace SWE.UI.Models
{
    public class SWEContext : DbContext
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Facultie> Faculties { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Student> Studentes { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }
        public DbSet<StudentLog> StudentLog { get; set; }
        //public DbSet<DepartmentProfessor> DepartmentProfessores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = .\khairy;Initial catalog=SWEDB;Integrated Security=true");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Course>()
               .HasMany(s => s.Students)
               .WithMany(b => b.Courses)
               .UsingEntity<CourseStudent>
               (bs => bs.HasOne<Student>().WithMany(),
                bs => bs.HasOne<Course>().WithMany())
               .Property(bs => bs.JoinDate)
               .HasDefaultValueSql("GETDATE()")
               ;
            modelBuilder.Entity<Course>()
                .HasMany(s => s.Professores)
                .WithMany(b => b.Courses)
                .UsingEntity<CourseProfessor>
                (bs => bs.HasOne<Professor>().WithMany(),
                 bs => bs.HasOne<Course>().WithMany())
                .Property(bs => bs.JoinDate)
                .HasDefaultValueSql("GETDATE()")
                ;

            modelBuilder.Entity<Department>()
                .HasOne(s => s.ProfessorManage)
                .WithOne(b => b.DepartmentProfessor);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.StudentLog)
                .WithOne(b => b.Student);

            modelBuilder.Entity<Professor>()
                .HasOne(s => s.ProfessorManage)
                .WithOne();

            modelBuilder.Entity<Department>()
                .HasMany(s => s.Professores)
                .WithOne(d => d.Department).HasForeignKey(D => D.DepartmentsId);


            modelBuilder.Entity<StudentLog>().HasKey(f => f.UserName);

            modelBuilder.Entity<Course>().Property(f => f.IsDelete).HasDefaultValue(false);
            modelBuilder.Entity<Department>().Property(f => f.IsDelete).HasDefaultValue(false);
            modelBuilder.Entity<Facultie>().Property(f => f.IsDelete).HasDefaultValue(false);
            modelBuilder.Entity<Professor>().Property(f => f.IsDelete).HasDefaultValue(false);
            modelBuilder.Entity<Student>().Property(f => f.IsDelete).HasDefaultValue(false);
        }
    }
}
