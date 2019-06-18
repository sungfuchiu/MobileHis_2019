using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Data
{
    //因為過往的資料庫為可空，無法全部改成不可空，所以把它全部改成可空便於我用介面來統一儲存
    public interface IDatedEntity
    {
        DateTime? CreateDate { get; set; }
        DateTime? ModDate { get; set; }
    }
}
