using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MobileHis.Data
{
    public class Account2Dept
    {
      public Account2Dept() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int DeptId { get; set; }
        public int AccountId { get; set; }


        [ForeignKey("DeptId")]
        public virtual Dept Dept { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}