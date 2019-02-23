using System;
using System.Collections.Generic;

namespace MobileHis.Models.Areas.Elearning.ViewModels
{
   
    public partial class TestedPaper
    {
        public int ID { get; set; }

        public int CourseID { get; set; }
        public string Paper { get; set; }

        public string Description { get; set; }

        public List<MobileHis.Data.TestQuestion> Questions { get; set; }

        public int Course_PaperId { get; set; }
    }

    public class TestQuestionViewModel
    {
        public int ID { get; set; }
        public int PaperID { get; set; }
        public string PaperTitle { get; set; }
        public string PaperType { get; set; }
        public bool IsCustomScore { get; set; }
        public bool IsPublish { get; set; }

        public DateTime Created { get; set; }

        public string QuestionType { get; set; }

        public double Score { get; set; }

        public string Question_Content { get; set; }
        public string Question_Editor { get; set; }

        public bool UseHtml { get; set; }

        public List<string> Answer { get; set; }

        public string QandAAnswer { get; set; }
        public string[] Correct { get; set; }

        public string QuestionImages { get; set; }



    }
}