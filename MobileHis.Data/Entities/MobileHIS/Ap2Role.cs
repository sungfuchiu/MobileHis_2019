using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MobileHis.Data
{
    public class Ap2Role
    {
        public Ap2Role() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int role_id { get; set; }
        [MaxLength(10)]
        public string ap_key { get; set; }
        [MaxLength(1)]
        public string isRead { get; set; }
        [MaxLength(1)]
        public string isAdd { get; set; }
        [MaxLength(1)]
        public string isUpdate { get; set; }
        [MaxLength(1)]
        public string isDelete { get; set; }
        [MaxLength(1)]
        public string isPrint { get; set; }


        [ForeignKey("role_id")]
        public virtual Role Role { get; set; }
    }
}