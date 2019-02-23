using System;
using System.Collections.Generic;
using MobileHis.Comm;
using MobileHis.Data;
using System.Linq;
using MobileHis.Models.Areas.Drug.ViewModels;
using MobileHis.Models.Areas.Laboratory.ViewModels;
using MobileHis.Models.Areas.Exam.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MobileHis.Models.Areas.OPD.ViewModels
{
    public class OpdRecordView
    {



        //public static OpdRecordView FromRegist(OpdRegister reg)
        //{
        //    var currentRecord = reg.OpdRecord == null ? reg.OpdRecord.FirstOrDefault() : new MobileHis.Data.OpdRecord();
        //    var icd10 = currentRecord.OpdRecord2ICD10.OrderBy(o => o.Index).Select(o => o.ICD10Code).ToList();

        //    return new OpdRecordView()
        //    {
        //        Id = currentRecord.ID,
        //        Code = currentRecord.Code,
        //        Subjective = currentRecord.Subjective,
        //        Objective = currentRecord.Objective,
        //        Assessment = currentRecord.Assessment,
        //        Plan = currentRecord.Plan,
        //        Remark = currentRecord.Remark,
        //        ICD10Code1 = icd10.FirstOrDefault(),
        //        ICD10Code2 = icd10.Skip(1).FirstOrDefault(),
        //        ICD10Code3 = icd10.Skip(2).FirstOrDefault(),
        //        ICD10Code4 = icd10.Skip(3).FirstOrDefault(),
        //        Submited = currentRecord.SubmitedAt.HasValue
        //    };
        //}
        public int Id { get; set; }
        public string Code { get; set; }
        [System.Web.Mvc.AllowHtml]
        public string Subjective { get; set; }
        [System.Web.Mvc.AllowHtml]
        public string Objective { get; set; }
        [System.Web.Mvc.AllowHtml]
        public string Assessment { get; set; }
        [System.Web.Mvc.AllowHtml]
        public string Plan { get; set; }
        public string Remark { get; set; }

        public int ICD10CodeID1 { get; set; }
        public int ICD10CodeID2 { get; set; }
        public int ICD10CodeID3 { get; set; }
        public int ICD10CodeID4 { get; set; }

        public string ICD10Code1 { get; set; }
        public string ICD10Code2 { get; set; }
        public string ICD10Code3 { get; set; }
        public string ICD10Code4 { get; set; }
        public bool? Submited { get; set; }
        public int DoctorID { get; set; }

        [Areas.Drug.ViewModels.DrugsValidator]
        public IEnumerable<DrugsOrderView> Drugs { get; set; }
        [Areas.Exam.ViewModels.ExamsValidator]
        public IEnumerable<ExamsOrderView> Exams { get; set; }


        public IEnumerable<OrderLaboratoryView> Laboratory { get; set; }


    }
    public class OpdRecord2ICD10View
    {
        public int ID { get; set; }
        public string ICD10Code { get; set; }

    }
    public struct UpdateSS
    {
        public int nRegId { get; set; }
        public bool bDiarrhea { get; set; }
        public bool bILI { get; set; }
        public bool bProlonged_Fever { get; set; }
        public bool bAFR { get; set; }
        public bool bNoneAll { get; set; }
    }
    public struct GenSyndromicSurveillanceModel
    {
        public int OpdRegisterId { get; set; }
        public bool InjuryRelated { get; set; }
        public bool AlcoholRelated { get; set; }
        public bool Diarrhea { get; set; }
        public bool ILI { get; set; }
        public bool Prolonged_Fever { get; set; }
        public bool AFR { get; set; }
        public bool NoneAll { get; set; }
    }
    public struct SaveToPackageModel
    {
        [Required]
        [MaxLength(30)]
        public string code { get; set; }
        [MaxLength(100)]
        public string desc { get; set; }
        [System.Web.Mvc.AllowHtml]
        public string subjective { get; set; }
        [System.Web.Mvc.AllowHtml]
        public string objective { get; set; }
        [MaxLength(10)]
        public string icd10_1 { get; set; }
        [MaxLength(10)]
        public string icd10_2 { get; set; }
        [MaxLength(10)]
        public string icd10_3 { get; set; }
        [MaxLength(10)]
        public string icd10_4 { get; set; }
        public int doctor { get; set; }
        public List<SaveToPackage_Drug> drugs { get; set; }
    }
    public struct SaveToPackage_Drug
    {
        public Guid id { get; set; }
        public float dose { get; set; }
        public int unit { get; set; }
        public int freq { get; set; }
        public int days { get; set; }
        public float qty { get; set; }
        public int router { get; set; }
    }

    public class OpdRecordHistoryJsonModel
    {
        public OpdRecordHistoryJsonModel()
        {

        }
        public OpdRecordHistoryJsonModel(OpdRecord record, Dictionary<int, string> routeList, Dictionary<int, string> frequencyList)
        {
            this.Assessment = record.Assessment;
            this.LabIssueNo = record.LabIssueNo;
            this.MedStatus = record.MedStatus;
            this.Objective = record.Objective;
            this.PayStatus = record.PayStatus;
            this.Plan = record.Plan;
            this.Remark = record.Remark;
            this.Subjective = record.Subjective;
            this.UpdatedBy = record.UpdatedBy;
            this.SubmitedAt = record.SubmitedAt ?? record.CreatedAt;


            this.OpdRecord2ICD10 = record.OpdRecord2ICD10
                .Select(a => new ICD10HistoryModel
                {
                    ICD10Code = a.ICD10Code,
                    Name = a.ICD10.StdName
                }).ToList();
            this.OrderDrug = record.OrderDrug
                .Select(a => new PrescriptionHistoryModel
                {
                    DrugTitle = "[" + a.Drug.DrugCode + "]" + a.Drug.Title,
                    Days = a.Days,
                    Dose = a.Dose,
                    Frequency = frequencyList[a.Frequency],
                    Quantity = a.Quantity,
                    Remark = a.Remark,
                    Route = routeList[a.Route]
                }).ToList();
            this.OrderExam = record.OrderExam
                .Select(a => new ExamHistory
                {
                    ExamName = "[" + a.Drug.ExamCode + "]" + a.Drug.Title,
                    AccessionNumber = a.AccessionNumber,
                    ExamCode = a.ExamCode,
                    ExamDate = a.ExamDate,
                    ExamMeaning = a.ExamMeaning,
                    ExamResult = a.ExamResult,
                    ExamStatus = a.ExamStatus,
                    ExamTime = a.ExamTime,
                    IsCheckin = a.IsCheckin
                }).ToList();
        }

        [MaxLength]
        public string Subjective { get; set; }

        [MaxLength]
        public string Objective { get; set; }

        [MaxLength]
        public string Assessment { get; set; }

        [MaxLength]
        public string Plan { get; set; }
        [MaxLength]
        public string Remark { get; set; }
        public bool? PayStatus { get; set; }
        public bool? MedStatus { get; set; }
        [MaxLength(20)]
        public string LabIssueNo { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime SubmitedAt { get; set; }

        public List<ICD10HistoryModel> OpdRecord2ICD10 { get; set; }
        public List<PrescriptionHistoryModel> OrderDrug { get; set; }
        public List<ExamHistory> OrderExam { get; set; }


    }
    public class ICD10HistoryModel
    {
        public string ICD10Code { get; set; }
        public string Name { get; set; }
    }
    public class PrescriptionHistoryModel
    {
        public string DrugTitle { get; set; }
        [Required]
        public double Dose { get; set; }
        [Required]
        public string Frequency { get; set; }
        [Required]
        public string Route { get; set; }
        [Required]
        public int Days { get; set; }
        [Required]
        public double Quantity { get; set; }
        [MaxLength]
        public string Remark { get; set; }
    }
    public class ExamHistory
    {
        public string ExamName { get; set; }
        [Required]
        [MaxLength(50)]
        public string AccessionNumber { get; set; }
        [MaxLength(50)]
        public string ExamCode { get; set; }
        [MaxLength(100)]
        public string ExamMeaning { get; set; }
        [Required]
        public DateTime ExamDate { get; set; }
        [Required]
        [MaxLength(6)]
        public string ExamTime { get; set; }
        [MaxLength(20)]
        public string ExamStatus { get; set; }
        [MaxLength]
        public string ExamResult { get; set; }
        public bool? IsCheckin { get; set; }
    }
}