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
    public partial class ini_growing_add : Form
    {
        public string _Action;
        public string _id;
        public ini_growing_add()
        {
            InitializeComponent();
        }

        private void ini_growing_add_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_Action) || string.IsNullOrWhiteSpace(_id)) return;

            if (_Action == "EDIT")
            {
                string sError = ""; // string.Empty;
                string sSql = string.Format("select* from fz WHERE id = '{0}'", _id);
                DataTable dt = SqlLiteHelper.GetDataTable(out sError, sSql);
                if (dt.Rows.Count == 0)
                {
                    CommonSettings.WinMessage(LangResx.Common.host_Load_1);
                    this.Close();
                }

                this.name_data.Text = dt.Rows[0][1].ToString();   //ip地址
                this.save.Text = LangResx.Common.host_Load_2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.name_data.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                CommonSettings.WinMessage(LangResx.Common.msg_data_null);
                return;
            }
            string sError = ""; // string.Empty;
            if (_Action == "EDIT")
            {
                string sSql = string.Format("update fz set name='{0}' where id= '{1}'", name, _id);
                bool bResult = SqlLiteHelper.UpdateData(out sError, sSql, true);
                if (bResult)
                {
                    CommonSettings.WinMessage(LangResx.Common.host_add_3);
                }
                else
                {
                    CommonSettings.WinMessage(LangResx.Common.host_add_4);
                    return;
                }
            }
            else
            {
                string sSql = string.Format("INSERT INTO fz(name) VALUES('{0}')", name);
                bool bResult = SqlLiteHelper.UpdateData(out sError, sSql, true);
                if (bResult)
                {
                    //=====================更改TOP
                    sSql = string.Format("select* from fz WHERE name = '{0}'", name);
                    DataTable dt = SqlLiteHelper.GetDataTable(out sError, sSql);
                    if (dt.Rows.Count >= 1)
                    {
                        string id = dt.Rows[0][0].ToString();
                        string top = Convert.ToString(int.Parse(id) + 10);
                        sSql = string.Format("update fz set top='{0}' where id= '{1}'", top, id);
                        SqlLiteHelper.UpdateData(out sError, sSql, true);
                    }
                    //=====================
                    CommonSettings.WinMessage(LangResx.Common.host_add_5);
                }
                else
                {
                    CommonSettings.WinMessage(LangResx.Common.host_add_6);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ini_growing_add_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
