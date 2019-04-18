using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Data
{
    public class OpdRecordHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int OpdRecordId { get; set; }
        public string HistoryJson { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        [ForeignKey("OpdRecordId")]
        public virtual OpdRecord OpdRecord { get; set; }
    }
}
