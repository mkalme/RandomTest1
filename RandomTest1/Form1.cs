using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace RandomTest1
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics bitmapGraphics;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bitmapGraphics = Graphics.FromImage(bmp);
            bitmapGraphics.Clear(Color.White);

            Graphics g = CreateGraphics();
            Random rand = new Random();

            new Thread(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    bitmapGraphics.FillRectangle(new SolidBrush(Color.Black), rand.Next(bmp.Width), rand.Next(bmp.Height), 1, 1);

                    if (i % 2500 == 0)
                    {
                        pictureBox1.Image = bmp;
                        Thread.Sleep(50);
                    }
                }
            }).Start();

            pictureBox1.Image = bmp;
        }
    }
}
