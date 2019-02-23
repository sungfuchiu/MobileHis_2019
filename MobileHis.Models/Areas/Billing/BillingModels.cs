using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using MobileHis.Data;

namespace MobileHis.Models.Areas.Billing
{
    public struct BillingIndexModel
    {
        public int OpdRecordId { get; set; }
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string Surname { get; set; }
        public bool IsPay { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
    }
    public struct BillingTotalModel
    {
        public int BillingOPDRecordID { get; set; }
        public Patient Patient { get; set; }
        public List<OrderDrug> OrderDrugList { get; set; }
        public List<OrderExam> OrderExamList { get; set; }
        public List<OrderLaboratory> OrderLabList { get; set; }
        public List<BillingItem> BillingItemList { get; set; }
        public List<BillingItemLog> BillingItemLog { get; set; }
        public IPagedList<BillingLog> LogList { get; set; }
        public double TotalAmount { get; set; }
        public double Own { get; set; }
        public PatientFrom PatientFrom { get; set; }
        public int? Insurance { get; set; }
    }
    public struct BillingPrintModel
    {
        public string ReceiptNo { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string ReceivedFrom { get; set; }
        public string Address { get; set; }
        public string DollarsInfo { get; set; }
        public decimal amt_price { get; set; }
        public decimal pay_price { get; set; }
        public string For { get; set; }
        public string By { get; set; }

    }
    public struct BillingUpdateMedialRecord
    {
        public int regId { get; set; }
        public PatientFrom patientFrom { get; set; }
        public int? insurance { get; set; }
    }
    public struct BillingItem
    {
        public Guid Gid { get; set; }
        public string name { get; set; }
        public double? InitialFee { get; set; }
        public double? DailyFee { get; set; }
    }
    public struct BillingItemResponse
    {
        public bool success { get; set; }
        public decimal total { get; set; }
        public decimal own { get; set; }
    }
}
