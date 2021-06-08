using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMGU_Demo
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        OpenFileDialog openFile = new OpenFileDialog();
        DetectCirlces dc = new DetectCirlces();
        private void button2_Click(object sender, EventArgs e)
        {
            openFile.Title = "Select Image File";
            openFile.Filter = "Image (*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|" + "All File(*.*)|*.*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName.ToString();
                dc.LoadOriginal(path);
                pictureBox1.ImageLocation = path;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "JPEG files(*.jpeg)|*.jpeg"; // Saving file in jpeg Format
            if (DialogResult.OK == saveFile.ShowDialog())
            {
                this.pictureBox2.Image.Save(saveFile.FileName, ImageFormat.Jpeg);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dc.Filter();
            pictureBox2.ImageLocation = "detected.jpg";
        }
    }
}
