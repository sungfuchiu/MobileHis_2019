using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public partial class ImagePoint
    {
        public int id { get; set; }
        public int num { get; set; }
        public int imageId { get; set; }
        public string text { get; set; }
        public Nullable<double> xP { get; set; }
        public Nullable<double> yP { get; set; }
    }


    public partial class PatientImage
    {
        public int id { get; set; }
        public string patientId { get; set; }
        public string doctorId { get; set; }
        public string smallImage { get; set; }
        public string jpegImage { get; set; }
        public string dicomImage { get; set; }
        public string note { get; set; }
        public string imageName { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    }


    public class imageAndPoint : PatientImage
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<ImagePoint> point { get; set; }
    }
}