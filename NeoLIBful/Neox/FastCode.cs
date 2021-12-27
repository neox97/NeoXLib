using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIO
{
    public class NX
    {
        public static string[] namevn22 = { "Luu", "Tran", "Phung", "Do", "Luong", "Vu", "Nguyen", "Ha", "Anh", "Minh", "Chi", "Lien", "Trinh", "hoang", "thi", "huynh", "van", "trung", "quang", "giang", "hang", "tien" };
        public static string[] nameus156 = { "Brycen", "Barrows", "Jo", "Hessel", "Delphine", "Streich", "Eugene", "Ledner", "Hank", "On", "Peter", "Nolan", "Daphnee", "DuBuque", "Fred", "Maggio", "Elna", "Ed", "Antonio", "VonRueden", "Irwin", "Mueller", "Karson", "Kutch", "Eldora", "Mann", "Rudolph", "Stark", "Deontae", "Price", "Carole", "Kunze", "Bernard", "Wintheiser", "Theresia", "Ziemann", "Norris", "Skiles", "Tracey", "Schuster", "Eunice", "Littel", "Emanuel", "Jaskolski", "Leonard", "Wol", "Jane", "Schiller", "Michele", "Crona", "Rosetta", "Huel", "Andrew", "Vandervort", "Vincenza", "Hermiston", "Lacey", "Brekke", "Katheryn", "Jones", "Braxton", "Zulau", "Kathleen", "Bode", "Kaleb", "Kiehn", "Mertie", "Beatty", "Guy", "Bogan", "Macey", "Bartoletti", "Stephan", "Senger", "Narciso", "Goodwin", "Dolores", "Schneider", "Iva", "Cronin", "Lenny", "Nikolaus", "Bessie", "Hessel", "Sylvester", "McLaughlin", "Mariah", "Sporer", "Luella", "Yundt", "Monica", "Pouros", "Ewald", "Paucek", "Dan", "Koelpin", "Dudley", "Crooks", "Kattie", "Von", "Gwen", "Baumbach", "Madaline", "Wilderman", "Emmanuel", "Cronin", "Emerson", "Daugherty", "Camylle", "Schumm", "Chaz", "Hand", "Emilio", "Bashirian", "Ryan", "Oberbrunner", "Wendell", "Wisozk", "Agustina", "Blick", "Melba", "Yost", "Enrico", "Schultz", "Myah", "Bednar", "Carmel", "Wehner", "Dedric", "Gleichner", "Cydney", "Mayert", "Aniyah", "Williamson", "Kennedi", "Lind", "Luther", "Hartmann", "Greta", "Connor", "Kuhlman", "Mavis", "Daniel", "Jamir", "Moen", "Rosario", "Shields", "Camylle", "Koch", "Shaina", "Leuschke", "Genel", "Treutel", "Elmo", "Haley" };
        public static string[] UserAgentChrome =
        {
            "Mozilla/5.0 (X11; CrOS x86_64 11895.118.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.159 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12499.66.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.106 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12607.58.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.86 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12105.100.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.144 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 11895.95.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.125 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12239.92.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.136 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12607.81.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.119 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12607.82.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.123 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12371.75.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.105 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 11021.81.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12739.105.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.158 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12499.51.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.92 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12739.94.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.137 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12239.67.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.102 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 11021.56.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.76 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12105.90.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.129 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10895.78.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.120 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 11647.104.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.88 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 11895.21.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.141 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 11316.165.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.122 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10575.58.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 11647.154.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.114 Safari/537.36","Mozilla/5.0 (X11; CrOS armv7l 12499.66.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.106 Safari/537.36","Mozilla/5.0 (X11; CrOS armv7l 12105.100.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.144 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12105.75.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.102 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10032.86.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.140 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12371.89.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.120 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 11151.113.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.127 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12239.92.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.136 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10718.88.2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.118 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 9901.77.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.97 Safari/537.36","Mozilla/5.0 (X11; CrOS aarch64 12607.82.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.123 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 11151.59.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.94 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10895.56.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.95 Safari/537.36","Mozilla/5.0 (X11; CrOS armv7l 9592.96.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.114 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10323.67.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.209 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12739.87.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.128 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10176.76.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.190 Safari/537.36","Mozilla/5.0 (X11; CrOS aarch64 12499.66.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.106 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12739.111.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.162 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 9592.96.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.114 Safari/537.36","Mozilla/5.0 (X11; CrOS aarch64 12371.75.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.105 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 7262.57.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.98 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12371.89.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.120 Safari/537.36","Mozilla/5.0 (X11; CrOS aarch64 12607.58.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.86 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10452.85.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.158 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12239.67.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.102 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 9765.85.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.123 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 8350.68.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10323.67.9) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.209 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12371.75.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.105 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 9000.91.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.110 Safari/537.36","Mozilla/5.0 (X11; CrOS armv7l 10575.58.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 9901.66.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.82 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10032.75.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.116 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 9202.64.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.146 Safari/537.36","Mozilla/5.0 (X11; CrOS armv7l 12371.89.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.120 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 8872.76.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.105 Safari/537.36","Mozilla/5.0 (X11; CrOS aarch64 12105.100.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.144 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12371.75.2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.105 Safari/537.36","Mozilla/5.0 (X11; CrOS aarch64 12239.92.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.136 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 8743.83.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.93 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12239.92.2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.136 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 8530.96.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.154 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10575.55.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12371.75.3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.105 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10452.96.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 11316.148.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.117 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 8743.85.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.101 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 9460.73.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.134 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 9460.60.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.91 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 8172.60.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36","Mozilla/5.0 (X11; CrOS armv7l 11895.118.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.159 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 7390.68.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.82 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 7647.84.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36","Mozilla/5.0 (X11; CrOS armv7l 11021.56.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.76 Safari/537.36	","Mozilla/5.0 (X11; CrOS armv7l 12239.67.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.102 Safari/537.36	","Mozilla/5.0 (X11; CrOS x86_64 6310.68.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.96 Safari/537.36","Mozilla/5.0 (X11; CrOS armv7l 10895.78.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.120 Safari/537.36	","Mozilla/5.0 (X11; CrOS x86_64 8872.73.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.103 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10452.99.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.203 Safari/537.36	","Mozilla/5.0 (X11; CrOS armv7l 12371.75.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.105 Safari/537.36	","Mozilla/5.0 (X11; CrOS x86_64 8172.62.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 12105.100.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.144 Safari/537.36	","Mozilla/5.0 (X11; CrOS x86_64 10176.72.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.167 Safari/537.36","","Mozilla/5.0 (X11; CrOS x86_64 9765.81.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.120 Safari/537.36	","Mozilla/5.0 (X11; CrOS aarch64 11895.118.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.159 Safari/537.36	","Mozilla/5.0 (X11; CrOS aarch64 12499.51.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.92 Safari/537.36	","Mozilla/5.0 (X11; CrOS armv7l 12105.75.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.102 Safari/537.36	","Mozilla/5.0 (X11; CrOS armv7l 7390.61.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.71 Safari/537.36	","Mozilla/5.0 (X11; CrOS x86_64 10895.58.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.96 Safari/537.36	","Mozilla/5.0 (X11; CrOS x86_64 9460.73.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.134 Safari/537.36	","Mozilla/5.0 (X11; CrOS aarch64 12739.105.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.158 Safari/537.36","Mozilla/5.0 (X11; CrOS armv7l 8172.62.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 9592.85.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.112 Safari/537.36	","Mozilla/5.0 (X11; CrOS x86_64 8530.81.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.103 Safari/537.36	","Mozilla/5.0 (X11; CrOS x86_64 9334.72.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.140 Safari/537.36","","Mozilla/5.0 (X11; CrOS x86_64 10176.68.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.144 Safari/537.36","","Mozilla/5.0 (X11; CrOS x86_64 9000.82.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36","Mozilla/5.0 (X11; CrOS x86_64 10323.62.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.184 Safari/537.36"
        };
        Random rd = new Random();
        private static string getRandomItem(List<string> l)
        {
            Random r = new Random();
            return l[r.Next(l.Count)];
        }
        private void BeginInvoke(MethodInvoker methodInvoker)
        {
            throw new NotImplementedException();
        }
        public static string Getserial()
        {
            string cmdCommand = "vol C:";
            Process cmd = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            cmd.StartInfo = startInfo;
            cmd.Start();
            cmd.StandardInput.WriteLine(cmdCommand);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            string result = cmd.StandardOutput.ReadToEnd();
            string url = Regex.Match(result, "(Number is.*)").Groups[1].Value.Trim();
            url = url.Substring(9);
            MD5 mh = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(url);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static string OpenForder()
        {
            string folder = "";
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folder = diag.SelectedPath;
            }
            return folder;
        }
        public static void WriteLine(string tenfile, string chuoi)
        {
            using (StreamWriter file = new StreamWriter(tenfile, true, System.Text.Encoding.UTF8))
            {
                file.WriteLine(chuoi);
                file.Close();
            }
        }
        public static string GetRandomString(int dodaichuoi)
        {
            var random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, dodaichuoi).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9')
                    || (str[i] >= 'A' && str[i] <= 'z'))
                // || (str[i] == '.' || str[i] == '_')))
                {
                    sb.Append(str[i]);
                }
            }
            return sb.ToString();
        }
        public static List<string> GetValueRG(string str, string strregex = "(?<=\").*?(?=\"\")")
        {
            List<string> vs = new List<string>();
            var x = Regex.Matches(str,@strregex, RegexOptions.Singleline);
            foreach (var item in x)
            {
                vs.Add(item.ToString());
            }
            return  vs;
        }
        public static void DcomChange()
        {
            Thread main = new Thread(() =>
            {
                RunCMD(@"%Windir%\system32\rasdial /disconnect");
                Thread.Sleep(1000);
                RunCMD(@"%Windir%\system32\rasdial viettel");
            });
            main.IsBackground = true;
            main.Start();
        }

        public static void RunCMD(string cmd)
        {
            Process cmdProcess;
            cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.Arguments = "/c " + cmd;
            cmdProcess.StartInfo.Verb = "runas";
            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.Start();
            string output = cmdProcess.StandardOutput.ReadToEnd();
            cmdProcess.WaitForExit();
        }
        public static string ExecuteCMD(string cmdCommand, string path = null)
        {
            try
            {
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo()
                {

                    FileName = "cmd.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };
                if (path != null)
                {
                    process.StartInfo.WorkingDirectory = path;
                }
                process.Start();
                process.StandardInput.WriteLine(cmdCommand);
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.WaitForExit();
                return process.StandardOutput.ReadToEnd();
            }
            catch
            {
                return (string)null;
            }
        }
        public static string GetCode2FA(string key)
        {
            string secretString = key;
            var bytes = Base32Encoding.ToBytes(secretString.Replace(" ", ""));
            var totp = new Totp(bytes);
            string codeVerify = totp.ComputeTotp();
            return codeVerify;
        }
        public static void ChangIpVpn()
        {
            CallVPN(true);
            CallVPN();
        }
        public static void CallVPN(bool disconnect = false)
        {
            var r = new Random();
            Process process = new Process();
            //process.StartInfo.Verb = "runas";
            process.StartInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn-gui.exe";
            if (disconnect == false)
            {
                process.StartInfo.Arguments = "--command connect USA" + r.Next(0, 7).ToString() + ".ovpn";
            }
            else
            {
                process.StartInfo.Arguments = "--command disconnect_all";
            }
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            if (disconnect == false)
            {
                Thread.Sleep(7000);
            }
            else
            {
                //Thread.Sleep(4000);
            }
            process.Close();
        }
    }
    public static class Base32Encoding
    {
        public static byte[] ToBytes(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }

            input = input.TrimEnd('='); //remove padding characters
            int byteCount = input.Length * 5 / 8; //this must be TRUNCATED
            byte[] returnArray = new byte[byteCount];

            byte curByte = 0, bitsRemaining = 8;
            int mask = 0, arrayIndex = 0;

            foreach (char c in input)
            {
                int cValue = CharToValue(c);

                if (bitsRemaining > 5)
                {
                    mask = cValue << (bitsRemaining - 5);
                    curByte = (byte)(curByte | mask);
                    bitsRemaining -= 5;
                }
                else
                {
                    mask = cValue >> (5 - bitsRemaining);
                    curByte = (byte)(curByte | mask);
                    returnArray[arrayIndex++] = curByte;
                    curByte = (byte)(cValue << (3 + bitsRemaining));
                    bitsRemaining += 3;
                }
            }

            //if we didn't end with a full byte
            if (arrayIndex != byteCount)
            {
                returnArray[arrayIndex] = curByte;
            }

            return returnArray;
        }
        public static string ToString(byte[] input)
        {
            if (input == null || input.Length == 0)
            {
                throw new ArgumentNullException("input");
            }

            int charCount = (int)Math.Ceiling(input.Length / 5d) * 8;
            char[] returnArray = new char[charCount];

            byte nextChar = 0, bitsRemaining = 5;
            int arrayIndex = 0;

            foreach (byte b in input)
            {
                nextChar = (byte)(nextChar | (b >> (8 - bitsRemaining)));
                returnArray[arrayIndex++] = ValueToChar(nextChar);

                if (bitsRemaining < 4)
                {
                    nextChar = (byte)((b >> (3 - bitsRemaining)) & 31);
                    returnArray[arrayIndex++] = ValueToChar(nextChar);
                    bitsRemaining += 5;
                }

                bitsRemaining -= 3;
                nextChar = (byte)((b << bitsRemaining) & 31);
            }

            //if we didn't end with a full char
            if (arrayIndex != charCount)
            {
                returnArray[arrayIndex++] = ValueToChar(nextChar);
                while (arrayIndex != charCount) returnArray[arrayIndex++] = '='; //padding
            }

            return new string(returnArray);
        }
        public static int CharToValue(char c)
        {
            int value = (int)c;

            //65-90 == uppercase letters
            if (value < 91 && value > 64)
            {
                return value - 65;
            }
            //50-55 == numbers 2-7
            if (value < 56 && value > 49)
            {
                return value - 24;
            }
            //97-122 == lowercase letters
            if (value < 123 && value > 96)
            {
                return value - 97;
            }

            throw new ArgumentException("Character is not a Base32 character.", "c");
        }
        public static char ValueToChar(byte b)
        {
            if (b < 26)
            {
                return (char)(b + 65);
            }

            if (b < 32)
            {
                return (char)(b + 24);
            }

            throw new ArgumentException("Byte is not a value Base32 value.", "b");
        }



    }
    public class Totp
    {
        const long unixEpochTicks = 621355968000000000L;
        const long ticksToSeconds = 10000000L;
        public const int step = 30;
        public const int totpSize = 6;
        public byte[] key;
        public Totp(byte[] secretKey)
        {
            key = secretKey;
        }
        public string ComputeTotp()
        {
            var window = CalculateTimeStepFromTimestamp(DateTime.UtcNow);

            var data = GetBigEndianBytes(window);

            var hmac = new HMACSHA1();
            hmac.Key = key;
            var hmacComputedHash = hmac.ComputeHash(data);

            int offset = hmacComputedHash[hmacComputedHash.Length - 1] & 0x0F;
            var otp = (hmacComputedHash[offset] & 0x7f) << 24
                   | (hmacComputedHash[offset + 1] & 0xff) << 16
                   | (hmacComputedHash[offset + 2] & 0xff) << 8
                   | (hmacComputedHash[offset + 3] & 0xff) % 1000000;

            var result = Digits(otp, totpSize);

            return result;
        }
        public int RemainingSeconds()
        {
            return step - (int)(((DateTime.UtcNow.Ticks - unixEpochTicks) / ticksToSeconds) % step);
        }
        public byte[] GetBigEndianBytes(long input)
        {
            // Since .net uses little endian numbers, we need to reverse the byte order to get big endian.
            var data = BitConverter.GetBytes(input);
            Array.Reverse(data);
            return data;
        }
        public long CalculateTimeStepFromTimestamp(DateTime timestamp)
        {
            var unixTimestamp = (timestamp.Ticks - unixEpochTicks) / ticksToSeconds;
            var window = unixTimestamp / (long)step;
            return window;
        }
        public string Digits(long input, int digitCount)
        {
            var truncatedValue = ((int)input % (int)Math.Pow(10, digitCount));
            return truncatedValue.ToString().PadLeft(digitCount, '0');
        }

    }

}
