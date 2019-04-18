using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class VitalSign
    {
        public VitalSign() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(12)]
        public string PatientID { get; set; }

        /// <summary>
        /// 收縮壓
        /// </summary>
        public double? Systolic { get; set; }
        /// <summary>
        /// 舒張壓
        /// </summary>
        public double? Diastolic { get; set; }
        /// <summary>
        /// 脈搏
        /// </summary>
        public double? Pulse { get; set; }
        /// <summary>
        /// 體溫
        /// </summary>
        public double? BodyTemp { get; set; }
        /// <summary>
        /// 體重
        /// </summary>
        public double? Weight { get; set; }
        public double? BMI { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public double? Height { get; set; }
        /// <summary>
        /// 血氧
        /// </summary>
        public double? O2 { get; set; }
        /// <summary>
        /// 血糖
        /// </summary>
        public double? BloodSugar { get; set; }
        /// <summary>
        /// 體脂
        /// </summary>
        public double? BodyFat { get; set; }
        /// <summary>
        /// 內臟脂肪
        /// </summary>
        public double? VatLevel { get; set; }
        /// <summary>
        /// 基礎代謝
        /// </summary>
        public double? BMR { get; set; }
        /// <summary>
        /// 體年齡
        /// </summary>
        public double? MetabolicAge { get; set; }
        /// <summary>
        /// 肌肉含量
        /// </summary>
        public double? MuscleMass { get; set; }
        /// <summary>
        /// 骨量
        /// </summary>
        public double? BoneMass { get; set; }
        /// <summary>
        /// 體水份
        /// </summary>
        public double? BodyWaterMass { get; set; }

        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }

        [ForeignKey("PatientID")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("CreateBy")]
        public virtual Account Creator { get; set; }

        //[ForeignKey("PatinetID")]
        //public virtual Patient Patient { get; set; }

    }
}