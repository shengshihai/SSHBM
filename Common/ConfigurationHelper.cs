using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
   
    public static class ConfigurationHelper
    {

        /// <summary>
        /// 获取配置文件的AppSetting
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AppSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
        public static List<string> getModel()
        {
            List<string> modelList = new List<string>();
            Assembly model = Assembly.Load("MODEL");
            Type[] mytypes = model.GetTypes();
            foreach (var item in mytypes)
            {
                if (item.Name != "UserInfo")
                    modelList.Add(item.Name);
            }
            return modelList;
        }


        
    }
}
