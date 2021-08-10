
namespace rdp
{
    partial class ini
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ini));
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BitmapPersistence_yes = new System.Windows.Forms.RadioButton();
            this.BitmapPersistence_no = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EnableCredSspSupport_yes = new System.Windows.Forms.RadioButton();
            this.EnableCredSspSupport_no = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RedirectClipboard_yes = new System.Windows.Forms.RadioButton();
            this.RedirectClipboard_no = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NetworkConnectionType = new System.Windows.Forms.ComboBox();
            this.AudioRedirectionMode = new System.Windows.Forms.ComboBox();
            this.ColorDepth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Width_Height = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tab2 = new System.Windows.Forms.TabPage();
            this.ping_color = new System.Windows.Forms.CheckBox();
            this.ping_run = new System.Windows.Forms.CheckBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.checkBox_password = new System.Windows.Forms.CheckBox();
            this.list_update = new System.Windows.Forms.Button();
            this.listView_list = new System.Windows.Forms.ListView();
            this.growing_Move_down = new System.Windows.Forms.Button();
            this.growing_Move_up = new System.Windows.Forms.Button();
            this.growing_delete = new System.Windows.Forms.Button();
            this.growing_edit = new System.Windows.Forms.Button();
            this.growing_add = new System.Windows.Forms.Button();
            this.listView_growing = new System.Windows.Forms.ListView();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.HideSelection = false;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BitmapPersistence_yes);
            this.panel3.Controls.Add(this.BitmapPersistence_no);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // BitmapPersistence_yes
            // 
            resources.ApplyResources(this.BitmapPersistence_yes, "BitmapPersistence_yes");
            this.BitmapPersistence_yes.Checked = true;
            this.BitmapPersistence_yes.Name = "BitmapPersistence_yes";
            this.BitmapPersistence_yes.TabStop = true;
            this.BitmapPersistence_yes.UseVisualStyleBackColor = true;
            this.BitmapPersistence_yes.CheckedChanged += new System.EventHandler(this.BitmapPersistence_yes_CheckedChanged);
            // 
            // BitmapPersistence_no
            // 
            resources.ApplyResources(this.BitmapPersistence_no, "BitmapPersistence_no");
            this.BitmapPersistence_no.Name = "BitmapPersistence_no";
            this.BitmapPersistence_no.TabStop = true;
            this.BitmapPersistence_no.UseVisualStyleBackColor = true;
            this.BitmapPersistence_no.CheckedChanged += new System.EventHandler(this.BitmapPersistence_no_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.EnableCredSspSupport_yes);
            this.panel2.Controls.Add(this.EnableCredSspSupport_no);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // EnableCredSspSupport_yes
            // 
            resources.ApplyResources(this.EnableCredSspSupport_yes, "EnableCredSspSupport_yes");
            this.EnableCredSspSupport_yes.Checked = true;
            this.EnableCredSspSupport_yes.Name = "EnableCredSspSupport_yes";
            this.EnableCredSspSupport_yes.TabStop = true;
            this.EnableCredSspSupport_yes.UseVisualStyleBackColor = true;
            this.EnableCredSspSupport_yes.CheckedChanged += new System.EventHandler(this.EnableCredSspSupport_yes_CheckedChanged);
            // 
            // EnableCredSspSupport_no
            // 
            resources.ApplyResources(this.EnableCredSspSupport_no, "EnableCredSspSupport_no");
            this.EnableCredSspSupport_no.Name = "EnableCredSspSupport_no";
            this.EnableCredSspSupport_no.TabStop = true;
            this.EnableCredSspSupport_no.UseVisualStyleBackColor = true;
            this.EnableCredSspSupport_no.CheckedChanged += new System.EventHandler(this.EnableCredSspSupport_no_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RedirectClipboard_yes);
            this.panel1.Controls.Add(this.RedirectClipboard_no);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // RedirectClipboard_yes
            // 
            resources.ApplyResources(this.RedirectClipboard_yes, "RedirectClipboard_yes");
            this.RedirectClipboard_yes.Checked = true;
            this.RedirectClipboard_yes.Name = "RedirectClipboard_yes";
            this.RedirectClipboard_yes.TabStop = true;
            this.RedirectClipboard_yes.UseVisualStyleBackColor = true;
            this.RedirectClipboard_yes.CheckedChanged += new System.EventHandler(this.RedirectClipboard_yes_CheckedChanged);
            // 
            // RedirectClipboard_no
            // 
            resources.ApplyResources(this.RedirectClipboard_no, "RedirectClipboard_no");
            this.RedirectClipboard_no.Name = "RedirectClipboard_no";
            this.RedirectClipboard_no.TabStop = true;
            this.RedirectClipboard_no.UseVisualStyleBackColor = true;
            this.RedirectClipboard_no.CheckedChanged += new System.EventHandler(this.RedirectClipboard_no_CheckedChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // NetworkConnectionType
            // 
            this.NetworkConnectionType.FormattingEnabled = true;
            resources.ApplyResources(this.NetworkConnectionType, "NetworkConnectionType");
            this.NetworkConnectionType.Name = "NetworkConnectionType";
            // 
            // AudioRedirectionMode
            // 
            this.AudioRedirectionMode.FormattingEnabled = true;
            resources.ApplyResources(this.AudioRedirectionMode, "AudioRedirectionMode");
            this.AudioRedirectionMode.Name = "AudioRedirectionMode";
            // 
            // ColorDepth
            // 
            this.ColorDepth.FormattingEnabled = true;
            resources.ApplyResources(this.ColorDepth, "ColorDepth");
            this.ColorDepth.Name = "ColorDepth";
            this.ColorDepth.Tag = "";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Width_Height
            // 
            this.Width_Height.FormattingEnabled = true;
            resources.ApplyResources(this.Width_Height, "Width_Height");
            this.Width_Height.Name = "Width_Height";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file_disk_open.ico");
            this.imageList1.Images.SetKeyName(1, "file_disk_close.ico");
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.ping_color);
            this.tab2.Controls.Add(this.ping_run);
            this.tab2.Controls.Add(this.textBox_password);
            this.tab2.Controls.Add(this.checkBox_password);
            this.tab2.Controls.Add(this.list_update);
            this.tab2.Controls.Add(this.listView_list);
            this.tab2.Controls.Add(this.growing_Move_down);
            this.tab2.Controls.Add(this.growing_Move_up);
            this.tab2.Controls.Add(this.growing_delete);
            this.tab2.Controls.Add(this.growing_edit);
            this.tab2.Controls.Add(this.growing_add);
            this.tab2.Controls.Add(this.listView_growing);
            resources.ApplyResources(this.tab2, "tab2");
            this.tab2.Name = "tab2";
            this.tab2.UseVisualStyleBackColor = true;
            // 
            // ping_color
            // 
            resources.ApplyResources(this.ping_color, "ping_color");
            this.ping_color.Name = "ping_color";
            this.ping_color.UseVisualStyleBackColor = true;
            this.ping_color.CheckedChanged += new System.EventHandler(this.ping_color_CheckedChanged);
            // 
            // ping_run
            // 
            resources.ApplyResources(this.ping_run, "ping_run");
            this.ping_run.Name = "ping_run";
            this.ping_run.UseVisualStyleBackColor = true;
            this.ping_run.CheckedChanged += new System.EventHandler(this.ping_run_CheckedChanged);
            // 
            // textBox_password
            // 
            resources.ApplyResources(this.textBox_password, "textBox_password");
            this.textBox_password.Name = "textBox_password";
            // 
            // checkBox_password
            // 
            resources.ApplyResources(this.checkBox_password, "checkBox_password");
            this.checkBox_password.Name = "checkBox_password";
            this.checkBox_password.UseVisualStyleBackColor = true;
            this.checkBox_password.CheckedChanged += new System.EventHandler(this.checkBox_password_CheckedChanged);
            // 
            // list_update
            // 
            resources.ApplyResources(this.list_update, "list_update");
            this.list_update.Name = "list_update";
            this.list_update.UseVisualStyleBackColor = true;
            this.list_update.Click += new System.EventHandler(this.list_update_Click);
            // 
            // listView_list
            // 
            this.listView_list.HideSelection = false;
            resources.ApplyResources(this.listView_list, "listView_list");
            this.listView_list.Name = "listView_list";
            this.listView_list.UseCompatibleStateImageBehavior = false;
            this.listView_list.SelectedIndexChanged += new System.EventHandler(this.listView_list_SelectedIndexChanged);
            // 
            // growing_Move_down
            // 
            resources.ApplyResources(this.growing_Move_down, "growing_Move_down");
            this.growing_Move_down.Name = "growing_Move_down";
            this.growing_Move_down.UseVisualStyleBackColor = true;
            this.growing_Move_down.Click += new System.EventHandler(this.growing_Move_down_Click);
            // 
            // growing_Move_up
            // 
            resources.ApplyResources(this.growing_Move_up, "growing_Move_up");
            this.growing_Move_up.Name = "growing_Move_up";
            this.growing_Move_up.UseVisualStyleBackColor = true;
            this.growing_Move_up.Click += new System.EventHandler(this.growing_Move_up_Click);
            // 
            // growing_delete
            // 
            resources.ApplyResources(this.growing_delete, "growing_delete");
            this.growing_delete.Name = "growing_delete";
            this.growing_delete.UseVisualStyleBackColor = true;
            this.growing_delete.Click += new System.EventHandler(this.growing_delete_Click);
            // 
            // growing_edit
            // 
            resources.ApplyResources(this.growing_edit, "growing_edit");
            this.growing_edit.Name = "growing_edit";
            this.growing_edit.UseVisualStyleBackColor = true;
            this.growing_edit.Click += new System.EventHandler(this.growing_edit_Click);
            // 
            // growing_add
            // 
            resources.ApplyResources(this.growing_add, "growing_add");
            this.growing_add.Name = "growing_add";
            this.growing_add.UseVisualStyleBackColor = true;
            this.growing_add.Click += new System.EventHandler(this.growing_add_Click);
            // 
            // listView_growing
            // 
            this.listView_growing.HideSelection = false;
            resources.ApplyResources(this.listView_growing, "listView_growing");
            this.listView_growing.Name = "listView_growing";
            this.listView_growing.UseCompatibleStateImageBehavior = false;
            this.listView_growing.SelectedIndexChanged += new System.EventHandler(this.listView_growing_SelectedIndexChanged);
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.listView1);
            this.tab1.Controls.Add(this.panel3);
            this.tab1.Controls.Add(this.panel2);
            this.tab1.Controls.Add(this.panel1);
            this.tab1.Controls.Add(this.label10);
            this.tab1.Controls.Add(this.label9);
            this.tab1.Controls.Add(this.label8);
            this.tab1.Controls.Add(this.label5);
            this.tab1.Controls.Add(this.label4);
            this.tab1.Controls.Add(this.label3);
            this.tab1.Controls.Add(this.label2);
            this.tab1.Controls.Add(this.NetworkConnectionType);
            this.tab1.Controls.Add(this.AudioRedirectionMode);
            this.tab1.Controls.Add(this.ColorDepth);
            this.tab1.Controls.Add(this.label1);
            this.tab1.Controls.Add(this.Width_Height);
            resources.ApplyResources(this.tab1, "tab1");
            this.tab1.Name = "tab1";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tab2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // ini
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "ini";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ini_FormClosed);
            this.Load += new System.EventHandler(this.ini_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton BitmapPersistence_yes;
        private System.Windows.Forms.RadioButton BitmapPersistence_no;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton EnableCredSspSupport_yes;
        private System.Windows.Forms.RadioButton EnableCredSspSupport_no;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RedirectClipboard_yes;
        private System.Windows.Forms.RadioButton RedirectClipboard_no;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox NetworkConnectionType;
        private System.Windows.Forms.ComboBox AudioRedirectionMode;
        private System.Windows.Forms.ComboBox ColorDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Width_Height;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.ListView listView_growing;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button growing_Move_down;
        private System.Windows.Forms.Button growing_Move_up;
        private System.Windows.Forms.Button growing_delete;
        private System.Windows.Forms.Button growing_edit;
        private System.Windows.Forms.Button growing_add;
        private System.Windows.Forms.ListView listView_list;
        private System.Windows.Forms.Button list_update;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.CheckBox checkBox_password;
        private System.Windows.Forms.CheckBox ping_color;
        private System.Windows.Forms.CheckBox ping_run;
    }
}