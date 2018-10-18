namespace SanityArchiver
{
    partial class Form1
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
            this.driveList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Compress = new System.Windows.Forms.Button();
            this.crypt = new System.Windows.Forms.Button();
            this.DeCompress = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // driveList
            // 
            this.driveList.FormattingEnabled = true;
            this.driveList.Location = new System.Drawing.Point(12, 55);
            this.driveList.Name = "driveList";
            this.driveList.Size = new System.Drawing.Size(138, 56);
            this.driveList.TabIndex = 3;
            this.driveList.SelectedIndexChanged += new System.EventHandler(this.driveList_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Size1,
            this.Date1});
            this.listView1.Location = new System.Drawing.Point(156, 55);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(620, 264);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 289;
            // 
            // Size1
            // 
            this.Size1.Text = "Size";
            this.Size1.Width = 118;
            // 
            // Date1
            // 
            this.Date1.Text = "Date";
            this.Date1.Width = 207;
            // 
            // Compress
            // 
            this.Compress.Location = new System.Drawing.Point(40, 137);
            this.Compress.Name = "Compress";
            this.Compress.Size = new System.Drawing.Size(75, 23);
            this.Compress.TabIndex = 8;
            this.Compress.Text = "Compress";
            this.Compress.UseVisualStyleBackColor = true;
            this.Compress.Click += new System.EventHandler(this.Compress_Click_1);
            // 
            // crypt
            // 
            this.crypt.Location = new System.Drawing.Point(40, 194);
            this.crypt.Name = "crypt";
            this.crypt.Size = new System.Drawing.Size(75, 23);
            this.crypt.TabIndex = 9;
            this.crypt.Text = "Crypt";
            this.crypt.UseVisualStyleBackColor = true;
            this.crypt.Click += new System.EventHandler(this.crypt_Click);
            // 
            // DeCompress
            // 
            this.DeCompress.Location = new System.Drawing.Point(40, 166);
            this.DeCompress.Name = "DeCompress";
            this.DeCompress.Size = new System.Drawing.Size(75, 23);
            this.DeCompress.TabIndex = 10;
            this.DeCompress.Text = "DeCompress";
            this.DeCompress.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(40, 223);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 11;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 332);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.DeCompress);
            this.Controls.Add(this.crypt);
            this.Controls.Add(this.Compress);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.driveList);
            this.Text = "SanityArchiver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox driveList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Size1;
        private System.Windows.Forms.ColumnHeader Date1;
        private System.Windows.Forms.Button Compress;
        private System.Windows.Forms.Button crypt;
        private System.Windows.Forms.Button DeCompress;
        private System.Windows.Forms.Button Delete;
    }
}

