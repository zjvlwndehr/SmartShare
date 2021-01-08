namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Open_Directory = new System.Windows.Forms.Button();
            this.CurrentSessionLabel = new System.Windows.Forms.Label();
            this.DragDropPictureBox = new System.Windows.Forms.PictureBox();
            this.FTP_Upload = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Uploaded_status_label = new System.Windows.Forms.Label();
            this.Maintain_LogOn_checkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DragDropPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Open_Directory
            // 
            this.Open_Directory.Location = new System.Drawing.Point(659, 364);
            this.Open_Directory.Name = "Open_Directory";
            this.Open_Directory.Size = new System.Drawing.Size(129, 74);
            this.Open_Directory.TabIndex = 0;
            this.Open_Directory.Text = "Open_Directory";
            this.Open_Directory.UseVisualStyleBackColor = true;
            this.Open_Directory.Click += new System.EventHandler(this.Open_Directory_Click);
            // 
            // CurrentSessionLabel
            // 
            this.CurrentSessionLabel.AutoSize = true;
            this.CurrentSessionLabel.Location = new System.Drawing.Point(13, 13);
            this.CurrentSessionLabel.Name = "CurrentSessionLabel";
            this.CurrentSessionLabel.Size = new System.Drawing.Size(87, 15);
            this.CurrentSessionLabel.TabIndex = 1;
            this.CurrentSessionLabel.Text = "current drive:\\";
            // 
            // DragDropPictureBox
            // 
            this.DragDropPictureBox.BackColor = System.Drawing.Color.White;
            this.DragDropPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DragDropPictureBox.Location = new System.Drawing.Point(12, 52);
            this.DragDropPictureBox.Name = "DragDropPictureBox";
            this.DragDropPictureBox.Size = new System.Drawing.Size(599, 318);
            this.DragDropPictureBox.TabIndex = 2;
            this.DragDropPictureBox.TabStop = false;
            this.DragDropPictureBox.Click += new System.EventHandler(this.DragDropPictureBox_Click);
            this.DragDropPictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop);
            this.DragDropPictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // FTP_Upload
            // 
            this.FTP_Upload.Location = new System.Drawing.Point(659, 277);
            this.FTP_Upload.Name = "FTP_Upload";
            this.FTP_Upload.Size = new System.Drawing.Size(128, 69);
            this.FTP_Upload.TabIndex = 3;
            this.FTP_Upload.Text = "FTP_Upload";
            this.FTP_Upload.UseVisualStyleBackColor = true;
            this.FTP_Upload.Click += new System.EventHandler(this.FTP_Upload_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(617, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 23);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(646, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(142, 23);
            this.textBox2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(571, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Id";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(646, 63);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '•';
            this.textBox3.Size = new System.Drawing.Size(142, 23);
            this.textBox3.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(617, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "pw";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 376);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(598, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // Uploaded_status_label
            // 
            this.Uploaded_status_label.AutoSize = true;
            this.Uploaded_status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Uploaded_status_label.Location = new System.Drawing.Point(270, 412);
            this.Uploaded_status_label.Name = "Uploaded_status_label";
            this.Uploaded_status_label.Size = new System.Drawing.Size(79, 18);
            this.Uploaded_status_label.TabIndex = 7;
            this.Uploaded_status_label.Text = "Uploaded";
            // 
            // Maintain_LogOn_checkBox
            // 
            this.Maintain_LogOn_checkBox.AutoSize = true;
            this.Maintain_LogOn_checkBox.Location = new System.Drawing.Point(646, 92);
            this.Maintain_LogOn_checkBox.Name = "Maintain_LogOn_checkBox";
            this.Maintain_LogOn_checkBox.Size = new System.Drawing.Size(84, 19);
            this.Maintain_LogOn_checkBox.TabIndex = 8;
            this.Maintain_LogOn_checkBox.Text = "checkBox1";
            this.Maintain_LogOn_checkBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Maintain_LogOn_checkBox);
            this.Controls.Add(this.Uploaded_status_label);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.FTP_Upload);
            this.Controls.Add(this.DragDropPictureBox);
            this.Controls.Add(this.CurrentSessionLabel);
            this.Controls.Add(this.Open_Directory);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DragDropPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Open_Directory;
        private System.Windows.Forms.Label CurrentSessionLabel;
        private System.Windows.Forms.PictureBox DragDropPictureBox;
        private System.Windows.Forms.Button FTP_Upload;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label Uploaded_status_label;
        private System.Windows.Forms.CheckBox Maintain_LogOn_checkBox;
    }
}

