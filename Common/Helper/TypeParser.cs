using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace Common
{
    public sealed class TypeParser
    {

        /// <summary>
        /// 字符串转换为整数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defValue">默认值</param>
        /// <returns></returns>
        public static int ToInt32(string str, int defValue)
        {
            if (str == null)
                return defValue;

            if (str.Length > 0 && str.Length <= 11 && Regex.IsMatch(str, @"^[-]?[0-9]*$"))
            {
                if ((str.Length < 10) || (str.Length == 10 && str[0] == '1') || (str.Length == 11 && str[0] == '-' && str[1] == '1'))
                    return Int32.Parse(str, CultureInfo.CurrentCulture);
            }

            return defValue;
        }

        /// <summary>
        /// 字符串转换为整数 默认值为0
        /// </summary>
        public static int ToInt32(string str)
        {
            int result = 0;
            int.TryParse(str,out result);
            return result;
        }


        /// <summary>
        /// 对象转换为整数
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defValue">默认值</param>
        /// <returns></returns>
        public static int ToInt32(object obj)
        {
            if (obj != null)
                return ToInt32(obj.ToString());
            else
                return 0;
        }

       

       


        /// <summary>
        /// 字符串转换为Double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ToDouble(string str)
        {
            try
            {
                if (Thread.CurrentThread.CurrentCulture.CompareInfo.Name == "fr-FR")
                    return Double.Parse(str.Replace(".", ","));
                else
                    return Double.Parse(str);
            }
            catch
            {
                return 0.00;
            }
        }


        /// <summary>
        /// 对象转换为Double
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDouble(object obj)
        {
            if (obj != null)
                return ToDouble(obj.ToString());
            else
                return 0.00;
        }


        /// <summary>
        /// Double转换为Decimal
        /// </summary>
        /// <param name="dou"></param>
        /// <returns></returns>
        public static decimal ToDecimal(double dou)
        {

            return ToDecimal(dou.ToString());

        }

        /// <summary>
        /// 对象转换为Decimal
        /// </summary>
        /// <param name="dou"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj)
        {

            if (obj != null)
                return ToDecimal(obj.ToString());
            else
                return 0;
        }

        /// <summary>
        /// 字符串转换为Decimal
        /// </summary>
        /// <param name="dou"></param>
        /// <returns></returns>
        public static decimal ToDecimal(string str)
        {
            try
            {
                if (Thread.CurrentThread.CurrentCulture.CompareInfo.Name == "fr-FR")
                    str = str.Replace(".", ",");

                return Decimal.Round(Decimal.Parse(str.Replace(" ", ""),
                    NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol), 2);

            }
            catch
            {
                return 0;
            }
        }


        /// <summary>
        /// 字符串转换为日期
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string value)
        {
            try
            {
                return Convert.ToDateTime(value, CultureInfo.CurrentCulture);

            }
            catch
            {
                return Convert.ToDateTime("1753/12/31 0:00:00");
            }

        }




        //string to money
        public static string ToMoney(string str)
        {
            return string.Format("{0:c}", decimal.Parse(str));

        }

        //string to bool
        public static bool ToBool(string str)
        {
            if (str == "1"||str.ToLower()=="true")
                return true;
            bool result = false;
            bool.TryParse(str, out result);
            return result;


        }

        //object to bool
        public static bool ToBool(object obj)
        {
            if (obj == null)
                return false;
            else
            {
               return  ToBool(obj.ToString());
            }
        }

        /// <summary>
        /// 如果参数为空，返回空字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            try
            {
                if (obj == null) return "";
                else return obj.ToString();
            }
            catch { return ""; }
        }

        /// <summary>
        /// 如果参数为空，返回空字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToSqlString(object obj)
        {
            try
            {
                if (obj == null) return "";
                else
                {
                    Regex reg = new Regex("['|\\\\|\"|-|/]");
                    return reg.Replace(obj.ToString(), "");
                }
            }
            catch { return ""; }
        }

        /// <summary>
        /// 如果参数为空，返回当前时间
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToNowDatetime(object obj)
        {
            try
            {
                if (obj == null) return DateTime.Now;
                else return Convert.ToDateTime(obj);
            }
            catch { return DateTime.Now; }
        }
    }
}
