using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AxMSTSCLib;
using MSTSCLib;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Threading;
//using System.ComponentModel;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using System.Windows;

namespace rdp
{

    public partial class Link : Form
    {
        private bool OSVersion_bool = Environment.OSVersion.Version < new Version(5, 9, 9, 9);  //版本
        private AxMsRdpClient6NotSafeForScripting axMsRdp_Client_AA;
        private IMsRdpClientNonScriptable4 imsRdp_Client_AA;
        private AxMsRdpClient7NotSafeForScripting axMsRdp_Client_BB;
        private IMsRdpClientNonScriptable5 imsRdp_Client_BB;
        public string Server_Ip = "";
        public string Server_Port = "";
        public string UserName = "";
        public string Password = "";

        
        //===================================
        //private Rectangle rectangle_1;
        public static Point ini_point = Point.Empty;
        public static Size ini_size = Size.Empty;

        public string shell_id = "";
        // public  static bool bool_1=true;

        public IntPtr form_hWnd;  //当前窗体句柄
        public bool form_rdp_link=false;

        public Link()
        {
            InitializeComponent();
        }



        //public void method_30(Point point_1)
        //{
        //    base.Location = point_1;
        //}

        //public void method_32(Size size_1)
        //{
        //    base.Size = size_1;
        //}

        public void send_shell_id(string id)
        {
            shell_id = id;
        }

        public string get_shell_id()
        {
            return shell_id;
        }

        public void form_Location(Point Location)  //窗体位置
        {
            this.Location = Location;
        }

        public void form_Size(Size size)  //窗体大小
        {
            this.Size = size;
        }


        public Size get_form_size()  //返回大小
        {
            return ini_size;
        }

 
        //最大化: this.WindowState = FormWindowState.Maximized;
        //原始大小: this.WindowState = FormWindowState.Normal;
        //最小化: this.WindowState = FormWindowState.Minimized;

        public static bool list_form_Tile(Rectangle rectangle_2, Link[] gform0_0)
        {
            if (rectangle_2.IsEmpty || gform0_0 == null || gform0_0.Length < 1)
            {
                return false;
            }

            int x_spacing = 0;  //X 间距
            int y_spacing = 0;  //y 间距
            int Width_xx = Config.ini_Width;//   800;  //应用视图的宽
            int Height_xx = Config.ini_Height;//    600;  //应用视图的高
            int max_Width = Screen.AllScreens.Length * rectangle_2.Width; //总宽度
            int Height = rectangle_2.Height;
            bool flag = true;

            int row = Convert.ToInt32(Math.Floor((double)(max_Width / (Width_xx + x_spacing))));// 3;  //列
            int loc = Convert.ToInt32(Math.Floor((double)(Height / (Height_xx + y_spacing))));  //2;  //行
            int zs_bab = row * loc;  //可承载数量
            int num3 = gform0_0.Length - 1;
            for (int i = 0; i <= num3; i++)
            {
                if(i>= zs_bab)
                {
                    flag = false;
                    gform0_0[i].WindowState = FormWindowState.Minimized;  //设置窗口最小化
                    //break;
                    continue;
                }
                int rowxx = i / row;//行号
                //1/3=0,2/3=0,3/3=1;
                int locxx = i % row;//列号
                //每一个应用视图的X ＝ 左边距 ＋ （应用视图的宽 ＋ 应用左右间距）*列号
                //每一个应用视图的Y ＝ 上边距 ＋ （应用视图的高 ＋ 应用上下间距）*行号
                int x = 0 + (Width_xx + x_spacing) * locxx;
                int y = 0 + (Height_xx + y_spacing) * rowxx;

                gform0_0[i].WindowState = FormWindowState.Normal;  //原始大小
                gform0_0[i].form_Location(new Point(x, y));  //位置
                gform0_0[i].form_Size(gform0_0[i].get_form_size());   //大小
            }
            return flag;
        }

        public static void list_form_window(Rectangle rectangle_2, Link[] gform0_0)
        {
            if (rectangle_2.IsEmpty || gform0_0 == null || gform0_0.Length < 1)
            {
                return;
            }
            double num = 0.0;
            double num2 = 0.0;
                int num3 = gform0_0.Length - 1;
                for (int i = 0; i <= num3; i++)
                {
                    num += (double)gform0_0[i].get_form_size().Width;
                    num2 += (double)gform0_0[i].get_form_size().Height;
                    //num += (double)gform0_0[i].Width;
                    //num2 += (double)gform0_0[i].Height;
                }

                //Console.WriteLine("num   " + num);
                //Console.WriteLine("num2   " + num2);
                Size size = new Size((int)Math.Round(num / (double)gform0_0.Length), (int)Math.Round(num2 / (double)gform0_0.Length));
                Size size2 = new Size(ini_point.Y, ini_point.Y);
                if (size2.Width == 0 || size2.Height == 0)
                {
                    size2 = new Size(30, 30);
                }
                int num4 = rectangle_2.Width - size.Width;
                if (num4 < 0)
                {
                    num4 = 0;
                }
                int num5 = rectangle_2.Height - size.Height;
                if (num5 < 0)
                {
                    num5 = 0;
                }

                //Console.WriteLine("num4   " + num4);
                //Console.WriteLine("num5   " + num5);
                Point point = Point.Empty;
                Point point2 = Point.Empty;
                int num6 = gform0_0.Length - 1;
                for (int i = 0; i <= num6; i++)
                {
                    if (!point2.IsEmpty)
                    {
                        Rectangle rectangle = Rectangle.Intersect(new Rectangle(point2.X + rectangle_2.X, point2.Y + rectangle_2.Y, size.Width, size.Height), rectangle_2);
                        if ((double)rectangle.Width < (double)size.Width * 0.666 || (double)rectangle.Height < (double)size.Height * 0.666)
                        {
                            if (point.Y == 0)
                            {
                                point.X += size.Width;
                                if (point.X > num4)
                                {
                                    point = new Point(0, num5 - unchecked(checked((point.X - num4) * size2.Height) / size2.Width));
                                }
                            }
                            else
                            {
                                point.Y -= size.Height;
                                if (point.Y < 0)
                                {
                                    point = new Point(checked(-1 * point.Y * size2.Width) / size2.Height, 0);
                                }
                            }
                            if (point.X > num4 || point.Y < 0)
                            {
                                point = Point.Empty;
                            }
                            point2 = point;
                        }
                    }

                gform0_0[i].form_Location(new Point(point2.X + rectangle_2.X, point2.Y + rectangle_2.Y));  //位置
                    gform0_0[i].form_Size(ini_size);   //大小
                if (gform0_0[i].Visible)
                    {
                        gform0_0[i].Activate();
                    }
                    point2 += size2;
                }
        }
       

        public static Rectangle get_WorkingArea(Rectangle rectangle_0)
        {
            Screen[] allScreens = Screen.AllScreens;
            int num = 0;
            Rectangle result = Rectangle.Empty;
            int num2 = allScreens.Length - 1;
            for (int i = 0; i <= num2; i++)
            {
                Rectangle rectangle = Rectangle.Intersect(allScreens[i].WorkingArea, rectangle_0);
                if (!rectangle.IsEmpty)
                {
                    int num3;
                    try
                    {
                        num3 = rectangle.Width * rectangle.Height;
                    }
                    catch (Exception projectError)
                    {
                        num3 = 0;
                    }
                    if (num < num3)
                    {
                        num = num3;
                        result = allScreens[i].WorkingArea;
                    }
                }
            }
            return result;
        }

        public static Rectangle get_Bounds(Rectangle rectangle_0)
        {
            Screen[] allScreens = Screen.AllScreens;
            int num = 0;
            Rectangle result = Rectangle.Empty;
            int num2 = allScreens.Length - 1;
            for (int i = 0; i <= num2; i++)
            {
                Rectangle rectangle = Rectangle.Intersect(allScreens[i].Bounds, rectangle_0);
                if (!rectangle.IsEmpty)
                {
                    int num3;
                    try
                    {
                        num3 = rectangle.Width * rectangle.Height;
                    }
                    catch (Exception projectError)
                    {
                        num3 = 0;
                    }
                    if (num < num3)
                    {
                        num = num3;
                        result = allScreens[i].Bounds;
                    }
                }
            }
            return result;
        }



        //=======================================================================
        //=======================================================================
        //=======================================================================
        private void Link_FormClosing(object sender, FormClosingEventArgs e)
        {
            host_close();  //断开链接
            int num5 = Config.host_list.Count;
            try
            {
                for (int i = 0; i < num5; i++)
                {
                    if (i >= num5)
                    {
                        break;
                    }
                    try
                    {
                        if (Config.host_list[i].get_shell_id() == shell_id)
                        {
                            Config.host_list.RemoveAt(i); // 删除指定索引位置5的元素
                        }
                    }
                    catch (Exception ex)
                    {
                        Msg.add("link_Closing", "err:" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Msg.add("link_Closing", "err:" + ex.Message);
            }

            try
            {
                if (OSVersion_bool)
                {
                    imsRdp_Client_AA = null;
                    axMsRdp_Client_AA.Disconnect();
                }
                else
                {
                    imsRdp_Client_BB = null;
                    axMsRdp_Client_BB.Disconnect();
                }
                this.LinkLabel1.Dispose();
                this.Timer1.Dispose();
            }
            catch (Exception ex)
            {
                Msg.add("link_Closing", "err:" + ex.Message);
            }
            axMsRdp_Client_AA = null;
            axMsRdp_Client_BB = null;
            base.Controls.Clear();
            this.LinkLabel1 = null;
            this.Timer1 = null;
        }

       

        //===============保存截图
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;                             //最左坐标
            public int Top;                             //最上坐标
            public int Right;                           //最右坐标
            public int Bottom;                        //最下坐标
        }

        private void Save_jpg()  //保存截图
        {
            IntPtr awin = GetForegroundWindow();    //获取当前窗口句柄
            RECT rect = new RECT();
            GetWindowRect(awin, ref rect);
            int width = rect.Right - rect.Left - 20;                        //窗口的宽度  //最上坐标
            int height = rect.Bottom - rect.Top - 41;                   //窗口的高度   //最上坐标
            int x = rect.Left + 10;        //最右坐标
            int y = rect.Top + 30;         //最下坐标

            //创建图象，保存将来截取的图象
            Bitmap image = new Bitmap(width, height);   //Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height
            Graphics imgGraphics = Graphics.FromImage(image);

            //设置截屏区域
            imgGraphics.CopyFromScreen(x, y, 0, 0, new Size(width, height));
            //保存
            //SaveImage(image);
            if (shell_id != "")
            {
                string fileName = string.Format("data\\{0}.jpg", shell_id);  // "id.jpg";
                image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }



      

        private void Save_jpg_run()
        {
            while (true)
            {
                try
                {
                    Task task_B = Task.Run(task_YS_B);  //  //延时60秒
                    task_B.Wait();
                    //Console.WriteLine(shell_id + "=form_rdp_link========   " + form_rdp_link);
                    if (form_rdp_link == false)
                    {
                        continue;
                    }

                    if (form_hWnd == IntPtr.Zero)
                    {
                        form_hWnd = FindWindow(null, this.Text);    //标题查找句柄
                    }

                    Invoke(new Action(() =>
                    {
                    IntPtr awin = GetForegroundWindow();    //获取当前窗口句柄
                    if(form_hWnd== awin)
                    {
                        Save_jpg();  //保存截图
                    }
                    }));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Save_jpg_run  err  " + e.Message);
                }
            }


        }
        public static async Task task_YS_B()
        {
            await Task.Delay(30000);
        }

        //=================保存截图
        private void Link_Load(object sender, EventArgs e)
        {
            Link_new(); //初始化链接
        }
        private void Link_new()  //初始化链接
        {
            //===========
            try
            {
                if (Config.ini_list_run == "1")
                {
                    Thread td_ping = new Thread(new ThreadStart(Save_jpg_run));
                    td_ping.IsBackground = true;
                    td_ping.Start();  //开启
                }
            }
            catch (Exception projectError)
            {
            }
            //===========
            //=================================
            try
            {
                
                if (OSVersion_bool)
                {
                    axMsRdp_Client_AA = new AxMsRdpClient6NotSafeForScripting();
                    this.Controls.Add(axMsRdp_Client_AA);
                    imsRdp_Client_AA = (IMsRdpClientNonScriptable4)axMsRdp_Client_AA.GetOcx();
                    ((System.ComponentModel.ISupportInitialize)(axMsRdp_Client_AA)).BeginInit();
                }
                else
                {
                    axMsRdp_Client_BB = new AxMsRdpClient7NotSafeForScripting();
                    this.Controls.Add(axMsRdp_Client_BB);
                    imsRdp_Client_BB = (IMsRdpClientNonScriptable5)axMsRdp_Client_BB.GetOcx();
                    ((System.ComponentModel.ISupportInitialize)(axMsRdp_Client_BB)).BeginInit();
               
                }
            }
            catch (Exception ex)
            {
                Msg.add("link_Load", "远程桌面连接对象初始化失败！");
                MessageBox.Show("远程桌面连接对象初始化失败！\r\n\r\n" + ex.Message);
            }
            if (OSVersion_bool)
            {
                axMsRdp_Client_AA.TabStop = false;
                axMsRdp_Client_AA.SendToBack();
                axMsRdp_Client_AA.Dock = DockStyle.Fill;
                axMsRdp_Client_AA.ConnectingText = "正在建立远程桌面连接...";
                axMsRdp_Client_AA.DisconnectedText = "远程桌面连接已断开";
                axMsRdp_Client_AA.AdvancedSettings.allowBackgroundInput = 1;
                axMsRdp_Client_AA.AdvancedSettings.Compress = 1;
                axMsRdp_Client_AA.AdvancedSettings2.RedirectPorts = false;
                axMsRdp_Client_AA.AdvancedSettings2.RedirectPrinters = false;
                axMsRdp_Client_AA.AdvancedSettings2.RedirectSmartCards = false;
                axMsRdp_Client_AA.AdvancedSettings5.AuthenticationLevel = 0u;
                axMsRdp_Client_AA.FullScreen = false;
                axMsRdp_Client_AA.SecuredSettings2.KeyboardHookMode = 0;
                axMsRdp_Client_AA.OnConnected += AxMsRdp_Client_OnConnected;   //连接
                axMsRdp_Client_AA.OnDisconnected += AxMsRdp_Client_OnDisconnected;  //断开连接时
                ((System.ComponentModel.ISupportInitialize)(axMsRdp_Client_AA)).EndInit();
            }
            else
            {
                axMsRdp_Client_BB.TabStop = false;
                axMsRdp_Client_BB.SendToBack();
                axMsRdp_Client_BB.Dock = DockStyle.Fill;
                axMsRdp_Client_BB.ConnectingText = "正在建立远程桌面连接...";
                axMsRdp_Client_BB.DisconnectedText = "远程桌面连接已断开";
                axMsRdp_Client_BB.AdvancedSettings.allowBackgroundInput = 1;
                axMsRdp_Client_BB.AdvancedSettings.Compress = 1;
                axMsRdp_Client_BB.AdvancedSettings2.RedirectPorts = false;
                axMsRdp_Client_BB.AdvancedSettings2.RedirectPrinters = false;
                axMsRdp_Client_BB.AdvancedSettings2.RedirectSmartCards = false;
                axMsRdp_Client_BB.AdvancedSettings5.AuthenticationLevel = 0u;
                axMsRdp_Client_BB.FullScreen = false;
                axMsRdp_Client_BB.SecuredSettings2.KeyboardHookMode = 0;
                axMsRdp_Client_BB.OnConnected += AxMsRdp_Client_OnConnected;   //连接
                axMsRdp_Client_BB.OnDisconnected += AxMsRdp_Client_OnDisconnected;  //断开连接时
                axMsRdp_Client_BB.Enabled = true;
                ((System.ComponentModel.ISupportInitialize)(axMsRdp_Client_BB)).EndInit();


                //this.rdp.OnConnecting += new System.EventHandler(this.rdp_OnConnecting);  //关于连接
                //this.rdp.OnConnected += new System.EventHandler(this.rdp_OnConnected);  //连接的
                //this.rdp.OnLoginComplete += new System.EventHandler(this.rdp_OnLoginComplete);  //登录完成后
                //this.rdp.OnDisconnected += new AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler(this.rdp_OnDisconnected);  //断开连接时
                //this.rdp.OnLeaveFullScreenMode += new System.EventHandler(this.rdp_OnLeaveFullScreenMode);  //离开全屏模式
                //this.rdp.OnFatalError += new AxMSTSCLib.IMsTscAxEvents_OnFatalErrorEventHandler(this.rdp_OnFatalError);   //论致命错误
                //this.rdp.OnWarning += new AxMSTSCLib.IMsTscAxEvents_OnWarningEventHandler(this.rdp_OnWarning);    //警告
                //this.rdp.OnRemoteDesktopSizeChange += new AxMSTSCLib.IMsTscAxEvents_OnRemoteDesktopSizeChangeEventHandler(this.rdp_OnRemoteDesktopSizeChange);  //在远程桌面上更改大小
                //this.rdp.OnReceivedTSPublicKey += new AxMSTSCLib.IMsTscAxEvents_OnReceivedTSPublicKeyEventHandler(this.rdp_OnReceivedTSPublicKey);   //关于接收到的TS公钥
                //this.rdp.OnLogonError += new AxMSTSCLib.IMsTscAxEvents_OnLogonErrorEventHandler(this.rdp_OnLogonError);   //登录错误
                //this.rdp.OnServiceMessageReceived += new AxMSTSCLib.IMsTscAxEvents_OnServiceMessageReceivedEventHandler(this.rdp_OnServiceMessageReceived);   //在收到服务信息时
                //this.rdp.OnNetworkStatusChanged += new AxMSTSCLib.IMsTscAxEvents_OnNetworkStatusChangedEventHandler(this.rdp_OnNetworkStatusChanged);   //关于网络状态的更改
                //this.rdp.OnAutoReconnected += new System.EventHandler(this.rdp_OnAutoReconnected);   //关于自动重新连接

            }
            //===============================
            base.ShowInTaskbar = true;
            //bool_1 = true;
            CreateAxMsRdpClient();/// 创建远程桌面连接



        }

        //private void axMsRdpc_OnConnecting(object sender, EventArgs e)  // 远程桌面-连接  远程桌面组件axMsRdpc
        //{
        //    var _axMsRdp = sender as AxMsRdpClient7NotSafeForScripting;
        //    _axMsRdp.ConnectingText = _axMsRdp.GetStatusText(Convert.ToUInt32(_axMsRdp.Connected));
        //    _axMsRdp.FindForm().WindowState = FormWindowState.Normal;
        //}

        //private void axMsRdpc_OnDisconnected(object sender, IMsTscAxEvents_OnDisconnectedEvent e)  // 远程桌面-连接断开
        //{
        //    var _axMsRdp = sender as AxMsRdpClient7NotSafeForScripting;
        //    string disconnectedText = string.Format("{0} {1} {2}", LangResx.Common.link_desktop, _axMsRdp.Server, LangResx.Common.link_break);
        //    _axMsRdp.DisconnectedText = disconnectedText;
        //    _axMsRdp.FindForm().Close();
        //    CommonSettings.WinMessage(disconnectedText, LangResx.Common.link);
        //}

        private void AxMsRdp_Client_OnConnected(object sender, EventArgs e)
        {
            form_rdp_link = true;
        }

        private void host_close()  //断开链接
        {
            try
            {
                if (OSVersion_bool)
                {
                    if (axMsRdp_Client_AA != null)
                    {
                        axMsRdp_Client_AA.Disconnect();
                    }
                }else{
                    if (axMsRdp_Client_BB != null)
                    {
                        axMsRdp_Client_BB.Disconnect();
                    }
                }
            }
            catch (Exception projectError)
            {
            }
        }
        private void AxMsRdp_Client_OnDisconnected(object object_1, IMsTscAxEvents_OnDisconnectedEvent imsTscAxEvents_OnDisconnectedEvent_0)
        {
            //if (bool_1)
            //{
            //    if (gstruct6_0.bool_4)
            //    {
            //          this.timer1.Enabled = true;  //隐藏
            //        return;
            //    }
            form_rdp_link = false;
            host_close();  //断开链接
            if (this.LinkLabel1 != null)
            {
                this.LinkLabel1.Visible = true;
                this.LinkLabel1.Text = "远程桌面连接已断开，重新连接";
                this.LinkLabel1.LinkArea = new LinkArea(10, 4);
            }
            
            //}
        }

        public void Server_Ini(string[] args)  //初始化
        {
            //Console.WriteLine("=========   " + this.server_ip);
            //Console.WriteLine("=========   " + args[1]);
            //Console.WriteLine("=========   " + args[2]);
            //Console.WriteLine("=========   " + args[3]);
            //Console.WriteLine("=========   " + osversion_bool);
            //==============
            int Width = Config.ini_Width;
            int Height = Config.ini_Height;
            if (Width >= 640 && Width <= 3840 && Height >= 480 && Height <= 2160)
            {
                ini_size = new Size(Width, Height);
            }
            else
            {
                ini_size = new Size(Config.ini_Width, Config.ini_Height);
            }
            //==============
            //=======================================
            if (args[0] != null && Regex.IsMatch(args[0], "\\A[A-Za-z0-9\\.\\-]+(?:\\:\\d{1,5})?\\z"))
            {
                this.Server_Ip = Regex.Match(args[0], "\\A[^\\:]+").Value;
                this.Server_Port = Regex.Match(args[0], "(?<=\\:)\\d{1,5}\\z").Value;
                if (string.IsNullOrEmpty(Server_Port))
                {
                    this.Server_Port = "3389";
                }
                if (int.Parse(Server_Port) > 65535)
                {
                    this.Server_Ip = null;
                    this.Server_Port = null;
                }
            }
            Rectangle rectangle = base.Bounds;
            if (rectangle.IsEmpty)
            {
                rectangle = Screen.PrimaryScreen.Bounds;
            }
            this.UserName = args[1];    // 远程登录账号
            this.Password = args[2];   // 远程登录密码
            this.Text= args[3] + "("   + this.Server_Ip + ")";  //设置标题
            //base.FormBorderStyle = FormBorderStyle.None;
            base.Location = rectangle.Location;
            this.Visible = false;
            if (Config.ini_Width < 600)
            {
                this.Width = 800;
                this.Height = 600;
            }else{
                this.Width = Config.ini_Width;
                this.Height = Config.ini_Height;
            }
            
        }

        //=========================================
        /// </summary>
        /// <param name="args">参数数组 new string[] { ServerIp, UserName, Password }</param>
        public void CreateAxMsRdpClient()/// 创建远程桌面连接
        {
            if (OSVersion_bool)
            {
                //=======================================
                try
                {
                    //设置声音 
                    axMsRdp_Client_AA.AdvancedSettings6.AudioRedirectionMode = (uint)Config.ini_AudioRedirectionMode;
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_true   AudioRedirectionMode", "err:" + projectError.Message);
                }
                //============
                try
                {
                    //缓存
                    if (Config.ini_BitmapPersistence == 1)
                    {  //启用缓存
                        axMsRdp_Client_AA.AdvancedSettings2.BitmapPersistence = 1;  //将此参数设置为0可禁用缓存，或设置为非零值以启用缓存。
                        axMsRdp_Client_AA.AdvancedSettings2.CachePersistenceActive = 1;  //指定是否应使用永久性位图缓存。 永久性缓存可以提高性能，但需要额外的磁盘空间。将此参数设置为0可禁用该功能
                    }else{  //不启用缓存
                        axMsRdp_Client_AA.AdvancedSettings2.BitmapPersistence = 0;
                        axMsRdp_Client_AA.AdvancedSettings2.CachePersistenceActive = 0;
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_true   BitmapPersistence", "err:" + projectError.Message);
                }
                //============
                try
                {
                    // 颜色位数
                    int ColorDepth = Config.ini_ColorDepth;
                    if (ColorDepth != 8 && ColorDepth != 15 && ColorDepth != 16 && ColorDepth != 24 && ColorDepth != 32 && ColorDepth != 256)
                    {// 颜色位数
                        axMsRdp_Client_AA.ColorDepth = 32;
                    }else{// 颜色位数
                        axMsRdp_Client_AA.ColorDepth = ColorDepth;
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_true   ColorDepth", "err:" + projectError.Message);
                }
                //============
                try
                {
                    //账户密码
                    if (!string.IsNullOrEmpty(this.Server_Ip) && !string.IsNullOrEmpty(this.Server_Port))
                    {
                        axMsRdp_Client_AA.Server = this.Server_Ip;   // 服务器地址
                        //axMsRdp_Client_AA.AdvancedSettings2.RDPPort = int.Parse(this.Server_Port);  // 远程端口号
                        axMsRdp_Client_AA.AdvancedSettings2.RDPPort = Convert.ToInt32(this.Server_Port);
                    }
                    axMsRdp_Client_AA.UserName = this.UserName;    // 远程登录账号
                    if (!string.IsNullOrEmpty(this.Password))
                    {
                        axMsRdp_Client_AA.AdvancedSettings2.ClearTextPassword = this.Password;   // 远程登录密码
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_true   Server_Ip", "err:" + projectError.Message);
                }
                //============
                try
                {
                    //身份验证
                    if (Config.ini_EnableCredSspSupport == 1)
                    {
                        imsRdp_Client_AA.EnableCredSspSupport = true;  // 启用CredSSP身份验证（有些服务器连接没有反应，需要开启这个）
                    }else{
                        imsRdp_Client_AA.EnableCredSspSupport = false;  // 启用CredSSP身份验证（有些服务器连接没有反应，需要开启这个）
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_true   EnableCredSspSupport", "err:" + projectError.Message);
                }
                //============
                try
                {
                    //设置或检索剪贴板
                    if (Config.ini_RedirectClipboard == 1)
                    {
                        axMsRdp_Client_AA.AdvancedSettings6.RedirectClipboard = true;
                    }else{
                        axMsRdp_Client_AA.AdvancedSettings6.RedirectClipboard = false;
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_true   RedirectClipboard", "err:" + projectError.Message);
                }
                //============
                try
                {
                    //磁盘映射
                    string dir = Config.ini_Drive; //"|C:\\|D:\\|"
                    dir = ((!string.IsNullOrEmpty(dir)) ? ("\r\n" + dir + "\r\n") : "");
                    if (string.IsNullOrEmpty(dir))
                    {
                        axMsRdp_Client_AA.AdvancedSettings2.RedirectDrives = false;  //允许共享磁盘
                    }
                    checked
                    {
                        string[] Drive_array = dir.Split(new char[] { '|' });  //
                        int num2 = (int)(unchecked((long)imsRdp_Client_BB.DriveCollection.DriveCount) - 1L);   //检索集合中的对象的计数。对象计数。
                        for (int i = 0; i <= num2; i++)
                        {
                            string disc = imsRdp_Client_BB.DriveCollection.get_DriveByIndex((uint)i).Name.Trim(default(char));
                            if (new List<string>(Drive_array).Contains(disc))
                            {
                                imsRdp_Client_BB.DriveCollection.get_DriveByIndex((uint)i).RedirectionState = true;  //共享磁盘
                            }
                        }

                        axMsRdp_Client_AA.AdvancedSettings2.SmartSizing = true;  //自动调整大小
                        if (!string.IsNullOrEmpty(this.UserName))
                        {
                            axMsRdp_Client_BB.UserName = this.UserName;   //指定用户名登录凭据。
                        }
                        //指定键盘重定向设置，该设置指定如何以及何时应用 Windows 键盘快捷方式 (例如，ALT + TAB) 。   
                        //0 仅在客户端计算机上以本地方式应用密钥组合。   1 在远程服务器上应用键组合。   2 仅当客户端在全屏模式下运行时，才将密钥组合应用到远程服务器。 这是默认值。
                        axMsRdp_Client_AA.SecuredSettings2.KeyboardHookMode = 1;
                        axMsRdp_Client_AA.AdvancedSettings3.PerformanceFlags = 400;   //启用桌面组合。//指定可在服务器上设置以提高性能的一组功能。
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_true   Drive", "err:" + projectError.Message);
                }
                //============
                //=======================================
            }else{  //xxxxxxxxxxxxxxxxxxxxxxxxxxxxx=======================xxxxxxxxxxxxxxxxx
                //=======================================
                try
                {
                    //指定或检索一个布尔值，该值指示是否将默认音频输入设备从客户端重定向到远程会话。 
                    if (Config.ini_AudioRedirectionMode == 1)
                    {
                        axMsRdp_Client_BB.AdvancedSettings8.AudioCaptureRedirectionMode = true;
                    }else{
                        axMsRdp_Client_BB.AdvancedSettings8.AudioCaptureRedirectionMode = false;
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_false   AudioRedirectionMode", "err:" + projectError.Message);
                }
                //============
                try
                {
                    //设置声音 
                    axMsRdp_Client_BB.AdvancedSettings6.AudioRedirectionMode = (uint)Config.ini_AudioRedirectionMode;
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_false   AudioRedirectionMode", "err:" + projectError.Message);
                }
                //============
                try
                {
                    //缓存
                    if (Config.ini_BitmapPersistence == 1)
                    {  //启用缓存
                        axMsRdp_Client_BB.AdvancedSettings2.BitmapPersistence = 1;  //将此参数设置为0可禁用缓存，或设置为非零值以启用缓存。
                        axMsRdp_Client_BB.AdvancedSettings2.CachePersistenceActive = 1;  //指定是否应使用永久性位图缓存。 永久性缓存可以提高性能，但需要额外的磁盘空间。将此参数设置为0可禁用该功能
                    }else{  //不启用缓存
                        axMsRdp_Client_BB.AdvancedSettings2.BitmapPersistence = 0;
                        axMsRdp_Client_BB.AdvancedSettings2.CachePersistenceActive = 0;
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_false   BitmapPersistence", "err:" + projectError.Message);
                }
                //============
                try
                {
                    // 颜色位数
                    int ColorDepth = Config.ini_ColorDepth;
                    if (ColorDepth != 8 && ColorDepth != 15 && ColorDepth != 16 && ColorDepth != 24 && ColorDepth != 32 && ColorDepth != 256)
                    {// 颜色位数
                        axMsRdp_Client_BB.ColorDepth = 32;
                    }else{// 颜色位数
                        axMsRdp_Client_BB.ColorDepth = ColorDepth;
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_false   ColorDepth", "err:" + projectError.Message);
                }
                //============
                try
                {
                    //账户密码
                    if (!string.IsNullOrEmpty(this.Server_Ip) && !string.IsNullOrEmpty(this.Server_Port))
                    {
                        axMsRdp_Client_BB.Server = this.Server_Ip;   // 服务器地址
                        //axMsRdp_Client_BB.AdvancedSettings2.RDPPort = int.Parse(this.Server_Port);  // 远程端口号
                        axMsRdp_Client_BB.AdvancedSettings2.RDPPort = Convert.ToInt32(this.Server_Port);
                    }
                    axMsRdp_Client_BB.UserName = this.UserName;    // 远程登录账号
                    if (!string.IsNullOrEmpty(this.Password))
                    {
                        axMsRdp_Client_BB.AdvancedSettings2.ClearTextPassword = this.Password;   // 远程登录密码
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_false   Server_Ip", "err:" + projectError.Message);
                }
                //============
                try
                {
                    //身份验证
                    if (Config.ini_EnableCredSspSupport == 1)
                    {
                        imsRdp_Client_BB.EnableCredSspSupport = true;  // 启用CredSSP身份验证（有些服务器连接没有反应，需要开启这个）
                    }else{
                        imsRdp_Client_BB.EnableCredSspSupport = false;  // 启用CredSSP身份验证（有些服务器连接没有反应，需要开启这个）
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_false   EnableCredSspSupport", "err:" + projectError.Message);
                }
                //============
                try
                {
                    //设置或检索剪贴板
                    if (Config.ini_RedirectClipboard == 1)
                    {
                        axMsRdp_Client_BB.AdvancedSettings6.RedirectClipboard = true;
                    }else{
                        axMsRdp_Client_BB.AdvancedSettings6.RedirectClipboard = false;
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_false   RedirectClipboard", "err:" + projectError.Message);
                }
                //============
                try
                {
                    //磁盘映射
                    string dir = Config.ini_Drive; //"|C:\\|D:\\|"
                    dir = ((!string.IsNullOrEmpty(dir)) ? ("\r\n" + dir + "\r\n") : "");
                    if (string.IsNullOrEmpty(dir))
                    {
                        axMsRdp_Client_BB.AdvancedSettings2.RedirectDrives = false;  //允许共享磁盘
                    }
                    checked
                    {
                        string[] Drive_array = dir.Split(new char[] { '|' });  //
                        int num2 = (int)(unchecked((long)imsRdp_Client_BB.DriveCollection.DriveCount) - 1L);   //检索集合中的对象的计数。对象计数。
                        for (int i = 0; i <= num2; i++)
                        {     
                            string disc =imsRdp_Client_BB.DriveCollection.get_DriveByIndex((uint)i).Name.Trim(default(char));
                            if (new List<string>(Drive_array).Contains(disc))
                            {
                                imsRdp_Client_BB.DriveCollection.get_DriveByIndex((uint)i).RedirectionState = true;  //共享磁盘
                            }
                        }

                        axMsRdp_Client_BB.AdvancedSettings2.SmartSizing = true;  //自动调整大小
                        if (!string.IsNullOrEmpty(this.UserName))
                        {
                            axMsRdp_Client_BB.UserName = this.UserName;   //指定用户名登录凭据。
                        }
                        //指定键盘重定向设置，该设置指定如何以及何时应用 Windows 键盘快捷方式 (例如，ALT + TAB) 。   
                        //0 仅在客户端计算机上以本地方式应用密钥组合。   1 在远程服务器上应用键组合。   2 仅当客户端在全屏模式下运行时，才将密钥组合应用到远程服务器。 这是默认值。
                        axMsRdp_Client_BB.SecuredSettings2.KeyboardHookMode = 1;
                        axMsRdp_Client_BB.AdvancedSettings3.PerformanceFlags = 400;   //启用桌面组合。//指定可在服务器上设置以提高性能的一组功能。
                    }
                }
                catch (Exception projectError)
                {
                    Msg.add("OSVersion_false   Drive", "err:" + projectError.Message);
                }
                //============
                //=======================================
            }
            //=======================================
            this.Open_link();
        }

        private void Open_link()
        {
            this.Timer1.Enabled = false; //暂停
            this.LinkLabel1.Visible = false;  //隐藏
            if (OSVersion_bool)
            {
                try
                {
                    axMsRdp_Client_AA.Connect();
                    
                }
                catch (Exception e)
                {
                    Msg.add("open_link", "err:" + e.Message);
                }
            }
            else
            {
                try
                {
                    axMsRdp_Client_BB.Connect();
                }
                catch (Exception e)
                {
                    Msg.add("open_link", "err:" + e.Message);
                }
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (OSVersion_bool)
            {
                axMsRdp_Client_AA.ConnectingText = "远程桌面连接已断开";
                axMsRdp_Client_AA.DisconnectedText = "正在建立远程桌面连接...";
            }
            else
            {
                axMsRdp_Client_BB.ConnectingText = "远程桌面连接已断开";
                axMsRdp_Client_BB.DisconnectedText = "正在建立远程桌面连接...";
            }
            //Link_new(); //初始化链接
            //CreateAxMsRdpClient();/// 创建远程桌面连接
            this.Open_link();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Open_link();
        }

       








        //=========================================
        //=========================================
        //=========================================




    }
}
