
using LocalRes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileHis.Models.ViewModel
{
    public class sysSettingView
    {
        public string FingerPrint { get; set; }
        public string Pacs { get; set; }
        public string ConsultationFee { get; set; }
        public HttpPostedFileBase BK_img_file { get; set; }
        public HttpPostedFileBase Official_Banner_Img_file { get; set; }
        public HttpPostedFileBase Official_Logo_Img_file { get; set; }
        public string BK_img { get; set; }
        public string Official_Banner_Img { get; set; }
        public string Official_Logo_Img { get; set; }
        public string Partner_Img { get; set; }
        public string Opd_Shift_Morning_Start { get; set; }
        public string Opd_Shift_Morning_End { get; set; }
        public string Opd_Shift_Afternoon_Start { get; set; }
        public string Opd_Shift_Afternoon_End { get; set; }
        public string Opd_Shift_Night_Start { get; set; }
        public string Opd_Shift_Night_End { get; set; }
        public string Opd_Shift_Morning { get; set; }
        public string Opd_Shift_Afternoon { get; set; }
        public string Opd_Shift_Night { get; set; }
        public string ApiKey { get; set; }
    }

    public class sysOtherSettingView
    {
        public string UPIS_IP { get; set; }
        public string UPIS_APIKEY { get; set; }
        public string SymptomShot { get; set; }
        public string SymptomShotIP { get; set; }
        public string SymptomShot_3DesKey { get; set; }
        public string SymptomShot_3DesIv { get; set; }
        public string SmartHealth_APIKEY { get; set; }
        public string SmartHealth_IP { get; set; }
        public string SmartHealth_Register_IP { get; set; }
        public string SmartHealth_3DesKey { get; set; }
        public string SmartHealth_3DesIv { get; set; }

        public string Owl_IP { get; set; }
        public string Owl_APIKEY { get; set; }
        public string Owl_3DesKey { get; set; }
        public string Owl_3DesIv { get; set; }
        public string Lab_IP { get; set; }

    }

    public class sysInfoSettingView
    {
        //public string Hospital_No { get; set; }
        public string Hospital_Name { get; set; }
        public string Hospital_Tel { get; set; }
        public string Hospital_Address { get; set; }
        public string Hospital_Contact_Name { get; set; }
        public string Hospital_Contact_Tel { get; set; }
        public string Hospital_About { get; set; }
        public string Hospital_lat { get; set; }
        public string Hospital_lng { get; set; }
        public string Hospital_Environment { get; set; }
        public string Hospital_Slogan { get; set; }

    }


    public class sysMailSettingView
    {
        public string Mail_UserName { get; set; }
        public string Mail_UserPassword { get; set; }
        public string Mail_Port { get; set; }
        public string Mail_Url { get; set; }
        public string Mail_ContactMail { get; set; }
        public string Mail_ContactBccMail { get; set; }

    }

    public class NewsView
    {
        private DateTime _PublishEnd;
        public string ID { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "News_Title")]
        [Required]
        public string NewsTitle { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "News_Content")]
        public string NewsContent
        {
            get;
            set;
        }

        [Display(ResourceType = typeof(Resource), Name = "News_PublishStart")]
        public DateTime PublishStart { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "News_PublishEnd")]
        public DateTime PublishEnd
        {
            get
            {
                return _PublishEnd;
            }
            set
            {
                if (value == DateTime.MinValue)
                {
                    _PublishEnd = DateTime.MaxValue;
                }
                else
                {

                    _PublishEnd = value;
                }

            }
        }

        [Display(ResourceType = typeof(Resource), Name = "News_IsEnable")]
        public bool IsEnable { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModDate { get; set; }

        public string ModUser { get; set; }

    }
}