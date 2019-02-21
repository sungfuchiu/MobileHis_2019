using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class TestQuestion
    {
        public TestQuestion() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int PaperID { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question { get; set; }
        [Required]
        [MaxLength(50)]
        public string QuestionType { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int Creator { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsEnabled { get; set; }
        [Required]
        [MaxLength(500)]
        public string Remark { get; set; }
        public double Score { get; set; }
        [Required]
        public bool UseHtmlEditor { get; set; }

        [ForeignKey("PaperID")]
        public virtual TestPaper TestPaper { get; set; }


        public virtual ICollection<TestQuestionImage> TestQuestionImage { get; set; }
        public virtual ICollection<TestAnswer> TestAnswer { get; set; }

    }
}