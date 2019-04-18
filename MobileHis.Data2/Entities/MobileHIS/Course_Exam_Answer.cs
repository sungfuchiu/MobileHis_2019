using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Course_Exam_Answer
    {
        public Course_Exam_Answer() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int ExamQuestionID { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Answer { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        [Required]
        public int Sort { get; set; }

        [ForeignKey("ExamQuestionID")]
        public virtual Course_Exam_Question Course_Exam_Question { get; set; }

        public virtual ICollection<Course_Exam_AnswerImage> AnswerImage { get; set; }


    }
}