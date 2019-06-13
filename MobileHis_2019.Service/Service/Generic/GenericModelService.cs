using MobileHis_2019.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Service
{
    //Try to do this in extension
    public class GenericModelService<TEntity, TViewModel> : GenericService<TEntity> where TEntity : class
    {
        protected GenericModelService(IUnitOfWork inDB) : base(inDB) { }
        protected virtual TEntity ToCreateEntity(TViewModel model)
        {
            return AutoMapper.Mapper.Map<TEntity>(model);
        }
        protected virtual void ToUpdateEntity(TViewModel model, TEntity entity)
        {
            AutoMapper.Mapper.Map(model, entity);
        }

        protected virtual TViewModel EntityToViewModel(TEntity entity)
        {
            return AutoMapper.Mapper.Map<TViewModel>(entity);
        }
    }
}
