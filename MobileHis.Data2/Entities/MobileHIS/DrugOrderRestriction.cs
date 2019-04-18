using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class DrugOrderRestriction
    {
        public DrugOrderRestriction() { }

        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GID { get; set; }
        [ForeignKey("Drug")]
        public Guid DrugId { get; set; }
        public Drug Drug { get; set; }
        [MaxLength(255)]
        [Required]
        public string RestrictName { get; set; }
        [MaxLength]
        [Required]
        public string Data { get; set; }
        [Required]
        public bool Enabled { get; set; }

    }
}