using IDALRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DALMsSqlRepository
{
    public partial class DBSession:IDBSession
    {
        public System.Data.Entity.DbContext DbContext
        {
            get
            {
                return new DbContextFactory().GetDbContext();
            }
        }

        //public int ExcuteSql(string sql, params System.Data.Objects.ObjectParameter[] parameters)
        //{
        //    return DbContext.ExecuteFunction(sql, parameters);
        //}

        public int SaveChanges()
        {
           
        
            int num = DbContext.SaveChanges();

            return num;
        }




        public int ExcuteSql(string sql, params System.Data.Objects.ObjectParameter[] parameters)
        {
            
            return DbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public int ExecuteTransaction()
        {
            
            int i = 0;
            DbConnection con = ((IObjectContextAdapter)DbContext).ObjectContext.Connection;
            con.Open();
            using (var tran = con.BeginTransaction())
            {
                try
                {

                    i = SaveChanges();
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new SqlException(e.ToString());
                    
                }
                finally
                {
                    con.Close();
                }
            }
            return i;
        }
    }
}
