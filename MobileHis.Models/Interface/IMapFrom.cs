using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Interface
{
    /// <summary>
    /// 設定ViewModel要對應的Model。
    /// 這個用預設的Convention來對應
    /// </summary>
    /// <typeparam name="T">要被對應到的Type</typeparam>
    public interface IMapFrom<T>
    {
    }
}
