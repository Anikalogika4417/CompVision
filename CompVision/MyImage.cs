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

namespace CompVision
{
    internal class MyImage
    {
        Mat img_color;
        Mat img_grey;
        Mat img_bin;
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

        public void MakeGray()
        {
            img_grey = new Mat();
            CvInvoke.CvtColor(img_color, img_grey, ColorConversion.Bgr2Gray);
        }


        public void CutPart()
        {
            img_bin = new Mat();
            double my_threshold = 150;
            CvInvoke.Threshold(img_grey, img_bin, my_threshold, 255, ThresholdType.Binary);
        }

        public void PrintContur()
        {
            if(conturs != null)
            {
                Image<Bgr, byte> i_img_color = img_color.ToImage<Bgr, byte>();
                for (int i = 0; i < conturs.Size; i++)
                {
                Point[] contursArr = conturs[i].ToArray(); 
                    foreach (Point p in contursArr)
                    {
                        i_img_color[p.X, p.Y] = new Bgr(0, 0, 255);
                    }
                }
                img_color = i_img_color.Mat;
            }
            else
            {
                MessageBox.Show("I didn't saw any objects");
                return;
            }
        }

        public void Contur()
        {
            conturs = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(img_bin, conturs, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);
            WaitCallback callback = new WaitCallback(CvObjectWork);
            for(int i = 0; i < conturs.Size; i++)
            {
                ThreadPool.QueueUserWorkItem(callback, conturs[i]);
            }
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
