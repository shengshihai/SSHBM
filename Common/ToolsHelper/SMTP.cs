using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Util;
using System.Net.Mail;
using System.Net;
namespace Common
{
    /// <summary>
    /// 邮件发送类
    /// </summary>
    public class SMTP
    {

        //mail.Port = 25;

        string Sender = "exportimes@mec.com.cn";//ConfigurationManager.AppSettings["Number"];//发送方邮箱
        string pwd = "mec1994#";//ConfigurationManager.AppSettings["Pwd"];//发送方密码
        string To;//接收方邮箱账号
        string SmtpServer = "smtp.mec.com.cn"; //ConfigurationManager.AppSettings["Server"];//服务器
        /// <summary>
        /// 邮件发送初始化
        /// </summary>
        /// <param name="To"></param>
        public SMTP(string To)//第1个参数：接收方邮箱账号
        {

            this.To = To;
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="bodyinfo">内容</param>
        /// <returns></returns>
        public bool sendemail(string subject, string bodyinfo)
        {
            bool flag = false;
            string formto = Sender;
            string to = To;
            string content = subject;
            string body = bodyinfo;
            string name = Sender;
            string upass = pwd;
            string smtp = SmtpServer;
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = smtp; //指定SMTP服务器
            _smtpClient.Credentials = new System.Net.NetworkCredential(name, upass);//用户名和密码
            MailMessage _mailMessage = new MailMessage();
            //发件人，发件人名 
            _mailMessage.From = new MailAddress(formto, "出口时代验证邮箱");
            //收件人 
            _mailMessage.To.Add(to);
            _mailMessage.SubjectEncoding = System.Text.Encoding.GetEncoding("gb2312");
            _mailMessage.Subject = content;//主题

            _mailMessage.Body = body;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("gb2312");//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.High;//优先级    
            _mailMessage.IsBodyHtml = true;
            try
            {
                _smtpClient.Send(_mailMessage);
                flag = true;
            }
            catch (Exception)
            {

                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 邮箱激活
        /// </summary>
        /// <param name="url"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Activation(string url, string ID)
        {
            bool flag = false;
            string formto = Sender;
            string to = To;
            string content = "出口时代:";
            string body = "尊敬的" + ID + "用户:请点击些链接验证邮箱:";
            body += "<a href=" + url + ">" + url + "</a>";
            string name = Sender;
            string upass = pwd;
            string smtp = SmtpServer;// "smtp.qq.com";
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = smtp; //指定SMTP服务器
            _smtpClient.Credentials = new System.Net.NetworkCredential(name, upass);//用户名和密码
            MailMessage _mailMessage = new MailMessage();
            //发件人，发件人名 
            _mailMessage.From = new MailAddress(formto, "出口时代验证邮箱");
            //收件人 
            _mailMessage.To.Add(to);
            _mailMessage.SubjectEncoding = System.Text.Encoding.GetEncoding("gb2312");
            _mailMessage.Subject = content;//主题

            _mailMessage.Body = body;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("gb2312");//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.High;//优先级    
            _mailMessage.IsBodyHtml = true;
            try
            {
                _smtpClient.Send(_mailMessage);
                flag = true;
            }
            catch (Exception)
            {

                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 邮箱激活
        /// </summary>
        /// <param name="url"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool MessageInquiry(string objectname, string username, string title, string context)
        {
            bool flag = false;
            string formto = Sender;
            string to = To;
            string content = "Dear " + username + ", You got a message from Exportimes: " + title + "";
            string body = "<table width='700' border='0' align='center' cellpadding='0' cellspacing='0' style='font-family:Verdana, Geneva, sans-serif; font-size:14px;'>  <tr>    <td valign='middle' style='height:100px;width:433px; padding-left:15px'><img src='http://www.exportimes.com/images/logoo.jpg' width='250' height='56' /></td>    <td valign='middle'><a href='http://www.exportimes.com' style='color:#a1a1a1; text-decoration:none; padding-left:15px;'><span style='text-decoration:none;'>www.exportimes.com</span></a></td>  </tr>  <tr>    <td colspan='2' style='line-height:62px; background:#0eabd8; padding: 0px 21px; color:#def0f8;'>Dear <b style='color:#fff;'>" + objectname + "</b>, You got a message:</td>  </tr>  <tr>    <td colspan='2' style='background:#eef5fb; color:#333; padding:21px; padding-bottom:6px; line-height:24px;color:#000;'><b>" + username + ": </b>" + title + "</td>  </tr>  <tr>    <td colspan='2' style='background:#eef5fb; color:#333; padding:6px 21px; padding-bottom:21px; line-height:24px;'>" + context + "</td>  </tr>  <tr>    <td colspan='2' align='center' style='padding:21px;'><table width='162' border='0' cellspacing='0' cellpadding='0'>  <tr>    <td align='center' style='text-align:center; line-height:38px; background:#fd9206; border:1px solid #fc7700;'><a href='" + Common.ConfigurationHelper.AppSetting("Center") + "/message/default.htm#feedback/all' style=' color:#fff; text-decoration:none; font-weight:bold;'><span style='text-decoration:none;'>Reply Now</span></a></td>  </tr></table></td>  </tr></table>";

            string name = Sender;
            string upass = pwd;
            string smtp = SmtpServer;// "smtp.qq.com";
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = smtp; //指定SMTP服务器
            _smtpClient.Credentials = new System.Net.NetworkCredential(name, upass);//用户名和密码
            MailMessage _mailMessage = new MailMessage();
            //发件人，发件人名 
            _mailMessage.From = new MailAddress(formto, "Exportimes");
            //收件人 
            _mailMessage.To.Add(to);
            _mailMessage.SubjectEncoding = System.Text.Encoding.GetEncoding("utf-8");
            _mailMessage.Subject = content;//主题

            _mailMessage.Body = body;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.High;//优先级    
            _mailMessage.IsBodyHtml = true;
            try
            {
                _smtpClient.Send(_mailMessage);
                flag = true;
            }
            catch (Exception)
            {

                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public void SendMail(string subject, string body)//第一个参数邮箱主题，第二个参数邮箱内容
        {
            MailAddress from = new MailAddress(this.Sender);

            MailAddress to = new MailAddress(this.To);

            MailMessage oMail = new MailMessage(from, to);
            oMail.Subject = subject;//主题
            oMail.Body = body;//内容

            oMail.IsBodyHtml = true;
            oMail.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");
            oMail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Host = SmtpServer; //指定邮件服务器
            client.Credentials = new NetworkCredential(this.Sender, this.pwd);//指定服务器邮件,及密码 


            //发送 
            try
            {
                client.Send(oMail); //发送邮件 

            }
            catch (Exception cp)
            {


                //发送不成功！


            }

            oMail.Dispose(); //释放资源 
        }









    }
}
