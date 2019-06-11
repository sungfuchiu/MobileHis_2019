using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Data
{
    public interface IDatedEntity
    {
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}
