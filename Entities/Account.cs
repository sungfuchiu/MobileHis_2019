using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Entities
{
    public class Account
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int number { get; set; }
    }
}
