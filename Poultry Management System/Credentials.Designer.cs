namespace Poultry_Management_System
{
    partial class Credentials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Credentials));
            this.panel2 = new System.Windows.Forms.Panel();
            this.Exitbtn = new Guna.UI2.WinForms.Guna2Button();
            this.Deletebtn = new Guna.UI2.WinForms.Guna2Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.PASSWORDBOX = new Guna.UI2.WinForms.Guna2TextBox();
            this.USERNAMEBOX = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.Exitbtn);
            this.panel2.Controls.Add(this.Deletebtn);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.PASSWORDBOX);
            this.panel2.Controls.Add(this.USERNAMEBOX);
            this.panel2.Location = new System.Drawing.Point(442, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 280);
            this.panel2.TabIndex = 21;
            // 
            // Exitbtn
            // 
            this.Exitbtn.BorderColor = System.Drawing.Color.Blue;
            this.Exitbtn.BorderRadius = 20;
            this.Exitbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Exitbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Exitbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Exitbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Exitbtn.FillColor = System.Drawing.Color.Red;
            this.Exitbtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exitbtn.ForeColor = System.Drawing.Color.White;
            this.Exitbtn.Location = new System.Drawing.Point(52, 223);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(283, 45);
            this.Exitbtn.TabIndex = 62;
            this.Exitbtn.Text = "Exit";
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.BorderColor = System.Drawing.Color.Blue;
            this.Deletebtn.BorderRadius = 20;
            this.Deletebtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Deletebtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Deletebtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Deletebtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Deletebtn.FillColor = System.Drawing.Color.Blue;
            this.Deletebtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deletebtn.ForeColor = System.Drawing.Color.White;
            this.Deletebtn.Location = new System.Drawing.Point(52, 172);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(283, 45);
            this.Deletebtn.TabIndex = 61;
            this.Deletebtn.Text = "Delete";
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(52, 119);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 23);
            this.checkBox1.TabIndex = 60;
            this.checkBox1.Text = "Show Password";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // PASSWORDBOX
            // 
            this.PASSWORDBOX.Animated = true;
            this.PASSWORDBOX.AutoRoundedCorners = true;
            this.PASSWORDBOX.BorderRadius = 17;
            this.PASSWORDBOX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PASSWORDBOX.DefaultText = "";
            this.PASSWORDBOX.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PASSWORDBOX.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PASSWORDBOX.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PASSWORDBOX.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PASSWORDBOX.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PASSWORDBOX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.PASSWORDBOX.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PASSWORDBOX.IconLeft = ((System.Drawing.Image)(resources.GetObject("PASSWORDBOX.IconLeft")));
            this.PASSWORDBOX.IconLeftSize = new System.Drawing.Size(25, 25);
            this.PASSWORDBOX.IconRightSize = new System.Drawing.Size(50, 20);
            this.PASSWORDBOX.Location = new System.Drawing.Point(52, 72);
            this.PASSWORDBOX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PASSWORDBOX.Name = "PASSWORDBOX";
            this.PASSWORDBOX.PasswordChar = '●';
            this.PASSWORDBOX.PlaceholderText = "Enter Password";
            this.PASSWORDBOX.SelectedText = "";
            this.PASSWORDBOX.Size = new System.Drawing.Size(283, 36);
            this.PASSWORDBOX.TabIndex = 59;
            // 
            // USERNAMEBOX
            // 
            this.USERNAMEBOX.Animated = true;
            this.USERNAMEBOX.AutoRoundedCorners = true;
            this.USERNAMEBOX.BorderRadius = 17;
            this.USERNAMEBOX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.USERNAMEBOX.DefaultText = "";
            this.USERNAMEBOX.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.USERNAMEBOX.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.USERNAMEBOX.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.USERNAMEBOX.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.USERNAMEBOX.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.USERNAMEBOX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.USERNAMEBOX.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.USERNAMEBOX.IconLeft = ((System.Drawing.Image)(resources.GetObject("USERNAMEBOX.IconLeft")));
            this.USERNAMEBOX.IconLeftSize = new System.Drawing.Size(25, 25);
            this.USERNAMEBOX.IconRightSize = new System.Drawing.Size(30, 30);
            this.USERNAMEBOX.Location = new System.Drawing.Point(52, 17);
            this.USERNAMEBOX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.USERNAMEBOX.Name = "USERNAMEBOX";
            this.USERNAMEBOX.PasswordChar = '\0';
            this.USERNAMEBOX.PlaceholderText = "Enter Username";
            this.USERNAMEBOX.SelectedText = "";
            this.USERNAMEBOX.Size = new System.Drawing.Size(283, 36);
            this.USERNAMEBOX.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(444, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 34);
            this.label1.TabIndex = 56;
            this.label1.Text = "Add Credentials to Confirm";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(424, 336);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 57;
            this.guna2PictureBox1.TabStop = false;
            // 
            // Credentials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(811, 360);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Credentials";
            this.Text = "Credentials";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private Guna.UI2.WinForms.Guna2TextBox PASSWORDBOX;
        private Guna.UI2.WinForms.Guna2TextBox USERNAMEBOX;
        private Guna.UI2.WinForms.Guna2Button Exitbtn;
        private Guna.UI2.WinForms.Guna2Button Deletebtn;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}