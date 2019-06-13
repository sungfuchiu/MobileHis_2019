using MobileHis_2019.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Extension
{
    public static class ExtensionViewModel<TEntity, TViewModel> where TEntity : class
    {
        public static TEntity ToCreateEntity(IExtensionModel<TEntity, TViewModel> extensionModel, TViewModel model)
        {
            return extensionModel.Model.ToCreateEntity(model);
        }
        public static void ToUpdateEntity(IExtensionModel<TEntity, TViewModel> extensionModel, TViewModel model, TEntity entity)
        {
            extensionModel.Model.ToUpdateEntity(model, entity);
        }

        public static TViewModel EntityToViewModel(IExtensionModel<TEntity, TViewModel> extensionModel, TEntity entity)
        {
            return extensionModel.Model.EntityToViewModel(entity);
        }
    }
}
