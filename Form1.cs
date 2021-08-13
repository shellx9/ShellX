using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxMSTSCLib;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections;
using System.Runtime.InteropServices;



using System.ComponentModel;
using System.Linq;
using System.Text;
using MSTSCLib;
//using ComponentOwl.BetterListView;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Resources;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
//using ComponentOwl.BetterListView;
//using Microsoft.VisualBasic.CompilerServices;
//using AxMSTSCLib;
//using MSTSCLib;
using System.Text.RegularExpressions;
//using Microsoft.Win32;
//using RemoteDesktopManager.My;
//using RemoteDesktopManager.My.Resources;

//using System.Diagnostics;
//using System.Net.NetworkInformation;



//微软API说明地址
//https://docs.microsoft.com/zh-cn/windows/win32/termserv/terminal-services-configuration-classes
//好的ICO  下载
//https://www.iconfont.cn/



namespace rdp
{

    public partial class Form1 : Form
    {
        private List<string> axMsRdpcArray = null;  //链接列表
        private Thread td_ping = null;  //ping线程


        //缩率图
        private static int img_Width= 120;   
        private static int img_Height= 88;
        //是行距  是列距  间距
        private static int img_row = 130;   //行间距
        private static int img_loc = 138;   //列间距

        //传统的 4:3 （1.33:1）
        //小   93  67       103   110
        //中   120  88       130   138    1.363
        //大   211  155      191   230
        //===============================
        private int LVM_SETICONSPACING = 0x1035;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        //===============================
        public Form1()
        {
            InitializeComponent();
            axMsRdpcArray = new List<string>();
        }

        private void Form1_Load(object sender, EventArgs e)  // 主窗体-窗体加载
        {
            //=============
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");//创建新路径
            }
            //=============
            //this.ShowInTaskbar = true;  //
            listView1_ini();  //shell列表初始化
            BindsListViewDataSource();   // 主机绑定初始化
            Bontext_fzDataSource();   //分组初始化
            Bontext_ColorDataSource();   //标记初始化
            ping_run();  //运行
        }

        //=========================================
        //=============线程ping
        public void ping_run()
        {
            try
            {
                if (td_ping != null)
                {
                    td_ping.Abort();//调用Thread.Abort方法试图强制终止thread线程
                }
            }
            catch (Exception e)
            {
                Msg.add("ping_run", "Abort err:" + e.Message);
            }
            if (Config.ini_ping_run == "1")
            {
                try
                {
                    if (Config.ini_list_run == "0")
                    {
                        td_ping = new Thread(new ThreadStart(receive));
                        td_ping.IsBackground = true;
                        td_ping.Start();  //开启
                    }
                }
                catch (Exception e)
                {
                    Msg.add("ping_run", "Start err:" + e.Message);
                }
            }
        }

        public void ping_set(string id,bool color_bool, string Time_to, Color Colorxxx,string fz)  //设置ping
        {
            try
            {
                this.listView1.BeginUpdate();
                Invoke(new Action(() =>
                {
                    foreach (ListViewItem item in this.listView1.Items)
                    {
                        string idxx = item.SubItems[5].Text;
                        if (idxx == id)
                        {
                            item.SubItems[7].Text = Time_to;
                            if (color_bool == true)
                            {
                            
                                //if (fz == "0")
                                //{
                                item.UseItemStyleForSubItems = false;
                                //}
                                item.SubItems[7].BackColor = Colorxxx;   //Color Color_xx
                            
                            }
                        }
                    }
                }));
                this.listView1.EndUpdate();
            }
            catch (Exception e)
            {
                Msg.add("ping_set", "err:" + e.Message);
            }
        }
        private void receive()
        {
            while (true)
            {
                try
                {
                    //==============
                    string sErrorxx = ""; // string.Empty;
                string sSql = "select * from shell order by top asc";   //数据
                DataTable dtxx = SqlLiteHelper.GetDataTable(out sErrorxx, sSql);   //数据
                if (sErrorxx == "")
                {
                    if (dtxx.Rows.Count == 0)
                    {
                        Task task_B = Task.Run(task_YS_B);  //  //延时60秒
                        task_B.Wait(); 
                    }
                    string ping_color = Config.ini_ping_color;
                        string fz = Config.ini_fz;
                    for (int x = 0; x < dtxx.Rows.Count; x++)
                    {
                        try
                        {
                            string id = dtxx.Rows[x][0].ToString();   //id
                            string server = dtxx.Rows[x][1].ToString();   //IP  服务器
                        
                            string Server_Ip = Regex.Match(server, "\\A[^\\:]+").Value;
                            string Time_to = PingHelp.PingHost(Server_Ip);
                            //Console.WriteLine("xxxxxxxxxServer_Ip  " + Server_Ip);//输出语句，自动换行
                            //Console.WriteLine("xxxxxxxxxTime_to  " + Time_to);//输出语句，自动换行
                            bool color_bool = false;
                            Color Colorxx = Color.FromArgb(255, 0, 0);
                                //https://www.sojson.com/rgb.html
                                //<= 50ms 0 205 102
                                //50~100ms 0 238 118
                                //100~150ms 84 255 159
                                //150~200ms 255 246 143
                                //> 200ms 244 164 96
                                //超时     255 0 0
                                if (ping_color == "1")
                            {
                                color_bool = true;
                            }
                            //是否色彩标记
                            if (Time_to.Contains("超时")|| Time_to.Contains("失败") || Time_to.Contains("over time") || Time_to.Contains("err"))
                            {
                                color_bool = true;
                                //color_bool = false;
                            }else{
                                int int_Time_to = 0;
                                try { int_Time_to = Convert.ToInt32(Time_to); } catch (Exception e) { Msg.add("receive", " ToInt32 err:" + e.Message); }
                                    //=============
                                if (int_Time_to <= 50) { Colorxx = Color.FromArgb(0, 205, 102); } 
                                if (int_Time_to >= 50 && int_Time_to <= 100){Colorxx = Color.FromArgb(0, 238, 118); }
                                if (int_Time_to >= 100 && int_Time_to <= 150) { Colorxx = Color.FromArgb(84, 255, 159); }
                                if (int_Time_to >= 150 && int_Time_to <= 200) { Colorxx = Color.FromArgb(255, 246, 143); }
                                if (int_Time_to >= 200) { Colorxx = Color.FromArgb(244, 164, 96); }
                                    //=============
                                    Time_to = string.Format("{0} ms", Time_to);
                            }
                        
                            this.BeginInvoke(new EventHandler(delegate {
                                ping_set(id, color_bool, Time_to, Colorxx, fz);
                            }));

                            Task task_A = Task.Run(task_YS_A);  //延时3秒
                            task_A.Wait();
                        }
                        catch (Exception e)
                        {
                            Msg.add("receive", "err:" + e.Message);
                            Task task_xx = Task.Run(task_YS_C);  //延时10秒
                            task_xx.Wait();
                        }
                    }
                    Task task_C = Task.Run(task_YS_C);  //延时10秒
                    task_C.Wait();
                    
                }

                    //==============
                    //Task task_2 = Task.Run(task_YS_A);
                    //task_2.Wait(); //注释打开则等待task_2延时，注释掉则不等待
                    //string ss = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                    //this.BeginInvoke(new EventHandler(delegate {
                    //    ping_set(ss, ss);
                    //}));
                    //this.Invoke(new EventHandler(delegate {
                    //    this.textBox1.Text += "2";
                    //}));

                    //Console.WriteLine("xxxxxxxxx" + ss);//输出语句，自动换行
                }
                catch (Exception e)
                {
                    Msg.add("receive", "err:" + e.Message);
                    Task task_AA = Task.Run(task_YS_B);  //延时10秒
                    task_AA.Wait();
                }
            }
        }
        public static async Task task_YS_A()
        {
            await Task.Delay(1000);
            //Console.WriteLine("3秒后执行，方式二 输出语句...");
        }
        public static async Task task_YS_B()
        {
            await Task.Delay(60000);
        }
        public static async Task task_YS_C()
        {
            await Task.Delay(10000);
        }
        //=============


        enum OperType { Add, Edit }

        public void listView1_ini()  //shell列表初始化
        {
            //=========
            //list_1.Text 小图标
            //list_2.Text 中图标
            //list_3.Text 大图标
            //list_close.Text 显示视图
            //list_display.Text 关闭视图

            if (Config.ini_list_run == "0")
            {
                list_display.BackColor = Color.FromArgb(176, 226, 255);  //关闭视图

                list_close.BackColor = Color.FromArgb(240,240,240);  //显示视图
                list_1.BackColor = Color.FromArgb(240, 240, 240);
                list_2.BackColor = Color.FromArgb(240, 240, 240);
                list_3.BackColor = Color.FromArgb(240, 240, 240);
            }
            else
            {
                list_close.BackColor = Color.FromArgb(176, 226, 255);  //显示视图

                list_display.BackColor = Color.FromArgb(240, 240, 240);  //关闭视图
                list_1.BackColor = Color.FromArgb(240, 240, 240);
                list_2.BackColor = Color.FromArgb(240, 240, 240);
                list_3.BackColor = Color.FromArgb(240, 240, 240);
                if (Config.ini_list_index == "1") { list_1.BackColor = Color.FromArgb(176, 226, 255); }
                if (Config.ini_list_index == "2") { list_2.BackColor = Color.FromArgb(176, 226, 255); }
                if (Config.ini_list_index == "3") { list_3.BackColor = Color.FromArgb(176, 226, 255); }
            }
            //=========
            this.listView1.Clear();
            this.listView1.Columns.Add(LangResx.Common.list_name, int.Parse(find_list_data("1")), HorizontalAlignment.Left);
            this.listView1.Columns.Add(LangResx.Common.list_server, int.Parse(find_list_data("2")), HorizontalAlignment.Left);
            this.listView1.Columns.Add(LangResx.Common.list_user_name, int.Parse(find_list_data("3")), HorizontalAlignment.Left);
            this.listView1.Columns.Add("password", 0, HorizontalAlignment.Left);
            this.listView1.Columns.Add(LangResx.Common.list_bz, int.Parse(find_list_data("4")), HorizontalAlignment.Left);
            this.listView1.Columns.Add("id", 0, HorizontalAlignment.Left);
            this.listView1.Columns.Add("top", 0, HorizontalAlignment.Left);
            this.listView1.Columns.Add("ping", int.Parse(find_list_data("5")), HorizontalAlignment.Left);
            this.listView1.View = System.Windows.Forms.View.Details;//不写这句，加的列显示不出来

            this.listView1.FullRowSelect = true;   //设置是否行选择模式
            //this.listView1.GridLines = true;   //设置行和列之间是否显示网格线
            this.listView1.MultiSelect = true;   //设置是否可以选择多个项



            //中   93  67       103   110
            //中   120  88       130   138    1.363
            //大   211  155      191   230
            if(Config.ini_list_run=="0"){
                this.listView1.View = View.Details;   //视图模式
                this.listView1.LargeImageList = this.imageList1;
                //this.listView1.StateImageList = this.imageList1;
                this.listView1.SmallImageList = this.imageList1;
            }
            else{
                if (Config.ini_list_index == "1"){  //小
                    img_Width = 93;  //缩率图
                    img_Height = 67;  //缩率图
                    img_row = 103;   //行间距
                    img_loc = 110;   //列间距
                }
                if (Config.ini_list_index == "2")  //中
                {
                    img_Width = 120;  //缩率图
                    img_Height = 88;  //缩率图
                    img_row = 130;   //行间距
                    img_loc = 138;   //列间距
                }
                if (Config.ini_list_index == "3")   //大
                {
                    img_Width = 211;  //缩率图
                    img_Height = 155;  //缩率图
                    img_row = 191;   //行间距
                    img_loc = 230;   //列间距
                }
                //=====
                this.listView1.View = View.LargeIcon;   //视图模式
                ImageList imageL = new ImageList();
                imageL.ImageSize = new Size(img_Width, img_Height);
                //imageL.Images.Add(Image.FromFile("C:\\Users\\Admin\\Desktop\\3389rdp\\git\\123.jpg"));
                int vvx = 0;
                foreach (Image img in imageList_img.Images)
                {   //lvi.ImageKey = "host.png";      
                    imageL.Images.Add(imageList_img.Images.Keys[vvx].ToString(),img);    //这个地方不知道怎么找KEY name
                    ++vvx;
                }
                //imageL.Images.Add("123.jpg", new Bitmap("C:\\Users\\Admin\\Desktop\\3389rdp\\git\\123.jpg"));
                JSONArray jsonArray = data_ergodic();  //遍历目录
                for (int i = 0; i < jsonArray.Count; i++)
                {
                    string name = jsonArray[i].ToString();
                    string fiel_path = Application.StartupPath + "\\data\\" + name;
                    imageL.Images.Add(name, new Bitmap(fiel_path));
                }
                this.listView1.LargeImageList = imageL;
                //Console.WriteLine("xxxxxxxx  " + imageL.Images.Count);
                //=====
            }

            //for (int i = 0; i < imageList1.Images.Count; i++)
            //{
            //    imageL.Images.Add(imageList1.Images[i]);
            //}
        }

        public static JSONArray data_ergodic()  //遍历目录
        {
            JSONArray jsonArray = new JSONArray();
            DirectoryInfo theFolder = new DirectoryInfo(@"data");
            if (!theFolder.Exists) return jsonArray;
            DirectoryInfo dir = theFolder as DirectoryInfo;
            if (dir == null) return jsonArray;//不是目录
            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;
                if (file != null)//是文件
                {
                    if(file.Extension == ".jpg")
                    {
                        jsonArray.Add(file.Name);
                    }
                    //listBox.Items.Add("名字: " + file.Name + ", 创建时间: " + file.CreationTime + ", 扩展名: " + file.Extension + ", 上次访问时间: " + file.LastAccessTime);
                }
                //else scan(files[i]);
            }
            return jsonArray;
        }

        public static string find_list_data(string index)  //查找px
        {
            string sError = ""; // string.Empty;
            string sSql = string.Format("SELECT * FROM list  where i='{0}'", index);
            DataTable dtxx = SqlLiteHelper.GetDataTable(out sError, sSql);
            string px = "100";
            if (dtxx.Rows.Count >= 1)
            {
                px = dtxx.Rows[0][2].ToString();
            }
            return px;
        }
        public void ListView_add(DataRow dt, ListViewGroup man_lvg, bool add,string Colorxxx)  //添加SHELL
        {
            string id = dt[0].ToString();   //id
            string ip = dt[1].ToString();   //ip地址
                                                    //string post = dt[2].ToString();   //端口
            string user = dt[3].ToString();   //用户名
            string password = dt[4].ToString();   //密码
            string name = dt[5].ToString();   //名称
            string bz = dt[6].ToString();   //备注
            string top = dt[7].ToString();   //排序
            string os = dt[8].ToString();   //系统
            string Colorvv = dt[10].ToString();   //颜色标记

            ListViewItem lvi = new ListViewItem(new string[] {
                        name,ip,user,password,bz,id,top,""});
            //id  名称  ip地址  用户名   密码  备注
            if (Config.ini_list_run == "0")
            {
                lvi.ImageIndex = int.Parse(os);  //设置图标
            }
            else
            {
                string fiel_name = string.Format("{0}.jpg", id);
                string fiel_path = Application.StartupPath + "\\data\\" + fiel_name;
                if (File.Exists(fiel_path))
                {
                    lvi.ImageKey = fiel_name;
                }else{
                    //lvi.ImageIndex = 0;  //设置图标
                    lvi.ImageKey = "host.png";
                } 
            }
                

            lvi.UseItemStyleForSubItems = false;  //设置底色

            if (Colorxxx == "1")    //颜色标记
            {
                //this.listView1.Items[0].SubItems[0].ForeColor = Color.Green;//改变 字体
                if (Colorvv == "2"){
                    lvi.SubItems[0].BackColor = Color.SteelBlue;  //底色
                }
                if (Colorvv == "3"){
                    lvi.SubItems[0].BackColor = Color.Tomato;
                }
                if (Colorvv == "4"){
                    lvi.SubItems[0].BackColor = Color.SlateBlue;
                }
                if (Colorvv == "5"){
                    lvi.SubItems[0].BackColor = Color.SandyBrown;
                }
                if (Colorvv == "6"){
                    lvi.SubItems[0].BackColor = Color.MediumSpringGreen;
                }
            }
            
            //lvi.subitems.add(id);
            //lvi.subitems.add(name);
            if (add == true)
            {
                man_lvg.Items.Add(lvi);   //分组添加子项
            }
            this.listView1.Items.Add(lvi);
        }

        public void BindsListViewDataSource()   // 主机绑定数据源
        {
            this.listView1.BeginUpdate();   //数据更新
            this.listView1.Items.Clear();
            //==========================
            string Color = Config.ini_Color;  //颜色标记
            string fz = Config.ini_fz;  //分组
            string sError = ""; // string.Empty;
            string sErrorxx = ""; // string.Empty;
            string sSql = "select * from fz order by top asc";  //分组
            DataTable dt = SqlLiteHelper.GetDataTable(out sError, sSql);  //分组
            sSql = "select * from shell order by top asc";   //数据
            DataTable dtxx = SqlLiteHelper.GetDataTable(out sErrorxx, sSql);   //数据
            ArrayList index_list = new ArrayList();
            if (fz == "1")
            {
                if (sError == "")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)  //分组
                    {
                        string id = dt.Rows[i][0].ToString();   //id
                        string name = dt.Rows[i][1].ToString();   //ip地址
                        ListViewGroup man_lvg = new ListViewGroup();  //创建男生分组  
                        //实现收放   展开   后面在写
                        //http://www.codeproject.com/Articles/36775/Collapsible-ListViewGroup
                        man_lvg.Header = name;  //设置组的标题。  
                        man_lvg.HeaderAlignment = HorizontalAlignment.Left;   //设置组标题文本的对齐方式。（默认为Left）
                        this.listView1.Groups.Add(man_lvg);    //把分组添加到listview中
                        if (sErrorxx == "")
                        {
                            for (int x = 0; x < dtxx.Rows.Count; x++)
                            {
                                if (dtxx.Rows[x][9].ToString() == id)
                                {
                                    index_list.Add(dtxx.Rows[x][0].ToString());
                                    ListView_add(dtxx.Rows[x], man_lvg, true, Color);  //添加分组
                                }
                            }
                        }
                    }
                    if (dt.Rows.Count >= 1)
                    {
                        this.listView1.ShowGroups = true;  //记得要设置ShowGroups属性为true（默认是false），否则显示不出分组 
                        //=======//未分组
                        ListViewGroup man_lvg = new ListViewGroup();  //创建男生分组  
                        man_lvg.Header = "NULL Host";  //设置组的标题。  
                        man_lvg.HeaderAlignment = HorizontalAlignment.Left;   //设置组标题文本的对齐方式。（默认为Left）
                        this.listView1.Groups.Add(man_lvg);    //把分组添加到listview中
                        if (sErrorxx == "")
                        {
                            for (int x = 0; x < dtxx.Rows.Count; x++)
                            {
                                string id = dtxx.Rows[x][0].ToString();
                                if (index_list.Contains(id) == false)
                                {
                                    ListView_add(dtxx.Rows[x], man_lvg, true, Color);  //添加分组
                                }
                            }
                        }
                        //=======
                    }
                }
            }
            if (dt.Rows.Count == 0 || fz == "0") 
            {
                //=======
                if (sErrorxx == "")
                {
                    this.listView1.ShowGroups = false;  //记得要设置ShowGroups属性为true（默认是false），否则显示不出分组 
                    ListViewGroup man_lvg = new ListViewGroup();  //创建男生分组 
                    for (int x = 0; x < dtxx.Rows.Count; x++)
                    {
                        string id = dtxx.Rows[x][0].ToString();
                        if (index_list.Contains(id) == false)
                        {
                            ListView_add(dtxx.Rows[x], man_lvg, false, Color);  //添加分组
                        }
                    }
                }
                //=======
            }
            //if (dtxx.Rows.Count >= 1)
            //{
            //    this.tool_fz.Enabled = true;
            //    this.tool_Color.Enabled = true;
            //}

            SendMessage(this.listView1.Handle, LVM_SETICONSPACING, 0, 0x10000 * img_row + img_loc);//70是行距，60是列距，一般比你的图片的宽高大一点点即可。大出来的部分便是间隙。

            this.listView1.EndUpdate();  //结束数据处理

            this.tsItemLabel.Text = string.Format(LangResx.Common.form1_tsItemLabel_together + " {0} " + LangResx.Common.form1_tsItemLabel_bar, dtxx.Rows.Count);
            listView1_Selected();  //选择状态
        }

        

        public void Bontext_ColorDataSource()  //标记
        {
            this.context_Color.Items.Clear();
            ToolStripItem itembb = new ToolStripMenuItem();
            itembb.Name = "0";   //id
            itembb.Text = LangResx.Common.bj_no_display;   // "不显示标记";   //名称
            itembb.Image = Properties.Resources.close;    //增加ICO
            if (Config.ini_Color == "0")
            {
                itembb.BackColor = Color.FromArgb(176, 226, 255);
            }
            itembb.Click += new EventHandler(context_Color_ItemClick);
            this.context_Color.Items.Add(itembb);

            itembb = new ToolStripMenuItem();
            itembb.Name = "1";   //id
            itembb.Text = LangResx.Common.bj_display;  // "显示标记";   //名称
            itembb.Image = Properties.Resources.open;   //增加ICO
            if (Config.ini_Color == "1")
            {
                itembb.BackColor = Color.FromArgb(176, 226, 255);
            }
            itembb.Click += new EventHandler(context_Color_ItemClick);
            this.context_Color.Items.Add(itembb);
            
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            this.context_Color.Items.Add(toolStripSeparator1);


            itembb = new ToolStripMenuItem();
            itembb.Name = "2";   //id
            itembb.Text = string.Format("{0}  1", LangResx.Common.bj);  //"标记  1";   //名称
            itembb.BackColor = Color.SteelBlue;
            itembb.Click += new EventHandler(context_Color_ItemClick);
            this.context_Color.Items.Add(itembb);
            itembb = new ToolStripMenuItem();
            itembb.Name = "3";   //id
            itembb.Text = string.Format("{0}  2", LangResx.Common.bj);  //"标记  2";   //名称
            itembb.BackColor = Color.Tomato;
            itembb.Click += new EventHandler(context_Color_ItemClick);
            this.context_Color.Items.Add(itembb);
            itembb = new ToolStripMenuItem();
            itembb.Name = "4";   //id
            itembb.Text = string.Format("{0}  3", LangResx.Common.bj);  //"标记  3";   //名称
            itembb.BackColor = Color.SlateBlue;
            itembb.Click += new EventHandler(context_Color_ItemClick);
            this.context_Color.Items.Add(itembb);
            itembb = new ToolStripMenuItem();
            itembb.Name = "5";   //id
            itembb.Text = string.Format("{0}  4", LangResx.Common.bj);  //"标记  4";   //名称
            itembb.BackColor = Color.SandyBrown;
            itembb.Click += new EventHandler(context_Color_ItemClick);
            this.context_Color.Items.Add(itembb);
            itembb = new ToolStripMenuItem();
            itembb.Name = "6";   //id
            itembb.Text = string.Format("{0}  5", LangResx.Common.bj); //"标记  5";   //名称
            itembb.BackColor = Color.MediumSpringGreen;
            itembb.Click += new EventHandler(context_Color_ItemClick);
            this.context_Color.Items.Add(itembb);

            
        }

        public void Bontext_fzDataSource()   //分组绑定数据源
        {
            this.context_fz.Items.Clear();
            ToolStripItem itemxx = new ToolStripMenuItem();
            itemxx.Name = "null";   //id
            itemxx.Text = LangResx.Common.fz_no_display;  // "不显示分组";   //名称
            itemxx.Image = Properties.Resources.close;    //增加ICO
            //Properties.Resources.delete;
            if (Config.ini_fz == "0"){
                itemxx.BackColor = Color.FromArgb(176, 226, 255);
            }
            itemxx.Click += new EventHandler(context_fz_ItemClick);
            this.context_fz.Items.Add(itemxx);

            itemxx = new ToolStripMenuItem();
            itemxx.Name = "display";   //id
            itemxx.Text = LangResx.Common.fz_display; // "显示分组";   //名称
            itemxx.Image = Properties.Resources.open;   //增加ICO
            if (Config.ini_fz == "1")
            {
                itemxx.BackColor = Color.FromArgb(176, 226, 255);
            }
            itemxx.Click += new EventHandler(context_fz_ItemClick);
            this.context_fz.Items.Add(itemxx);

            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            this.context_fz.Items.Add(toolStripSeparator1);

            string sError = ""; // string.Empty;
            string sSql = "select * from fz order by top asc";
            DataTable dt = SqlLiteHelper.GetDataTable(out sError, sSql);
            if (sError == "")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ToolStripItem item = new ToolStripMenuItem();
                    item.Name = dt.Rows[i][0].ToString();   //id
                    item.Text = dt.Rows[i][1].ToString();   //名称
                    item.Click += new EventHandler(context_fz_ItemClick);
                    this.context_fz.Items.Add(item);
                }
            }
        }

        private void context_fz_ItemClick(object sender, EventArgs e)  //分组
        {
            ToolStripItem item = (ToolStripItem)sender;
            string name = item.Name;
            if (name == "null")   //不显示分组
            {
                Config.Set_fz("0");
                BindsListViewDataSource();  // 重新绑定数据源
                BindsListViewDataSource();  // 重新绑定数据源
                Bontext_fzDataSource();   //分组绑定数据源
                return;
            }
            if (name == "display")   //显示分组
            {
                Config.Set_fz("1");
                BindsListViewDataSource();  // 重新绑定数据源
                BindsListViewDataSource();  // 重新绑定数据源
                Bontext_fzDataSource();   //分组绑定数据源
                return;
            }
            

            if (this.listView1.SelectedItems.Count == 0) return;
            string sError = ""; // string.Empty;
            for (int j = 0; j < this.listView1.SelectedItems.Count; j++)
            {
                string id = this.listView1.SelectedItems[j].SubItems[5].Text;
                //string serror = ""; // string.empty;
                string sql = string.Format("update shell set fz='{0}' where id='{1}'", name, id);
                bool bresult = SqlLiteHelper.UpdateData(out sError, sql, true);
            }
            if (sError == "")
            {
                Config.Set_fz("1");
                BindsListViewDataSource();  // 重新绑定数据源
                BindsListViewDataSource();  // 重新绑定数据源
            }
            else
            {
                CommonSettings.WinMessage(LangResx.Common.msg_fail);
                return;
            }
        }

        private void context_Color_ItemClick(object sender, EventArgs e)  //标记
        {
            ToolStripItem item = (ToolStripItem)sender;
            string name = item.Name;
            if (name == "0")   //不标记
            {
                Config.Set_Color("0");
                BindsListViewDataSource();  // 重新绑定数据源
                BindsListViewDataSource();  // 重新绑定数据源
                Bontext_ColorDataSource();  //标记
                return;
            }
            if (name == "1")   //标记
            {
                Config.Set_Color("1");
                BindsListViewDataSource();  // 重新绑定数据源
                BindsListViewDataSource();  // 重新绑定数据源
                Bontext_ColorDataSource();  //标记
                return;
            }
            if (this.listView1.SelectedItems.Count == 0) return;
            string sError = ""; // string.Empty;
            for (int j = 0; j < this.listView1.SelectedItems.Count; j++)
            {
                string id = this.listView1.SelectedItems[j].SubItems[5].Text;
                //string serror = ""; // string.empty;
                string sql = string.Format("update shell set Color='{0}' where id='{1}'", name, id);
                bool bresult = SqlLiteHelper.UpdateData(out sError, sql, true);
            }
            if (sError == "")
            {
                Config.Set_Color("1");
                BindsListViewDataSource();  // 重新绑定数据源
                BindsListViewDataSource();  // 重新绑定数据源
            }
            else
            {
                CommonSettings.WinMessage(LangResx.Common.msg_fail);
                return;
            }
        }

        //===========================================

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

        private void axMsRdpcForm_Closed(object sender, FormClosedEventArgs e)  // 远程桌面窗体-关闭  远程桌面窗体axMsRdpcForm
        {
            Form frm = (Form)sender;
            //MessageBox.Show(frm.Controls[0].GetType().ToString());
            foreach (Control ctrl in frm.Controls)
            {
                // 找到当前打开窗口下面的远程桌面
                if (ctrl.GetType().ToString() == "AxMSTSCLib.AxMsRdpClient7NotSafeForScripting")
                {
                    // 释放缓存
                    if (axMsRdpcArray.Contains(ctrl.Name)) axMsRdpcArray.Remove(ctrl.Name);
                    // 断开连接
                    var _axMsRdp = ctrl as AxMsRdpClient7NotSafeForScripting;
                    if (_axMsRdp.Connected != 0)
                    {
                        _axMsRdp.Disconnect();
                        _axMsRdp.Dispose();
                    }
                }
            }
        }


        private bool find_shell_id(string id)
        {
            int num5 = Config.host_list.Count - 1;
            for (int i = 0; i <= num5; i++)
            {
                if (Config.host_list[i].get_shell_id() == id)
                {
                    return true;
                }
            }
            return false;
        }
        private void SelectListViewRunRdpc()  /// 启动选中列表行的数据进行远程服务器连接
        {
            Rectangle rectangle = Link.get_Bounds(new Rectangle(base.Location, base.Size));
            Rectangle rectangle_ = Link.get_WorkingArea(rectangle);

            List<Link> list2 = new List<Link>();
            //Console.WriteLine("bbbbbbbbb----bbbbbbbbbbbb   ");
            if (this.listView1.SelectedItems.Count == 0) return;
            for (int i = 0; i < this.listView1.SelectedItems.Count; i++)
            {
                string id = this.listView1.SelectedItems[i].SubItems[5].Text;  //ID
                if (find_shell_id(id) == true){continue;}  //防止重复加载

                var abc = new string[] {
                    this.listView1.SelectedItems[i].SubItems[1].Text,  //ip
                    this.listView1.SelectedItems[i].SubItems[2].Text,  //user
                    this.listView1.SelectedItems[i].SubItems[3].Text,  //密码
                    this.listView1.SelectedItems[i].SubItems[0].Text,   //名称
                    this.listView1.SelectedItems[i].SubItems[4].Text};  //备注

                Link frm = new Link();

                frm.send_shell_id(id);  //记录ID防止重复加载
                frm.form_Location(rectangle_.Location);   //设置窗口坐标位置
                frm.Server_Ini(abc);
                list2.Add(frm);
                //frm.Show();
                //frm.ShowDialog();
            }
            Link.list_form_window(rectangle_, list2.ToArray());
            int num11 = list2.Count - 1;
            for (int i = 0; i <= num11; i++)
            {
                list2[i].Show();
            }
            Config.host_list.AddRange(list2);

        }

        private void listView1_Selected()
        {
            if (this.listView1.SelectedItems.Count == 0)
            {
                this.tsbConnect.Enabled = false;
                this.tsbEdit.Enabled = false;
                this.tsbDel.Enabled = false;
                this.tsMenuConnect.Enabled = false;
                this.tsMenuEdit.Enabled = false;
                this.tsMenuDel.Enabled = false;
                this.tsindex_upper.Enabled = false;
                this.ToolStrip_upper.Enabled = false;
                this.tsindex_lower.Enabled = false;
                this.tool_fz.Enabled = false;
                this.tool_Color.Enabled = false;
                this.ToolStrip_Color.Enabled = false;
                this.ToolStrip_fz.Enabled = false;
                this.ToolStrip_lower.Enabled = false;
            }
            else
            {
                this.tsbConnect.Enabled = true;
                this.tsbEdit.Enabled = true;
                this.tsbDel.Enabled = true;
                this.tsMenuConnect.Enabled = true;
                this.tsMenuEdit.Enabled = true;
                this.tsMenuDel.Enabled = true;
                this.tool_fz.Enabled = true;
                this.tool_Color.Enabled = true;
                this.ToolStrip_Color.Enabled = true;
                this.ToolStrip_fz.Enabled = true;

                //this.tsindex_upper.Enabled = true;
                //this.tsindex_lower.Enabled = true;
                int index = this.listView1.SelectedItems[0].Index;
                if (index <= 0)
                {
                    this.tsindex_upper.Enabled = false;
                    this.ToolStrip_upper.Enabled = false;
                    this.tsindex_lower.Enabled = true;
                    this.ToolStrip_lower.Enabled = true;
                }
                else
                {
                    if (index == this.listView1.Items.Count - 1)
                    {
                        this.tsindex_upper.Enabled = true;
                        this.ToolStrip_upper.Enabled = true;
                        this.tsindex_lower.Enabled = false;
                        this.ToolStrip_lower.Enabled = false;
                    }
                    else
                    {
                        this.tsindex_upper.Enabled = true;
                        this.ToolStrip_upper.Enabled = true;
                        this.tsindex_lower.Enabled = true;
                        this.ToolStrip_lower.Enabled = true;
                    }
                }
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)     // ListView-至少选中一条数据才显示可用菜单项
        {
            listView1_Selected();  //选择状态
        }

        private void listView1_DoubleClick(object sender, EventArgs e)  // ListView-双击打开远程连接
        {
            SelectListViewRunRdpc();
        }

        private void DeleteListViewDataSource()  // 根据服务器IP删除数据
        {
            if (this.listView1.SelectedItems.Count == 0) return;

            DialogResult result = MessageBox.Show(LangResx.Common.msg_del_yes_no, LangResx.Common.msg_del_title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)   //"已选中 1 项数据，是否确认删除？"
            { //遍历删除
                string sError = ""; // string.Empty;
                for (int j = 0; j < this.listView1.SelectedItems.Count; j++)
                {
                    string id = this.listView1.SelectedItems[j].SubItems[5].Text;
                    string sSql = string.Format("delete from shell where id= '{0}'", id);
                    bool bResult = SqlLiteHelper.UpdateData(out sError, sSql, true);
                    string fiel_path = Application.StartupPath + "\\data\\" + id+".jpg";
                    File.Delete(fiel_path);  //删除文件
                }
                if(sError == "")
                {
                    BindsListViewDataSource();  // 重新绑定数据源
                }else{
                    CommonSettings.WinMessage(LangResx.Common.msg_del_fail);
                    return;
                }

                //string id = this.listView1.SelectedItems[0].SubItems[5].Text;
                //string sSql = string.Format("delete from shell where id= '{0}'", id);
                //string sError = ""; // string.Empty;
                //bool bResult = SqlLiteHelper.UpdateData(out sError, sSql, true);
                //if (bResult)
                //{
                //    BindsListViewDataSource();  // 重新绑定数据源
                //}else{
                //    CommonSettings.WinMessage(LangResx.Common.msg_del_fail);
                //    return;
                //}
            }
        }

        private void tsbAddData_Click(object sender, EventArgs e)  // 菜单栏-添加
        {
            AddOrEditListViewDataSource(OperType.Add);
        }

        private void tsbEdit_Click(object sender, EventArgs e)  // 菜单栏-编辑
        {
            AddOrEditListViewDataSource(OperType.Edit);
        }

        private void tsbDel_Click(object sender, EventArgs e)  // 菜单栏-删除
        {
            DeleteListViewDataSource();
        }


        //private void tsbFullScreen_Click_1(object sender, EventArgs e)  // 菜单栏-全屏模式
        //{
        //    this.isFullScreen = !this.isFullScreen;
        //    if (this.isFullScreen)
        //    {
        //        this.tsbFullScreen.Text = "取消全屏";
        //        this.tsbFullScreen.ForeColor = Color.Gray;
        //    }
        //    else
        //    {
        //        this.tsbFullScreen.Text = "全屏模式";
        //        this.tsbFullScreen.ForeColor = Color.OliveDrab;
        //    }
        //}

        

        #region 右键菜单
        private void tsMenuConnect_Click(object sender, EventArgs e)  // 右键菜单-连接
        {
            SelectListViewRunRdpc();
        }

        private void tsMenuEdit_Click(object sender, EventArgs e)   // 右键菜单-编辑
        {
            AddOrEditListViewDataSource(OperType.Edit);
        }

        private void tsMenuDel_Click(object sender, EventArgs e)  // 右键菜单-删除
        {
            DeleteListViewDataSource();
        }
        #endregion

        private void tsbConnect_Click(object sender, EventArgs e)  // 菜单栏-连接
        {
            SelectListViewRunRdpc();
        }

        private void AddOrEditListViewDataSource(OperType type)  //增加修改数据
        {
            //Console.WriteLine("xxxxxxxxx");//输出语句，自动换行
            host frm = new host();
            if (type == OperType.Edit)
            {
                if (this.listView1.SelectedItems.Count == 0) return;
                frm._Action = "EDIT";
                frm._id = this.listView1.SelectedItems[0].SubItems[5].Text;
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindsListViewDataSource();
            }
        }
        private void Form1_SizeChanged(object sender, EventArgs e) // 主窗体-恢复窗体
        {
            this.ShowInTaskbar = true;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)  //主窗体-关闭
        {
            Application.Exit();
        }
        private void tsbAbout_Click(object sender, EventArgs e)  // 菜单栏-关于
        {
            About frm = new About();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void tsbini_Click(object sender, EventArgs e)   //ini配置
        {
            ini frm = new ini();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                listView1_ini();  //shell列表初始化
                BindsListViewDataSource();   // 重新绑定数据源
                Bontext_fzDataSource();   //分组绑定数据源
                Bontext_ColorDataSource();  //标记
                ping_run();  //运行
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)// 菜单栏-关于
        {
            About frm = new About();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void menu_Website_Click(object sender, EventArgs e)   // 菜单栏-官网
        {
            System.Diagnostics.Process.Start("explorer.exe", "http://shell-X.com");
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            LangUtil.SetDefaultLang("zh");
            // 是否重启 变量内容多语言
            DialogResult result = MessageBox.Show(text: LangResx.Common.msg_IS_en_ch, caption: LangResx.Common.msg_title, buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            LangUtil.SetDefaultLang("en");
            // 是否重启 变量内容多语言
            DialogResult result = MessageBox.Show(text: LangResx.Common.msg_IS_en_ch, caption: LangResx.Common.msg_title, buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }


        private void upper()  //上移
        {
            if (this.listView1.SelectedItems.Count == 0) return;
            string sError = ""; // string.Empty;
            for (int j = 0; j < this.listView1.SelectedItems.Count; j++)
            {
                int index = this.listView1.SelectedItems[j].Index;
                if (index <= 0) return;
                //if (index == this.listView1.Items.Count-1) return;
                string top = this.listView1.Items[index - 1].SubItems[6].Text;
                string id = this.listView1.SelectedItems[j].SubItems[5].Text;
                //string serror = ""; // string.empty;
                string sql = string.Format("select * from shell where top='{0}'", top);
                DataTable dt = SqlLiteHelper.GetDataTable(out sError, sql);
                if (dt.Rows.Count >= 1)
                {
                    top = Convert.ToString(int.Parse(top) - 1);
                }
                sql = string.Format("update shell set top='{0}' where id='{1}'", top, id);
                bool bresult = SqlLiteHelper.UpdateData(out sError, sql, true);
            }

            if (sError == "")
            {
                BindsListViewDataSource();  // 重新绑定数据源
            }
            else
            {
                CommonSettings.WinMessage(LangResx.Common.msg_fail);
                BindsListViewDataSource();  // 重新绑定数据源
            }
        }

        private void tsindex_upper_Click(object sender, EventArgs e)   //上移
        {
            upper();  //上移
        }
        private void lower()   //下移
        {
            if (this.listView1.SelectedItems.Count == 0) return;


            string sError = ""; // string.Empty;
            for (int j = 0; j < this.listView1.SelectedItems.Count; j++)
            {
                int index = this.listView1.SelectedItems[j].Index;
                //if (index <= 0) return;
                if (index == this.listView1.Items.Count - 1) return;
                string top = this.listView1.Items[index + 1].SubItems[6].Text;
                string id = this.listView1.SelectedItems[j].SubItems[5].Text;
                //string serror = ""; // string.Empty;
                string sql = string.Format("select * from shell where top='{0}'", top);
                DataTable dt = SqlLiteHelper.GetDataTable(out sError, sql);
                if (dt.Rows.Count >= 1)
                {
                    top = Convert.ToString(int.Parse(top) + 1);
                }
                sql = string.Format("update shell set top='{0}' where id='{1}'", top, id);
                bool bResult = SqlLiteHelper.UpdateData(out sError, sql, true);
            }
            if (sError == "")
            {
                BindsListViewDataSource();  // 重新绑定数据源
            }else{
                CommonSettings.WinMessage(LangResx.Common.msg_fail);
                BindsListViewDataSource();  // 重新绑定数据源
            }
        }

        private void tsindex_lower_Click(object sender, EventArgs e)   //下移
        {
            lower();   //下移
        }

        private void ToolStrip_upper_Click(object sender, EventArgs e)
        {
            upper();  //上移
        }

        private void ToolStrip_lower_Click(object sender, EventArgs e)
        {
            lower();   //下移
        }

        private void tool_Window_Tile_Click(object sender, EventArgs e)   //窗口 分块后面在折腾
        {
            Rectangle rectangle = Link.get_Bounds(new Rectangle(base.Location, base.Size));
            Rectangle rectangle_ = Link.get_WorkingArea(new Rectangle(base.Location, base.Size));

            List<Link> list = new List<Link>();
            int num3 = Config.host_list.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                Config.host_list[i].WindowState = FormWindowState.Normal;
                list.Add(Config.host_list[i]);
            }
            if (list.Count == 0)
            {
                if (Config.host_list.Count == 0)
                {
                    MessageBox.Show(LangResx.Common.link_host_err);
                }else{
                    MessageBox.Show(LangResx.Common.link_host_null);
                }
            }
            else if (!Link.list_form_Tile(rectangle_, list.ToArray()))
            {
                MessageBox.Show(LangResx.Common.link_host_max);
            }
        }

        private void tool_Overlay_window_Click(object sender, EventArgs e)  //窗口 叠加
        {
            Rectangle rectangle = Link.get_Bounds(new Rectangle(base.Location, base.Size));
            Rectangle rectangle_ = Link.get_WorkingArea(new Rectangle(base.Location, base.Size));

            List<Link> list = new List<Link>();
            int num3 = Config.host_list.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                Config.host_list[i].WindowState = FormWindowState.Normal;
                Config.host_list[i].form_Size(Config.host_list[i].MaximumSize);
                list.Add(Config.host_list[i]);
            }

            if (list.Count == 0)
            {
                if (Config.host_list.Count == 0)
                {
                    MessageBox.Show(LangResx.Common.link_host_err);
                }else{
                    MessageBox.Show(LangResx.Common.link_host_null);
                }
            }else{
                Link.list_form_window(rectangle_, list.ToArray());
                
            }

        }

        private void tool_mini_mize_Click(object sender, EventArgs e)  //窗口最小化
        {
            FormWindowState windowState = FormWindowState.Normal;
            Rectangle rectangle = Link.get_Bounds(new Rectangle(base.Location, base.Size));
            if (rectangle.IsEmpty)
            {
                //method_15("主窗口位置不在显示器可见范围", Enum0.const_3, 2800);
                return;
            }
            List<Link> list = new List<Link>();
            int num4 = Config.host_list.Count - 1;
            for (int i = 0; i <= num4; i++)
            {
                    list.Add(Config.host_list[i]);
                    if (Config.host_list[i].WindowState != FormWindowState.Minimized)
                    {
                        windowState = FormWindowState.Minimized;
                    }
            }
            if (list.Count == 0)
            {
                if (Config.host_list.Count == 0)
                {
                    MessageBox.Show(LangResx.Common.link_host_err);
                }else{
                    MessageBox.Show(LangResx.Common.link_host_null);
                }
            }
            else
            {
                int num5 = list.Count - 1;
                for (int i = 0; i <= num5; i++)
                {
                    list[i].WindowState = windowState;
                }
            }
        }

        private void list_display_Click(object sender, EventArgs e)  //关闭视图
        {
            Config.Set_list_run("0");
            listView1_ini();  //shell列表初始化
            BindsListViewDataSource();   // 重新绑定数据源
            Bontext_fzDataSource();   //分组绑定数据源
            Bontext_ColorDataSource();  //标记
            ping_run();  //运行
        }

        private void list_close_Click(object sender, EventArgs e)  //显示视图
        {
            Config.Set_list_run("1");
            listView1_ini();  //shell列表初始化
            BindsListViewDataSource();   // 重新绑定数据源
            Bontext_fzDataSource();   //分组绑定数据源
            Bontext_ColorDataSource();  //标记
            ping_run();  //运行
        }

        private void list_1_Click(object sender, EventArgs e)  //小图标
        {
            Config.Set_list_run("1");
            Config.Set_list_index("1");
            listView1_ini();  //shell列表初始化
            BindsListViewDataSource();   // 重新绑定数据源
            Bontext_fzDataSource();   //分组绑定数据源
            Bontext_ColorDataSource();  //标记
            ping_run();  //运行
        }

        private void list_2_Click(object sender, EventArgs e)  //中图标
        {
            Config.Set_list_run("1");
            Config.Set_list_index("2");
            listView1_ini();  //shell列表初始化
            BindsListViewDataSource();   // 重新绑定数据源
            Bontext_fzDataSource();   //分组绑定数据源
            Bontext_ColorDataSource();  //标记
            ping_run();  //运行
        }

        private void list_3_Click(object sender, EventArgs e)  //大图标
        {
            Config.Set_list_run("1");
            Config.Set_list_index("3");
            listView1_ini();  //shell列表初始化
            BindsListViewDataSource();   // 重新绑定数据源
            Bontext_fzDataSource();   //分组绑定数据源
            ping_run();  //运行
        }






        //=========================================




    }
}
