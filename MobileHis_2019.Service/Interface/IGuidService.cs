using MobileHis.Data;
using MobileHis_2019.Service.Composition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Interface
{
    public interface IGuidService<TEntity> : IService<TEntity> where TEntity : IGuidEntity
    {
        void Delete(Guid guid);
        TEntity Read(Guid guid);
    }
    public interface IGuidServiceComposition<TEntity> where TEntity : class, IGuidEntity
    {
        CompositionGuidService<TEntity> GuidService { get; set; }
    }
}
