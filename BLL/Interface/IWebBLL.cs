using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IWebBLL<TModel>
    {
        void Index(TModel model);
        TModel Read(int ID);
        void Create(TModel model);
        void Update(TModel model);
        void Delete(int ID);
    }
}
