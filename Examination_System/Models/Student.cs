using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        [StringLength(50)]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,}", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        public string Password { get; set; }
        [NotMapped] // ==> won't go to the DB
        [Compare("Password")]
        public required string ConfirmPassword { get; set; }
        public int Age { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
       // [ForeignKey("student")]
       // public int Std_Leader { get; set; }

        public string? Image_ID { get; set; }

        [ForeignKey("Track")]
        public int? TrackId { get; set; }

        public  Track? Track { get; set; }    
       // public Student _Student { get; set; }
        public  ICollection<StudentCourse> CourseStudents { get; set; } = new HashSet<StudentCourse>();
        public  ICollection<StudentAnswer> StudentAnswers { get; set; } = new HashSet<StudentAnswer>();
    }
}
