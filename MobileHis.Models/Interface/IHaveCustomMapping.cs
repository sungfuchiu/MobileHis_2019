using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Interface
{
    /// <summary>
    /// 設定ViewModel要對應的Model
    /// 如果需要客制AutoMapper的邏輯，讓ViewModel實作此Interface
    /// </summary>
    public interface IHaveCustomMapping
    {
        /// <summary>
        /// 設定自定義的Mapping邏輯
        /// </summary>
        /// <param name="configuration">Automapper的Config物件</param>
        void CreateMappings(AutoMapper.IConfigurationProvider configuration);
    }
}
