using MobileHis.Data;
using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Extension
{
    public static class ExtensionIDService
    {
        public static TEntity Read<TEntity>(this IIDServiceComposition<TEntity> IDService, int ID) where TEntity : class, IIDEntity
        {
            return IDService.IDService.Read(ID);
        }
        public static void Delete<TEntity>(IIDServiceComposition<TEntity> IDService, int ID) where TEntity : class, IIDEntity
        {
            IDService.IDService.Delete(ID);
        }
        
    }
}
