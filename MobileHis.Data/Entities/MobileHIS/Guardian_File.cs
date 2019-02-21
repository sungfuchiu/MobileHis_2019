using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Guardian_File
    {
        public Guardian_File() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int Guardian_ID { get; set; }
        [MaxLength(200)]
        public string FileName { get; set; }
        public int Show_Order { get; set; }
        public int Show_Seconds { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }


        #region ForeignKey
        [ForeignKey("Guardian_ID")]
        public virtual Guardian Guardian { get; set; }
        #endregion
    }
}
