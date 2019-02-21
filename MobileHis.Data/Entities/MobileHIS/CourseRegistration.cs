using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class CourseRegistration
    {
        public CourseRegistration() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CourseID { get; set; }
        public int? Account { get; set; }
        [MaxLength(20)]
        public string UserNo { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
        public DateTime? Created { get; set; }


        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
    }
}