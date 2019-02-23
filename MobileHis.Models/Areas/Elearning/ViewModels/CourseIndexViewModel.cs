using X.PagedList;

namespace MobileHis.Models.Areas.Elearning.ViewModels
{
    public class CourseIndexViewModel
    {
        public IPagedList<CourseList> Courses { get; set; }
        public int Page { get; set; }

        public string KeyWord { get; set; }

        public CourseIndexViewModel()
        {
            KeyWord = string.Empty;
            Page = 0;
        }
    }
}