using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileHis.Data
{
    public class Ward
    {
        public Ward() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string WardName { get; set; }

        public virtual ICollection<PatientAdmissionForm> AdmissionForm { get; set; }
    }
}
