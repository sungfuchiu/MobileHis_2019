using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Course_Exam
    {
        public Course_Exam() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? ExamID { get; set; }
        public bool IsDeleted { get; set; }
        [MaxLength(150)]
        public string ExamTitle { get; set; }
        public int? TestType { get; set; }
        public bool? IsCustomScore { get; set; }
        public bool? IsPublic { get; set; }
        public int? CourseID { get; set; }


        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }


        public virtual ICollection<Course_Exam_Question> Course_Exam_Question { get; set; }
    }
}