
using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class DrugSearchByCaseViewModel
    {

        public int ID { get; set; }

        public int? OpdRecordID { get; set; }
        public string patient_name { get; set; }

        public string PatinetID { get; set; }

        public string NationalID { get; set; }

        public string DepName { get; set; }

        public string RoomName { get; set; }

        public ScheduleShift ShiftNo { get; set; }

        public DateTime? OpdDate { get; set; }

        public bool? MedStatus { get; set; }

        public string OpdStatus { get; set; }
    }
}