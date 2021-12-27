using Leaf.xNet;
using NIO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace NIO
{
    public class FB
    {
        public static string[] work = { "Quảng Cáo", "Người mẫu quảng cáo", "MAKE UP FOR EVER", "Lập Trình Viên", "Thư Viện Lập Trình", "Sinh viên", "Sinh Viên Việt Nam", "Học viện IBPO", "Elcom Corp(Official)", "Tinhvan Group", "Tinhvan Outsourcing Jsc., (TVO)", "Education for Nature - Vietnam(ENV)", "Cho thuê sim", "KFC HNBM", "LuLu Wedding - Phóng Sự Cưới", "OTVINA Company Limited", "Afiliate Marketing KIẾM TIỀN AZ", "Linh Jace Makeup Academy", "Học Viện Chém Gió", "Học Viện Ngôi Sao - Star Academy Vietnam", "Học sinh, Sinh viên Việt Nam", "Thông Tin Tuyển Sinh" };
        public static string[] school = { "Đại học Bôn Ba-khoa chém gió", "đại học bôn ba", "Trường Đại Học Bôn Ba", "Harved university", "Đại học Chém Gió Hà Nội", "Tuổi trẻ Đại học Sài Gòn", "Trường Đại học Kinh tế - Đại học Quốc gia Hà Nội", "Học viện Chém gió Quốc gia Việt Nam", "Học Viện Ngôi Sao - Star Academy Vietnam", "Đại Học Hàng Hải", "Đại Học Hải Phòng", "Đại học Y Hải Phòng", "Đội Sinh Viên Tình Nguyện Đại Học Y Dược Hải Phòng - HPUMP SVT", "Đại học Greenwich Việt Nam", "Cổng thông tin Trung ương Đoàn TNCS Hồ Chí Minh", "Học viện Ninja - Naruto Đại Chiến", "Naruto Đại Chiến - Học Viện Ninja", "Thượng Cổ Kỳ Duyên" };
        public static string[] city = { "Thái Nguyên", "An Giang", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bình Định", "Cà Mau", "Trà Vinh", "Tuyên Quang", "Đà Nẵng", "Hà Nội" };
        public static string[] town = { "Thái Nguyên", "An Giang", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bình Định", "Cà Mau", "Trà Vinh", "Tuyên Quang", "Đà Nẵng", "Hà Nội" };
        public static void ChangInfo(string cookie)
        {
            var r = new Random();
            var http = new HttpRequest();
            http.Cookies = new CookieStorage();
            string userAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_1_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/16D57";
            string getdata = RQX.GetData("https://mbasic.facebook.com/editprofile/eduwork/add/?type=1&_rdr", http, userAgent, cookie);
            // RQX.TestData(getdata);
            string fb_dtsg = "";
            try
            {
                fb_dtsg = Regex.Matches(getdata, "(?<=name=\"fb_dtsg\" value=\").*?(?=\")", RegexOptions.Singleline)[0].ToString();
            }
            catch
            {
                return;
            }
            string jazoest = Regex.Matches(getdata, "(?<=name=\"jazoest\" value=\").*?(?=\")", RegexOptions.Singleline)[0].ToString();
            try
            {
                ChangeCity(http, fb_dtsg, jazoest, "Hanoi");
            }
            catch { }
            try
            {
                ChangeTown(http, fb_dtsg, jazoest, "Hanoi");
            }
            catch { }
            try
            {
                ChangeWork(http, fb_dtsg, jazoest, FB.work[r.Next(0, FB.work.Count())]);
            }
            catch { }
            try
            {
                ChangeSchool(http, fb_dtsg, jazoest, FB.school[r.Next(0, FB.school.Count())]);
            }
            catch { }

        }
        public static void ChangeWork(HttpRequest http, string fb_dtsg, string jazoest, string work)
        {
            string userAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_1_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/16D57";
            string data = "fb_dtsg=" + fb_dtsg + "&jazoest=" + jazoest + "&query=" + work;
            string html = RQX.PostData(http, "https://mbasic.facebook.com/profile/edit/exp/work/confirm/?session_id=7825ebea3f743a34747f&typeahead_sid=cee816a2-92e4-4ca7-a7c3-1dabbcc392a2", data, "application/x-www-form-urlencoded", userAgent);
            // TestData(html);
            string urlpostwork = html.Substring(html.IndexOf("profile/create/exp/work/"));
            urlpostwork = "https://mbasic.facebook.com/" + urlpostwork.Substring(0, urlpostwork.IndexOf("\"")).Replace("amp;", "");
            RQX.GetData(urlpostwork, http, userAgent);
            // MessageBox.Show("Change Work Thanh Cong");
        }
        public static void ChangeSchool(HttpRequest http, string fb_dtsg, string jazoest, string school)
        {
            string data = "fb_dtsg=" + fb_dtsg + "&jazoest=" + jazoest + "&query=" + school;
            string userAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_1_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/16D57";
            string html = RQX.PostData(http, "https://mbasic.facebook.com/profile/edit/exp/edu/confirm/?school_type=1&session_id=fd768989-c3da-40ca-b7f2-9a8a0ab48f64&typeahead_sid=fd768989-c3da-40ca-b7f2-9a8a0ab48f64", data, "application/x-www-form-urlencoded", userAgent);
            //TestData(html);
            string urlpost = html.Substring(html.IndexOf("profile/create/exp/edu/"));
            urlpost = "https://mbasic.facebook.com/" + urlpost.Substring(0, urlpost.IndexOf("\"")).Replace("amp;", "");
            RQX.GetData(urlpost, http, userAgent);

        }
        public static void ChangeCity(HttpRequest http, string fb_dtsg, string jazoest, string thanhpho)
        {
            string data = "fb_dtsg=" + fb_dtsg + "&jazoest=" + jazoest + "&edit=current_city&type=basic&current_city[]=" + thanhpho + "&privacy%5B8787650733%5D=300645083384735&save=L%C6%B0u";
            string userAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_1_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/16D57";
            RQX.PostData(http, "https://mbasic.facebook.com/a/editprofile.php", data, "application/x-www-form-urlencoded", userAgent);
            // TestData(html);
        }
        public static void ChangeTown(HttpRequest http, string fb_dtsg, string jazoest, string thanhpho)
        {
            string data = "fb_dtsg=" + fb_dtsg + "&jazoest=" + jazoest + "&edit=hometown&type=basic&hometown%5B%5D=" + thanhpho + "&privacy%5B8787655733%5D=300645083384735&save=L%C6%B0u";
            string userAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_1_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/16D57";
            RQX.PostData(http, "https://mbasic.facebook.com/a/editprofile.php", data, "application/x-www-form-urlencoded", userAgent);
            //TestData(html);
        }
        public static void UpdateBio(HttpRequest http, string fb_dtsg, string jazoest, string text)
        {
            //string data = "fb_dtsg=" + fb_dtsg + "&jazoest=" + jazoest + "&edit=hometown&type=basic&hometown%5B%5D=" + thanhpho + "&privacy%5B8787655733%5D=300645083384735&save=L%C6%B0u";
            string data = "fb_dtsg=" + fb_dtsg + "&jazoest=" + jazoest + "&bio=" + text;
            string userAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 12_1_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/16D57";
            RQX.PostData(http, "https://mbasic.facebook.com/profile/intro/bio/save/", data, "application/x-www-form-urlencoded", userAgent);
            //TestData(html);
        }
        public static string GetTokenFacebook(string account, string password)
        {
            string token = "";
            try
            {
                token = RQX.GetData("https://b-graph.facebook.com/auth/login?email=" + account + "&password=" + password + "&access_token=6628568379|c1e620fa708a1d5696fb991c1bde5662&method=post");
                if (token.Contains("EAA"))
                {
                    token = token.Substring(token.IndexOf("EAA"));
                    token = token.Substring(0, token.IndexOf("\""));
                }
                else
                {
                    token = "Fail";
                }
            }
            catch (Exception loi)
            {
                token = loi.Message;
            }

            return token;
        }
        public static bool LoginS(ChromeDriver driver, string cookie)
        {
            driver.Manage().Cookies.DeleteAllCookies();
            Selenium.GotoUrl(driver, "https://upload.facebook.com/");
            var allcookie = cookie.Split(';');
            for (int i = 0; i < allcookie.Count() - 1; i++)
            {
                try
                {
                    var keyvalue = allcookie[i].Split('=');
                    Cookie cooke = new OpenQA.Selenium.Cookie(keyvalue[0].ToString(), keyvalue[1].ToString());
                    driver.Manage().Cookies.AddCookie(cooke);
                }
                catch
                {

                }
            }
            driver.Navigate().Refresh();
            Selenium.GotoUrl(driver, "https://mbasic.facebook.com/");
            for (int i = 0; i < allcookie.Count() - 1; i++)
            {
                try
                {
                    var keyvalue = allcookie[i].Split('=');
                    Cookie cooke = new OpenQA.Selenium.Cookie(keyvalue[0].ToString(), keyvalue[1].ToString());
                    driver.Manage().Cookies.AddCookie(cooke);
                }
                catch
                {

                }
            }
            driver.Navigate().Refresh();
            return true;
        }
        public static void UploadAvatarS(ChromeDriver driver)
        {
            var r = new Random();
            Selenium.GotoUrl(driver, "https://mbasic.facebook.com/profile_picture");
            string fulpath = Path.GetFullPath("avatar/" + r.Next(1, 1140) + ".jpg");
            Selenium.SentTextByXpath(driver, "/html/body/div/div/div[2]/div/table/tbody/tr/td/div[1]/div[4]/form/ol/li[1]/input", fulpath);
            Selenium.ClickXpath(driver, "/html/body/div/div/div[2]/div/table/tbody/tr/td/div[1]/div[4]/form/ol/li[2]/input");
            Thread.Sleep(5000);
        }
        public static string TwoFaS(ChromeDriver driver)
        {
            Selenium.GotoUrl(driver, "https://mbasic.facebook.com/security/2fac/setup/intro/");
            if (driver.Url.Contains("checkpoint") || driver.PageSource.Contains("Sorry, something went wrong."))
            {
                return "cp";
            }
            string link = driver.PageSource.Substring(driver.PageSource.IndexOf("qrcode/generate/"));
            link = "https://mbasic.facebook.com/security/2fac/setup/" + link.Substring(0, link.IndexOf("\""));
            Selenium.GotoUrl(driver, link.Replace("amp;", ""));
            var element = driver.FindElementByXPath("/html/body/div/div/div[2]/div/table/tbody/tr/td/form/div[2]/div/table/tbody/tr/td/div/div[2]/div[2]");
            string twofakey = element.Text;
            Selenium.ClickXpath(driver, "/html/body/div/div/div[2]/div/table/tbody/tr/td/form/div[3]/div/input");
            string code = NX.GetCode2FA(twofakey);
            Selenium.SendText(driver, "#type_code_container", code);
            Selenium.Click(driver, "#submit_code_button");
            Thread.Sleep(3000);
            return twofakey;
        }
        public static void AddMailS(ChromeDriver driver, string mail, string pass)
        {
            Selenium.GotoUrl(driver, "https://mbasic.facebook.com/settings/email/add");

            Selenium.SendTextByName(driver, "email", mail);
            if (Selenium.CheckName(driver, "save_password"))
            {
                Selenium.SendTextByName(driver, "save_password", pass);
                Selenium.Click(driver, "#m-settings-form > div:nth-child(8) > input");

            }
            else
            {
                Selenium.Click(driver, "#m-settings-form > div:nth-child(6) > input");
            }
            Thread.Sleep(3333);
        }
        public static void AddSuggestionFriend(ChromeDriver driver)
        {
            Selenium.GotoUrl(driver, "https://m.facebook.com/friends/center/suggestions/");
            for (int i = 0; i <= 10; i++)
            {
                Selenium.ClickXpath(driver, "/html/body/div[1]/div/div[4]/div/div[1]/div[2]/div[" + i + "]/div[2]/div/div[3]/div[1]/div/div[1]/a/button",5);
                Thread.Sleep(500);
            }
        }
        public static void ContactRemoveMailS(ChromeDriver driver, string mail)
        {
            Random r = new Random();
            Selenium.GotoUrl(driver, "https://m.facebook.com/help/contact/255904741169641");
            Selenium.ClickXpath(driver, "/html/body/div[1]/div/div[3]/article/form/div[1]/div/div[2]/div[1]/div/div/label[2]/input",5);
            Selenium.SendTextByName(driver, "email", mail + "@gmail.com");
            Selenium.SendTextByName(driver, "details", "my email is used ! Please help me");
            Selenium.SendTextByName(driver, "full_name", NX.namevn22[r.Next(0, 22)] + " " + NX.namevn22[r.Next(0, 22)]);
            Selenium.SendTextByName(driver, "dob[year]", "1987");
            Selenium.ClickXpath(driver, "/html/body/div[1]/div/div[3]/article/form/div[1]/div/div[2]/div[9]/div/div/label/input",5);
            Selenium.ClickXpath(driver, "/html/body/div[1]/div/div[3]/article/form/div[2]/button",5);
            Thread.Sleep(2000);
        }
        public static void AddInfoS(ChromeDriver driver)
        {
            Selenium.GotoUrl(driver, "https://m.facebook.com/profile/wizard/nux/?step=4");
            Selenium.ClickXpath(driver, "/html/body/div[1]/div/div[4]/div/div[1]/div/div[2]/div/div[2]/div/div[1]/div/span/div/div/form/div[1]/div/div[1]/a[1]/p", 2);
            Selenium.ClickByName(driver, "save", 2);
            Selenium.ClickXpath(driver, "/html/body/div[1]/div/div[4]/div/div[1]/div/div[2]/div/div[2]/div/div[2]/div/span/div/div/form/div[1]/div/div[1]/a[1]/p[2]", 2);
            Selenium.ClickByName(driver, "save", 2);
            Selenium.ClickXpath(driver, "/html/body/div[1]/div/div[4]/div/div[1]/div/div[2]/div/div[2]/div/div[3]/div/span/div/div/form/div[1]/div/div[1]/a[1]/p[1]", 2);
            Selenium.ClickByName(driver, "save", 2);
            Selenium.ClickXpath(driver, "/html/body/div[1]/div/div[4]/div/div[1]/div/div[2]/div/div[2]/div/div[4]/div/span/div/div/form/div[1]/div/div[1]/a[1]/p", 2);
            Selenium.ClickByName(driver, "save", 2);
            Selenium.ClickXpath(driver, "/html/body/div[1]/div/div[4]/div/div[1]/div/div[2]/div/div[2]/div/div[5]/div/span/div/div/form/div[1]/div/div[1]/a[1]/p[1]", 2);
            Selenium.ClickByName(driver, "save", 2);
        }
    }
}
