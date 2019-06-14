using AutoMapper;
using MobileHis_2019.Repository.Interface;

namespace MobileHis_2019.Service.Service
{
    //Try to do this in extension
    public class GenericModelService<TEntity, TViewModel> : GenericService<TEntity> where TEntity : class
    {
        protected GenericModelService(IUnitOfWork inDB) : base(inDB) { }
        protected virtual TEntity ToCreateEntity(TViewModel model)
        {
            var settingConfig = new MapperConfiguration(
                cfg => cfg.CreateMap<TViewModel, TEntity>());
            var settingMapper = settingConfig.CreateMapper();
            return settingMapper.Map<TEntity>(model);
        }
        protected virtual void ToUpdateEntity(TViewModel model, TEntity entity)
        {
            var settingConfig = new MapperConfiguration(
                cfg => cfg.CreateMap<TViewModel, TEntity>());
            var settingMapper = settingConfig.CreateMapper();
            settingMapper.Map(model, entity);
        }

        protected virtual TViewModel EntityToViewModel(TEntity entity)
        {
            var settingConfig = new MapperConfiguration(
                cfg => cfg.CreateMap<TEntity, TViewModel>());
            var settingMapper = settingConfig.CreateMapper();
            return settingMapper.Map<TViewModel>(entity);
        }
    }
}
