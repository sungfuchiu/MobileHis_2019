using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHis.Data;

namespace MobileHis.Models.Areas.PatientMgr
{
    public class PatientViewModel
    {
        public Patient Patient { get; set; }
        //public TodayMedicalRecord MedicalRecord { get; set; }
        public List<OpdRegister> OpdRegisters { get; set; }
    }
    public class PatientVitalSignResponseModel
    {
        public string SignValue { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public struct PatientSearchModel
    {
        public string s_patient_id { get; set; }
        public string s_national_id { get; set; }
        public string s_keyword { get; set; }
        public string s_hospital_no { get; set; }
        public string s_first_name { get; set; }
        public string s_mid_name { get; set; }
        public string s_last_name { get; set; }
        public DateTime? s_birthday { get; set; }
        public string s_FingerPrintData { get; set; }
        public MobileHis.Data.PatientFrom? PatientFrom { get; set; }
        public int? page { get; set; }
    }
    public class ManagePatientViewModel
    {
        public string HospitalNo { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string DateofBirth { get; set; }
        public string CreatedDate { get; set; }

    }
    public struct TodayMedicalRecord
    {
        public int id { get; set; }
        public string dept { get; set; }
        public int? callNo { get; set; }
        public string visitType { get; set; }
        public string createdAt { get; set; }

    }

    public struct AppointmentTimelineModel
    {
        public bool success { get; set; }
        public string msg { get; set; }
        /// <summary>
        /// opd reg seq
        /// </summary>
        public int callNo { get; set; }
        /// <summary>
        /// receiption create time
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// receiption create time
        /// </summary>
        public string entityTime { get; set; }
        /// <summary>
        /// medical record create time
        /// </summary>
        public string mrTime { get; set; }
        /// <summary>
        /// opd reg create time
        /// </summary>
        public string triageTime { get; set; }
        /// <summary>
        /// opd record temp create time
        /// </summary>
        public string doctorTime { get; set; }

    }
    public struct CreateMedicalRecordResponseModel
    {
        public Enums.DbStatus status { get; set; }
        public int regId { get; set; }
    }
    #region encounter form
    public struct PatientEncounterFormIndexModel
    {
        public Patient Patient { get; set; }
        //  public List<Reception> Receptions { get; set; }
    }
    public struct Reception
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public string VisitDate { get; set; }
        public string CreatedDate { get; set; }
        public List<EncounterFromTableModel> EncounterForms { get; set; }
    }
    public struct EncounterFromTableModel
    {
        public int RecordId { get; set; }
        public string DeptName { get; set; }
        public string DoctorName { get; set; }

    }
    public struct PatientReceptionForm
    {
        public int Id { get; set; }
        public string CreateDate { get; set; }
        public string CallNo { get; set; }
        public string Clinic { get; set; }
        public string TypeofVisit { get; set; }
        public bool AlcoholRelated { get; set; }
        public bool InjuryRelated { get; set; }


        public bool Admit { get; set; }

        public bool Diarrhea { get; set; }
        public bool ILI { get; set; }
        public bool Prolonged_Fever { get; set; }
        public bool AFR { get; set; }
        public bool NoneAll { get; set; }
    }
    public struct PatientEncounterForm
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public string EntityTime { get; set; }
        public string MrTime { get; set; }
        public string TriageTime { get; set; }
        public string DoctorTime { get; set; }
        public string Dept { get; set; }
        public string Doctor { get; set; }


        public string ICD10_1 { get; set; }
        public string ICD10_2 { get; set; }
        public string ICD10_3 { get; set; }
        public string ICD10_4 { get; set; }

        public string ICD10_1_lbl { get; set; }
        public string ICD10_2_lbl { get; set; }
        public string ICD10_3_lbl { get; set; }
        public string ICD10_4_lbl { get; set; }
    }
    public struct PatientReceptionUpdate
    {
        public int Id { get; set; }
        public bool AlcoholRelated { get; set; }
        public bool InjuryRelated { get; set; }
        public bool Admit { get; set; }
        public bool Diarrhea { get; set; }
        public bool ILI { get; set; }
        public bool Prolonged_Fever { get; set; }
        public bool AFR { get; set; }
        public bool NoneAll { get; set; }
    }
    public struct PatientEncounterUpdate
    {
        public int Id { get; set; }
        public string TriageTime { get; set; }
        public string DoctorTime { get; set; }

        public string ICD10_1 { get; set; }
        public string ICD10_2 { get; set; }
        public string ICD10_3 { get; set; }
        public string ICD10_4 { get; set; }
    }

    #endregion
    #region admission form
    public struct PatientAdmissionFormIndexModel
    {
        public Patient Patient { get; set; }
        public List<AdmissionFormIndexTable> List { get; set; }
        public Dictionary<int, string> Doctors { get; set; }//#145
    }
    public struct AdmissionFormIndexTable
    {
        public int Id { get; set; }
        public string AdmissionDate { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
    }
    public struct AdmissionFormCreate
    {
        public int? Id { get; set; }
        public string PatientID { get; set; }

        public DateTime AdmissionDate { get; set; }
        public string sAdmissionDate { get; set; }
        public int? RoomId { get; set; }
        public int? WardId { get; set; }
        public int? Ward2RoomId { get; set; }
        public int? Bed { get; set; }
        public int? AdmittingPhysican { get; set; }
        public bool? AdmitFrom_ER { get; set; }
        public bool? AdmitFrom_OPD { get; set; }
        public bool? AdmitFrom_RHC { get; set; }
        public bool? AdmitFrom_MCH { get; set; }
        public string NewbornWeight { get; set; }
        public string NewbornWeight_OZ { get; set; }
        public string DischCashier { get; set; }
        public string WeeksOfGestation { get; set; }


        public List<AdmissionDiagnosis> Diagnosis { get; set; }
        public List<AdmissionOperativeProcedure> OperativeProcedure { get; set; }
        /// <summary>
        /// Dismissed
        /// </summary>
        public bool? Discharge_Dismissed { get; set; }
        /// <summary>
        /// Left against medical advice
        /// </summary>
        public bool? Discharge_LeftAgainst { get; set; }
        /// <summary>
        /// Death Under 24 Hours in hospital
        /// </summary>
        public bool? Discharge_Death24 { get; set; }
        /// <summary>
        /// Death 48 Hours and over in hospital
        /// </summary>
        public bool? Discharge_Death48 { get; set; }
        public DateTime? DischargeDate { get; set; }
        public string sDischargeDate { get; set; }
        public int? DischargeTotalDay { get; set; }
        public bool? AutopsyPerformed { get; set; }
        public string CaseOfDeath_A { get; set; }
        public string CaseOfDeath_B { get; set; }
        public string CaseOfDeath_C { get; set; }
        public string CaseOfDeath_A_Label { get; set; }
        public string CaseOfDeath_B_Label { get; set; }
        public string CaseOfDeath_C_Label { get; set; }
    }
    public struct AdmissionDiagnosis
    {
        public int? Id { get; set; }

        public string DiagnosisLabel { get; set; }
        public string Diagnosis { get; set; }
        public string ConditionOnDischarge { get; set; }
        public bool Delete { get; set; }
    }
    public struct AdmissionOperativeProcedure
    {
        public int? Id { get; set; }
        public string OperatopmNo { get; set; }
        public string OperativeProcedure { get; set; }
        public DateTime Date { get; set; }
        public string sDate { get; set; }
        public bool Is_PO_Infaceion { get; set; }
        public bool Delete { get; set; }
    }

    #endregion
}
