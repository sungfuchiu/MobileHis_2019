using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Data
{
    public partial class ICD10Favorites
    {
        public ICD10Favorites() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(10)]
        public string ICD10Code { get; set; }
        public int AccountID { get; set; }
        [ForeignKey("ICD10Code")]
        public virtual ICD10 ICD10 { get; set; }
    }
}
