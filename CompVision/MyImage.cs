using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using System.Windows.Forms;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace CompVision
{
    internal class MyImage
    {
        Mat img_color;
        Mat img_smooth;
        Mat img_grey;
        Mat img_bin;
        Mat img_bin_simple;
        VectorOfVectorOfPoint conturs;
        List<CvObject> images;

        bool corr_creation = false;
        public bool Corr_creation { 
            get => corr_creation; 
            private set => corr_creation = value;  
        }

        public Mat Img_color
        {
            get => img_color;
            private set => img_color = value;
        }

        public Mat Img_smooth
        {
            get => img_smooth;
            private set => img_smooth = value;
        }
        public Mat Img_grey
        {
            get => img_grey;
            private set => img_grey = value;
        }
        public Mat Img_bin
        {
            get => img_bin;
            private set => img_bin = value;
        }
        public List<CvObject> Images
        {
            get => images;
            private set => images = value;
        }
        public MyImage(Image<Bgr, byte> start_img) 

        {
            try
            {
                Img_color = start_img.Mat;
            }
            catch
            {
                MessageBox.Show("Mistake in reading the photo");
                return;
            }
        }

        public void Smooth()
        {
            img_smooth = new Mat();
            int kernelSize = 15;  // Adjust the kernel size as needed
            CvInvoke.GaussianBlur(img_color, img_smooth, new Size(kernelSize, kernelSize), 0);
            //CvInvoke.MedianBlur(img_color, img_smooth,kernelSize);
            //CvInvoke.Blur(img_color, img_smooth, new Size(kernelSize, kernelSize), 0);
        }

        public void MakeGray()
        {
            img_grey = new Mat();
            CvInvoke.CvtColor(img_smooth, img_grey, ColorConversion.Bgr2Gray);
        }


        public void CutPart()
        {
            img_bin_simple = new Mat();
            img_bin = new Mat();
            double my_threshold = 128;
            //CvInvoke.Threshold(img_grey, img_bin, my_threshold, 255, ThresholdType.Binary);

            /*Canny*/
            //CvInvoke.Threshold(img_grey, img_bin_simple, my_threshold, 255, ThresholdType.Binary);
            CvInvoke.Canny(img_grey, img_bin, 128, 255);

            /*Sobel*/
            /*
            Mat sobelX = new Mat();
            Mat sobelY = new Mat();
            CvInvoke.Sobel(img_grey, sobelX, DepthType.Cv8U, 1, 0);
            CvInvoke.Sobel(img_grey, sobelY, DepthType.Cv8U, 0, 1);
            CvInvoke.AddWeighted(sobelX, 0.5, sobelY, 0.5, 0, img_bin);
            CvInvoke.Threshold(img_bin, img_bin, my_threshold, 255, ThresholdType.Binary);
            */
        }

        public void PrintContur()
        {
            if(conturs != null)
            {
                //Image<Bgr, byte> i_img_color = img_color.ToImage<Bgr, byte>();
                CvInvoke.DrawContours(img_color, conturs, -1, new MCvScalar(0, 0, 255), 3); // Draw all contours in green
                //img_color = i_img_color.Mat;
            }
            else
            {
                MessageBox.Show("I didn't saw any objects");
                return;
            }
        }

        public void Contur()
        {
            Image<Bgr, byte> i_img_color = img_color.ToImage<Bgr, byte>();

            conturs = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(img_bin, conturs, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            WaitCallback callback = new WaitCallback(CvObjectWork);
            for (int i = 0; i < conturs.Size; i++)
            {
                ThreadPool.QueueUserWorkItem(callback, conturs[i]);
            }
                            img_color = i_img_color.Mat;

        }

        void CvObjectWork(Object obj) 
        {
            images = new List<CvObject>();
            CvObject item = new CvObject(obj as VectorOfPoint);
            lock  (this)
            {
                Images.Add(item);
            }
        }
    }
}
