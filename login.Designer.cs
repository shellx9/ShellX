
namespace rdp
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.label1 = new System.Windows.Forms.Label();
            this.text_password = new System.Windows.Forms.TextBox();
            this.Sign_in = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.about = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.git = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // text_password
            // 
            resources.ApplyResources(this.text_password, "text_password");
            this.text_password.Name = "text_password";
            this.text_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_password_KeyPress);
            // 
            // Sign_in
            // 
            resources.ApplyResources(this.Sign_in, "Sign_in");
            this.Sign_in.Name = "Sign_in";
            this.Sign_in.UseVisualStyleBackColor = true;
            this.Sign_in.Click += new System.EventHandler(this.Sign_in_Click);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // about
            // 
            resources.ApplyResources(this.about, "about");
            this.about.Name = "about";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // git
            // 
            resources.ApplyResources(this.git, "git");
            this.git.Name = "git";
            this.git.TabStop = true;
            this.git.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.git_LinkClicked);
            // 
            // login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.git);
            this.Controls.Add(this.about);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Sign_in);
            this.Controls.Add(this.text_password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_password;
        private System.Windows.Forms.Button Sign_in;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label about;
        private System.Windows.Forms.LinkLabel git;
    }
}