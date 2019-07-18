using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MobileHis.Data
{
    public class Role
    {
        public Role() { }

        public Role(string name)
        {
            this.name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(20)]
        public string name { get; set; }

        public virtual ICollection<Account2Role> Account2Role { get; set; }
    }
}