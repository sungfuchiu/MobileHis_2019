using MobileHis_2019.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Interface
{
    public interface IExtensionModel<TEntity, TViewModel> where TEntity : class
    {
        GenericModelService<TEntity,TViewModel> Model { get; set; }
    }
}
