﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWE.UI.Models;

namespace SWE.UI.Migrations
{
    [DbContext(typeof(SWEContext))]
    partial class SWEContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SWE.UI.Models.Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("EvaluationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EvaluationId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.CourseProfessor", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("CourseId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("CourseProfessor");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.CourseStudent", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FacultieId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfessorManageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacultieId");

                    b.HasIndex("ProfessorManageId")
                        .IsUnique()
                        .HasFilter("[ProfessorManageId] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Resualt")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Evaluation");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Facultie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("EvaluationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfessorManageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EvaluationId");

                    b.HasIndex("ProfessorManageId")
                        .IsUnique()
                        .HasFilter("[ProfessorManageId] IS NOT NULL");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Leval")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Studentes");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.StudentLog", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EvaluationId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("UserName");

                    b.HasIndex("EvaluationId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentLog");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Course", b =>
                {
                    b.HasOne("SWE.UI.Models.Domain.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("SWE.UI.Models.Domain.Evaluation", null)
                        .WithMany("Courses")
                        .HasForeignKey("EvaluationId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.CourseProfessor", b =>
                {
                    b.HasOne("SWE.UI.Models.Domain.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWE.UI.Models.Domain.Professor", null)
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.CourseStudent", b =>
                {
                    b.HasOne("SWE.UI.Models.Domain.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWE.UI.Models.Domain.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Department", b =>
                {
                    b.HasOne("SWE.UI.Models.Domain.Facultie", "Facultie")
                        .WithMany("Departments")
                        .HasForeignKey("FacultieId");

                    b.HasOne("SWE.UI.Models.Domain.Professor", "ProfessorManage")
                        .WithOne("DepartmentProfessor")
                        .HasForeignKey("SWE.UI.Models.Domain.Department", "ProfessorManageId");

                    b.Navigation("Facultie");

                    b.Navigation("ProfessorManage");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Professor", b =>
                {
                    b.HasOne("SWE.UI.Models.Domain.Department", "Department")
                        .WithMany("Professores")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("SWE.UI.Models.Domain.Evaluation", null)
                        .WithMany("Professors")
                        .HasForeignKey("EvaluationId");

                    b.HasOne("SWE.UI.Models.Domain.Professor", "ProfessorManage")
                        .WithOne()
                        .HasForeignKey("SWE.UI.Models.Domain.Professor", "ProfessorManageId");

                    b.Navigation("Department");

                    b.Navigation("ProfessorManage");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.StudentLog", b =>
                {
                    b.HasOne("SWE.UI.Models.Domain.Evaluation", null)
                        .WithMany("StudentLog")
                        .HasForeignKey("EvaluationId");

                    b.HasOne("SWE.UI.Models.Domain.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Professores");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Evaluation", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Professors");

                    b.Navigation("StudentLog");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Facultie", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("SWE.UI.Models.Domain.Professor", b =>
                {
                    b.Navigation("DepartmentProfessor");
                });
#pragma warning restore 612, 618
        }
    }
}
