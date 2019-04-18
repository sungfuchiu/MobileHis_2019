using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class CourseSetting
    {
        public CourseSetting() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public bool CheckOnline { get; set; }
        public int? CheckRemain { get; set; }
        public int? CheckTimer { get; set; }
        public int? ExamLimit { get; set; }
        public int? PassMinutes { get; set; }
        public bool? CanGrandTotal { get; set; }
        public bool? LearnedQuiz { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

    }
}