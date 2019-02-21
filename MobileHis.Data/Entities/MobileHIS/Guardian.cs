﻿using System;
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
     public class Guardian
    {
        public Guardian() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int Guardian_Type_CodeFile { get; set; }
        [MaxLength(50)]
        public string Guardian_Name { get; set; }
        public bool IsUsed { get; set; }
        public bool IsForLobbyUsed { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }


        #region ForeignKey
        [ForeignKey("Guardian_Type_CodeFile")]
        public virtual CodeFile CodeFile { get; set; }
        #endregion

        #region ICollection
        public virtual ICollection<Room> Room { get; set; }
        public virtual ICollection<Guardian_File> Guardian_File { get; set; }
        #endregion
    }
}
