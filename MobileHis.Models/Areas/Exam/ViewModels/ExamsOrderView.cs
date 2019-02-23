using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MobileHis.Data;

namespace MobileHis.Models.Areas.Exam.ViewModels
{
    public class ExamsOrderView
    {
        //public static IEnumerable<ExamsOrderView> Load(OpdRecord record)
        //{
        //    if (record == null) return new ExamsOrderView[] { };
        //    return Load(record.OrderExam);
        //}

        //public static IEnumerable<ExamsOrderView> Load(IEnumerable<OrderExam> records)
        //{
        //    if (records == null || records.Count() == 0) return new List<ExamsOrderView>();
        //    return records.Select(d => new ExamsOrderView()
        //    {
        //        ID = d.ID,
        //        DrugID = d.DrugID,
        //        DrugLabel = d.Drug.Title,
        //        ExamCode = d.ExamCode,
        //        ExamDate = d.ExamDate,
        //        ExamTime = d.ExamTime,
        //        ExamMeaning = d.ExamMeaning,
        //        ExamResult = d.ExamResult,
        //        ExamStatus = d.ExamStatus,
        //        isCheckin = d.IsCheckin,
        //        AccessionNumber = d.AccessionNumber,
        //        _Destroy = false
        //    });
        //}

        public Guid? ID { get; set; }

        public Guid DrugID { get; set; }

        public string DrugLabel { get; set; }
        [Required]
        public string AccessionNumber { get; set; }

        public string ExamCode { get; set; }

        public string ExamMeaning { get; set; }

        public DateTime ExamDate { get; set; }

        public string ExamTime { get; set; }

        public string ExamStatus { get; set; }

        public string ExamResult { get; set; }

        public bool? _Destroy { get; set; }
        public bool? isCheckin { get; set; }

        public string Error { get; set; }

        //public void Update(MobileHISEntities db, OpdRecord record)
        //{
        //    if (_Destroy.HasValue && _Destroy.Value)
        //    {
        //        // DELETE
        //        var _v=record.OrderExam.Where(d => d.ID == this.ID.Value);
        //        // DELETE PACS 
        //        //var pacsF = MobileHis.Comm.pacsFactory.Create(Comm.pacsFactory.pacsType.eweb);
        //        //foreach(var r in _v)
        //        //    pacsF.Delete(r.AccessionNumber);

        //        db.OrderExam.RemoveRange(_v);
                
        //    }
        //    else
        //    {
        //        var drug = record.OrderExam.Where(d => d.ID == ID).FirstOrDefault();
        //        if (drug == null)
        //        {
        //            var _now=System.DateTime.Now;
        //            var drugInfo = db.Drug.Where(x => x.GID == this.DrugID).First();
        //            // CREATE
        //            drug = new OrderExam()
        //            {
        //                ID = Guid.NewGuid(),                        
        //                OpdRecord = record                      
        //            };
        //            db.OrderExam.Add(drug);
        //            this.ExamStatus = "Pending";           
        //        }                

        //        // UPDATE
        //        drug.DrugID = this.DrugID;
        //        drug.AccessionNumber = this.AccessionNumber;
        //        drug.ExamCode = this.ExamCode;
        //        drug.ExamMeaning = this.ExamMeaning;
        //        drug.ExamDate = this.ExamDate;
        //        drug.ExamTime = this.ExamTime;
               
        //    }
        //}
    }
}