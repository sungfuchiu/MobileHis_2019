using MobileHis.Data;
using MobileHis_2019.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Service.Service
{
    public interface ISystemLogService
    {
        void Log(SystemLog record);
    }
    public class SystemLogService : GenericService<SystemLog>, ISystemLogService
    {
        public SystemLogService(IUnitOfWork inDB) : base(inDB)
        {

        }
        public void Log(SystemLog record)
        {
            if (record != null)
            {
                Create(record);
                Save();
            }
        }
    }
}
