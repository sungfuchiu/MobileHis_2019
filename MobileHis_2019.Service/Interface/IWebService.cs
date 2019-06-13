using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Interface
{
    public interface IWebService<TModel>
    {
        void Index(TModel model);
        TModel Read(int ID);
        void Create(TModel model);
        void Update(TModel model);
        void Delete(int ID);
    }
}
