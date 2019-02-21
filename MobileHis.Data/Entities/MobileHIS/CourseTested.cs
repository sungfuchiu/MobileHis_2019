using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class CourseTested
    {
        public CourseTested() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CourseTestPaperID { get; set; }
        [Required]
        public int AccountID { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public bool IsTested { get; set; }
        [Required]
        [MaxLength(150)]
        public string PaperPath { get; set; }
        [Required]
        public double CorrectRate { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public int? CourseID { get; set; }
        public double? Score { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool IsEnabled { get; set; }

    }
}