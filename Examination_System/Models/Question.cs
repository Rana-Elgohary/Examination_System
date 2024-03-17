using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_System.Models
{
    public class Question
    {
        [Key]
        public int Ques_ID {  get; set; }
        [StringLength(500)]
        public string Quest {  get; set; }
        [StringLength(500)]
        public string Corr_Answer {  get; set; }
        [StringLength(500)]
        public string ?OPt1_Answer { get; set; }
        [StringLength(500)]
        public string? OPt2_Answer { get; set; }
        [StringLength(500)]
        public string? OPt3_Answer { get; set; }
        [StringLength(5)]
        public string Type { get; set;}
        public int Quest_Deg { get;set; }
        [ForeignKey("Exam")]
        public int Exam_ID {  get; set; }

        public Exam Exam { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
