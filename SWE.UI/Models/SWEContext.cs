using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models
{
    public class SWEContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Facultie> Faculties { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Student> Studentes { get; set; }
        public DbSet<StudentLog> StudentLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = .\khairy;Initial catalog=SWEDB;Integrated Security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<StudentLog>().HasKey(s => s.UserName);
        }
    }
}
