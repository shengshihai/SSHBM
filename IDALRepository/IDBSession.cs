using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDALRepository
{
    public partial interface IDBSession
    {
        DbContext DbContext { get; }

        //IUserInfoRepository UserInfoRepository { get; set; }
        //IProductRepository ProductRepository { get; set; }

        int ExcuteSql(string sql, params ObjectParameter[] parameters);


        /// <summary>
        /// 将整个数据库访问层的所有的修改都一次性的提交回数据库
        /// 业务逻辑层：一个业务场景，肯定会对多个表做修改，和对多表进行处理，
        /// 有此方法的存在，能极大的提高数据库访问层批量提交sql的性能，提高数据库的吞吐率，减少了跟数据库的交互次数
        /// </summary>
        /// <returns></returns>
        int SaveChanges();//UnitWork模式




        int ExecuteTransaction();
    }
}
