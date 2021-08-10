using System.Drawing;


namespace rdp
{
    partial class Link
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Link));
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.LinkLabel1, "LinkLabel1");
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Link
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LinkLabel1);
            this.MaximizeBox = false;
            this.Name = "Link";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Link_Closing);
            this.Load += new System.EventHandler(this.Link_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.LinkLabel LinkLabel1;
        private System.Windows.Forms.Timer Timer1;
    }
}