using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompVision
{

    public enum Steps
    {
        MODIFY,
        STEP1,
        STEP2,
        STEP3,

    }

    public partial class Form1 : Form
    {
        MyImage image_downloaded;
        Hashtable stepMappings = new Hashtable
        {
            { Steps.MODIFY, "Modify" },
            { Steps.STEP1, "Step 1" },
            { Steps.STEP2, "Step 2" },
            { Steps.STEP3, "Step 3" },

        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonModify.Visible = true;
        }

        private void textBox_download_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            // Open file dialog to select an image file
            using (OpenFileDialog openFileDialog_download = new OpenFileDialog())
            {
                openFileDialog_download.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif|All Files|*.*";
                openFileDialog_download.Title = "Select an Image File";

                if (openFileDialog_download.ShowDialog() == DialogResult.OK)
                {
                    image_downloaded = new MyImage(new Image<Bgr,byte>(openFileDialog_download.FileName));
                    pictureBox_download.Image = new Image<Bgr, byte>(openFileDialog_download.FileName).ToBitmap();

                    //pictureBox_download.ImageLocation = openFileDialog_download.FileName;
                    buttonModify.Visible = true;
                    buttonModify.Enabled = true;
                    buttonModify.Text = "Modify";
                }
            }
        }
        private void buttonModify_Click(object sender, EventArgs e)
        {
            if(image_downloaded != null) 
            {

            } else
            {
                MessageBox.Show("Please load an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (buttonModify.Text)
            {
                case "Modify":
                    image_downloaded.MakeGray();
                    buttonDownload.Enabled = false;
                    Bitmap image_g = image_downloaded.Img_grey.ToImage<Bgr,byte>().ToBitmap();
                    pictureBox_download.Image = image_g;
                    buttonModify.Text = "Step 1";
                    break;
                case "Step 1":
                    image_downloaded.CutPart();
                    Bitmap image_b = image_downloaded.Img_bin.ToImage<Bgr, byte>().ToBitmap();
                    pictureBox_download.Image = image_b;
                    buttonModify.Text = "Step 2";
                    break;
                case "Step 2":
                    image_downloaded.Contur();
                    image_downloaded.PrintContur();
                    Bitmap image_finish = image_downloaded.Img_grey.ToImage<Bgr, byte>().ToBitmap();
                    pictureBox_download.Image = image_finish;
                    buttonModify.Visible = false;
                    buttonDownload.Enabled = true;
                    break;
            }
        }
    }
}
