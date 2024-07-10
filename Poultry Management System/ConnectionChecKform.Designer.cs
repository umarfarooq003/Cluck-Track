namespace Poultry_Management_System
{
    partial class ConnectionChecKform
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
            this.connectionbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // connectionbtn
            // 
            this.connectionbtn.Location = new System.Drawing.Point(272, 12);
            this.connectionbtn.Name = "connectionbtn";
            this.connectionbtn.Size = new System.Drawing.Size(133, 38);
            this.connectionbtn.TabIndex = 0;
            this.connectionbtn.Text = "Connection";
            this.connectionbtn.UseVisualStyleBackColor = true;
            this.connectionbtn.Click += new System.EventHandler(this.connectionbtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(108, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(520, 195);
            this.dataGridView1.TabIndex = 1;
            // 
            // ConnectionChecKform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.connectionbtn);
            this.Name = "ConnectionChecKform";
            this.Text = "ConnectionChecKform";
            this.Load += new System.EventHandler(this.ConnectionChecKform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button connectionbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}