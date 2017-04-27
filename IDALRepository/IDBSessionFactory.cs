using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDALRepository
{
    /// <summary>
    /// 数据仓储工厂
    /// </summary>
    public interface IDBSessionFactory
    {
        IDALRepository.IDBSession GetDBSession();
    }
}
