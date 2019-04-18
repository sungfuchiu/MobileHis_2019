using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileHis.Data
{
    public class CourseDateTime
    {
        public CourseDateTime() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public DateTime BeginDateTime { get; set; }
        [Column(TypeName = "bigint")]
        public long? TotalSeconds { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        [Required]
        public bool IsEnabled { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
    }
}