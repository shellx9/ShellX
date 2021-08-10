
namespace rdp
{
    partial class host
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(host));
            this.iptxt = new System.Windows.Forms.Label();
            this.usertxt = new System.Windows.Forms.Label();
            this.passwordtxt = new System.Windows.Forms.Label();
            this.bztxt = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.bz = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.erase = new System.Windows.Forms.Button();
            this.nametxt = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // iptxt
            // 
            resources.ApplyResources(this.iptxt, "iptxt");
            this.iptxt.Name = "iptxt";
            // 
            // usertxt
            // 
            resources.ApplyResources(this.usertxt, "usertxt");
            this.usertxt.Name = "usertxt";
            // 
            // passwordtxt
            // 
            resources.ApplyResources(this.passwordtxt, "passwordtxt");
            this.passwordtxt.Name = "passwordtxt";
            // 
            // bztxt
            // 
            resources.ApplyResources(this.bztxt, "bztxt");
            this.bztxt.Name = "bztxt";
            // 
            // ip
            // 
            resources.ApplyResources(this.ip, "ip");
            this.ip.ForeColor = System.Drawing.SystemColors.MenuText;
            this.ip.Name = "ip";
            // 
            // user
            // 
            resources.ApplyResources(this.user, "user");
            this.user.Name = "user";
            // 
            // password
            // 
            resources.ApplyResources(this.password, "password");
            this.password.Name = "password";
            // 
            // bz
            // 
            resources.ApplyResources(this.bz, "bz");
            this.bz.Name = "bz";
            // 
            // save
            // 
            resources.ApplyResources(this.save, "save");
            this.save.Name = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.button1_Click);
            // 
            // erase
            // 
            resources.ApplyResources(this.erase, "erase");
            this.erase.Name = "erase";
            this.erase.UseVisualStyleBackColor = true;
            this.erase.Click += new System.EventHandler(this.button2_Click);
            // 
            // nametxt
            // 
            resources.ApplyResources(this.nametxt, "nametxt");
            this.nametxt.Name = "nametxt";
            // 
            // name
            // 
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            // 
            // host
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.name);
            this.Controls.Add(this.nametxt);
            this.Controls.Add(this.erase);
            this.Controls.Add(this.save);
            this.Controls.Add(this.bz);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.bztxt);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.usertxt);
            this.Controls.Add(this.iptxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "host";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.host_FormClosed);
            this.Load += new System.EventHandler(this.host_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label iptxt;
        private System.Windows.Forms.Label usertxt;
        private System.Windows.Forms.Label passwordtxt;
        private System.Windows.Forms.Label bztxt;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox bz;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button erase;
        private System.Windows.Forms.Label nametxt;
        private System.Windows.Forms.TextBox name;
    }
}