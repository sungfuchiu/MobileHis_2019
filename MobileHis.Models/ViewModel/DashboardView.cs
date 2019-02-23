using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using MobileHis.DAL
using MobileHis.Models.Object;
using MobileHis.Models.Areas.Report;

namespace MobileHis.Models.ViewModel
{
    public class DashboardView
    {
        public DashboardView()
        {
            NewsViewModel = new List<NewsView>();
            ICDViewModel = new List<StatisticsICD>();
            DrugViewModel = new List<StatisticsDrug>();
            CourseSchedle = new List<ScheduleObj>();
            SyndromicSurveillance = new List<SyndromicSurveillanceDashboard>();
        }
        public List<NewsView> NewsViewModel { get; set; }
        public List<StatisticsICD> ICDViewModel { get; set; }
        public List<StatisticsDrug> DrugViewModel { get; set; }
        public List<ScheduleObj> CourseSchedle { get; set; }
        public List<SyndromicSurveillanceDashboard> SyndromicSurveillance { get; set; }
    }
}