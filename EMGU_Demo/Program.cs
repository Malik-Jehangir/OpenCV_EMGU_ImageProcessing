using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace EMGU_Demo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string fname = "C:\\Users\\jehan\\source\\repos\\EMGU_Demo\\EMGU_Demo\\karsten.png";
            //Image<Bgr, byte> img = new Image<Bgr, byte>(fname);
            //CvInvoke.Imshow("Image", img);
            //CvInvoke.WaitKey(0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
