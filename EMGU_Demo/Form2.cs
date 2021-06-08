using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace EMGU_Demo
{
    public partial class Form2 : Form
    {

        Image<Bgr, byte> imgMain;
        Image<Gray, byte> imgGray;

        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imgGray = imgMain.Convert<Gray, byte>();

            pictureBox1.Image = imgGray.Bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = "C:\\Users\\jehan\\source\\repos\\EMGU_Demo\\EMGU_Demo\\karsten.png";
            imgMain = new Image<Bgr, byte>(fname);
            if(imgMain == null)
            {
                MessageBox.Show("Failed to load an image");
                return;
            }
            imageBox1.Image = imgMain;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DenseHistogram histogram1 = new DenseHistogram(256, new RangeF(0, 255));
            histogram1.Calculate(new Image<Gray, Byte>[] { imgMain[0] }, false, null);
            Mat m = new Mat();
            histogram1.CopyTo(m);
            histogramBox1.AddHistogram("Blue Channel histogram", Color.Blue, m, 256, new float[] { 0, 256 });
            histogramBox1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DenseHistogram histogram1 = new DenseHistogram(256, new RangeF(0, 255));
            histogram1.Calculate(new Image<Gray, Byte>[] { imgGray }, false, null);
            Mat m = new Mat();
            histogram1.CopyTo(m);
            histogramBox2.AddHistogram("Gray Scale histogram", Color.Blue, m, 256, new float[] { 0, 256 });
            histogramBox2.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
