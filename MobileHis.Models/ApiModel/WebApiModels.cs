using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.ApiModel
{
    #region request
    public class LoginRequestModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    #endregion
    #region response
    public class BaseApiModel
    {
        public BaseApiModel() { }
        public BaseApiModel(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }
        public bool success { get; set; }
        public string message { get; set; }
        public BaseApiDataModel data { get; set; }
    }
    public class BaseApiDataModel
    {

    }

    public class LoginResponseModel : BaseApiDataModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
    public class GetDetailResponse : BaseApiDataModel
    {
        public string name { get; set; }
        public string title { get; set; }
        public string gender { get; set; }
        public string birth { get; set; }
        public string imgPath { get; set; }
    }
    #endregion
}
