using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class CourseYoutube
    {
        public CourseYoutube() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        [MaxLength(300)]
        public string HyperLink { get; set; }
        [Required]
        public bool IsEnabled { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

    }
}