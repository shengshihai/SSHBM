using Common;
using IBLLService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class YX_sysConfigs_MANAGER : BaseBLLService<YX_sysConfigs>, IYX_sysConfigs_MANAGER
    {

        public string GetKeyValue(string key)
        {
            string keyValue = "";
            object weixinAppId = CacheHelper.GetCache(key);//设置缓存  防止多次访问数据库
            if (weixinAppId != null)
            {
                keyValue = weixinAppId.ToString().Trim();
            }
            else
            {
                var model = base.Get(s => s.wxkey == key);
                if (model != null)
                {
                    keyValue = model.wxkeyvalue;
                    CacheHelper.SetCache(key, keyValue, TimeSpan.FromMinutes(30));
                }
            }

            return keyValue;
        }


        public bool Save(string name, string value)
        {
            bool status = false;

            try
            {
                var model = base.GetModelWithOutTrace(sc => sc.wxkey== name);
                if (model != null)
                {
                    model.wxkeyvalue = value;
                    model.wxkeytime = DateTime.Now;
                    base.Modify(model, "wxkeyvalue", "wxkeytime");
                }
                else
                {
                    model = new YX_sysConfigs() { wxkeytime = DateTime.Now, wxkey = name, wxkeyvalue = value, RegTim1 = DateTime.Now };
                    base.Add(model);
                }
                IDBSession.SaveChanges();

                return status;
            }
            catch (Exception)
            {

                return status;
            }
        }
    }
}
