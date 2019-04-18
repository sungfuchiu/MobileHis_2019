using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class TestAnswerImage
    {
        public TestAnswerImage() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int Sort { get; set; }
        public int? AnswerID { get; set; }
        [MaxLength(500)]
        public string FileName { get; set; }

        [ForeignKey("AnswerID")]
        public virtual TestAnswer TestAnswer { get; set; }

    }
}