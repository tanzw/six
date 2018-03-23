using System;

namespace Well.Common
{
    public class EmailHelper
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">收件人</param>
        /// <param name="subject">邮件标题</param>
        /// <param name="body">邮件正文</param>
        /// <param name="Ishtml">是否为html格式</param>
        public static bool SendMail(string to, string subject, string body, bool Ishtml = true)
        {
            using (System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage())
            {
                msg.To.Add(to);
                msg.From = new System.Net.Mail.MailAddress("wxk0248@126.com", "【PP基金】", System.Text.Encoding.UTF8);
                msg.Subject = subject;//邮件标题
                msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码
                msg.Body = body;//邮件内容
                msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码
                msg.IsBodyHtml = Ishtml;//是否是HTML邮件
                msg.Priority = System.Net.Mail.MailPriority.High;//邮件优先级
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("111111@126.com", "7056991");
                client.Host = "smtp.126.com";
                object userState = msg;
                try
                {
                    client.Send(msg);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }

}
