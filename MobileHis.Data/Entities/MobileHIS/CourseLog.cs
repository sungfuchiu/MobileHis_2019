using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class CourseLog
    {
        public CourseLog() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        [MaxLength(30)]
        public string LogType { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int Creator { get; set; }
        [Required]
        [MaxLength(100)]
        public string CreatorName { get; set; }
        public int? ParentId { get; set; }
        [MaxLength(2000)]
        public string Before { get; set; }
        [MaxLength(2000)]
        public string After { get; set; }

    }
}