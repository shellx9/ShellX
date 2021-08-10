
namespace rdp
{
    partial class ini_list_update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ini_list_update));
            this.save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label_px = new System.Windows.Forms.Label();
            this.textBox_px = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // save
            // 
            resources.ApplyResources(this.save, "save");
            this.save.Name = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_px
            // 
            resources.ApplyResources(this.label_px, "label_px");
            this.label_px.Name = "label_px";
            // 
            // textBox_px
            // 
            resources.ApplyResources(this.textBox_px, "textBox_px");
            this.textBox_px.Name = "textBox_px";
            // 
            // ini_list_update
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_px);
            this.Controls.Add(this.label_px);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ini_list_update";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ini_list_update_FormClosed);
            this.Load += new System.EventHandler(this.ini_list_update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_px;
        private System.Windows.Forms.TextBox textBox_px;
    }
}