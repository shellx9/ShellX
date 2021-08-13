using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rdp
{
    public partial class host : Form
    {
        public string _Action;
        public string _id;
        public host()
        {
            InitializeComponent();
        }

        private void host_Load(object sender, EventArgs e)   // 主窗体-加载
        {
            if (string.IsNullOrWhiteSpace(_Action) || string.IsNullOrWhiteSpace(_id)) return;

            if (_Action == "EDIT")
            { 
                string sError = ""; // string.Empty;
                string sSql = string.Format("select* from shell WHERE id = '{0}'", _id);
                DataTable dt = SqlLiteHelper.GetDataTable(out sError, sSql);
                if (dt.Rows.Count == 0)
                {
                    CommonSettings.WinMessage(LangResx.Common.host_Load_1);
                    this.Close();
                }

                this.ip.Text = dt.Rows[0][1].ToString();   //ip地址
                this.user.Text = dt.Rows[0][3].ToString();   //用户名
                this.password.Text = dt.Rows[0][4].ToString();   //密码
                this.name.Text = dt.Rows[0][5].ToString();   //名称
                this.bz.Text = dt.Rows[0][6].ToString();   //备注
                this.save.Text = LangResx.Common.host_Load_2;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.name.Text.Trim();
            string ip = this.ip.Text.Trim();
            string user = this.user.Text.Trim();
            string password = this.password.Text.Trim();
            string bz = this.bz.Text.Trim();

            if (string.IsNullOrWhiteSpace(ip))
            {
                CommonSettings.WinMessage(LangResx.Common.host_add_1);
                return;
            }
            //if (!CommonSettings.IsServerAddress(ip))
            //{
            //    CommonSettings.WinMessage("服务器IP地址格式不合法!");
            //    return;
            //}
            if (string.IsNullOrWhiteSpace(user))
            {
                CommonSettings.WinMessage(LangResx.Common.host_add_2);
                return;
            }
            string sError = ""; // string.Empty;
            if (_Action == "EDIT")
            {
                string sSql = string.Format("update shell set name='{0}',ip='{1}',user='{2}',password= '{3}',bz= '{4}' where id= '{5}'", name, ip, user, password, bz, _id);
                bool bResult = SqlLiteHelper.UpdateData(out sError, sSql, true);
                if (bResult)
                {
                    CommonSettings.WinMessage(LangResx.Common.host_add_3);
                }else{
                    CommonSettings.WinMessage(LangResx.Common.host_add_4);
                    return;
                }
            }
            else
            {
                string sSql = string.Format("INSERT INTO shell(name,ip, user, password, bz) VALUES('{0}','{1}','{2}','{3}','{4}')", name,ip, user, password, bz);
                bool bResult = SqlLiteHelper.UpdateData(out sError, sSql, true);
                if (bResult)
                {
                    //=====================更改TOP
                    sSql = string.Format("select* from shell WHERE name = '{0}' and ip = '{1}' and user = '{2}' and password = '{3}' and bz = '{4}'", name, ip, user, password, bz);
                    DataTable dt = SqlLiteHelper.GetDataTable(out sError, sSql);
                    if (dt.Rows.Count >= 1)
                    {
                        string id=dt.Rows[0][0].ToString();
                        string top = Convert.ToString(int.Parse(id) + 10);
                        sSql = string.Format("update shell set top='{0}' where id= '{1}'", top, id);
                        SqlLiteHelper.UpdateData(out sError, sSql, true);
                    }
                    //=====================
                    this.ip.Text = "";
                    CommonSettings.WinMessage(LangResx.Common.host_add_5);
                }else{
                    CommonSettings.WinMessage(LangResx.Common.host_add_6);
                    return;
                }
            }
            
            if (checkBox_add_continuity.Checked == false)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void host_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
