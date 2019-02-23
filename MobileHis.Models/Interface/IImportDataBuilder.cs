using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Interface
{
    public interface IImportDataBuilder<T> where T : new()
    {
        void HandleDocument(HttpPostedFileBase f, ref Dictionary<string, dynamic> result);
        Dictionary<string, dynamic> ValidateImportData(List<T> ListItem);

        //bool ValidateImportDataFromDB(string[] idarray);

        Dictionary<string, dynamic> WriterToDB(DataTable dt, Dictionary<string, dynamic> result);
    }
}