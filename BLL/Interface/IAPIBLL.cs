using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IAPIBLL<TModel>
    {
        void Index(TModel model);
        void Create(TModel model);
        void Update(TModel model);
        void Delete(int ID);
    }
}
