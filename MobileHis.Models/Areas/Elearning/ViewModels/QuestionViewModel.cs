
using System;
using System.Web;
using System.Web.Mvc;
using MobileHis.Data;

namespace MobileHis.Models.Areas.Elearning.ViewModels
{
    public class QuestionCreate 
    {
       
        public int PaperID { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        
        public string PaperType { get; set; }
        public bool IsPublic { get; set; }

        public bool IsCustomScore { get; set; }

        public DateTime Created { get; set; }

        public MobileHis.Data.TestQuestion Questions { get; set; }

        public string Question_Content { get; set; }

        [AllowHtml]
        public string Question_Editor { get; set; }

        public double Score { get; set; }

        public bool IsAverage { get; set; }

        public bool UseHtml { get; set; }
        public HttpPostedFileBase files { get; set; }
    }


}