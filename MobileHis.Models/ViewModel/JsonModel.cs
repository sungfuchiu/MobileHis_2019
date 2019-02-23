
using System;
namespace MobileHis.Models.ViewModels
{
    public class JsonSearchModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string Code { get; set; }
        public decimal? StockAmount { get; set; }
        public string DrugType { get; set; }
    }
    public class JsonCodeFileModel
    {
        public string itemType { get; set; }
        public string text { get; set; }
        public int value { get; set; }
    }
    public class JsonPhraseModel
    {
        public string name { get; set; }
        public string description { get; set; }
    }
    public class JsonCourseRegisteredModel
    {
        string _wayOgTeaching;
        public int ID { get; set; }
        public string CourseType { get; set; }
        public string Name { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Room { get; set; }
        public string WayOfTeaching
        {
            get { return _wayOgTeaching; }
            set { _wayOgTeaching = value.ToUpper() == "CLASSROOM" ? "實體教室" : "線上"; }
            //  course.WayOfTeaching.ToUpper() == "CLASSROOM" ? "實體教室" : "線上",
        }
        public DateTime Created { get; set; }
    }

}
