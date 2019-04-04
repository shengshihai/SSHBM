using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace ShengUI.Helper
{
    public class StockApi
    {
        static string appkey = "ce356ee6be9aa5d187e077d14ca7acc8"; //配置您申请的appkey

        public static string  getStockPrice(string gid)
        {
            //3.美国股市
            string url3 = "http://web.juhe.cn:8080/finance/stock/usa";

            var parameters3 = new Dictionary<string, string>();

            parameters3.Add("gid", gid); //股票代码，如：aapl 为“苹果公司”的股票代码
            parameters3.Add("key", appkey);//你申请的key

            string result3 = sendPost(url3, parameters3, "get");
            JObject newObj3 = JsonConvert.DeserializeObject<JObject>(result3);
            
            //JObject  newObj3 = new JObject (result3);
            String errorCode3 = newObj3["error_code"].ToString();
            if (errorCode3 == "0")
            {
                LogHelper.WriteLog("成功");
               //
               // LogHelper.WriteLog(newObj3);
                return newObj3["result"][0]["data"]["lastestpri"].ToString();
            }
            else
            {
                LogHelper.WriteLog("失败");
             //  LogHelper.WriteLog(newObj3["error_code"].Value + ":" + newObj3["reason"].Value);
                
            }
            return "";
        }
        /// <summary>
        /// Http (GET/POST)
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="method">请求方法</param>
        /// <returns>响应内容</returns>
        static string sendPost(string url, IDictionary<string, string> parameters, string method)
        {
            if (method.ToLower() == "post")
            {
                HttpWebRequest req = null;
                HttpWebResponse rsp = null;
                System.IO.Stream reqStream = null;
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = method;
                    req.KeepAlive = false;
                    req.ProtocolVersion = HttpVersion.Version10;
                    req.Timeout = 5000;
                    req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                    byte[] postData = Encoding.UTF8.GetBytes(BuildQuery(parameters, "utf8"));
                    reqStream = req.GetRequestStream();
                    reqStream.Write(postData, 0, postData.Length);
                    rsp = (HttpWebResponse)req.GetResponse();
                    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    return GetResponseAsString(rsp, encoding);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (reqStream != null) reqStream.Close();
                    if (rsp != null) rsp.Close();
                }
            }
            else
            {
                //创建请求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + BuildQuery(parameters, "utf8"));

                //GET请求
                request.Method = "GET";
                request.ReadWriteTimeout = 5000;
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

                //返回内容
                string retString = myStreamReader.ReadToEnd();
                return retString;
            }
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        static string BuildQuery(IDictionary<string, string> parameters, string encode)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;
            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name))//&& !string.IsNullOrEmpty(value)
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }
                    postData.Append(name);
                    postData.Append("=");
                    if (encode == "gb2312")
                    {
                        postData.Append(HttpUtility.UrlEncode(value, Encoding.GetEncoding("gb2312")));
                    }
                    else if (encode == "utf8")
                    {
                        postData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                    }
                    else
                    {
                        postData.Append(value);
                    }
                    hasParam = true;
                }
            }
            return postData.ToString();
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            System.IO.Stream stream = null;
            StreamReader reader = null;
            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }
    }
    public class USStockInfo
    {
        public string resultcode { get; set; }
        public string reason { get; set; }
                    //        {
                    //"resultcode":"200", /*返回码，200:正常*/
                    //"reason":"SUCCESSED!",
                    //"result":[
                    //{
                    //    "data":{
                    //        "gid":"aapl",				/*股票编号*/
                    //        "name":"苹果",				/*股票名称*/
                    //        "lastestpri":"437.87",			/*最新价*/
                    //        "openpri":"429.70",			/*开盘价*/
                    //        "formpri":"431.72",			/*前收盘价*/
                    //        "maxpri":"439.01",			/*最高价*/
                    //        "minpri":"425.14",			/*最低价*/
                    //        "uppic":"6.15",				/*涨跌额*/
                    //        "limit":"1.42",				/*涨跌幅%*/
                    //        "traAmount":"16884191",			/*成交量（股）*/
                    //        "avgTraNumber":"16910781",		/*平均成交量（股）*/
                    //        "markValue":"411185326460",		/*市值*/
                    //        "max52":"705.07",			/*52周最高*/
                    //        "min52":"419.00",			/*52周最低*/
                    //        "EPS":"44.16",				/*美股收益*/
                    //        "priearn":"9.92",			/*市盈率*/
                    //        "beta":"1.10",				/*贝塔系数*/
                    //        "divident":"10.60",			/*股息*/
                    //        "ROR":"10.24",				/*收益率*/
                    //        "capital":"939058000",			/*股本*/
                    //        "afterpic":"437.29",			/*盘后价*/
                    //        "afterlimit":"-0.13",			/*盘后涨跌幅%*/
                    //        "afteruppic":"-0.58",			/*盘后涨跌额*/
                    //        "aftertime":"Mar 11 7:59PM EDT",	/*盘后计算时间*/
                    //        "ustime":"Mar 11 4:00PM EDT",		/*美国当前更新时间*/
                    //        "chtime":"2013-03-12 07:58:04"		/*中国时间*/
                    //    },
                    //    "gopicture":{
                    //    "minurl":"http://image.sinajs.cn/newchartv5/usstock/min/aapl.gif",/*分时K线图*/
                    //    "min_weekpic":"http://image.sinajs.cn/newchartv5/usstock/min_week/aapl.gif",/*5日K线图*/
                    //    "dayurl":"http://image.sinajs.cn/newchartv5/usstock/daily/aapl.gif",/*日K线图*/
                    //    "weekurl":"http://image.sinajs.cn/newchartv5/usstock/weekly/aapl.gif",/*周K线图*/
                    //    "monthurl":"http://image.sinajs.cn/newchartv5/usstock/monthly/aapl.gif"/*月K线图*/
                    //    }
                    //}]
    //}
    }
  
}
