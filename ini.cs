using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Text;


namespace rdp
{
    public partial class ini : Form
    {

        public string id { get; set; }
        public string name { get; set; }

        enum OperType { Add, Edit }
        public ini()
        {
            InitializeComponent();
        }

        private void add_ini()
        {
            List<RegInfo> regInfos = new List<RegInfo>();
            regInfos.Add(new RegInfo { Id = 0, Name = LangResx.Common.ini_Width_Height });  //"全屏"
            regInfos.Add(new RegInfo { Id = 1, Name = "1920 x 1080" });
            regInfos.Add(new RegInfo { Id = 2, Name = "1680 x 1050" });
            regInfos.Add(new RegInfo { Id = 3, Name = "1600 x 1200" });
            regInfos.Add(new RegInfo { Id = 4, Name = "1400 x 1050" });
            regInfos.Add(new RegInfo { Id = 5, Name = "1440 x 900" });
            regInfos.Add(new RegInfo { Id = 6, Name = "1366 x 768" });
            regInfos.Add(new RegInfo { Id = 7, Name = "1280 x 1024" });
            regInfos.Add(new RegInfo { Id = 8, Name = "1280 x 800" });
            regInfos.Add(new RegInfo { Id = 9, Name = "1280 x 768" });
            regInfos.Add(new RegInfo { Id = 10, Name = "1280 x 720" });
            regInfos.Add(new RegInfo { Id = 11, Name = "1152 x 864" });
            regInfos.Add(new RegInfo { Id = 12, Name = "1024 x 768" });
            regInfos.Add(new RegInfo { Id = 13, Name = "800 x 600" });
            regInfos.Add(new RegInfo { Id = 14, Name = "640 x 480" });
            this.Width_Height.ValueMember = "Id";//value隐藏值
            this.Width_Height.DisplayMember = "Name";//display显示
            this.Width_Height.DataSource = regInfos;
            this.Width_Height.SelectedIndex = int.Parse(Config.ini_px);
            this.Width_Height.SelectedIndexChanged += Width_Height_SelectedIndexChanged;
            //===================
            List<RegInfo> regInfos_Color = new List<RegInfo>();
            regInfos_Color.Add(new RegInfo { Id = 0, Name = LangResx.Common.ini_Color_0 });  //"256色" 
            regInfos_Color.Add(new RegInfo { Id = 1, Name = LangResx.Common.ini_Color_1 });  //"增强色(15位)"
            regInfos_Color.Add(new RegInfo { Id = 2, Name = LangResx.Common.ini_Color_2 });  //"增强色(16位)"
            regInfos_Color.Add(new RegInfo { Id = 3, Name = LangResx.Common.ini_Color_3 });  //"真彩色(24位)"
            regInfos_Color.Add(new RegInfo { Id = 4, Name = LangResx.Common.ini_Color_4 });  //"最高质量(32位)"
            this.ColorDepth.ValueMember = "Id";//value隐藏值
            this.ColorDepth.DisplayMember = "Name";//display显示
            this.ColorDepth.DataSource = regInfos_Color;
            this.ColorDepth.SelectedIndex = Config.ini_ColorDepth;
            this.ColorDepth.SelectedIndexChanged += ColorDepth_SelectedIndexChanged;
            //===================
            List<RegInfo> regInfos_Audio = new List<RegInfo>();
            regInfos_Audio.Add(new RegInfo { Id = 0, Name = LangResx.Common.ini_Audio_0 });  //"在此计算机上播放"
            regInfos_Audio.Add(new RegInfo { Id = 1, Name = LangResx.Common.ini_Audio_1 });  //"在远程计算机上播放"
            regInfos_Audio.Add(new RegInfo { Id = 2, Name = LangResx.Common.ini_Audio_2 });  //"不要播放"
            this.AudioRedirectionMode.ValueMember = "Id";//value隐藏值
            this.AudioRedirectionMode.DisplayMember = "Name";//display显示
            this.AudioRedirectionMode.DataSource = regInfos_Audio;
            this.AudioRedirectionMode.SelectedIndex = Config.ini_AudioRedirectionMode;
            this.AudioRedirectionMode.SelectedIndexChanged += AudioRedirectionMode_SelectedIndexChanged;
            //===================
            List<RegInfo> regInfos_Network = new List<RegInfo>();
            regInfos_Network.Add(new RegInfo { Id = 0, Name = LangResx.Common.ini_Network_0 });  //"调制解调器(56 kbps)"
            regInfos_Network.Add(new RegInfo { Id = 1, Name = LangResx.Common.ini_Network_1 });  //"低速宽带(256 kbps - 2 Mbps)"
            regInfos_Network.Add(new RegInfo { Id = 2, Name = LangResx.Common.ini_Network_2 });  //"卫星(2 Mbps - 16 Mbps，具有高延迟)"
            regInfos_Network.Add(new RegInfo { Id = 3, Name = LangResx.Common.ini_Network_3 });  //"高速宽带(2 Mbps - 10 Mbps)"
            regInfos_Network.Add(new RegInfo { Id = 4, Name = LangResx.Common.ini_Network_4 });  //"广域网(10 Mbps 或更高，且延迟较高)"
            regInfos_Network.Add(new RegInfo { Id = 5, Name = LangResx.Common.ini_Network_5 });  //"局域网(LAN)(10 Mbps 或更高版本)"
            this.NetworkConnectionType.ValueMember = "Id";//value隐藏值
            this.NetworkConnectionType.DisplayMember = "Name";//display显示
            this.NetworkConnectionType.DataSource = regInfos_Network;
            this.NetworkConnectionType.SelectedIndex = Config.ini_NetworkConnectionType;
            this.NetworkConnectionType.SelectedIndexChanged += NetworkConnectionType_SelectedIndexChanged;
            //===================  //共享剪贴板
            if (Config.ini_RedirectClipboard == 1)
            {
                this.RedirectClipboard_yes.Checked = true;
                this.RedirectClipboard_no.Checked = false;
            }
            else
            {
                this.RedirectClipboard_yes.Checked = false;
                this.RedirectClipboard_no.Checked = true;
            }
            //===================  //网络验证
            if (Config.ini_EnableCredSspSupport == 1)
            {
                this.EnableCredSspSupport_yes.Checked = true;
                this.EnableCredSspSupport_no.Checked = false;
            }
            else
            {
                this.EnableCredSspSupport_yes.Checked = false;
                this.EnableCredSspSupport_no.Checked = true;
            }
            //===================  //启用缓存
            if (Config.ini_BitmapPersistence == 1)
            {
                this.BitmapPersistence_yes.Checked = true;
                this.BitmapPersistence_no.Checked = false;
            }
            else
            {
                this.BitmapPersistence_yes.Checked = false;
                this.BitmapPersistence_no.Checked = true;
            }
            //=================== ping
            if (Config.ini_ping_run == "1")
            {
                this.ping_run.Checked = true;
            }
            if (Config.ini_ping_color == "1")
            {
                this.ping_color.Checked = true;
            }
            //=================== 加载磁盘
            String[] drives = Environment.GetLogicalDrives();   //获取当前计算机逻辑磁盘名称列表
            string path = Environment.ExpandEnvironmentVariables("%systemdrive%");    //获取当前系统磁盘符方法2,返回：C:
            string[] Drive_array = Config.ini_Drive.Split(new char[] { '|' });  //读取配置

            this.listView1.View = View.LargeIcon;
            this.listView1.LargeImageList = this.imageList1;
           
            this.listView1.BeginUpdate();
            //ImageList imgList = new ImageList();
            //imgList.ImageSize = new Size(1, 15);// 设置行高 20 //分别是宽和高  
            //this.listView1.SmallImageList = imgList; //这里设置listView的SmallImageList ,用imgList将其撑大 
            this.listView1.Items.Clear();
            foreach (String dir in drives)
            {
                ListViewItem lvi = new ListViewItem();
                if (dir.Contains(path))
                {
                    lvi.ImageIndex = 0;  //0系统  1磁盘
                }
                else
                {
                    lvi.ImageIndex = 1;  //0系统  1磁盘
                }
                lvi.Text = dir;

                if (new List<string>(Drive_array).Contains(dir))
                {
                    lvi.Checked = true;//选中
                }
                this.listView1.Items.Add(lvi);
            }
            this.listView1.EndUpdate();
            //this.listView1.Items[0].Checked = true;
            //===================
            //===================


        }
        //===================================================

        private void Width_Height_SelectedIndexChanged(object sender, EventArgs e)   //分辨率选择
        {
            //this.Width_Height.SelectedItem.ToString()
            Config.Set_Width_Height(this.Width_Height.SelectedValue.ToString());
        }

        private void ColorDepth_SelectedIndexChanged(object sender, EventArgs e)  //色彩
        {
            Config.Set_ColorDeptht(this.ColorDepth.SelectedValue.ToString());

        }
        
        private void AudioRedirectionMode_SelectedIndexChanged(object sender, EventArgs e)   //远程音频播放
        {
            Config.Set_AudioRedirectionMode(this.AudioRedirectionMode.SelectedValue.ToString());
        }

        private void NetworkConnectionType_SelectedIndexChanged(object sender, EventArgs e)  //连接速度
        {
            Config.Set_NetworkConnectionType(this.NetworkConnectionType.SelectedValue.ToString());
        }

        private void RedirectClipboard_yes_CheckedChanged(object sender, EventArgs e)  //共享剪贴板
        {
            Config.Set_RedirectClipboard("1");
        }

        private void RedirectClipboard_no_CheckedChanged(object sender, EventArgs e)  //共享剪贴板
        {
            Config.Set_RedirectClipboard("0");
        }

        private void EnableCredSspSupport_no_CheckedChanged(object sender, EventArgs e)  //网络验证
        {
            Config.Set_EnableCredSspSupport("0");
        }

        private void EnableCredSspSupport_yes_CheckedChanged(object sender, EventArgs e)  //网络验证
        {
            Config.Set_EnableCredSspSupport("1");
        }

        private void BitmapPersistence_yes_CheckedChanged(object sender, EventArgs e)   //启用缓存
        {
            Config.Set_BitmapPersistence("1");
        }

        private void BitmapPersistence_no_CheckedChanged(object sender, EventArgs e)   //启用缓存
        {
            Config.Set_BitmapPersistence("0");
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)  //选择数据
        {
            //imsRdpClientNonScriptable4_0.DriveCollection.get_DriveByIndex((uint)i).RedirectionState
            int m = this.listView1.CheckedItems.Count;
            ///string[] dir = new string[m];
            string data = "";
            for (int i = 0; i < m; i++)
            {
                if (this.listView1.CheckedItems[i].Checked)
                {
                    string name = this.listView1.CheckedItems[i].SubItems[0].Text;
                    name = name.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
                    data = data + "|" + name;
                }
            }
            //Console.WriteLine("ssssss" + data);
            if (data != "")
            {
                Config.Set_Drive(data + "|");
            }
        }
        //=============================

        private void ini_Load(object sender, EventArgs e)
        {
            this.add_ini();  //加载INI
            //===================
            this.listView_growing.Columns.Add(LangResx.Common.fz_name, 200, HorizontalAlignment.Left);
            this.listView_growing.Columns.Add(LangResx.Common.fz_count, 150, HorizontalAlignment.Left);
            this.listView_growing.Columns.Add("id", 0, HorizontalAlignment.Left);
            this.listView_growing.Columns.Add("top", 0, HorizontalAlignment.Left);
            this.listView_growing.View = System.Windows.Forms.View.Details;//不写这句，加的列显示不出来
            this.listView_growing.FullRowSelect = true;   //设置是否行选择模式
            this.listView_growing.MultiSelect = false;   //设置是否可以选择多个项
            BindsListViewDataSource();   // 绑定数据源
            //===================
            this.listView_list.Columns.Add(LangResx.Common.list_name_name, 200, HorizontalAlignment.Left);
            this.listView_list.Columns.Add(LangResx.Common.list_name_name_px, 150, HorizontalAlignment.Left);
            this.listView_list.Columns.Add("id", 0, HorizontalAlignment.Left);
            this.listView_list.Columns.Add("index", 0, HorizontalAlignment.Left);
            this.listView_list.View = System.Windows.Forms.View.Details;//不写这句，加的列显示不出来
            this.listView_list.FullRowSelect = true;   //设置是否行选择模式
            this.listView_list.MultiSelect = false;   //设置是否可以选择多个项
            listView_listDataSource();   // 绑定数据源
            //===================
            if (Config.ini_password != "")
            {
                if (Config.ini_password_bool == "1")
                {
                    this.checkBox_password.Checked = true;
                }
                string password = Encoding.Default.GetString(Convert.FromBase64String(Config.ini_password));
                this.textBox_password.Text = password;
            }
            
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
        public void listView_listDataSource()   //列表
        {
            this.listView_list.BeginUpdate();   //数据更新
            this.listView_list.Items.Clear();
            ListViewItem lvi = new ListViewItem(new string[] { LangResx.Common.list_name, find_list_data("1"), "1", "1" }); ;
            this.listView_list.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { LangResx.Common.list_server, find_list_data("2"), "2", "2" });
            this.listView_list.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { LangResx.Common.list_user_name, find_list_data("3"), "3", "3" });
            this.listView_list.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { LangResx.Common.list_bz, find_list_data("4"), "4", "4" });
            this.listView_list.Items.Add(lvi); 
            lvi = new ListViewItem(new string[] { "ping", find_list_data("5"), "5", "5" });
            this.listView_list.Items.Add(lvi);
            
            this.listView_list.EndUpdate();  //结束数据处理
        }
        public void BindsListViewDataSource()   // 绑定数据源
        {
            this.listView_growing.BeginUpdate();   //数据更新
            this.listView_growing.Items.Clear();
            string sError = ""; // string.Empty;
            string sSql = "select * from fz order by top asc";
            DataTable dt = SqlLiteHelper.GetDataTable(out sError, sSql);
            if (sError == "")
            {
                //foreach (datarow row in dt.rows)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();   //id
                    string name = dt.Rows[i][1].ToString();   //名称
                    string top = dt.Rows[i][2].ToString();   //排序

                    sSql = string.Format("SELECT count(*) AS x FROM shell  where fz='{0}'", id);
                    DataTable dtxx = SqlLiteHelper.GetDataTable(out sError, sSql);
                    string top_index = "0";
                    if (dtxx.Rows.Count>=1)
                    {
                        top_index = dtxx.Rows[0][0].ToString();
                    }

                    ListViewItem lvi = new ListViewItem(new string[] {name, top_index, id,top});
                    this.listView_growing.Items.Add(lvi);
                }
                this.listView_growing.EndUpdate();  //结束数据处理
            }
        }
        private void list_update_Click(object sender, EventArgs e)
        {
            update_list_DataSource(OperType.Edit);
        }
        private void growing_add_Click(object sender, EventArgs e)
        {
            AddOrEditListViewDataSource(OperType.Add);
        }

        private void growing_edit_Click(object sender, EventArgs e)
        {
            AddOrEditListViewDataSource(OperType.Edit);
        }
        private void update_list_DataSource(OperType type)  //修改列表 PX
        {
            ini_list_update frm = new ini_list_update();
            if (type == OperType.Edit)
            {
                if (this.listView_list.SelectedItems.Count == 0) return;
                frm._Action = "EDIT";
                frm._id = this.listView_list.SelectedItems[0].SubItems[3].Text;
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                listView_listDataSource();   // 绑定数据源
            }
        }
        private void AddOrEditListViewDataSource(OperType type)  //增加修改数据
        {
            //Console.WriteLine("xxxxxxxxx");//输出语句，自动换行
            ini_growing_add frm = new ini_growing_add();
            if (type == OperType.Edit)
            {
                if (this.listView_growing.SelectedItems.Count == 0) return;
                frm._Action = "EDIT";
                frm._id = this.listView_growing.SelectedItems[0].SubItems[2].Text;
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindsListViewDataSource();
            }
        }

        private void listView_growing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView_growing.SelectedItems.Count == 0)
            {
                this.growing_edit.Enabled = false;
                this.growing_delete.Enabled = false;
                this.growing_Move_up.Enabled = false;
                this.growing_Move_down.Enabled = false;
            }
            else
            {
                this.growing_edit.Enabled = true;
                this.growing_delete.Enabled = true;
                //this.growing_Move_up.Enabled = true;
                //this.growing_Move_down.Enabled = true;
                int index = this.listView_growing.SelectedItems[0].Index;
                if (index <= 0)
                {
                    this.growing_Move_up.Enabled = false;
                    this.growing_Move_down.Enabled = true;
                }
                else
                {
                    if (index == this.listView_growing.Items.Count - 1)
                    {
                        this.growing_Move_up.Enabled = true;
                        this.growing_Move_down.Enabled = false;
                    }
                    else
                    {
                        this.growing_Move_up.Enabled = true;
                        this.growing_Move_down.Enabled = true;
                    }
                }
            }
        }

        private void growing_delete_Click(object sender, EventArgs e)
        {
            if (this.listView_growing.SelectedItems.Count == 0) return;

            DialogResult result = MessageBox.Show(LangResx.Common.msg_del_yes_no, LangResx.Common.msg_del_fail, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {  //遍历删除
                string sError = ""; // string.Empty;
                for (int j = 0; j < this.listView_growing.SelectedItems.Count; j++)
                {
                    string id = this.listView_growing.SelectedItems[j].SubItems[2].Text;
                    string sSql = string.Format("delete from fz where id= '{0}'", id);
                    bool bResult = SqlLiteHelper.UpdateData(out sError, sSql, true);
                }
                if (sError == "")
                {
                    BindsListViewDataSource();  // 重新绑定数据源
                }
                else
                {
                    CommonSettings.WinMessage(LangResx.Common.msg_del_fail);
                    return;
                }

                //string id = this.listView_growing.SelectedItems[0].SubItems[2].Text;
                //string sSql = string.Format("delete from fz where id= '{0}'", id);
                //string sError = ""; // string.Empty;
                //bool bResult = SqlLiteHelper.UpdateData(out sError, sSql, true);
                //if (bResult)
                //{
                //    BindsListViewDataSource();  // 重新绑定数据源
                //}
                //else
                //{
                //    CommonSettings.WinMessage(LangResx.Common.msg_del_fail); 
                //    return;
                //}
            }
        }

        private void growing_Move_up_Click(object sender, EventArgs e)
        {
            if (this.listView_growing.SelectedItems.Count == 0) return;
            int index = this.listView_growing.SelectedItems[0].Index;
            if (index <= 0) return;
            //if (index == this.listView_growing.Items.Count-1) return;
            string top = this.listView_growing.Items[index - 1].SubItems[3].Text;
            string id = this.listView_growing.SelectedItems[0].SubItems[3].Text;
            string serror = ""; // string.empty;

            string sql = string.Format("select * fz shell where top='{0}'", top);
            DataTable dt = SqlLiteHelper.GetDataTable(out serror, sql);
            if (dt.Rows.Count >= 1)
            {
                top = Convert.ToString(int.Parse(top) - 1);
            }
            sql = string.Format("update fz set top='{0}' where id='{1}'", top, id);
            bool bresult = SqlLiteHelper.UpdateData(out serror, sql, true);
            if (bresult)
            {
                BindsListViewDataSource();  // 重新绑定数据源
            }
            else
            {
                CommonSettings.WinMessage(LangResx.Common.msg_fail);
                return;
            }
        }

        private void growing_Move_down_Click(object sender, EventArgs e)
        {
            if (this.listView_growing.SelectedItems.Count == 0) return;
            int index = this.listView_growing.SelectedItems[0].Index;
            //if (index <= 0) return;
            if (index == this.listView_growing.Items.Count - 1) return;
            string top = this.listView_growing.Items[index + 1].SubItems[3].Text;
            string id = this.listView_growing.SelectedItems[0].SubItems[3].Text;
            string serror = ""; // string.Empty;
            string sql = string.Format("select * from fz where top='{0}'", top);
            DataTable dt = SqlLiteHelper.GetDataTable(out serror, sql);
            if (dt.Rows.Count >= 1)
            {
                top = Convert.ToString(int.Parse(top) + 1);
            }
            sql = string.Format("update fz set top='{0}' where id='{1}'", top, id);
            bool bResult = SqlLiteHelper.UpdateData(out serror, sql, true);
            if (bResult)
            {
                BindsListViewDataSource();  // 重新绑定数据源
            }
            else
            {
                CommonSettings.WinMessage(LangResx.Common.msg_fail);
                return;
            }
        }

        private void ini_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listView_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView_list.SelectedItems.Count == 0)
            {
                this.list_update.Enabled = false;
            }
            else
            {
                this.list_update.Enabled = true;
            }
        }

        //private void textBox_password_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    string password = textBox_password.Text;
        //    password= password.Replace("\n", "");
        //    if (password != "")
        //    {
        //        string bs64 = Convert.ToBase64String(Encoding.Default.GetBytes(password));   //编码
        //        Config.Set_password(bs64);
        //    }
        //    //if (e.KeyChar == '\r')
        //    //{}
        //}

        private void checkBox_password_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_password.Checked == true)
            {
                string password = textBox_password.Text;
                password = password.Replace("\n", "");
                if (password == "")
                {
                    //DialogResult result = MessageBox.Show(text: "密码不能为空", caption: "", buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question);
                    this.checkBox_password.Checked = false;
                    return;
                }
                else
                {
                    Config.Set_password_bool("1");
                    string bs64 = Convert.ToBase64String(Encoding.Default.GetBytes(password));   //编码
                    Config.Set_password(bs64);
                    DialogResult result = MessageBox.Show(text: LangResx.Common.msg_IS_en_ch, caption: LangResx.Common.msg_title, buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                }
            }
            else{
                Config.Set_password_bool("0");
            }

        }

        private void ping_run_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ping_run.Checked == true)
            {
                Config.Set_ping_run("1");
            }
            else
            {
                Config.Set_ping_run("0");
            }
        }
        private void ping_color_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ping_color.Checked == true)
            {
                Config.Set_ping_color("1");
            }
            else
            {
                Config.Set_ping_color("0");
            }
        }
    }



    class RegInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

        
    }
