using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class TestPaper
    {
        public TestPaper() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public int TestType { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int Creator { get; set; }
        [Required]
        public bool ShuffleAnswer { get; set; }
        [Required]
        public bool IsCustomScore { get; set; }

        public virtual ICollection<TestQuestion> TestQuestion { get; set; }

    }
}