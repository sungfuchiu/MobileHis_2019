using X.PagedList;

namespace MobileHis.Models.Areas.Elearning.ViewModels
{
    public class TestPaperIndexViewModel
    {
        public IPagedList<TestPaperList> Papers { get; set; }
        public int Page { get; set; }

        public string KeyWord { get; set; }

        public TestPaperIndexViewModel()
        {
            KeyWord = string.Empty;
            Page = 0;
        }
    }
}