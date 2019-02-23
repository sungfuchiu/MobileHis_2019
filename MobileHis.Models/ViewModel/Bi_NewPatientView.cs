
using LocalRes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class Bi_NewPatientView
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Total { get; set; }
        public int Local { get; set; }
        public int Visitor { get; set; }
    }
}