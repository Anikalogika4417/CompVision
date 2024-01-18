using System.Windows.Forms;

namespace CompVision
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
            this.buttonDownload = new System.Windows.Forms.Button();
            this.pictureBox_download = new System.Windows.Forms.PictureBox();
            this.textBox_download = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonModify = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_download)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(711, 432);
            this.buttonDownload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(88, 23);
            this.buttonDownload.TabIndex = 0;
            this.buttonDownload.Text = "Select";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // pictureBox_download
            // 
            this.pictureBox_download.Location = new System.Drawing.Point(6, 49);
            this.pictureBox_download.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox_download.Name = "pictureBox_download";
            this.pictureBox_download.Size = new System.Drawing.Size(793, 379);
            this.pictureBox_download.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_download.TabIndex = 1;
            this.pictureBox_download.TabStop = false;
            // 
            // textBox_download
            // 
            this.textBox_download.Location = new System.Drawing.Point(104, 21);
            this.textBox_download.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_download.Name = "textBox_download";
            this.textBox_download.Size = new System.Drawing.Size(180, 20);
            this.textBox_download.TabIndex = 2;
            this.textBox_download.Text = "Please, choose the photo";
            this.textBox_download.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_download.TextChanged += new System.EventHandler(this.textBox_download_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog_download";
            this.openFileDialog1.Title = "Browse...";
            // 
            // buttonModify
            // 
            this.buttonModify.Enabled = false;
            this.buttonModify.Location = new System.Drawing.Point(635, 432);
            this.buttonModify.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(66, 23);
            this.buttonModify.TabIndex = 3;
            this.buttonModify.Text = "Modify";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(6, 5);
            this.result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(45, 13);
            this.result.TabIndex = 4;
            this.result.Text = "Results:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 466);
            this.Controls.Add(this.result);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.textBox_download);
            this.Controls.Add(this.pictureBox_download);
            this.Controls.Add(this.buttonDownload);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_download)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.PictureBox pictureBox_download;
        private System.Windows.Forms.TextBox textBox_download;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Button buttonModify;
        private Label result;
    }
}

