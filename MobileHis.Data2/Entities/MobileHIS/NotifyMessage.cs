using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class NotifyMessage
    {
        public NotifyMessage() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? MsgFrom { get; set; }
        public int? MsgTo { get; set; }
        [MaxLength]
        public string MessageText { get; set; }
        public int? IsRead { get; set; }
        public DateTime? Date { get; set; }

        #region ForeignKey
        [ForeignKey("MsgTo")]
        public virtual Account Account { get; set; }
        #endregion

    }
}