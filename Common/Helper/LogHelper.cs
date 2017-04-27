using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public partial class LogHelper
    {
        //异常信息的队列
        public static Queue<string> ExcMsg;

        static LogHelper()
        {
            ExcMsg = new Queue<string>();
            ThreadPool.QueueUserWorkItem(u =>
            {
                while (true)
                {
                    string str = string.Empty;

                    if (ExcMsg == null)
                    {
                        continue;
                    }

                    lock (ExcMsg)
                    {
                        if (ExcMsg.Count > 0)
                            str = ExcMsg.Dequeue();
                    }
                    //往日志文件里面写就可以了。
                    if (!string.IsNullOrEmpty(str))
                    {
                        ILog logger = log4net.LogManager.GetLogger("Logger");
                        logger.Error(str + "\r\n\n");
                    }
                    if (ExcMsg.Count() <= 0)
                    {
                        Thread.Sleep(30);
                    }


                }
            });
        }

        public static void WriteLog(string msg)
        {
            lock (ExcMsg)
            {
                ExcMsg.Enqueue(msg);
            }



            //数据结构。

            //磁盘。  内存块。

            //错误消息写到队列里面去。

            //lock ("全局锁")
            //{
            //    //写到文件里面去。
            //    using (StreamWriter writer = new StreamWriter())
            //    {
            //        writer.Write(msg);
            //    }

            //}
        }
    }
}
