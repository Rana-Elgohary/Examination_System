using Microsoft.EntityFrameworkCore;

namespace Examination_System.Models
{
    public class ITIContext : DbContext // to use it install the nuget
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<InstructorCourse> InstructorCourse { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentAnswer> StudentAnswer { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<Track_Instructor> Track_Instructor { get; set; }
        public ITIContext(DbContextOptions<ITIContext> options) : base(options) // options ==> will hold the type of DB and its name and so on
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track_Instructor>().HasKey(c => new { c.Ins_Id, c.TrackId });
            modelBuilder.Entity<InstructorCourse>().HasKey(c => new { c.CrsId, c.InstructorId });
            modelBuilder.Entity<StudentCourse>().HasKey(c => new { c.CrsId, c.StudentId });
            modelBuilder.Entity<StudentAnswer>().HasKey(c => new { c.Stud_Id, c.Ques_ID });


            //modelBuilder.Entity<Student>()
            //   .HasOne(s => s.Track)
            //   .WithMany()
            //   .HasForeignKey(s => s.TrackId)
            //   .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.student)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(sc => sc.StudentId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<StudentAnswer>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.StudentAnswers)
                .HasForeignKey(sa => sa.Stud_Id)
               .OnDelete(DeleteBehavior.ClientSetNull);

            // Disable cascade delete for the Track-Instructor relationship
            modelBuilder.Entity<Track>()
                .HasMany(t => t.Track_Instructor)
                .WithOne(ti => ti.Track)
                .HasForeignKey(ti => ti.TrackId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            // Disable cascade delete for the Student-Course relationship
            modelBuilder.Entity<Course>()
                .HasMany(c => c.studentCourses)
                .WithOne(sc => sc.course)
                .HasForeignKey(sc => sc.CrsId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            // Disable cascade delete for the Student-Answer relationship
            modelBuilder.Entity<Question>()
                .HasMany(q => q.StudentAnswers)
                .WithOne(sa => sa.Question)
                .HasForeignKey(sa => sa.Ques_ID)
               .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }

    }
}
