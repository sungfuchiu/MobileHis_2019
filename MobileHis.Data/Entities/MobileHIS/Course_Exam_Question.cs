using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Course_Exam_Question
    {
        public Course_Exam_Question() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int ExamID { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question { get; set; }
        [Required]
        [MaxLength(50)]
        public string QuestionType { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int Creator { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsEnabled { get; set; }
        [Required]
        [MaxLength(500)]
        public string Remark { get; set; }
        public double Score { get; set; }
        [Required]
        public bool UseHtmlEditor { get; set; }

        [ForeignKey("ExamID")]
        public virtual Course_Exam Course_Exam { get; set; }

        public virtual ICollection<Course_Exam_Answer> Course_Exam_Answer { get; set; }
        public virtual ICollection<Course_Exam_QuestionImage> QuestionImage { get; set; }

    }
}