using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using OpenCvSharp;

namespace EMGU_Demo
{
    class DetectCirlces
    {
        IplImage src, grayImage, houghImage;


        public void LoadOriginal(String fname)
        {
            src = Cv.LoadImage(fname, LoadMode.Color);
            Cv.SaveImage("load.jpg", src);

        }


        public void cvtGray()
        {
            grayImage = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, grayImage, ColorConversion.RgbToGray);
            Cv.SaveImage("gray.jpg", grayImage);
        }

        public void Filter()
        {
            cvtGray();
            Cv.Smooth(grayImage, grayImage, SmoothType.Gaussian, 9);
            Cv.Canny(grayImage, grayImage, 10, 30, ApertureSize.Size3);
            Cv.SaveImage("edges.jpg", grayImage);
            houghImage = src.Clone();
            var stor = new CvMemStorage();
            CvSeq<CvCircleSegment> seq = grayImage.HoughCircles(stor, HoughCirclesMethod.Gradient, 1, 50, 10, 25, 0, 40);

            foreach (CvCircleSegment item in seq)
            {
                houghImage.Circle(item.Center, (int)item.Radius, CvColor.Magenta, 2, LineType.Link4);

            }

            Cv.SaveImage("detected.jpg", houghImage);
        }
    }
}