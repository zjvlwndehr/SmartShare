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
            this.choose_drive = new System.Windows.Forms.Button();
            this.labelCurrentDrive = new System.Windows.Forms.Label();
            this.DragDropPictureBox = new System.Windows.Forms.PictureBox();
            this.FTP_Upload = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DragDropPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // choose_drive
            // 
            this.choose_drive.Location = new System.Drawing.Point(659, 364);
            this.choose_drive.Name = "choose_drive";
            this.choose_drive.Size = new System.Drawing.Size(129, 74);
            this.choose_drive.TabIndex = 0;
            this.choose_drive.Text = "choose_drive";
            this.choose_drive.UseVisualStyleBackColor = true;
            this.choose_drive.Click += new System.EventHandler(this.choose_drive_Click);
            // 
            // labelCurrentDrive
            // 
            this.labelCurrentDrive.AutoSize = true;
            this.labelCurrentDrive.Location = new System.Drawing.Point(13, 13);
            this.labelCurrentDrive.Name = "labelCurrentDrive";
            this.labelCurrentDrive.Size = new System.Drawing.Size(87, 15);
            this.labelCurrentDrive.TabIndex = 1;
            this.labelCurrentDrive.Text = "current drive:\\";
            // 
            // DragDropPictureBox
            // 
            this.DragDropPictureBox.BackColor = System.Drawing.Color.White;
            this.DragDropPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DragDropPictureBox.Location = new System.Drawing.Point(12, 31);
            this.DragDropPictureBox.Name = "DragDropPictureBox";
            this.DragDropPictureBox.Size = new System.Drawing.Size(641, 407);
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
            this.textBox1.Location = new System.Drawing.Point(688, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(688, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(659, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(659, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "pw";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.FTP_Upload);
            this.Controls.Add(this.DragDropPictureBox);
            this.Controls.Add(this.labelCurrentDrive);
            this.Controls.Add(this.choose_drive);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DragDropPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button choose_drive;
        private System.Windows.Forms.Label labelCurrentDrive;
        private System.Windows.Forms.PictureBox DragDropPictureBox;
        private System.Windows.Forms.Button FTP_Upload;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

