﻿// <auto-generated />
using System;
using Examination_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examination_System.Migrations
{
    [DbContext(typeof(ITIContext))]
    [Migration("20240316234743_nullableImageID")]
    partial class nullableImageID
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examination_System.Models.Course", b =>
                {
                    b.Property<int>("Course_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Course_ID"));

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Course_ID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Examination_System.Models.Exam", b =>
                {
                    b.Property<int>("Exam_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Exam_ID"));

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.HasKey("Exam_ID");

                    b.HasIndex("Course_ID")
                        .IsUnique();

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("Examination_System.Models.Instructor", b =>
                {
                    b.Property<int>("Ins_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ins_Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Img_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasKey("Ins_Id");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("Examination_System.Models.InstructorCourse", b =>
                {
                    b.Property<int>("CrsId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.HasKey("CrsId", "InstructorId");

                    b.HasIndex("InstructorId");

                    b.ToTable("InstructorCourse");
                });

            modelBuilder.Entity("Examination_System.Models.Question", b =>
                {
                    b.Property<int>("Ques_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ques_ID"));

                    b.Property<string>("Corr_Answer")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Exam_ID")
                        .HasColumnType("int");

                    b.Property<string>("OPt1_Answer")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("OPt2_Answer")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("OPt3_Answer")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Quest")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Quest_Deg")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Ques_ID");

                    b.HasIndex("Exam_ID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Examination_System.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Image_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Examination_System.Models.StudentAnswer", b =>
                {
                    b.Property<int>("Stud_Id")
                        .HasColumnType("int");

                    b.Property<int>("Ques_ID")
                        .HasColumnType("int");

                    b.Property<bool>("If_Correct")
                        .HasColumnType("bit");

                    b.Property<string>("Student_Answer")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Stud_Id", "Ques_ID");

                    b.HasIndex("Ques_ID");

                    b.ToTable("StudentAnswer");
                });

            modelBuilder.Entity("Examination_System.Models.StudentCourse", b =>
                {
                    b.Property<int>("CrsId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<float?>("Grade")
                        .HasColumnType("real");

                    b.HasKey("CrsId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("Examination_System.Models.Topic", b =>
                {
                    b.Property<int>("Topic_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Topic_ID"));

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Topic_ID");

                    b.HasIndex("Course_ID");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("Examination_System.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Supervisor")
                        .HasColumnType("int");

                    b.HasKey("TrackId");

                    b.HasIndex("Supervisor")
                        .IsUnique()
                        .HasFilter("[Supervisor] IS NOT NULL");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("Examination_System.Models.Track_Instructor", b =>
                {
                    b.Property<int>("Ins_Id")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("Ins_Id", "TrackId");

                    b.HasIndex("TrackId");

                    b.ToTable("Track_Instructor");
                });

            modelBuilder.Entity("Examination_System.Models.Exam", b =>
                {
                    b.HasOne("Examination_System.Models.Course", "Course")
                        .WithOne("Exam")
                        .HasForeignKey("Examination_System.Models.Exam", "Course_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Examination_System.Models.InstructorCourse", b =>
                {
                    b.HasOne("Examination_System.Models.Course", "Course")
                        .WithMany("InstructorCourses")
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examination_System.Models.Instructor", "instructor")
                        .WithMany("InstructorCourse")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("instructor");
                });

            modelBuilder.Entity("Examination_System.Models.Question", b =>
                {
                    b.HasOne("Examination_System.Models.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("Exam_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("Examination_System.Models.Student", b =>
                {
                    b.HasOne("Examination_System.Models.Track", "Track")
                        .WithMany("students")
                        .HasForeignKey("TrackId");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Examination_System.Models.StudentAnswer", b =>
                {
                    b.HasOne("Examination_System.Models.Question", "Question")
                        .WithMany("StudentAnswers")
                        .HasForeignKey("Ques_ID")
                        .IsRequired();

                    b.HasOne("Examination_System.Models.Student", "Student")
                        .WithMany("StudentAnswers")
                        .HasForeignKey("Stud_Id")
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Examination_System.Models.StudentCourse", b =>
                {
                    b.HasOne("Examination_System.Models.Course", "course")
                        .WithMany("studentCourses")
                        .HasForeignKey("CrsId")
                        .IsRequired();

                    b.HasOne("Examination_System.Models.Student", "student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentId")
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("student");
                });

            modelBuilder.Entity("Examination_System.Models.Topic", b =>
                {
                    b.HasOne("Examination_System.Models.Course", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Examination_System.Models.Track", b =>
                {
                    b.HasOne("Examination_System.Models.Instructor", "Instructor")
                        .WithOne("Track")
                        .HasForeignKey("Examination_System.Models.Track", "Supervisor");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Examination_System.Models.Track_Instructor", b =>
                {
                    b.HasOne("Examination_System.Models.Instructor", "instructor")
                        .WithMany("Track_Instructor")
                        .HasForeignKey("Ins_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examination_System.Models.Track", "Track")
                        .WithMany("Track_Instructor")
                        .HasForeignKey("TrackId")
                        .IsRequired();

                    b.Navigation("Track");

                    b.Navigation("instructor");
                });

            modelBuilder.Entity("Examination_System.Models.Course", b =>
                {
                    b.Navigation("Exam")
                        .IsRequired();

                    b.Navigation("InstructorCourses");

                    b.Navigation("Topics");

                    b.Navigation("studentCourses");
                });

            modelBuilder.Entity("Examination_System.Models.Exam", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Examination_System.Models.Instructor", b =>
                {
                    b.Navigation("InstructorCourse");

                    b.Navigation("Track");

                    b.Navigation("Track_Instructor");
                });

            modelBuilder.Entity("Examination_System.Models.Question", b =>
                {
                    b.Navigation("StudentAnswers");
                });

            modelBuilder.Entity("Examination_System.Models.Student", b =>
                {
                    b.Navigation("CourseStudents");

                    b.Navigation("StudentAnswers");
                });

            modelBuilder.Entity("Examination_System.Models.Track", b =>
                {
                    b.Navigation("Track_Instructor");

                    b.Navigation("students");
                });
#pragma warning restore 612, 618
        }
    }
}
