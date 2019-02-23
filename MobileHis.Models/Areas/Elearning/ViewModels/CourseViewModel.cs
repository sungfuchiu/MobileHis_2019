//using MobileHis.DAL;
using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace MobileHis.Models.Areas.Elearning.ViewModels
{
    public partial class CourseList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string YoutubeLink { get; set; }
        public string Room { get; set; }
        public string CourseType { get; set; }

        public string WayOfTeaching { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime BeginDateTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime EndDateTime { get; set; }
        public int Enrollment { get; set; }
        public string Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Created { get; set; }
        [Display(Name = "Creator", ResourceType = typeof(LocalRes.Resource))]
        public string Creator { get; set; }

        public int CreatorID { get; set; }

        public int Views { get; set; }
        public List<CourseAttachment> Attachment { get; set; }

        public string Precautions { get; set; }
        public string Remark { get; set; }

        public bool OpenEnrollment { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public Nullable<DateTime> EnrollmentBeginDateTime { get; set; }
        public Nullable<DateTime> EnrollmentEndDateTime { get; set; }

        public DateTime? PublishDateTime { get; set; }
        public DateTime? UnPublishDateTime { get; set; }
    }

    public class CourseDetail : CourseList
    {
        public int SignedCount { get; set; }
        public bool Signed { get; set; }

        public bool OnlineStart { get; set; }
        public CourseSetting Setting { get; set; }
        public List<Course_Paper> CourseTestPapers { get; set; }

        public List<CourseDateTime> CourseDateTime { get; set; }

    }

    public class Course_Paper
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public int Course_TestPaper_Id { get; set; }
        public int CourseId { get; set; }
        public string Description { get; set; }
        public string TestType { get; set; }
        public int Type { get; set; }

        public int ExamId { get; set; }

    }

    public class CourseNewEdit
    {
        public int ID { get; set; }
        //[LocalizedDisplayName("Name")]
        [Display(Name = "Course_Title", ResourceType = typeof(LocalRes.Resource))]
        public string Name { get; set; }
        [Display(Name = "Course_Description", ResourceType = typeof(LocalRes.Resource))]
        public string Description { get; set; }
        public int? RoomID { get; set; }


        public int CourseType { get; set; }

        [Display(Name = "Course_Number_of_Applicants", ResourceType = typeof(LocalRes.Resource))]
        public int? Enrollment { get; set; }



        [Display(Name = "Course_Method_of_teaching", ResourceType = typeof(LocalRes.Resource))]
        public string WayOfTeaching { get; set; }


        public string BeginTime { get; set; }

        [Required(ErrorMessage = "開始時間為必填")]
        [Display(Name = "BeginTime", ResourceType = typeof(LocalRes.Resource))]

        public Nullable<DateTime> BeginDate { get; set; }

        public string EndTime { get; set; }

        [Required(ErrorMessage = "結束時間為必填")]
        [Display(Name = "EndTime", ResourceType = typeof(LocalRes.Resource))]
        public Nullable<DateTime> EndDate { get; set; }


        [Display(Name = "Record", ResourceType = typeof(LocalRes.Resource))]
        public bool NeedRecord { get; set; }
        [Display(Name = "Live", ResourceType = typeof(LocalRes.Resource))]
        public bool BroadcastLive { get; set; }

        [Display(Name = "Course_Open_for_Application", ResourceType = typeof(LocalRes.Resource))]
        public bool OpenEnrollment { get; set; }

        [Display(Name = "OpenTime", ResourceType = typeof(LocalRes.Resource))]
        public Nullable<DateTime> EnrollmentBeginDateTime { get; set; }

        public Nullable<DateTime> EnrollmentEndDateTime { get; set; }

        [Display(Name = "OpenTime", ResourceType = typeof(LocalRes.Resource))]
        public string OpenEnrollmentTime { get; set; }

        public string Status { get; set; }

        //[Display(Name = "EmailNotice", ResourceType = typeof(LocalRes.Resource))]
        public bool EmailNotice { get; set; }

        [Display(Name = "Comm_Upload", ResourceType = typeof(LocalRes.Resource))]
        public List<HttpPostedFileBase> files { get; set; }

        [Display(Name = "YoutubeLink", ResourceType = typeof(LocalRes.Resource))]
        public string YoutubeLink { get; set; }

        [Display(Name = "Course_Precautions", ResourceType = typeof(LocalRes.Resource))]
        public string Precautions { get; set; }

        [Display(Name = "Course_Remark", ResourceType = typeof(LocalRes.Resource))]
        public string Remark { get; set; }


        public DateTime? PublishDateTime { get; set; }


        public DateTime? UnPublishDateTime { get; set; }

        public DateTime Created { get; set; }

        public string Creator { get; set; }

        public int CreatorID { get; set; }
        public string DelAttachment { get; set; }

        public List<CourseAttachment> Attachment { get; set; }

        public List<CourseUsers> Members { get; set; }

        public List<Course_Paper> Papers { get; set; }

        public List<CourseDateTime> CourseDateTime { get; set; }

        public List<CourseAttachment> CourseAttachment { get; set; }

        public bool AnyBody { get; set; }
        public bool PageInitial { get; set; }
        #region == IEnumerable ==
        [Display(Name = "Course_Type", ResourceType = typeof(LocalRes.Resource))]
        public IEnumerable<SelectListItem> CourseTypes { get; set; } //{ return getCourseTypes(); } }


        [Display(Name = "Course_Room", ResourceType = typeof(LocalRes.Resource))]
        public IEnumerable<SelectListItem> Rooms { get; set; } //{ return getCourseRooms(); } }




        public IEnumerable<SelectListItem> EnrollmentAmount { get { return GetEnrollmentAmount(); } }

        public IEnumerable<SelectListItem> WayOfTeachingItems { get { return getWayOfTeaching(); } }
        #endregion

        public CourseSetting Setting { get; set; }


        #region == SelectListItem Method ==
        private List<SelectListItem> GetEnrollmentAmount()
        {
            int[] En = new int[] { 99999, 10, 20, 50, 100 };
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var t in En)
            {
                if (t >= 99999)
                {
                    items.Add(new SelectListItem()
                    {
                        Value = t.ToString(),
                        Text = LocalRes.Resource.Unlimited
                    });
                }
                else
                {
                    items.Add(new SelectListItem()
                    {
                        Value = t.ToString(),
                        Text = t.ToString()
                    });
                }
            }
            return items;
        }





        private List<SelectListItem> getWayOfTeaching()
        {
            Dictionary<string, string> way = new Dictionary<string, string>  
            {
                {WayOfTeach.CLASSROOM.ToString(),"實體教室"},
                {WayOfTeach.ONLINE.ToString(),"線上學習"}
            };
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (KeyValuePair<string, string> item in way)
            {

                items.Add(new SelectListItem()
                {
                    Value = item.Key,
                    Text = item.Value
                });


            }
            return items;
        }


        #endregion
    }



    public class CourseFiles
    {
        public int ID { get; set; }
        public HttpPostedFileBase File { get; set; }

        public byte[] fileStream { get; set; }
        public string FileName { get; set; }
        public int FileLen { get; set; }
    }

    public class CourseUsers
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string Member { get; set; }
        public string MemberType { get; set; }

        public string UserNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Dept {
            get
            {
                return IDepts!=null?string.Join(",", IDepts):"";
            }
        
        }
        public IEnumerable<string> IDepts { get; set; }

    }
    public enum WayOfTeach
    {
        None = 0,
        CLASSROOM,
        ONLINE
    }


}