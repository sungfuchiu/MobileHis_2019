using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Interface
{
    public interface IPageFilter<TEntity>
    {
        int? page { get; set; }
        List<TEntity> Entities { get; set; }
    }
}
