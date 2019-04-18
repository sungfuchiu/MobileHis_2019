using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Drug
    {
        public Drug()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GID { get; set; }
        // public Guid? Appearance_id { get; set; }
        [MaxLength(50)]
        [Required]
        public string OrderCode { get; set; }
        [MaxLength(50)]
        [Required]
        public string DrugCode { get; set; }
        [MaxLength(20)]
        public string ExamCode { get; set; }
        [MaxLength(10)]
        public string ExamModality { get; set; }
        [MaxLength(256)]
        [Required]
        public string Title { get; set; }
        [MaxLength]
        public string Remark { get; set; }
        [MaxLength(20)]
        public string DrugType { get; set; }
        [Required]
        public bool IsHighRisk { get; set; }
        [Required]
        public bool IsPediatrics { get; set; }
        [MaxLength(500)]
        public string Allergy { get; set; }
        [MaxLength(500)]
        public string Direction { get; set; }
        public int? Unit { get; set; }
        /// <summary>
        /// 劑型
        /// </summary>
        public int? Formulation { get; set; }
        public int? SubCategory { get; set; }
        public PatientFrom? PatientFromType { get; set; }

        //   [ForeignKey("Appearance_id")]
        // [InverseProperty("Drug")]
        public virtual DrugAppearance DrugAppearance { get; set; }
        //  [ForeignKey("GID")]
        //  [InverseProperty("Drug")]
        //  [Required]
        public virtual DrugSetting DrugSetting { get; set; }


        #region ICollection
        public virtual ICollection<OrderExam> OrderExam { get; set; }
        public virtual ICollection<OrderLaboratory> OrderLaboratory { get; set; }
        public virtual ICollection<DrugRestriction> DrugRestriction { get; set; }
        public virtual ICollection<DrugCost> DrugCost { get; set; }
        public virtual ICollection<OrderDrug> OrderDrug { get; set; }
        public virtual ICollection<DrugOrderRestriction> DrugOrderRestriction { get; set; }
        public virtual ICollection<DrugVendor> DrugVendor { get; set; }
        public virtual ICollection<PurchaseD> PurchaseD { get; set; }
        public virtual ICollection<OrderKit> OrderKit { get; set; }
        public virtual ICollection<DrugStock> DrugStock { get; set; }
        #endregion



    }
}