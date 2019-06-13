using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Dept : IIDEntity
    {
        public Dept() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        [MaxLength(2)]
        public string DepNo { get; set; }
        [MaxLength(50)]
        public string DepName { get; set; }
        [MaxLength(20)]
        public string Clinic { get; set; }
        [MaxLength(1)]
        public string IsRegistered { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }


        #region ForeignKey
        [JsonIgnore]
        [ForeignKey("Category")]
        public virtual CodeFile Category_CodeFile { get; set; }
        //[ForeignKey("UnitId")]
        //public virtual CodeFile Unit { get; set; }
        #endregion

        #region ICollection
        [JsonIgnore]
        public virtual ICollection<OpdRegister> OpdRegister { get; set; }
        [JsonIgnore]
        public virtual ICollection<Account> Account { get; set; }
        [JsonIgnore]
        public virtual ICollection<Dept2Room> Dept2Room { get; set; }
        [JsonIgnore]
        public virtual ICollection<OpdRecord> OpdRecord { get; set; }
        #endregion
    }
}