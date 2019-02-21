using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Data
{
    public class OpdRecordAttachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OpdRecordId { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }

        #region ForeignKey
        [ForeignKey("CreateBy")]
        public virtual Account Creator { get; set; }
        [ForeignKey("OpdRecordId")]
        public virtual OpdRecord OpdRecord { get; set; }
        #endregion
    }
}
