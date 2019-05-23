using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Data.Interface
{
    public interface IGuidEntity
    {
        Guid GID { get; set; }
    }
    public interface IIDEntity
    {
        int ID { get; set; }
    }
}
