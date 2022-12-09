using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Bitmap image;
        public static UInt32[,] pixel;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(open_dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Invalidate();
                pictureBox3.Image = image;
                pixel = new UInt32[image.Height, image.Width];
                for (int y = 0; y < image.Height; y++)
                    for (int x = 0; x < image.Width; x++)
                        pixel[y, x] = (UInt32)(image.GetPixel(x, y).ToArgb());
                pictureBox2.Image = null;
                saveToolStripMenuItem.Enabled = brightnessUpToolStripMenuItem.Enabled =
                    colourToolStripMenuItem.Enabled = blurToolStripMenuItem.Enabled =
                    anotherBlurToolStripMenuItem.Enabled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(save_dialog.FileName);

            }
        }
        struct RGB
        {
            public float R;
            public float G;
            public float B;
        }
        public UInt32 Brightness(UInt32 point)
        {
            int R;
            int G;
            int B;

            int N = 40;

            R = (int)(((point & 0x00FF0000) >> 16) + N * 128 / 100);
            G = (int)(((point & 0x0000FF00) >> 8) + N * 128 / 100);
            B = (int)((point & 0x000000FF) + N * 128 / 100);

            if (R < 0) R = 0;
            if (R > 255) R = 255;
            if (G < 0) G = 0;
            if (G > 255) G = 255;
            if (B < 0) B = 0;
            if (B > 255) B = 255;

            point = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);

            return point;
        }
        public static UInt32 Colour(UInt32 point)
        {
            int R = (int)(((point & 0x00FF0000) >> 16) + 14 * 128 / 100);
            int G = (int)(((point & 0x0000FF00) >> 8) + (-20) * 128 / 100);
            int B = (int)((point & 0x000000FF) + (-145) * 128 / 100);

            if (R < 0) R = 0;
            if (R > 255) R = 255;
            if (G < 0) G = 0;
            if (G > 255) G = 255;
            if (B < 0) B = 0;
            if (B > 255) B = 255;

            point = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);

            return point;
        }

        public static void FromPixelToBitmap()
        {
            for (int i = 0; i < image.Height; i++)
                for (int j = 0; j < image.Width; j++)
                    image.SetPixel(j, i, Color.FromArgb((int)pixel[i, j]));
        }

        public static void FromOnePixelToBitmap(int x, int y, UInt32 pixel)
        {
            image.SetPixel(y, x, Color.FromArgb((int)pixel));
        }

        private void brightnessUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < Form1.image.Height; i++)
                for (int j = 0; j < Form1.image.Width; j++)
                {
                    p = Brightness(Form1.pixel[i, j]);
                    Form1.FromOnePixelToBitmap(i, j, p);
                }
            pictureBox2.Image = image;
        }

        private void colourToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < Form1.image.Height; i++)
                for (int j = 0; j < Form1.image.Width; j++)
                {
                    p = Colour(Form1.pixel[i, j]);
                    Form1.FromOnePixelToBitmap(i, j, p);
                }
            pictureBox2.Image = image;
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UInt32[,] saver = pixel;
            pixel = matrix_filtration();
            FromPixelToBitmap();
            pictureBox2.Image = image;
            pixel = saver;
        }

        private void anotherBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UInt32[,] saver = pixel;
            pixel = matrix_filtration();
            pixel = matrix_filtration();
            pixel = matrix_filtration();
            FromPixelToBitmap();
            pictureBox2.Image = image;
            pixel = saver;
        }
        public UInt32[,] matrix_filtration()
        {
            int i, j, k, m, gap = (int)(1);
            int tmpH = image.Height + 2 * gap, tmpW = image.Width + 2 * gap;
            UInt32[,] tmppixel = new UInt32[tmpH, tmpW];
            UInt32[,] newpixel = new UInt32[image.Height, image.Width];
            for (i = 0; i < gap; i++)
                for (j = 0; j < gap; j++)
                {
                    tmppixel[i, j] = pixel[0, 0];
                    tmppixel[i, tmpW - 1 - j] = pixel[0, image.Width - 1];
                    tmppixel[tmpH - 1 - i, j] = pixel[image.Height - 1, 0];
                    tmppixel[tmpH - 1 - i, tmpW - 1 - j] = pixel[image.Height - 1, image.Width - 1];
                }
            for (i = gap; i < tmpH - gap; i++)
                for (j = 0; j < gap; j++)
                {
                    tmppixel[i, j] = pixel[i - gap, j];
                    tmppixel[i, tmpW - 1 - j] = pixel[i - gap, image.Width - 1 - j];
                }
            for (i = 0; i < gap; i++)
                for (j = gap; j < tmpW - gap; j++)
                {
                    tmppixel[i, j] = pixel[i, j - gap];
                    tmppixel[tmpH - 1 - i, j] = pixel[image.Height - 1 - i, j - gap];
                }
            for (i = 0; i < image.Height; i++)
                for (j = 0; j < image.Width; j++)
                    tmppixel[i + gap, j + gap] = pixel[i, j];
            RGB ColorOfPixel = new RGB();
            RGB ColorOfCell = new RGB();
            for (i = gap; i < tmpH - gap; i++)
                for (j = gap; j < tmpW - gap; j++)
                {
                    ColorOfPixel.R = 0;
                    ColorOfPixel.G = 0;
                    ColorOfPixel.B = 0;
                    for (k = 0; k < 3; k++)
                        for (m = 0; m < 3; m++)
                        {
                            ColorOfCell = calculationOfColor(tmppixel[i - gap + k, j - gap + m], blur[k, m]);
                            ColorOfPixel.R += ColorOfCell.R;
                            ColorOfPixel.G += ColorOfCell.G;
                            ColorOfPixel.B += ColorOfCell.B;
                        }

                    if (ColorOfPixel.R < 0) ColorOfPixel.R = 0;
                    if (ColorOfPixel.R > 255) ColorOfPixel.R = 255;
                    if (ColorOfPixel.G < 0) ColorOfPixel.G = 0;
                    if (ColorOfPixel.G > 255) ColorOfPixel.G = 255;
                    if (ColorOfPixel.B < 0) ColorOfPixel.B = 0;
                    if (ColorOfPixel.B > 255) ColorOfPixel.B = 255;

                    newpixel[i - gap, j - gap] = build(ColorOfPixel);
                }
            return newpixel;
        }

        public static double[,] blur = new double[3, 3] {{0.111, 0.111, 0.111},
                                                               {0.111, 0.111, 0.111},
                                                               {0.111, 0.111, 0.111}};

        RGB calculationOfColor(UInt32 pixel, double coefficient)
        {
            RGB Color = new RGB();
            Color.R = (float)(coefficient * ((pixel & 0x00FF0000) >> 16));
            Color.G = (float)(coefficient * ((pixel & 0x0000FF00) >> 8));
            Color.B = (float)(coefficient * (pixel & 0x000000FF));
            return Color;
        }

        UInt32 build(RGB ColorOfPixel)
        {
            UInt32 Color;
            Color = 0xFF000000 | ((UInt32)ColorOfPixel.R << 16) | ((UInt32)ColorOfPixel.G << 8) | ((UInt32)ColorOfPixel.B);
            return Color;
        }


    }
}