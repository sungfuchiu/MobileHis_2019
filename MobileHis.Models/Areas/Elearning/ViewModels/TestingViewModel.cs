using System.Collections.Generic;
using MobileHis.Data;

namespace MobileHis.Models.Areas.Elearning.ViewModels
{
    public class TestingViewModel
    {
        public int ID { get; set; }
        public int ExamID { get; set; }
        public bool IsDeleted { get; set; }
        public string ExamTitle { get; set; }
        public int TestType { get; set; }
        public bool IsCustomScore { get; set; }
        public bool IsPublic { get; set; }
        public int CourseID { get; set; }


        public List<Course_Exam_QuestionViewModel> Course_Exam_Question { get; set; }
        //public virtual ICollection<Course_Exam_Question> Course_Exam_Question { get; set; }
    }

    public class Course_Exam_QuestionViewModel{
        public int ID { get; set; }
        public int ExamID { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }
        public System.DateTime Created { get; set; }
        public int Creator { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEnabled { get; set; }
        public string Remark { get; set; }
        public double? Score { get; set; }
        public bool UseHtmlEditor { get; set; }


        public List<Course_Exam_QuestionImage> QuestionImage { get; set; }

        public  List<Course_Exam_Answer> Course_Exam_Answer { get; set; }
    //    public List<Course_Exam_AnswerImage> AnswerImage { get; set; }
    }

    public class Course_Exam_AnswerViewModel
    {
        public int ID { get; set; }
        public int ExamQuestionID { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public int Sort { get; set; }

        //public List<Course_Exam_AnswerImage> AnswerImage { get; set; }
    }
}