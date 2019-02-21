﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class DrugVendor
    {
        public DrugVendor() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int VendorID { get; set; }

        public Guid DrugGID { get; set; }

      //  [MaxLength(18)]
        public decimal Price { get; set; }

        public int? Unit { get; set; }
        public int PurchaseRate { get; set; }
        public int StockUsingRate { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [Required]
        public int Creator { get; set; }
        [Required]
        public bool Deleted { get; set; }

        [ForeignKey("DrugGID")]
        public virtual Drug Drug { get; set; }
        [ForeignKey("VendorID")]
        public virtual Vendor Vendor { get; set; }

    }
}