using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ApiModel
{
    public class LabReport
    {
        public bool Success { get; set; }

        public string Message { get; set; }

         public IEnumerable<IssueReport> Reports { get; set; }
    }
    public class IssueReport
    {
        public string PackCode { get; set; }
        public string UploadPath { get; set; }
        public Guid Id { get; set; }
    }
}