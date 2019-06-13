using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Interface
{
    public interface IAPIService<TModel>
    {
        void Index(TModel model);
        void Create(TModel model);
        void Update(TModel model);
        void Delete(int ID);
    }
}
