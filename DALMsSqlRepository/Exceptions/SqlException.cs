using System;
using System.Runtime.Serialization;

namespace DALMsSqlRepository
{
    [Serializable]
    public class SqlException : Exception
    {

        public SqlException()
            : base("数据库操作处理框架SqlClient引发异常")
        {
            Common.LogHelper.WriteLog("数据库操作处理框架SqlClient引发异常");
        }

        public SqlException(Exception ex)
            : base("数据库操作处理框架SqlClient引发异常", ex)
        {
            Common.LogHelper.WriteLog(ex.ToString());
        }


        public SqlException(string message)
            : base(message)
        {
            Common.LogHelper.WriteLog(message);

        }


        public SqlException(string message, Exception inner)
            : base(message, inner)
        {
            Common.LogHelper.WriteLog(message, inner);

        }

        protected SqlException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
