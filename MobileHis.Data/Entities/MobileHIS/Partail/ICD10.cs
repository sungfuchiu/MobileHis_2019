﻿using System;
using System.Linq;

namespace MobileHis.Data
{
    public partial class ICD10
    {
        public static string GetLabel(ICD10 item)
        {
            return String.Format("[{0}] {1}", item.ICD10Code, item.StdName);
        }
        public static string GetLabel(string code)
        {
            using (var db = new MobileHISEntities())
            {
                var record = db.ICD10.Where(i => i.ICD10Code == code).FirstOrDefault();
                if (record == null)
                {
                    return "";
                }
                else
                {
                    return GetLabel(record);
                }
            }
        }
    }
}