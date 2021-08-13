using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;


namespace rdp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //=============
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");//创建新路径
            }
            //=============
            LangUtil.ApplyDefaultLang();  // 初始化区域信息（即配置语言）
            //Application.Run(new Form1());

            ini_Load();  //初始化状态
            Config.Open_ini();  //加载INI 配置
            SqlLiteHelper.Info();  //数据库链接
            

            if (Config.ini_password_bool=="1")   //login
            {
                if (Config.ini_password=="")
                {
                    Application.Run(new Form1());
                }
                else
                {
                    Application.Run(new login());
                }
            }
            else
            {
                Application.Run(new Form1());
            }
        }

        static void ini_Load()  //初始化状态
        {
            //=========解压后运行
            if (Application.StartupPath.StartsWith(Path.GetTempPath(), StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(LangResx.Common.run_rar);
                Environment.Exit(1);
            }

            //程序互斥 防止重复运行
            int num2 = 0;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            Process[] processesByName = Process.GetProcessesByName(fileNameWithoutExtension);
            foreach (Process process in processesByName)
            {
                if (process.MainModule.FileName == Application.ExecutablePath)
                {
                    num2++;
                }
                //Console.WriteLine("xxxxxxxxx" + process.MainModule.FileName);
            }
            if (num2 > 1)
            {
                MessageBox.Show(LangResx.Common.run_exe);
                System.Environment.Exit(1);
            }


            //=========文件检测
            //https://www.cnblogs.com/stulzq/p/6090183.html    MD5文件校验
            string file_name = "AxInterop.MSTSCLib.dll";
            if (!File.Exists(file_name))
            {
                MessageBox.Show(LangResx.Common.run_AxInterop);
                System.Environment.Exit(1);
            }
            file_name = "AxInterop.MSTSCLib.dll";
            if (!File.Exists(file_name))
            {
                MessageBox.Show(LangResx.Common.run_Interop);
                System.Environment.Exit(1);
            }
            //=========
        }
    }
}
