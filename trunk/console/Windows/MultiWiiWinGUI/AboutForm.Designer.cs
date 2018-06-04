namespace MultiWiiSimpleGUI
{
    partial class frmAbout
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
            this.button1 = new System.Windows.Forms.Button();
            this.l_version = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.l_mwver = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // l_version
            // 
            this.l_version.BackColor = System.Drawing.Color.Transparent;
            this.l_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_version.ForeColor = System.Drawing.Color.Black;
            this.l_version.Location = new System.Drawing.Point(139, 9);
            this.l_version.Name = "l_version";
            this.l_version.Size = new System.Drawing.Size(132, 18);
            this.l_version.TabIndex = 1;
            this.l_version.Text = "Version 1.0 Beta";
            this.l_version.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(2, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "by KKUSA Based on WinGUI by EOSBandi";
            // 
            // l_mwver
            // 
            this.l_mwver.BackColor = System.Drawing.Color.Transparent;
            this.l_mwver.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_mwver.ForeColor = System.Drawing.Color.Maroon;
            this.l_mwver.Location = new System.Drawing.Point(73, 42);
            this.l_mwver.Name = "l_mwver";
            this.l_mwver.Size = new System.Drawing.Size(202, 26);
            this.l_mwver.TabIndex = 6;
            this.l_mwver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 111);
            this.ControlBox = false;
            this.Controls.Add(this.l_mwver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.l_version);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label l_version;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label l_mwver;
    }
}