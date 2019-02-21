using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class News
    {
        public News() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string NewsTitle { get; set; }
        [MaxLength]
        public string NewsContent { get; set; }
        [Required]
        public DateTime PublishStart { get; set; }
        [Required]
        public DateTime PublishEnd { get; set; }
        [Required]
        public bool IsEnable { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }

    }
}