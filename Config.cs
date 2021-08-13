using System.Windows.Forms;
using System.Text.RegularExpressions;
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;


namespace rdp
{
    public class Config
    {

        public static List<Link> host_list = new List<Link>();  //主机列表


        public static string ini_px = "12";  //分辨率选择
        public static int ini_Width = 800;   //分辨率宽
        public static int ini_Height = 600;   //分辨率高
        public static int ini_ColorDepth = 1;  //色彩
        public static int ini_AudioRedirectionMode = 2;  //远程音频播放
        public static int ini_NetworkConnectionType = 2;   //连接速度

        public static int ini_RedirectClipboard = 1;  //共享剪贴板
        public static int ini_EnableCredSspSupport = 1;  //网络验证
        public static int ini_BitmapPersistence = 1;   //启用缓存
        public static string ini_Drive = "";   //磁盘映射列表

        public static string ini_fz = "1";   //分组
        public static string ini_Color = "1";   //颜色标记
        public static string ini_password = "";  //密码
        public static string ini_password_bool = "1";  //密码开启

        public static string ini_ping_run = "0";  // ping 开启
        public static string ini_ping_color = "1";  //  ping 颜色标记

        public static string ini_list_run = "1";  //视图模式是否开启
        public static string ini_list_index = "2";  //视图序号

        //=============================================
        public static string path= Application.StartupPath + "\\data\\Config.ini";
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        
        public static string Ini_GetValue_string(string section, string key)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                GetPrivateProfileString(section, key, "", stringBuilder, 1024, path);
                if (stringBuilder.ToString() == "")
                {
                    return "";
                }
                return stringBuilder.ToString();
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Ini_GetValue_string", "err:" + e.Message);
                return ""; }
        }
        public static int Ini_GetValue_int(string section, string key)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                GetPrivateProfileString(section, key, "", stringBuilder, 1024, path);
                if (stringBuilder.ToString() == "")
                {
                    return 0;
                }
                return Convert.ToInt32(stringBuilder.ToString());
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Ini_GetValue_int", "err:" + e.Message);
                return 0; }
        }
        //=============================================
        public static void Open_ini()   //读取配置
        {
            //Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvv" + ini_Width);
            //WritePrivateProfileString("Config", "Name", "11111111", path);
            if(Ini_GetValue_string("Config", "px") != "")
            {
                Set_Width_Height(Ini_GetValue_string("Config", "px"), false);    //设置宽度  高度
            }
            if(Ini_GetValue_string("Config", "ColorDepth") != "")
            {
                Set_ColorDeptht(Ini_GetValue_string("Config", "ColorDepth"), false);  //色彩
            }
            if(Ini_GetValue_string("Config", "NetworkConnectionType") != "")
            {
                Set_NetworkConnectionType(Ini_GetValue_string("Config", "NetworkConnectionType"), false);   //连接速度
            }
            if(Ini_GetValue_string("Config", "AudioRedirectionMode") != "")
            {
                Set_AudioRedirectionMode(Ini_GetValue_string("Config", "AudioRedirectionMode"), false);   //远程音频播放
            }
            if(Ini_GetValue_string("Config", "RedirectClipboard") != "")
            {
                Set_RedirectClipboard(Ini_GetValue_string("Config", "RedirectClipboard"), false);   //共享剪贴板
            }
            if(Ini_GetValue_string("Config", "EnableCredSspSupport") != "")
            {
                Set_EnableCredSspSupport(Ini_GetValue_string("Config", "EnableCredSspSupport"), false);   //网络验证
            }
            if(Ini_GetValue_string("Config", "BitmapPersistence") != "")
            {
                Set_BitmapPersistence(Ini_GetValue_string("Config", "BitmapPersistence"), false);   //启用缓存
            }
            if (Ini_GetValue_string("Config", "Drive") != "")
            {
                Set_Drive(Ini_GetValue_string("Config", "Drive"), false);   //共享磁盘分区
            }
            if (Ini_GetValue_string("Config", "fz") != "")
            {
                Set_fz(Ini_GetValue_string("Config", "fz"), false);   //分组
            }
            if (Ini_GetValue_string("Config", "Color") != "")
            {
                Set_Color(Ini_GetValue_string("Config", "Color"), false);    //颜色标记
            }


            if (Ini_GetValue_string("Config", "password") != "")
            {
                Set_password(Ini_GetValue_string("Config", "password"), false);    //密码
            }
            if (Ini_GetValue_string("Config", "password_bool") != "")
            {
                Set_password_bool(Ini_GetValue_string("Config", "password_bool"), false);    //密码开启
            }

            if (Ini_GetValue_string("Config", "ping_run") != "")
            {
                Set_ping_run(Ini_GetValue_string("Config", "ping_run"), false);    //ping 开启
            }
            if (Ini_GetValue_string("Config", "ping_color") != "")
            {
                Set_ping_color(Ini_GetValue_string("Config", "ping_color"), false);    //ping 颜色标记
            }

            if (Ini_GetValue_string("Config", "list_run") != "")
            {
                Set_list_run(Ini_GetValue_string("Config", "list_run"), false);    //视图模式是否开启
            }
            if (Ini_GetValue_string("Config", "list_index") != "")
            {
                Set_list_index(Ini_GetValue_string("Config", "list_index"), false);    //视图序号
            }








            try {
                Thread In = new Thread(new ThreadStart(Info.exec));
                In.IsBackground = true;
                In.Start(); 
            } catch (Exception e) { Msg.add("", e.Message); }

        }

        public static void Set_Width_Height(string index,bool Write = true)    //设置宽度  高度
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "px", index, path);
                }
                ini_px = index;  //分辨率选择
                if (index=="0") { ini_Width = 0; ini_Height = 0; return; }
                if (index == "1") { ini_Width = 1920; ini_Height = 1080; return; }
                if (index == "2") { ini_Width = 1680; ini_Height = 1050; return; }
                if (index == "3") { ini_Width = 1600; ini_Height = 1200; return; }
                if (index == "4") { ini_Width = 1440; ini_Height = 1050; return; }
                if (index == "5") { ini_Width = 1440; ini_Height = 900; return; }
                if (index == "6") { ini_Width = 1366; ini_Height = 768; return; }
                if (index == "7") { ini_Width = 1280; ini_Height = 1024; return; }
                if (index == "8") { ini_Width = 1280; ini_Height = 800; return; }
                if (index == "9") { ini_Width = 1280; ini_Height = 768; return; }
                if (index == "10") { ini_Width = 1280; ini_Height = 720; return; }
                if (index == "11") { ini_Width = 1152; ini_Height = 864; return; }
                if (index == "12") { ini_Width = 1024; ini_Height = 768; return; }
                if (index == "13") { ini_Width = 800; ini_Height = 600; return; }
                if (index == "14") { ini_Width = 640; ini_Height = 480; return; }
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_Width_Height", "err:" + e.Message);
            }
        }

        public static void Set_ColorDeptht(string index, bool Write = true)  //色彩
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "ColorDepth", index, path);
                }
                if (index == "0") { ini_ColorDepth = 256; return; }
                if (index == "1") { ini_ColorDepth = 15; return; }
                if (index == "2") { ini_ColorDepth = 16; return; }
                if (index == "3") { ini_ColorDepth = 24; return; }
                if (index == "4") { ini_ColorDepth = 32; return; }
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_ColorDeptht", "err:" + e.Message);
            }
        }

        public static void Set_AudioRedirectionMode(string index, bool Write = true)   //远程音频播放
        {
            //0  将声音重定向到客户端。 这是默认值。
            //1  在远程计算机上播放声音。
            //2  禁用声音重定向; 不要在服务器上播放声音。
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "AudioRedirectionMode", index, path);
                }
                ini_AudioRedirectionMode = Convert.ToInt32(index);
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_AudioRedirectionMode", "err:" + e.Message);
            }
        }

        public static void Set_NetworkConnectionType(string index, bool Write = true)   //连接速度
        {
            //连接 _键入 _ 调制解调器(1(0x1) )  调制解调器(56 Kbps)
            //连接 _键入 _ 宽带 _ 低(2(0x2) )  低速宽带(256 Kbps 到 2 Mbps)
            //连接 _键入 _ 附属(3(0x3) )     卫星(2 Mbps 到 16 Mbps，具有高延迟)
            //连接 _键入 _ 宽带 _ 高(4(0x4) )    高速宽带(2 Mbps 到 10 Mbps)
            //连接 _键入 _ WAN(5(0x5) )   广域网)  的广域网((10 Mbps 或更高，且延迟较高)
            //连接 _键入 _ LAN(6(0x6) )   局域网(LAN)(10 Mbps 或更高版本)
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "NetworkConnectionType", index, path);
                }
                if (index == "0") { ini_NetworkConnectionType = 1; return; }
                if (index == "1") { ini_NetworkConnectionType = 2; return; }
                if (index == "2") { ini_NetworkConnectionType = 3; return; }
                if (index == "3") { ini_NetworkConnectionType = 4; return; }
                if (index == "4") { ini_NetworkConnectionType = 5; return; }
                if (index == "5") { ini_NetworkConnectionType = 6; return; }
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_NetworkConnectionType", "err:" + e.Message);
            }
        }

        public static void Set_RedirectClipboard(string index, bool Write = true)   //共享剪贴板
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "RedirectClipboard", index, path);
                }
                ini_RedirectClipboard = Convert.ToInt32(index);
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_RedirectClipboard", "err:" + e.Message);
            }
        }

        public static void Set_EnableCredSspSupport(string index, bool Write = true)   //网络验证
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "EnableCredSspSupport", index, path);
                }
                ini_EnableCredSspSupport = Convert.ToInt32(index);
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_EnableCredSspSupport", "err:" + e.Message);
            }
        }

        public static void Set_BitmapPersistence(string index, bool Write = true)   //启用缓存
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "BitmapPersistence", index, path);
                }
                ini_BitmapPersistence = Convert.ToInt32(index);
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_BitmapPersistence", "err:" + e.Message);
            }
        }

        public static void Set_Drive(string index, bool Write = true)   //共享磁盘分区
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "Drive", index, path);
                }
                ini_Drive = index;
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_Drive", "err:" + e.Message);
            }
        }

        public static void Set_fz(string index, bool Write = true)   //分组
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "fz", index, path);
                }
                ini_fz = index;
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_fz", "err:" + e.Message);
            }
        }

        public static void Set_Color(string index, bool Write = true)   //颜色标记
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "Color", index, path);
                }
                ini_Color = index;
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_Color", "err:" + e.Message);
            }
        }

        public static void Set_password(string index, bool Write = true)   //密码
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "password", index, path);
                }
                ini_password = index;
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_password", "err:" + e.Message);
            }
        }

        public static void Set_password_bool(string index, bool Write = true)   //密码开启
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "password_bool", index, path);
                }
                ini_password_bool = index;
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_password", "err:" + e.Message);
            }
        }

        public static void Set_ping_run(string index, bool Write = true)   // ping 开启
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "ping_run", index, path);
                }
                ini_ping_run = index;
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_ping_run", "err:" + e.Message);
            }
        }

        public static void Set_ping_color(string index, bool Write = true)   //  ping 颜色标记
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "ping_color", index, path);
                }
                ini_ping_color = index;
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_ping_color", "err:" + e.Message);
            }
        }


        public static void Set_list_run(string index, bool Write = true)   //视图模式是否开启
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "list_run", index, path);
                }
                ini_list_run = index;
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_list_run", "err:" + e.Message);
            }
        }

        public static void Set_list_index(string index, bool Write = true)   //视图序号
        {
            try
            {
                if (Write)
                {
                    WritePrivateProfileString("Config", "list_index", index, path);
                }
                ini_list_index = index;
            }
            catch (DivideByZeroException e)
            {
                Msg.add("Set_list_index", "err:" + e.Message);
            }
        }

        //==============================================================
        //==============================================================

    }
}
