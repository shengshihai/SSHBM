using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DALMsSqlRepository
{
    public class DbContextFactory:IDALRepository.IDbContextFactory
    {
        #region 创建 EF 上下文 对象，线程中共享一个上下问对象 + DbContext GetDbContext();
        /// <summary>
        /// 创建EF上下文对象,在线程中共享一个上下文对象
        /// </summary>
        /// <returns></returns>
        public  System.Data.Entity.DbContext GetDbContext()
        {
            DbContext dbContext = CallContext.GetData(typeof(DbContextFactory).Name) as DbContext;
            if (dbContext == null)
            {
                dbContext = new MODEL.SSHBMEntities();
                
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                CallContext.SetData(typeof(DbContextFactory).Name, dbContext);
            }
            return dbContext;
        }
        #endregion

    
    }
}
