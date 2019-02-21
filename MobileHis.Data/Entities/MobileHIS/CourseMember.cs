using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class CourseMember
    {
        public CourseMember() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Member { get; set; }
        [Required]
        [MaxLength(15)]
        public string MemberType { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

    }
}