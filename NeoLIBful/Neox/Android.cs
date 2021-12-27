using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace NIO
{
    public class Android
    {
        private static string LIST_DEVICES = "adb devices";
        private static string REBOOT = "adb -s {0} reboot";
        private static string ADDPROXY = "adb -s {0} shell settings put global http_proxy {1}";
        private static string CLIPBOARD = "adb -s {0} shell am broadcast -a clipper.set -e text \"{1}\"";
        private static string DELETEPROXY = "adb -s {0} shell settings delete global http_proxy";
        private static string TAP_DEVICES = "adb -s {0} shell input tap {1} {2}";
        private static string REMOUNT = "adb -s {0} remount";
        private static string SWIPE_DEVICES = "adb -s {0} shell input swipe {1} {2} {3} {4} {5}";
        private static string KEY_DEVICES = "adb -s {0} shell input keyevent {1}";
        private static string DELETEFILE = "adb -s {0} shell rm -f \"{1}\" ";
        private static string POST_FILE = "adb -s {0} push \"{1}\" \"{2}\"";
        private static string INSTALL = "adb -s {0} install \"{1}\"";
        private static string UNINSTALL = "adb -s {0} uninstall {1}";
        private static string WIPEDATA = "adb -s {0} shell pm clear \"{1}\"";
        private static string STOPAPP = "adb -s {0} shell am force-stop \"{1}\"";
        private static string SETTINGFB = "adb -s {0} shell am start -a android.intent.action.VIEW -d fb://settings";
        private static string Schemes = "adb -s {0} shell am start -a android.intent.action.VIEW -d fb://{1}";
        private static string GET_FILE = "adb -s {0} pull {1} {2}";
        private static string BACUPDATA = "adb -s {0} backup -f \"{1}\" {2}";
        private static string RESTORE = "adb -s {0} restore {2}";
        private static string INPUT_TEXT_DEVICES = "adb -s {0} shell input text \"{1}\"";
        private static string CAPTURE_SCREEN_TO_DEVICES = "adb -s {0} shell screencap -p \"{1}\"";
        private static string PULL_SCREEN_FROM_DEVICES = "adb -s {0} pull \"{1}\"";
        private static string REMOVE_SCREEN_FROM_DEVICES = "adb -s {0} shell rm -f \"{1}\"";
        private static string GET_SCREEN_RESOLUTION = "adb -s {0} shell dumpsys display | Find \"mCurrentDisplayRect\"";
        private static string ADB_FOLDER_PATH = "";
        private static string ADB_PATH = "";
        private const int DEFAULT_SWIPE_DURATION = 50;
        //adb shell am start -a android.intent.action.VIEW -d fb://faceweb/f?href=/1788049708028056
        public static void TapByPicture(string deviceID, Bitmap bitm, Bitmap bitm1 = null)
        {
            checksomeelement:
            Bitmap screen = Android.ScreenShoot(deviceID);
            var point = ImageScanOpenCV.FindOutPoint(screen, bitm);
            var point1 = ImageScanOpenCV.FindOutPoint(screen, bitm);
            if (point != null)
            {
                Android.Tap(deviceID, point.Value.X, point.Value.Y);
            }
            else if (point1 != null)
            {
                Android.Tap(deviceID, point1.Value.X, point1.Value.Y);
            }
            else
            {
                goto checksomeelement;
            }
        }
        public static void InPutText(string deviceID, string TextCanInput, int delay = 200)
        {
            var text = Regex.Matches(TextCanInput, ".", RegexOptions.Singleline);
            foreach (var item in text)
            {
                Task m = new Task(() =>
                {
                    InputText(deviceID, item.ToString());
                });
                m.Start();
                Thread.Sleep(delay);
            }
        }
        public static void TapByPictureRE(string deviceID, Bitmap bitm)
        {
            checksomeelement:
            var screen = Android.ScreenShoot(deviceID);
            var point = ImageScanOpenCV.FindOutPoint(screen, bitm);
            if (point != null)
            {
                Android.Tap(deviceID, point.Value.Y, point.Value.X);
            }
            else
            {
                goto checksomeelement;
            }
        }
        public static bool CheckPoint(string deviceID, Bitmap bitm, Bitmap bitm1 = null, Bitmap bitm2 = null, Bitmap bitm3 = null)
        {
            var screen = Android.ScreenShoot(deviceID);
            var point = ImageScanOpenCV.FindOutPoint(screen, bitm, 0.9);
            var point1 = ImageScanOpenCV.FindOutPoint(screen, bitm1);
            var point2 = ImageScanOpenCV.FindOutPoint(screen, bitm2);
            var point3 = ImageScanOpenCV.FindOutPoint(screen, bitm3);
            if (point != null)
            {
                return true;
            }
            else if (point1 != null)
            {
                return true;
            }
            else if (point2 != null)
            {
                return true;
            }
            else if (point3 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool seachImage(string deviceID, Bitmap bitm, Bitmap bitm2)
        {
            checksomeelement:
            var screen = Android.ScreenShoot(deviceID);
            var point = ImageScanOpenCV.FindOutPoint(screen, bitm);
            if (point != null)
            {
                return true;
            }
            else
            {
                var screen1 = Android.ScreenShoot(deviceID);
                var point1 = ImageScanOpenCV.FindOutPoint(screen, bitm2);
                if (point != null)
                {
                    return false;
                }
                else
                {
                    goto checksomeelement;
                }
            }
        }
        public static string DeviceFisrt()
        {
            string deviceID = null;
            var listDevice = Android.GetDevices();
            if (listDevice != null && listDevice.Count > 0)
            {
                deviceID = listDevice.First();
            }
            return deviceID;
        }
        public static string DeviceLast()
        {
            string deviceID = null;
            var listDevice = Android.GetDevices();
            if (listDevice != null && listDevice.Count > 0)
            {
                deviceID = listDevice.Last();
            }
            return deviceID;
        }
        public static void InstallApk(string deviceID, string DuongDanFileApk)
        {
            Android.Install(deviceID, DuongDanFileApk);
        }
        public static void PostFileToDevices(string deviceID, string DuongDanFilePOST, string DuongDanNhanFilePOST)
        {
            Android.PostFile(deviceID, DuongDanFilePOST, DuongDanNhanFilePOST);
        }
        public static void WipeData(string deviceID, string TenPackage)
        {
            Android.Deletedata(deviceID, TenPackage);
        }
        public static void ScreenSot(string deviceID, string TenFilePNGcanluu)
        {
            Android.ScreenShoot(deviceID, false, TenFilePNGcanluu);
        }
        public static void Reboot(string deviceID)
        {
            Android.Rebootdevice(deviceID);
        }
        public static void ClipBoard(string deviceID, string text)
        {
            Android.Sendclb(deviceID, text);
        }
        public static List<string> getlistdevice()
        {
            List<string> devices = Android.GetDevices();
            return devices;
        }
        public static string SetADBFolderPath(string folderPath)
        {
            Android.ADB_FOLDER_PATH = folderPath;
            Android.ADB_PATH = folderPath + "adb.exe";
            if (File.Exists(Android.ADB_PATH))
                return (string)null;
            return "ADB Path not Exits!!!";
        }
        public static string ExecuteCMD(string cmdCommand)
        {
            try
            {
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo()
                {
                    WorkingDirectory = Android.ADB_FOLDER_PATH,
                    FileName = "cmd.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };
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
        public static List<string> GetDevices()
        {
            List<string> stringList = new List<string>();
            MatchCollection matchCollection = Regex.Matches(Android.ExecuteCMD(Android.LIST_DEVICES), "(?<=List of devices attached ).*?(?=" + Path.GetPathRoot(AppDomain.CurrentDomain.BaseDirectory).Replace("\\", "") + ")", RegexOptions.Singleline);
            if (matchCollection != null && matchCollection.Count > 0)
            {
                foreach (object obj in matchCollection)
                {
                    string[] strArray = obj.ToString().Split(new string[1]
                    {
            "device"
                    }, StringSplitOptions.None);
                    for (int index = 0; index < strArray.Length - 1; ++index)
                    {
                        string str = strArray[index].Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        stringList.Add(str);
                    }
                }
            }
            return stringList;
        }
        public static void TapByPercent(string deviceID, double x, double y)
        {
            Point screenResolution = Android.GetScreenResolution(deviceID);
            int num1 = (int)(x * ((double)screenResolution.X * 1.0 / 100.0));
            int num2 = (int)(y * ((double)screenResolution.Y * 1.0 / 100.0));
            Android.ExecuteCMD(string.Format(Android.TAP_DEVICES, (object)deviceID, (object)num1, (object)num2));
        }
        public static void Tap(string deviceID, int x, int y)
        {
            Android.ExecuteCMD(string.Format(Android.TAP_DEVICES, (object)deviceID, (object)x, (object)y));
        }
        public static void Backup(string deviceID, string tenfile, string pakagename)
        {
            Android.ExecuteCMD(string.Format(Android.BACUPDATA, (object)deviceID, (object)tenfile, (object)pakagename));
        }
        public static void Restore(string deviceID, string tenfile)
        {
            Android.ExecuteCMD(string.Format(Android.RESTORE, (object)deviceID, (object)tenfile));
        }
        public static void Sendclb(string deviceID, string text)
        {
            Android.ExecuteCMD(string.Format(Android.CLIPBOARD, (object)deviceID, (object)text));
        }
        public static void Key(string deviceID, ADBKey key)
        {
            Android.ExecuteCMD(string.Format(Android.KEY_DEVICES, (object)deviceID, (object)key));
        }
        public static void GotoSettingFb(string deviceID)
        {
            Android.ExecuteCMD(string.Format(Android.SETTINGFB, (object)deviceID));
        }
        public static void PostFile(string deviceID, string tenfile, string duongdan)
        {
            Android.ExecuteCMD(string.Format(Android.POST_FILE, (object)deviceID, (object)tenfile, (object)duongdan));
        }
        public static void Install(string deviceID, string duongdan)
        {
            Android.ExecuteCMD(string.Format(Android.INSTALL, (object)deviceID, (object)duongdan));
        }
        public static void Uninstall(string deviceID, string packagename)
        {
            Android.ExecuteCMD(string.Format(Android.UNINSTALL, (object)deviceID, (object)packagename));
        }
        public static void ClearData(string deviceID, string packagename)
        {
            Android.WipeData(deviceID, packagename);
            Android.ExecuteCMD("adb -s " + deviceID + " shell rm -r data/data/" + packagename);
            //Android.ExecuteCMD("adb -s " + deviceID + " shell rm -r /data/user/0/" + packagename);
            Android.ExecuteCMD("adb -s " + deviceID + " shell mkdir -p data/data/" + packagename);
        }
        public static void Deletedata(string deviceID, string packagename)
        {
            Android.ExecuteCMD(string.Format(Android.WIPEDATA, (object)deviceID, (object)packagename));
        }
        public static void ForeStop(string deviceID, string packagename)
        {
            Android.ExecuteCMD(string.Format(Android.STOPAPP, (object)deviceID, (object)packagename));
        }
        public static void GetFile(string deviceID, string duongdanfilecanlay, string duongdanfileluu)
        {
            Android.ExecuteCMD(string.Format(Android.GET_FILE, (object)deviceID, (object)duongdanfilecanlay, (object)duongdanfileluu));
        }
        public static void InputText(string deviceID, string text)
        {
            Android.ExecuteCMD(string.Format(Android.INPUT_TEXT_DEVICES, (object)deviceID, (object)text.Replace(" ", "%s")));
        }
        public static void ExecuteSchemes(string deviceID, string text)
        {
            Android.ExecuteCMD(string.Format(Android.Schemes, (object)deviceID, (object)text));
        }
        public static void FakeIpByProxy(string deviceID, string ipport)
        {
            Android.ExecuteCMD(string.Format(Android.ADDPROXY, (object)deviceID, (object)ipport));
        }
        public static void DeleteProxy(string deviceID)
        {
            Android.ExecuteCMD(string.Format(Android.DELETEPROXY, (object)deviceID));
        }
        public static void DeleteFile(string deviceID, string FilePath)
        {
            Android.ExecuteCMD(string.Format(Android.DELETEFILE, (object)deviceID, (object)FilePath));
        }
        public static void Remount(string deviceID)
        {
            Android.ExecuteCMD(string.Format(Android.REMOUNT, (object)deviceID));
        }
        public static void Rebootdevice(string deviceID)
        {
            Android.ExecuteCMD(string.Format(Android.REBOOT, (object)deviceID));
        }

        public static void SwipeByPercent(
        string deviceID,
       double x1,
      double y1,
      double x2,
      double y2,
      int duration = 100)
        {
            Point screenResolution = Android.GetScreenResolution(deviceID);
            int num1 = (int)(x1 * ((double)screenResolution.X * 1.0 / 100.0));
            int num2 = (int)(y1 * ((double)screenResolution.Y * 1.0 / 100.0));
            int num3 = (int)(x2 * ((double)screenResolution.X * 1.0 / 100.0));
            int num4 = (int)(y2 * ((double)screenResolution.Y * 1.0 / 100.0));
            Android.ExecuteCMD(string.Format(Android.SWIPE_DEVICES, (object)deviceID, (object)num1, (object)num2, (object)num3, (object)num4, (object)duration));
        }

        public static void Swipe(string deviceID, int x1, int y1, int x2, int y2, int duration = 100)
        {
            Android.ExecuteCMD(string.Format(Android.SWIPE_DEVICES, (object)deviceID, (object)x1, (object)y1, (object)x2, (object)y2, (object)duration));
        }

        public static void LongPress(string deviceID, int x, int y, int duration = 100)
        {
            Android.ExecuteCMD(string.Format(Android.SWIPE_DEVICES, (object)deviceID, (object)x, (object)y, (object)x, (object)y, (object)duration));
        }

        public static Point GetScreenResolution(string deviceID)
        {
            string str1 = Android.ExecuteCMD(string.Format(Android.GET_SCREEN_RESOLUTION, (object)deviceID));
            string str2 = str1.Substring(str1.IndexOf("- "));
            string[] strArray = str2.Substring(str2.IndexOf(' '), str2.IndexOf(')') - str2.IndexOf(' ')).Split(',');
            return new Point(Convert.ToInt32(strArray[0].Trim()), Convert.ToInt32(strArray[1].Trim()));
        }

        public static Bitmap ScreenShoot(string deviceID = null, bool isDeleteImageAfterCapture = true, string fileName = "screenShoot.png")
        {
            getimg:
            try
            {
                fileName = NX.RemoveSpecialCharacters(deviceID) + ".png";
            }
            catch
            {
                fileName = deviceID + ".png";
            }
            Android.ExecuteCMD("adb -s " + deviceID + " shell screencap -p /sdcard/a.png");
            Thread.Sleep(200);
            try
            {
                Android.GetFile(deviceID, "/sdcard/a.png", fileName);
            }
            catch
            {
                goto getimg;
            }
            Bitmap bitmap = null;
            FileStream  file = new FileStream("Data/" + fileName, FileMode.Open, FileAccess.Read);
            bitmap = (Bitmap)Bitmap.FromStream(file);
            Thread.Sleep(100);
            file.Close();
            if (isDeleteImageAfterCapture == true)
            {
                File.Delete("Data/" + fileName);
            }
            return bitmap;

        }

        public static Bitmap ScreenShoot2(string deviceID, string path, bool deletefile = true)
        {
            Android.ExecuteCMD("adb -s " + deviceID + " shell screencap -p /sdcard/a.png");
            Android.GetFile(deviceID, "/sdcard/a.png", path);
            Bitmap bitmap = null;
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            bitmap = (Bitmap)Bitmap.FromStream(file);
            file.Close();
            if (deletefile == true)
            {
                File.Delete(path);
            }
            return bitmap;
        }
    }
    public class ImageScanOpenCV
    {
        public static Bitmap GetImage(string path)
        {
            return new Bitmap(path);
        }

        public static Bitmap Find(string main, string sub, double percent = 0.7)
        {
            ImageScanOpenCV.GetImage(main);
            ImageScanOpenCV.GetImage(sub);
            return ImageScanOpenCV.Find(main, sub, percent);
        }

        public static Bitmap Find(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.7)
        {
            Image<Bgr, byte> image1 = new Image<Bgr, byte>(mainBitmap);
            Image<Bgr, byte> template = new Image<Bgr, byte>(subBitmap);
            Image<Bgr, byte> image2 = image1.Copy();
            using (Image<Gray, float> image3 = image1.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] maxValues;
                Point[] maxLocations;
                image3.MinMax(out double[] _, out maxValues, out Point[] _, out maxLocations);
                if (maxValues[0] > percent)
                {
                    Rectangle rect = new Rectangle(maxLocations[0], template.Size);
                    image2.Draw(rect, new Bgr(System.Drawing.Color.Red), 2, LineType.EightConnected, 0);
                }
                else
                    image2 = (Image<Bgr, byte>)null;
            }
            return image2 == null ? (Bitmap)null : image2.ToBitmap();
        }

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public static Point? FindOutPoint(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.7)
        {
            if (subBitmap == null || mainBitmap == null)
                return new Point?();
            Thread.Sleep(100);
            if (subBitmap.Width > mainBitmap.Width || subBitmap.Height > mainBitmap.Height)
                return new Point?();
            Image<Bgr, byte> image1 = new Image<Bgr, byte>(mainBitmap);
            Image<Bgr, byte> template = new Image<Bgr, byte>(subBitmap);
            Point? nullable = new Point?();
            using (Image<Gray, float> image2 = image1.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] maxValues;
                Point[] maxLocations;
                image2.MinMax(out double[] _, out maxValues, out Point[] _, out maxLocations);
                if (maxValues[0] > percent)
                    nullable = new Point?(maxLocations[0]);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return nullable;
        }

        public static List<Point> FindOutPoints(
          Bitmap mainBitmap,
          Bitmap subBitmap,
          double percent = 0.9)
        {
            Image<Bgr, byte> image1 = new Image<Bgr, byte>(mainBitmap);
            Image<Bgr, byte> template = new Image<Bgr, byte>(subBitmap);
            List<Point> pointList = new List<Point>();
            while (true)
            {
                using (Image<Gray, float> image2 = image1.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
                {
                    double[] maxValues;
                    Point[] maxLocations;
                    image2.MinMax(out double[] _, out maxValues, out Point[] _, out maxLocations);
                    if (maxValues[0] > percent)
                    {
                        Rectangle rect = new Rectangle(maxLocations[0], template.Size);
                        image1.Draw(rect, new Bgr(System.Drawing.Color.Blue), -1, LineType.EightConnected, 0);
                        pointList.Add(maxLocations[0]);
                    }
                    else
                        break;
                }
            }
            return pointList;
        }

        public static List<Point> FindColor(Bitmap mainBitmap, System.Drawing.Color color)
        {
            int argb = color.ToArgb();
            List<Point> pointList = new List<Point>();
            using (Bitmap bitmap = mainBitmap)
            {
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    for (int y = 0; y < bitmap.Height; ++y)
                    {
                        if (argb.Equals(bitmap.GetPixel(x, y).ToArgb()))
                            pointList.Add(new Point(x, y));
                    }
                }
            }
            return pointList;
        }


    }

}
