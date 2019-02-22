using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{

    public enum BI_Function
    {       
        PatientRegister,
        Reception,
        SyndromicSurveillance

    }
    public enum FunctionType
    {
        NoRecord,
        Login,
        CreatePatient,
        Appointment,
        DoctorSchedule,
        Edit,
        Delete,
        Error
    }

    public enum ScheduleShift
    {
        All = 0,
        Morning = 1,
        Afternoon = 3,
        Night = 5
    }

    public enum OpdStatusEnum
    {
        Waitting, // 未看診
        Finished, // 已看診
        Transfer, // 轉診
        Canceled, // 退診
        Inspecting, // 看診中
        Examining // 檢查檢驗
    }

    public enum TypeOfVisit
    {
        Initial, // 初診
        Repeat,
        FollowUp,
        Refill
    }

    public enum PatientFrom
    {
        Local, // 當地
        Visitor, // 外來者
    }
    public enum PatientPaternity
    {
        Natural,
        Foster

    }
    public enum PatientMarried
    {
        Single,
        Married,
        Divorced
    }

    public enum StatusOfMedicalRecord
    {
        All, // 全部
        PulledOut, // 已經被拿出的
        NeedPullOut//需要被拿出
    }

    public class Enums
    {
        /// <summary>
        /// 資料庫狀態
        /// </summary>
        public enum DbStatus
        {
            OK,
            Successed,
            Error,
            Duplicate,
            OverLimit,
            ReadOnly,
            notFound
        }

        /// <summary>
        /// 使用者類別
        /// </summary>
        public enum UserType
        {
            Normal,
            Doctor
        }

        /// <summary>
        /// 生物量測類別
        /// </summary>
        public enum VitalSignType
        {
            [Description("P01")]
            Height,

            [Description("P02")]
            Weight,

            [Description("B01")]
            Bp,

            [Description("H01")]
            Pulse
        }

        public enum Action
        {
            Create,
            Update,
            Delete
        }

        public enum ReportType
        {
            Opd
        }
    }

    public class DrugConstant
    {
        public static readonly string Color = "CO";
        public static readonly string MajorType = "TP";
        public static readonly string Shape = "SP";
    }

    public struct SettingType
    {
        public static string Default = "Default";
        public static string info = "info";
        public static string other = "other";
        public static string category = "category";
        public static string mail = "mail";
    };

    public enum SettingTypes
    {
        Default,
        Info, 
        Other,
        Category,
        Mail
    }
}