using MobileHis.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Room : IIDEntity
    {
        public Room() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(5)]
        public string RoomNo { get; set; }
        [MaxLength(50)]
        public string RoomName { get; set; }
        public int? RoomMax { get; set; }
        [Column(TypeName = "ntext")]
        public string Remark { get; set; }
        public int? Guardian_ID { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }

        #region ForeignKey
        [ForeignKey("Guardian_ID")]
        public virtual Guardian Guardian { get; set; }
        #endregion

        #region ICollection
        public virtual ICollection<OpdRegister> OpdRegister { get; set; }
        public virtual ICollection<DorSchedule> DorSchedule { get; set; }
        public virtual ICollection<Dept2Room> Dept2Room { get; set; }
        #endregion

    }
}