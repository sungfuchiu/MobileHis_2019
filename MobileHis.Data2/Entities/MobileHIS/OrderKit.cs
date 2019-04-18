using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class OrderKit
    {
        public OrderKit() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public Guid KitID { get; set; }

        //[Key]
        public Guid DrugID { get; set; }
        [Required]
        public float Dose { get; set; }
        [Required]
        public int Frequency { get; set; }
        [Required]
        public int Route { get; set; }
        [Required]
        public int Days { get; set; }
        [Required]
        public float Quantity { get; set; }

        #region ForeignKey
        [ForeignKey("KitID")]
        public virtual Kit Kit { get; set; }
        [ForeignKey("DrugID")]
        public virtual Drug Drug { get; set; }
        #endregion

    }
}