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
            this.labelCurrentDrive.Size = new System.Drawing.Size(39, 15);
            this.labelCurrentDrive.TabIndex = 1;
            this.labelCurrentDrive.Text = "label1";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

