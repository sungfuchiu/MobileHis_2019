using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class CourseSignUp
    {
        public CourseSignUp() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int AccountID { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public bool Cancelled { get; set; }
        public int? ModifyID { get; set; }
        public DateTime? Modified { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int Creator { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

    }
}