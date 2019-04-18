using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Data
{
    public class BillingItemLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int OpdRecordID { get; set; }
        public string ItemName { get; set; }
        public double? InitialFee { get; set; }
        public double? DailyFee { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreatedBy { get; set; }

        [ForeignKey("OpdRecordID")]
        public Billing Billing { get; set; }
    }
}
