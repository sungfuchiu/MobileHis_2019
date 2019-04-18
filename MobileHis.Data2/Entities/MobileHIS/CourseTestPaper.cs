using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class CourseTestPaper
    {
        public CourseTestPaper() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int TestPaperID { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
        public bool? ShuffleAnswer { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

    }
}