//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileHis.Data.DataEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class EZ_ImageDevice
    {
        public string IM_ImageDeviceID { get; set; }
        public string ImagePath { get; set; }
        public string ImagePathDescription { get; set; }
        public string DeviceIPAddress { get; set; }
        public string DeviceUserID { get; set; }
        public string DevicePwd { get; set; }
        public string DeviceLevel { get; set; }
        public Nullable<int> DeviceTotalSize { get; set; }
        public Nullable<int> DeviceUsedSize { get; set; }
        public string DeviceMailService { get; set; }
        public string ID_CDT { get; set; }
        public string ID_CU { get; set; }
        public string ID_MDT { get; set; }
        public string ID_MU { get; set; }
    }
}