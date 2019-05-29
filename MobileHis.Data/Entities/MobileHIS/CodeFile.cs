using MobileHis.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MobileHis.Data
{
    public class CodeFile : IIDEntity
    {
        public CodeFile() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(2)]
        public string ItemType { get; set; }
        [MaxLength(8)]
        public string ItemCode { get; set; }
        [MaxLength(50)]
        public string ItemDescription { get; set; }
        [MaxLength(50)]
        public string Remark { get; set; }
        [MaxLength(1)]
        public string CheckFlag { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }
        public int? ParentCodeFile { get; set; }

        [ForeignKey("ParentCodeFile")]
        public virtual CodeFile Parent { get; set; }

        #region ICollection
        //public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<Dept> Dept { get; set; }
        public virtual ICollection<HealthEdu> Guardian { get; set; }
        public virtual ICollection<DorSchedule> DorSchedule { get; set; }

        #endregion
    }
}