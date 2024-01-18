using Emgu.CV;
using Emgu.CV.IntensityTransform;
using Emgu.CV.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompVision
{
    internal class CvObject
    {
        VectorOfPoint Contur_points { get; set; }
        VectorOfPoint Object_points { get; set; }
        Point GravityCenter { get; set; }

        public CvObject(VectorOfPoint contur) 
        {
            Contur_points = contur;
            Object_points = SearchObject(Contur_points);
            SearchCenter(Object_points);
        }

        VectorOfPoint SearchObject(VectorOfPoint contur_points) 
        {
            VectorOfPoint res = new VectorOfPoint();
            List<Point> res_arr = new List<Point>();

            Rectangle bound_rect = CvInvoke.BoundingRectangle(contur_points);
            for(int x = bound_rect.Left; x < bound_rect.Right; x++)
            {
                for (int y = bound_rect.Top; y < bound_rect.Bottom; y++)
                {
                    if(CvInvoke.PointPolygonTest(contur_points, new Point(x,y), true) >= 0)
                    {
                        res_arr.Add(new Point(x, y));
                    }
                }
            }
            res.Push(res_arr.ToArray());
            return res;
        }

        void SearchCenter(VectorOfPoint my_object)
        {
            int sum_x = 0; 
            int sum_y = 0;
            for(int i = 0; i < my_object.Size; i++)
            {
                sum_x += my_object[i].X;
                sum_y += my_object[i].Y;
            }
            GravityCenter = new Point(sum_x/ my_object.Size, sum_y/my_object.Size);
        }
    }
}
