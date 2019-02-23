using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis.Models.Areas.Elearning.ViewModels
{
    public class TestPaperCreate
    {
        //[Display(Name = "Test_Paper_Title", ResourceType = typeof(LocalRes.Resource))]
        [Required]
        [Display(Name = "Exam_Title", ResourceType = typeof(LocalRes.Resource))]
        public string Title { get; set; }

        //[Display(Name = "Course_Type", ResourceType = typeof(LocalRes.Resource))]
        [Display(Name = "Comm_Type", ResourceType = typeof(LocalRes.Resource))]
        public int? PaperType { get; set; }
        public IEnumerable<SelectListItem> PaperTypes { get; set; }//{ return getPaperTypes(); } }

        //[Display(Name = "Comm_Public", ResourceType = typeof(LocalRes.Resource))]
        [Display(Name = "Exam_Publish", ResourceType = typeof(LocalRes.Resource))]
        public bool IsPublic { get; set; }

        [Display(Name = "自訂試題分數")]
        public bool IsCustomScore { get; set; }

        [StringLength(299, ErrorMessage = "敘述文字長度限制300.")]
        [Display(Name = "Exam_Description", ResourceType = typeof(LocalRes.Resource))]
        public string Description { get; set; }

        //private List<SelectListItem> getPaperTypes()
        //{
        //    var Types = new CourseDal().GetCourseTypes();
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    var count = 0;
        //    foreach (var t in Types)
        //    {

        //        items.Add(new SelectListItem()
        //        {
        //            Value = t.ID.ToString(),
        //            Text = t.ItemDescription,
        //            Selected = count==0
        //        });

        //        count++;
        //    }

        //    return items;
        //}
    }

    public class TestPaperEdit : TestPaperCreate
    {
        public int ID { get; set; }
    }

    public class TestPaperList
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsPublic { get; set; }
        public string TestType { get; set; }
        public int CreatorID { get; set; }
        public string Creator { get; set; }

        public string Description { get; set; }
        public DateTime Created { get; set; }
    }

    public class TestedDetail
    {
        [Key]
        public int ID { get; set; }
        public string Course { get; set; }

        public int? CourseID { get; set; }

        public int PaperID { get; set; }

        public string TestPaper { get; set; }

        public double? Score { get; set; }

        public double? Rate { get; set; }

        public int TestedCount { get; set; }

        public DateTime LastTestTime { get; set; }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string FilePath { get; set; }

        public DateTime Created { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsEnabled { get; set; }
    }

    //public class TestedHistory
    //{
    //    public int ID { get; set; }
    //    public string Course { get; set; }

    //    public string TestPaper { get; set; }

    //    public double Score { get; set; }

    //    public DateTime Created { get; set; }
    //}
}