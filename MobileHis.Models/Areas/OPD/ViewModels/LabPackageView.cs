using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileHis.Models.Areas.OPD.ViewModels
{
    public class LabPackageView
    {
        public Guid Id { get; set; }
        public string PackageName { get; set; }

        public string UploadPath { get; set; }

        public static IEnumerable<LabPackageView> Select(IEnumerable<MobileHis.Data.Drug> Package, MobileHis.Models.ApiModel.LabReport remoteData)
        {
            if (Package == null || !Package.Any())
            {
                return null;
            }
            IEnumerable<LabPackageView> model = Package.Join(remoteData.Reports, x => x.DrugCode, o => o.PackCode
                                                       , (x, o) => new LabPackageView()
                                                       {
                                                           Id = o.Id,
                                                           PackageName = x.Title,
                                                           UploadPath = o.UploadPath
                                                       });
            return model;
        }
    }
}