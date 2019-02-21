using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class CourseAttachment
    {
        public CourseAttachment() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int CourseID { get; set; }
        //[Required]
        //[MaxLength(10)]
        //public string FileType { get; set; }
        //[Required]
        //[MaxLength(300)]
        //public string FilePath { get; set; }
        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }
        //[Required]
        //[MaxLength(10)]
        //public string FileExten { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
        [Required]
        public int FileLength { get; set; }
        //[MaxLength(100)]
        //public string PreName { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
    }
}