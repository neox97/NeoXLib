using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NIO
{
    public class RQX
    {

        public static void UpdateChromium(string path)
        {
            Directory.Delete(path, true);
            HttpRequest http = new HttpRequest();
            http.ConnectTimeout = 99999999;
            http.KeepAliveTimeout = 99999999;
            http.ReadWriteTimeout = 99999999;
            var binImg = http.Get("https://95iq9g.dm.files.1drv.com/y4m0yGn8oVkP-9mFrQ0WjFANB_MiYCCd3NHGRwlzfx9lkCaRuZn_vJb9hk0szEpm3e2f2lcMVj-hCVur7GqHS6jWqZPAAe03T4xCVNAB8MTzg2F6c08jy1h8gPjeOD0xcLzhNrKs4vFnDGsyBoMgnFILrazOocNxs7XSDY_nziECmtYW5IzCBXrMBUmWgnmYcTw2qPFrOouVZ26GGoRioLYxg").ToMemoryStream().ToArray();
            File.WriteAllBytes("crm.zip", binImg);
            ZipFile.ExtractToDirectory("crm.zip", path);
            File.Delete("crm.zip");
            File.Move(path + "chromedriver.exe", "chromedriver.exe");
        }
        public static void TestData(string html)
        {
            File.WriteAllText("res.html", html);
            Process.Start("res.html");
        }
        public static void AddCookie(HttpRequest http, string cookie)
        {
            var temp = cookie.Split(';');
            foreach (var item in temp)
            {
                var temp2 = item.Split('=');
                if (temp2.Count() > 1)
                {
                    try
                    {
                        System.Net.Cookie cook = new System.Net.Cookie();
                        cook.Name = temp[0];
                        cook.Value = temp[1];
                        http.Cookies.Add(cook);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        public static string GetData(string url, HttpRequest http = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieStorage();
            }
            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }
            string html = "";
            try
            {
                html = http.Get(url).ToString();
            }
            catch (Exception ds)
            {
                html = ds.Message;
            }
            return html;
        }
        public static string PostData(HttpRequest http, string url, string data = null, string contentType = null, string userArgent = "", string cookie = null)
        {
            http.ConnectTimeout = 99999999;
            http.KeepAliveTimeout = 99999999;
            http.ReadWriteTimeout = 99999999;
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieStorage();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }

            string html = http.Post(url, data, contentType).ToString();
            return html;
        }
        public static string PostDataMulti(HttpRequest http, string url, MultipartContent data = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieStorage();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }

            string html = http.Post(url, data).ToString();
            return html;
        }
        public static void DownloadFile(string fileaname, string url)
        {
            HttpRequest http = new HttpRequest();
            http.ConnectTimeout = 99999999;
            http.KeepAliveTimeout = 99999999;
            http.ReadWriteTimeout = 99999999;
            var binImg = http.Get(url).ToMemoryStream().ToArray();
            File.WriteAllBytes(fileaname, binImg);
        }
        public static string SendEmail(string mainmail, string pass, string _email, string _description)
        {
            string senderID = mainmail;
            string senderPassword = pass;
            string result = "Email Sent Successfully";
            string body = _description;
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(_email);
                mail.From = new MailAddress(senderID);
                mail.Subject = "Repply";
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(senderID, senderPassword);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result.ToString();
        }
    }
}
