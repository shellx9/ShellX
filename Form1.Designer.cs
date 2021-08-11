
namespace rdp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsItemLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.menu_cn = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_usa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_Website = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_Color = new System.Windows.Forms.ToolStripDropDownButton();
            this.context_Color = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tool_fz = new System.Windows.Forms.ToolStripDropDownButton();
            this.context_fz = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsindex_upper = new System.Windows.Forms.ToolStripButton();
            this.tsindex_lower = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbini = new System.Windows.Forms.ToolStripButton();
            this.tool_Window_Tile = new System.Windows.Forms.ToolStripButton();
            this.tool_Overlay_window = new System.Windows.Forms.ToolStripButton();
            this.tool_mini_mize = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStrip_Color = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip_fz = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip_upper = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip_lower = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.statusStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMsg,
            this.tsItemLabel});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // tsMsg
            // 
            this.tsMsg.Name = "tsMsg";
            resources.ApplyResources(this.tsMsg, "tsMsg");
            this.tsMsg.Spring = true;
            // 
            // tsItemLabel
            // 
            this.tsItemLabel.Name = "tsItemLabel";
            resources.ApplyResources(this.tsItemLabel, "tsItemLabel");
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbConnect,
            this.toolStripSeparator1,
            this.tsbAddData,
            this.toolStripSeparator2,
            this.tsbEdit,
            this.tsbDel,
            this.menu,
            this.toolStripSeparator5,
            this.tool_Color,
            this.tool_fz,
            this.tsindex_upper,
            this.tsindex_lower,
            this.toolStripSeparator7,
            this.tsbini,
            this.tool_Window_Tile,
            this.tool_Overlay_window,
            this.tool_mini_mize});
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.Name = "toolStrip2";
            // 
            // tsbConnect
            // 
            this.tsbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbConnect, "tsbConnect");
            this.tsbConnect.Image = global::rdp.Properties.Resources.a1;
            this.tsbConnect.Name = "tsbConnect";
            this.tsbConnect.Click += new System.EventHandler(this.tsbConnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsbAddData
            // 
            this.tsbAddData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddData.Image = global::rdp.Properties.Resources.b1;
            resources.ApplyResources(this.tsbAddData, "tsbAddData");
            this.tsbAddData.Name = "tsbAddData";
            this.tsbAddData.Click += new System.EventHandler(this.tsbAddData_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbEdit, "tsbEdit");
            this.tsbEdit.Image = global::rdp.Properties.Resources.b2;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbDel, "tsbDel");
            this.tsbDel.Image = global::rdp.Properties.Resources.b3;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // menu
            // 
            this.menu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_cn,
            this.menu_usa,
            this.toolStripSeparator6,
            this.menu_Website,
            this.menu_About});
            this.menu.ForeColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.menu, "menu");
            this.menu.Name = "menu";
            // 
            // menu_cn
            // 
            this.menu_cn.Image = global::rdp.Properties.Resources.CN;
            this.menu_cn.Name = "menu_cn";
            resources.ApplyResources(this.menu_cn, "menu_cn");
            this.menu_cn.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // menu_usa
            // 
            this.menu_usa.Image = global::rdp.Properties.Resources.US;
            this.menu_usa.Name = "menu_usa";
            resources.ApplyResources(this.menu_usa, "menu_usa");
            this.menu_usa.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // menu_Website
            // 
            resources.ApplyResources(this.menu_Website, "menu_Website");
            this.menu_Website.Name = "menu_Website";
            this.menu_Website.Click += new System.EventHandler(this.menu_Website_Click);
            // 
            // menu_About
            // 
            this.menu_About.Image = global::rdp.Properties.Resources.tsbAbout1;
            this.menu_About.Name = "menu_About";
            resources.ApplyResources(this.menu_About, "menu_About");
            this.menu_About.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // tool_Color
            // 
            this.tool_Color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_Color.DropDown = this.context_Color;
            resources.ApplyResources(this.tool_Color, "tool_Color");
            this.tool_Color.Image = global::rdp.Properties.Resources.c1;
            this.tool_Color.Name = "tool_Color";
            // 
            // context_Color
            // 
            this.context_Color.Name = "context_Color";
            this.context_Color.OwnerItem = this.ToolStrip_Color;
            resources.ApplyResources(this.context_Color, "context_Color");
            // 
            // tool_fz
            // 
            this.tool_fz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_fz.DropDown = this.context_fz;
            resources.ApplyResources(this.tool_fz, "tool_fz");
            this.tool_fz.Image = global::rdp.Properties.Resources.c2;
            this.tool_fz.Name = "tool_fz";
            // 
            // context_fz
            // 
            this.context_fz.Name = "context_fz";
            this.context_fz.OwnerItem = this.ToolStrip_fz;
            resources.ApplyResources(this.context_fz, "context_fz");
            // 
            // tsindex_upper
            // 
            this.tsindex_upper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsindex_upper, "tsindex_upper");
            this.tsindex_upper.Image = global::rdp.Properties.Resources.c3;
            this.tsindex_upper.Name = "tsindex_upper";
            this.tsindex_upper.Click += new System.EventHandler(this.tsindex_upper_Click);
            // 
            // tsindex_lower
            // 
            this.tsindex_lower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsindex_lower, "tsindex_lower");
            this.tsindex_lower.Image = global::rdp.Properties.Resources.c4;
            this.tsindex_lower.Name = "tsindex_lower";
            this.tsindex_lower.Click += new System.EventHandler(this.tsindex_lower_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // tsbini
            // 
            this.tsbini.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbini.Image = global::rdp.Properties.Resources.d1;
            resources.ApplyResources(this.tsbini, "tsbini");
            this.tsbini.Name = "tsbini";
            this.tsbini.Click += new System.EventHandler(this.tsbini_Click);
            // 
            // tool_Window_Tile
            // 
            this.tool_Window_Tile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tool_Window_Tile, "tool_Window_Tile");
            this.tool_Window_Tile.Image = global::rdp.Properties.Resources.e1;
            this.tool_Window_Tile.Name = "tool_Window_Tile";
            this.tool_Window_Tile.Click += new System.EventHandler(this.tool_Window_Tile_Click);
            // 
            // tool_Overlay_window
            // 
            this.tool_Overlay_window.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_Overlay_window.Image = global::rdp.Properties.Resources.e2;
            resources.ApplyResources(this.tool_Overlay_window, "tool_Overlay_window");
            this.tool_Overlay_window.Name = "tool_Overlay_window";
            this.tool_Overlay_window.Click += new System.EventHandler(this.tool_Overlay_window_Click);
            // 
            // tool_mini_mize
            // 
            this.tool_mini_mize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_mini_mize.Image = global::rdp.Properties.Resources.e3;
            resources.ApplyResources(this.tool_mini_mize, "tool_mini_mize");
            this.tool_mini_mize.Name = "tool_mini_mize";
            this.tool_mini_mize.Click += new System.EventHandler(this.tool_mini_mize_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuConnect,
            this.toolStripSeparator4,
            this.tsMenuEdit,
            this.tsMenuDel,
            this.toolStripSeparator3,
            this.ToolStrip_Color,
            this.ToolStrip_fz,
            this.ToolStrip_upper,
            this.ToolStrip_lower});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // tsMenuConnect
            // 
            resources.ApplyResources(this.tsMenuConnect, "tsMenuConnect");
            this.tsMenuConnect.Image = global::rdp.Properties.Resources.a1;
            this.tsMenuConnect.Name = "tsMenuConnect";
            this.tsMenuConnect.Click += new System.EventHandler(this.tsMenuConnect_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // tsMenuEdit
            // 
            resources.ApplyResources(this.tsMenuEdit, "tsMenuEdit");
            this.tsMenuEdit.Image = global::rdp.Properties.Resources.b2;
            this.tsMenuEdit.Name = "tsMenuEdit";
            this.tsMenuEdit.Click += new System.EventHandler(this.tsMenuEdit_Click);
            // 
            // tsMenuDel
            // 
            resources.ApplyResources(this.tsMenuDel, "tsMenuDel");
            this.tsMenuDel.Image = global::rdp.Properties.Resources.b3;
            this.tsMenuDel.Name = "tsMenuDel";
            this.tsMenuDel.Click += new System.EventHandler(this.tsMenuDel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // ToolStrip_Color
            // 
            this.ToolStrip_Color.DropDown = this.context_Color;
            resources.ApplyResources(this.ToolStrip_Color, "ToolStrip_Color");
            this.ToolStrip_Color.Image = global::rdp.Properties.Resources.c1;
            this.ToolStrip_Color.Name = "ToolStrip_Color";
            // 
            // ToolStrip_fz
            // 
            this.ToolStrip_fz.DropDown = this.context_fz;
            resources.ApplyResources(this.ToolStrip_fz, "ToolStrip_fz");
            this.ToolStrip_fz.Image = global::rdp.Properties.Resources.c2;
            this.ToolStrip_fz.Name = "ToolStrip_fz";
            // 
            // ToolStrip_upper
            // 
            resources.ApplyResources(this.ToolStrip_upper, "ToolStrip_upper");
            this.ToolStrip_upper.Image = global::rdp.Properties.Resources.c3;
            this.ToolStrip_upper.Name = "ToolStrip_upper";
            this.ToolStrip_upper.Click += new System.EventHandler(this.ToolStrip_upper_Click);
            // 
            // ToolStrip_lower
            // 
            resources.ApplyResources(this.ToolStrip_lower, "ToolStrip_lower");
            this.ToolStrip_lower.Image = global::rdp.Properties.Resources.c4;
            this.ToolStrip_lower.Name = "ToolStrip_lower";
            this.ToolStrip_lower.Click += new System.EventHandler(this.ToolStrip_lower_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "win.ico");
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.HideSelection = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsMsg;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbAddData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsMenuConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem tsMenuDel;
        private System.Windows.Forms.ToolStripStatusLabel tsItemLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        //private ComponentOwl.BetterListView.BetterListViewColumnHeader chServerIp;
        //private ComponentOwl.BetterListView.BetterListViewColumnHeader chUserName;
        //private ComponentOwl.BetterListView.BetterListViewColumnHeader chPassword;
        //private ComponentOwl.BetterListView.BetterListViewColumnHeader chRemark;
        private System.Windows.Forms.ToolStripButton tsbini;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripDropDownButton menu;
        private System.Windows.Forms.ToolStripMenuItem menu_cn;
        private System.Windows.Forms.ToolStripMenuItem menu_usa;
        private System.Windows.Forms.ToolStripMenuItem menu_About;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menu_Website;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsindex_upper;
        private System.Windows.Forms.ToolStripButton tsindex_lower;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripDropDownButton tool_fz;
        private System.Windows.Forms.ContextMenuStrip context_fz;
        private System.Windows.Forms.ToolStripDropDownButton tool_Color;
        private System.Windows.Forms.ContextMenuStrip context_Color;
        private System.Windows.Forms.ToolStripButton tool_Window_Tile;
        private System.Windows.Forms.ToolStripButton tool_Overlay_window;
        private System.Windows.Forms.ToolStripButton tool_mini_mize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_Color;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_fz;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_upper;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_lower;
    }
}

