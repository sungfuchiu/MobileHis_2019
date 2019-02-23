using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models.Interface
{
    interface IDashboardOpd<T>
    {
        IEnumerable<T> CalculateRecord();
    }
}