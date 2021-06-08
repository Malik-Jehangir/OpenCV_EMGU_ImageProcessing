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
    public partial class Form3 : Form
    {
        Image<Bgr, byte> imgMain;
        Image<Gray, byte> imgR;
        Image<Gray, byte> imgG;
        Image<Gray, byte> imgB;



        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = "C:\\Users\\jehan\\source\\repos\\EMGU_Demo\\EMGU_Demo\\karsten.png";
            imgMain = new Image<Bgr, byte>(fname);
            imgR = imgMain[0];
            imgG = imgMain[1];
            imgB = imgMain[2];

            imageBox1.Image = imgR;
            imageBox2.Image = imgG;
            imageBox3.Image = imgB;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (imgMain == null)
            {
                MessageBox.Show("Please select an Image");
                return;
            }

            histogramBox1.ClearHistogram();
            histogramBox2.ClearHistogram();
            histogramBox3.ClearHistogram();

            histogramBox1.GenerateHistograms(imgR, 256);
            histogramBox2.GenerateHistograms(imgG, 256);
            histogramBox3.GenerateHistograms(imgB, 256);


            histogramBox1.Refresh();
            histogramBox2.Refresh();
            histogramBox3.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    }
}
