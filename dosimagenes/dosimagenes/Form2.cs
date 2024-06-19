using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dosimagenes
{
    public partial class Form2 : Form
    {
        public int[,] matriz1;
        public int[,] matriz2;
        int l1, l2;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "archivos JPG|*.jpg|archivos bmp|*.bmp|archivos png|*.png";
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "archivos JPG|*.jpg|archivos bmp|*.bmp|archivos png|*.png";
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox2.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Color c = new Color();

            Bitmap bmp1 = (Bitmap)pictureBox1.Image;
            matriz1 = new int[1000000, 6];
            l1 = 1;
            for (int i = 0; i < bmp1.Width; i++)
            {
                for (int j = 0; j < bmp1.Height; j++)
                {
                    c = bmp1.GetPixel(i, j);
                    if (c.R < 245 && c.G < 245 && c.B < 245)
                    {
                        matriz1[l1, 0] = i;
                        matriz1[l1, 1] = j;
                        matriz1[l1, 2] = c.R;
                        matriz1[l1, 3] = c.G;
                        matriz1[l1, 4] = c.B;

                        l1++;
                    }

                }
            }
            matriz1[0, 0] = bmp1.Width;
            matriz1[0, 1] = bmp1.Height;
            matriz1[0, 2] = l1 - 1;
            matriz1[0, 3] = l1 - 1;
            matriz1[0, 4] = l1 - 1;
            int s, k, r, g, b;

            Console.WriteLine("fila columna red green blue");
            for (int i = 0; i < l1; i++)
            {
                s = matriz1[i, 0];
                k = matriz1[i, 1];
                r = matriz1[i, 2];
                g = matriz1[i, 3];
                b = matriz1[i, 4];
                Console.WriteLine("i " + s + " j " + k + " rgb = " + r + " " + g + " " + b);

            } 
            
          

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Color c = new Color();

            Bitmap bmp1 = (Bitmap)pictureBox1.Image;
            matriz1 = new int[1000000, 6];
            l1 = 1;
            for (int i = 0; i < bmp1.Width; i++)
            {
                for (int j = 0; j < bmp1.Height; j++)
                {
                    c = bmp1.GetPixel(i, j);
                    if (c.R < 245 && c.G < 245 && c.B < 245)
                    {
                        matriz1[l1, 0] = i;
                        matriz1[l1, 1] = j;
                        matriz1[l1, 2] = c.R;
                        matriz1[l1, 3] = c.G;
                        matriz1[l1, 4] = c.B;

                        l1++;
                    }

                }
            }
            matriz1[0, 0] = bmp1.Width;
            matriz1[0, 1] = bmp1.Height;
            matriz1[0, 2] = l1 - 1;
            matriz1[0, 3] = l1 - 1;
            matriz1[0, 4] = l1 - 1;

            Bitmap bmp2 = (Bitmap)pictureBox2.Image;
            matriz2 = new int[1000000, 6];
            l2 = 1;
            for (int i = 0; i < bmp2.Width; i++)
            {
                for (int j = 0; j < bmp2.Height; j++)
                {
                    c = bmp2.GetPixel(i, j);
                    if (c.R < 245 && c.G < 245 && c.B < 245)
                    {
                        matriz2[l2, 0] = i;
                        matriz2[l2, 1] = j;
                        matriz2[l2, 2] = c.R;
                        matriz2[l2, 3] = c.G;
                        matriz2[l2, 4] = c.B;

                        l2++;
                    }

                }
            }
            matriz2[0, 0] = bmp2.Width;
            matriz2[0, 1] = bmp2.Height;
            matriz2[0, 2] = l2 - 1;
            matriz2[0, 3] = l2 - 1;
            matriz2[0, 4] = l2 - 1;



            int s, k, r, g, b;
            int s2, k2, r2, g2, b2;
            int cc;


            Console.WriteLine("fila columna red green blue --- fila2 columna2 red2 green2 blue2");
            if (l1 > l2)
            {
                cc = l2;
            }
            else
            {
                cc = l1;
            } 
            for (int i = 0; i < cc; i++)
            {
                s = matriz1[i, 0];
                k = matriz1[i, 1];
                r = matriz1[i, 2];
                g = matriz1[i, 3];
                b = matriz1[i, 4];
                s2 = matriz2[i, 0];
                k2 = matriz2[i, 1];
                r2 = matriz2[i, 2];
                g2 = matriz2[i, 3];
                b2 = matriz2[i, 4];
                Console.WriteLine("i " + s + " j " + k + " rgb = " + r + " " + g + " " + b + "   ---- i2 " + s2 + " j2 " + k2 + " rgb = " + r2 + " " + g2 + " " + b2);

            } 
            

        }
    }
}
