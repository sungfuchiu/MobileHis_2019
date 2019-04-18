using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Phrase
    {
        public Phrase() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(20)]
        public string PhraseCode { get; set; }
        [MaxLength(50)]
        public string PhaereContent { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }
        public int? AccountID { get; set; }

        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }

    }
}