
namespace rdp
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.explanation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Website = new System.Windows.Forms.Label();
            this.Website_data = new System.Windows.Forms.LinkLabel();
            this.dev_qq = new System.Windows.Forms.Label();
            this.qq_qun = new System.Windows.Forms.Label();
            this.Telegram = new System.Windows.Forms.Label();
            this.Telegram_pd = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Telegram_pd_data = new System.Windows.Forms.Label();
            this.dev_qq_data = new System.Windows.Forms.LinkLabel();
            this.qq_qun_data = new System.Windows.Forms.LinkLabel();
            this.github = new System.Windows.Forms.Label();
            this.github_data = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // explanation
            // 
            resources.ApplyResources(this.explanation, "explanation");
            this.explanation.Name = "explanation";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Website
            // 
            resources.ApplyResources(this.Website, "Website");
            this.Website.Name = "Website";
            // 
            // Website_data
            // 
            resources.ApplyResources(this.Website_data, "Website_data");
            this.Website_data.Name = "Website_data";
            this.Website_data.TabStop = true;
            this.Website_data.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // dev_qq
            // 
            resources.ApplyResources(this.dev_qq, "dev_qq");
            this.dev_qq.Name = "dev_qq";
            // 
            // qq_qun
            // 
            resources.ApplyResources(this.qq_qun, "qq_qun");
            this.qq_qun.Name = "qq_qun";
            // 
            // Telegram
            // 
            resources.ApplyResources(this.Telegram, "Telegram");
            this.Telegram.Name = "Telegram";
            // 
            // Telegram_pd
            // 
            resources.ApplyResources(this.Telegram_pd, "Telegram_pd");
            this.Telegram_pd.Name = "Telegram_pd";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Telegram_pd_data
            // 
            resources.ApplyResources(this.Telegram_pd_data, "Telegram_pd_data");
            this.Telegram_pd_data.Name = "Telegram_pd_data";
            // 
            // dev_qq_data
            // 
            resources.ApplyResources(this.dev_qq_data, "dev_qq_data");
            this.dev_qq_data.Name = "dev_qq_data";
            this.dev_qq_data.TabStop = true;
            this.dev_qq_data.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // qq_qun_data
            // 
            resources.ApplyResources(this.qq_qun_data, "qq_qun_data");
            this.qq_qun_data.Name = "qq_qun_data";
            this.qq_qun_data.TabStop = true;
            this.qq_qun_data.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // github
            // 
            resources.ApplyResources(this.github, "github");
            this.github.Name = "github";
            // 
            // github_data
            // 
            resources.ApplyResources(this.github_data, "github_data");
            this.github_data.Name = "github_data";
            this.github_data.TabStop = true;
            this.github_data.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // About
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.github_data);
            this.Controls.Add(this.github);
            this.Controls.Add(this.qq_qun_data);
            this.Controls.Add(this.dev_qq_data);
            this.Controls.Add(this.Telegram_pd_data);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Telegram_pd);
            this.Controls.Add(this.Telegram);
            this.Controls.Add(this.qq_qun);
            this.Controls.Add(this.dev_qq);
            this.Controls.Add(this.Website_data);
            this.Controls.Add(this.Website);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.explanation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label explanation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Website;
        private System.Windows.Forms.LinkLabel Website_data;
        private System.Windows.Forms.Label dev_qq;
        private System.Windows.Forms.Label qq_qun;
        private System.Windows.Forms.Label Telegram;
        private System.Windows.Forms.Label Telegram_pd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Telegram_pd_data;
        private System.Windows.Forms.LinkLabel dev_qq_data;
        private System.Windows.Forms.LinkLabel qq_qun_data;
        private System.Windows.Forms.Label github;
        private System.Windows.Forms.LinkLabel github_data;
    }
}