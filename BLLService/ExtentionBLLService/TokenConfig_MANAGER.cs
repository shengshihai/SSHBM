using Common;
using IBLLService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
    public partial class TokenConfig_MANAGER : BaseBLLService<TokenConfig>, ITokenConfig_MANAGER
    {
        YX_sysConfigs_MANAGER sysConfigs = new YX_sysConfigs_MANAGER();
        public string IsExistAccess_Token()
        {
            string AccessToken = "";
            object Access_Token = CacheHelper.GetCache("Access_Token");//设置主菜单缓存  防止多次访问数据库V1003_TODAY_MUSIC
            if (Access_Token != null)
            {
                DateTime Tim = DateTime.Now;
                

                if (base.GetListBy(t=>t.id==1&&Tim>t.Tim).Count==0)
                {
                    AccessToken = Access_Token.ToString();
                }
                else
                {
                    AccessToken = WeChatTools.FirstAccess_Token(sysConfigs.GetKeyValue("appid"), sysConfigs.GetKeyValue("appsecret"));//重新获取Access_Token
                    CacheHelper.SetCache("Access_Token", AccessToken, TimeSpan.FromMinutes(120));
                    string sql = "update TokenConfig set Tim='" + DateTime.Now.AddMinutes(3) + "'";
                    idal.ExcuteSql(sql);
                }
            }
            else
            {
                AccessToken = WeChatTools.FirstAccess_Token(sysConfigs.GetKeyValue("appid"), sysConfigs.GetKeyValue("appsecret"));//重新获取Access_Token
                CacheHelper.SetCache("Access_Token", AccessToken, TimeSpan.FromMinutes(120));
                string sql = "update TokenConfig set Tim='" + DateTime.Now.AddMinutes(45) + "'";
                idal.ExcuteSql(sql);
            }
            LogHelper.WriteLog("最新的TOKEN：" + AccessToken);
            return AccessToken;
        }
    }
}
