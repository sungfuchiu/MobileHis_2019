using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class Course
    {
        public Course() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public int? RoomID { get; set; }
        public int CourseType { get; set; }
        [MaxLength(100)]
        public string WayOfTeaching { get; set; }
        public int? Enrollment { get; set; }
        public bool NeedRecord { get; set; }
        public bool BroadcastLive { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool OpenEnrollment { get; set; }
        public DateTime? EnrollmentBeginDateTime { get; set; }
        public DateTime? EnrollmentEndDateTime { get; set; }
        public DateTime? OpenEnrollmentDateTime { get; set; }
        [MaxLength(20)]
        public string Status { get; set; }
        public bool EmailNotice { get; set; }
        public int? Views { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime Created { get; set; }
        public int? CreatorID { get; set; }
        [MaxLength(50)]
        public string Creator { get; set; }
        public int? Lecturer { get; set; }
        [MaxLength(1000)]
        public string Precautions { get; set; }
        [MaxLength(1000)]
        public string Remark { get; set; }
        public DateTime? PublishDateTime { get; set; }
        public DateTime? UnPublishDateTime { get; set; }

        #region ForeignKey
        [ForeignKey("RoomID")]
        public virtual Room Room { get; set; }
        [ForeignKey("CourseType")]
        public virtual CodeFile CodeFile_CourseType { get; set; }
        #endregion

        #region ICollection
        public virtual ICollection<CourseMember> CourseMember { get; set; }
        public virtual ICollection<CourseTestPaper> CourseTestPaper { get; set; }
        public virtual ICollection<CourseRegistration> CourseRegistration { get; set; }
        public virtual ICollection<CourseYoutube> CourseYoutube { get; set; }
        public virtual ICollection<CourseSignUp> CourseSignUp { get; set; }
        public virtual ICollection<Course_Exam> Course_Exam { get; set; }
        public virtual ICollection<CourseDateTime> CourseDateTime { get; set; }
        public virtual ICollection<CourseSetting> CourseSetting { get; set; }
        public virtual ICollection<CourseAttachment> CourseAttachment { get; set; }
        public virtual ICollection<CourseLog> CourseLog { get; set; }
        #endregion

    }
}