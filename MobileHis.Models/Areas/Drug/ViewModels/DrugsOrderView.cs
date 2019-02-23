
using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class DrugsOrderView
    {
        //public static IEnumerable<DrugsOrderView> Load(OpdRecord record)
        //{
        //    if (record == null) return new DrugsOrderView[] { };
        //    return Load(record.OrderDrug);
        //}

        //public static IEnumerable<DrugsOrderView> Load(IEnumerable<OrderDrug> records)
        //{
        //    if (records == null || records.Count() == 0) return new List<DrugsOrderView>();
        //    return records.Select(d => new DrugsOrderView()
        //    {
        //        ID = d.ID,
        //        DrugID = d.DrugID,
        //        DrugLabel = d.Drug.Title.ToString(),
        //        Dose = d.Dose,
        //        Unit = d.Unit,
        //        Frequency = d.Frequency,
        //        Route = d.Route,
        //        Days = d.Days,
        //        Quantity = d.Quantity,
        //        Remark = d.Remark,
        //        _Destroy = false
        //    });
        //}

        public Guid? ID { get; set; }

        public Guid DrugID { get; set; }

        public string DrugLabel { get; set; }

        [Required]
        public double Dose { get; set; }

        public string Formulation { get; set; }

        public int Frequency { get; set; }

        public int Route { get; set; }

        public int Days { get; set; }

        public double Quantity { get; set; }

        public string Remark { get; set; }

        public decimal Total { get; set; }

        public bool? _Destroy { get; set; }

        public decimal? StockAmount { get; set; }

        public string Error { get; set; }

        //public void Update(MobileHISEntities db, OpdRecord record)
        //{
        //    if(_Destroy.HasValue && _Destroy.Value) 
        //    {
        //        // DELETE
        //        db.OrderDrug.RemoveRange(record.OrderDrug.Where(d => d.ID == this.ID.Value));
        //    } 
        //    else {
        //        var drug = record.OrderDrug.Where(d => d.ID == ID).FirstOrDefault();
        //        if(drug == null) {
        //            // CREATE
        //            drug = new OrderDrug() {
        //                ID = Guid.NewGuid(),
        //                OpdRecord = record
        //            };
        //            db.OrderDrug.Add(drug);
        //        }

        //        // UPDATE
        //        drug.DrugID = this.DrugID;
        //        drug.Dose = this.Dose;
        //        drug.Unit = this.Unit;
        //        drug.Frequency = this.Frequency;
        //        drug.Route = this.Route;
        //        drug.Days = this.Days;
        //        drug.Quantity = this.Quantity;
        //        //drug.Quantity = Convert.ToDouble(this.Total);
        //        drug.Remark = this.Remark ?? "";
        //    }
        //}
    }
}