using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public partial class DorSchedule
    {
        public DorSchedule() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public DateTime SchDate { get; set; }
        [Required]

        public int AccountID { get; set; }

        [Required]
        [MaxLength(2)]
        public string ShiftNo { get; set; }

        [Required]
        public int DeptID { get; set; }

        [Required]
        public int RoomID { get; set; }
        public bool isDeleted { get; set; }
        public int? CancelReasonId { get; set; }
        public string CancelRemark { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }


        #region ForeignKey
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }

        [ForeignKey("DeptID")]
        public virtual Dept Dept { get; set; }

        [ForeignKey("RoomID")]
        public virtual Room Room { get; set; }
        [ForeignKey("CancelReasonId")]
        public virtual CodeFile CancelReason { get; set; }
        #endregion

        #region ICollection
        public virtual ICollection<OpdRegister> OpdRegister { get; set; }
        #endregion


    }
}