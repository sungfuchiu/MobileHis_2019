using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class TestAnswer
    {
        public TestAnswer() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int QuestionID { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Answer { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        [Required]
        public int Sort { get; set; }

        [ForeignKey("QuestionID")]
        public virtual TestQuestion TestQuestion { get; set; }

       public virtual ICollection<TestAnswerImage> TestAnswerImage { get; set; }

    }
}