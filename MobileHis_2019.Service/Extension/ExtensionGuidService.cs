using MobileHis.Data;
using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Extension
{
    public static class ExtensionGuidService<TEntity> where TEntity : class, IGuidEntity
    {
        public static TEntity Read(IGuidServiceComposition<TEntity> guidService, Guid guid)
        {
            return guidService.GuidService.Read(guid);
        }
        public static void Delete(IGuidServiceComposition<TEntity> guidService, Guid guid)
        {
            guidService.GuidService.Delete(guid);
        }

    }
}
