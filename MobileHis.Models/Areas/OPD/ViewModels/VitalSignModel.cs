using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Areas.OPD.ViewModels
{
    #region SmartHealthResponse
    public struct SmartHealthResponse
    {
        public string Message { get; set; }
        public int ResultType { get; set; }
        public bool success { get; set; }
        public SmartHealthTestObject? tests { get; set; }
    }

    public struct SmartHealthTestObject
    {
        public SmartHealthVitalSign_BloodPressue BloodPressure { get; set; }
        public SmartHealthVitalSign_BloodSugar BloodSugar { get; set; }
        public SmartHealthVitalSign_BodyFat BodyFat { get; set; }
        public SmartHealthVitalSign_Height BodyHeight { get; set; }
        public SmartHealthVitalSign_BodyTemp BodyTemp { get; set; }
        public SmartHealthVitalSign_Weight BodyWeight { get; set; }
        public SmartHealthVitalSign_O2Saturation O2Saturation { get; set; }
    }
    #region SmartHealthVitalSign
    public class SmartHealthVitalSign
    {
        public int current { get; set; }
        public int rowCount { get; set; }
        public int total { get; set; }
    }
    public class SmartHealthVitalSign_BloodPressue : SmartHealthVitalSign
    {
        public List<BloodPressure> rows { get; set; }
    }
    public class SmartHealthVitalSign_BloodSugar : SmartHealthVitalSign
    {
        public List<BloodSugar> rows { get; set; }
    }
    public class SmartHealthVitalSign_BodyFat : SmartHealthVitalSign
    {
        public List<BodyFat> rows { get; set; }
    }
    public class SmartHealthVitalSign_Height : SmartHealthVitalSign
    {
        public List<Height> rows { get; set; }
    }
    public class SmartHealthVitalSign_BodyTemp : SmartHealthVitalSign
    {
        public List<BodyTemp> rows { get; set; }
    }
    public class SmartHealthVitalSign_Weight : SmartHealthVitalSign
    {
        public List<Weight> rows { get; set; }
    }
    public class SmartHealthVitalSign_O2Saturation : SmartHealthVitalSign
    {
        public List<O2Saturation> rows { get; set; }
    }
    #endregion
    #region SubVitalSign
    public class SubVitalSign
    {
        public int MachineUsageId { get; set; }
        public string testdate { get; set; }
    }
    public class BloodPressure : SubVitalSign
    {
        public string diastolic { get; set; }
        public string pulse { get; set; }
        public string systolic { get; set; }
    }
    public class BloodSugar : SubVitalSign
    {
        public string bloodsugar { get; set; }
    }
    public class BodyFat : SubVitalSign
    {
        public string bmr { get; set; }
        public string bodyfat { get; set; }
        public string bodywatermass { get; set; }
        public string bonemass { get; set; }
        public string metabolicage { get; set; }
        public string musclemass { get; set; }
        public string vatlevel { get; set; }
    }
    public class Height : SubVitalSign
    {
        public string bodyheight { get; set; }
    }
    public class Weight : SubVitalSign
    {
        public string bmi { get; set; }
        public string bodyweight { get; set; }
    }
    public class BodyTemp : SubVitalSign
    {
        public string temperature { get; set; }
    }
    public class O2Saturation : SubVitalSign
    {
        public string spo2 { get; set; }
    }
    #endregion
    #endregion

    public struct VitalSignModel
    {
        public int? Id { get; set; }
        public bool IsFromSmartHealth { get; set; }
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
    }
    public struct CreateVitalSignModel
    {
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
    }
}
