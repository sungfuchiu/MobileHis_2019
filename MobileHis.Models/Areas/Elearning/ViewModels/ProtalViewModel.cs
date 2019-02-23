
using System;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace MobileHis.Models.Areas.Elearning.ViewModels
{
    public class Index
    {
        public IPagedList<CourseList> Register {get;set;}
        public IPagedList<CourseList> History { get; set; }
        public IPagedList<ExamRecord> Exam { get; set; }

        public string Tab { get; set; }
    }

    public class RegisteredViewModel
    {
         public IPagedList<CourseList> Papers { get; set; }
        public int Page { get; set; }

        public string KeyWord { get; set; }

        public RegisteredViewModel()
        {
            KeyWord = string.Empty;
            Page = 0;
        }
    }
    public class RegisteredChartModel
    {

    }
    public class ExamRecord
    {
        [Key]
        public int ID { get; set; }
        public string course_title { get; set; }

        public string paper_title { get; set; }
        public double score { get; set; }

        public DateTime created { get; set; }
    }
}