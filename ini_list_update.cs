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
    public partial class ini_list_update : Form
    {
        public string _Action;
        public string _id;
        public ini_list_update()
        {
            InitializeComponent();
        }

        private void ini_list_update_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ini_list_update_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_Action) || string.IsNullOrWhiteSpace(_id)) return;

            if (_Action == "EDIT")
            {
                string sError = ""; // string.Empty;
                string sSql = string.Format("select* from list WHERE i = '{0}'", _id);
                DataTable dt = SqlLiteHelper.GetDataTable(out sError, sSql);
                if (dt.Rows.Count == 0)
                {
                    CommonSettings.WinMessage(LangResx.Common.host_Load_1);
                    this.Close();
                }
                this.textBox_px.Text = dt.Rows[0][2].ToString();   //ip地址
                this.save.Text = LangResx.Common.host_Load_2;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string px = this.textBox_px.Text.Trim();
            if (string.IsNullOrWhiteSpace(px))
            {
                CommonSettings.WinMessage(LangResx.Common.msg_data_null);
                return;
            }
            string sError = ""; // string.Empty;
            if (_Action == "EDIT")
            {
                string sSql = string.Format("update list set px='{0}' where i= '{1}'", px, _id);
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
