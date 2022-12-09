using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Project4
{
    public partial class Form1 : Form
    {
        public List<double[][]> points_projection;
        public double scale;
        public int axi_rot;
        int xCenter;
        int yCenter;

        private static List<double[][]> figure = new List<double[][]>()
        {
        new double[][]{
                new double[] { 1, 3, -1.5, 1},
                new double[] { -1, 3, -1.5, 1},
                new double[] { -2, 3, 0, 1},
                new double[] { 0, 3, 1, 1},
                new double[] { 2, 3, 0, 1},
            },
            new double[][]{
                new double[] { 1, -3, -1.5, 1},
                new double[] { -1, -3, -1.5, 1},
                new double[] { -2, -3, 0, 1},
                new double[] { 0, -3, 1, 1},
                new double[] { 2, -3, 0, 1},
            },
            new double[][]{
                new double[] { 1, -3, -1.5, 1},
                new double[] { -1, -3, -1.5, 1},
                new double[] { -1, 3, -1.5, 1},
                new double[] { 1, 3, -1.5, 1},
            },

            new double[][]{
                new double[] { -1, 3, -1.5, 1},
                new double[] { -1, -3, -1.5, 1},
                new double[] { -2, -3, 0, 1},
                new double[] { -2, 3, 0, 1},
            },
            new double[][]{
                new double[] { -2, -3, 0, 1},
                new double[] { -2, 3, 0, 1},
                new double[] { 0, 3, 1, 1},
                new double[] { 0, -3, 1, 1},
            },
            new double[][]{
                new double[] { 0, 3, 1, 1},
                new double[] { 0, -3, 1, 1},
                new double[] { 2, -3, 0, 1},
                new double[] { 2, 3, 0, 1},
            },
            new double[][]{
                new double[] { 2, -3, 0, 1},
                new double[] { 2, 3, 0, 1},
                new double[] { 1, 3, -1.5, 1},
                new double[] { 1, -3, -1.5, 1},
            },

    };
        private List<double[][]> figureSaver = figure;
        public Form1()
        {
            InitializeComponent();
            xCenter = pictureBox1.Width / 2;
            yCenter = pictureBox1.Height / 2;
            KeyPreview = true;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            scale = 30;
            Graphics g = e.Graphics;


            Pen pen = new Pen(Color.Gold, 1);
            Pen pen2 = new Pen(Color.Green, 1);
            pen2.DashStyle = DashStyle.DashDot;
            g.DrawLine(pen, xCenter, 0, xCenter, yCenter);
            g.DrawLine(pen2, xCenter, yCenter, xCenter, pictureBox1.Height);
            g.DrawLine(pen, xCenter, yCenter, pictureBox1.Width, yCenter);
            g.DrawLine(pen2, xCenter, yCenter, 0, yCenter);
            g.DrawLine(pen, xCenter, yCenter, xCenter - yCenter * 2, pictureBox1.Height);
            g.DrawLine(pen2, xCenter, yCenter, xCenter + yCenter * 2, 0);

            double B = 20 * Math.PI / 180;
            double[][] matrix = { new double[] {1, 0, 0, 0},
                                 new double[] {0, 1, 0, 0},
                                 new double[] {Math.Cos(B), Math.Sin(B), 0, 0},
                                 new double[] {0, 0, 0, 1}};

            GraphicsPath path = new GraphicsPath();
            Pen pen3 = new Pen(Color.Black);
            points_projection = matrixChanger(matrix);
            for (int i = 0; i < points_projection.Count; i++)
            {
                paintPlateFacets(g, path, pen3, points_projection[i], 1);
            }
        }

        public List<double[][]> matrixChanger(double[][] matrix)
        {
            List<double[][]> facets = new List<double[][]>();
            int counter = 0;
            foreach (var platefacets in figure)
            {
                int facets_count = platefacets.Length;
                int matrix_columns = matrix[0].Length;
                int vertice_coord_count;

                facets.Add(new double[facets_count][]);
                for (int i = 0; i < facets_count; i++)
                {
                    vertice_coord_count = platefacets[i].Length;
                    facets[counter][i] = new double[matrix_columns];
                    for (int j = 0; j < matrix_columns; j++)
                    {
                        facets[counter][i][j] = 0;
                        for (int k = 0; k < vertice_coord_count; k++)
                            facets[counter][i][j] += platefacets[i][k] * matrix[k][j];
                    }
                }
                counter++;
            }
            return facets;
        }
        public static List<double[][]> MSaver(List<double[][]> A)
        {

            List<double[][]> facets = new List<double[][]>();
            int counter = 0;
            foreach (var platefacets in A)
            {
                int facets_count = platefacets.Length;
                facets.Add(new double[facets_count][]);
                int x = platefacets[0].Length;
                for (int i = 0; i < facets_count; i++)
                {
                    int vertice_coord_count = platefacets[i].Length;
                    facets[counter][i] = new double[vertice_coord_count];
                    for (int j = 0; j < x; j++)
                        facets[counter][i][j] = platefacets[i][j] / platefacets[i][x - 1];
                }

                counter++;
            }
            return facets;
        }

        private void paintPlateFacets(Graphics g, GraphicsPath graphics_path, Pen pen, double[][] facets, int enclosing)
        {
            PointF[] points_toDraw = new PointF[facets.Length+1];
            int i = 0;
            for (; i < facets.Length; i++)
                points_toDraw[i] = new PointF(Convert.ToInt32(facets[i][0] * scale + xCenter), Convert.ToInt32(yCenter - facets[i][1] * scale));
            points_toDraw[i] = new PointF(Convert.ToInt32(facets[0][0] * scale + xCenter), Convert.ToInt32(yCenter - facets[0][1] * scale));
            graphics_path.AddLines(points_toDraw);
            g.FillPolygon(new SolidBrush(Color.FromArgb(30, 0, 0, 255)), points_toDraw);
            g.DrawLines(pen, points_toDraw);
        }
        double tryParser()
        {
            if (!double.TryParse(textBox1.Text, out double degrees))
            {
                MessageBox.Show(
                "Enter degrees in field",
                "Not critical error");
                textBox1.Clear();
                return 0;
            }
            return degrees = degrees * Math.PI / 180;
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,1, 0, 1}};
            figure = matrixChanger(move);
            pictureBox1.Invalidate();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,-1, 0, 1}};
            figure = matrixChanger(move);
            pictureBox1.Invalidate();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {1, 0, 0, 1}};
            figure = matrixChanger(move);
            pictureBox1.Invalidate();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                              new double[] {0, 1, 0, 0},
                              new double[] {0, 0, 1, 0},
                              new double[] {-1, 0, 0, 1}};
            figure = matrixChanger(move);
            pictureBox1.Invalidate();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            {
                double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,0, 1, 1}};
                figure = matrixChanger(move);
                pictureBox1.Invalidate();
            }
        }

        private void nearerButton_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,0, -1, 1}};
            figure = matrixChanger(move);
            pictureBox1.Invalidate();
        }

        private void zoomPlusButton_Click(object sender, EventArgs e)
        {
            double[][] zoomPlus = { new double[] {1, 0, 0, 0},
                                 new double[] {0, 1, 0, 0},
                                 new double[] {0, 0, 1, 0},
                                 new double[] {0, 0, 0, 0.9}};
            figure = matrixChanger(zoomPlus);
            figure = MSaver(figure);
            pictureBox1.Invalidate();
        }

        private void zoomMinuseButton_Click(object sender, EventArgs e)
        {
                    double[][] zoomMinuse = { new double[] {1, 0, 0, 0},
                                            new double[] {0, 1, 0, 0},
                                            new double[] {0, 0, 1, 0},
                                            new double[] {0, 0, 0, 1.1}};
                    figure = matrixChanger(zoomMinuse);
                    figure = MSaver(figure);
                    pictureBox1.Invalidate();
        }

        private void flipOXbutton_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {-1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,0, 0, 1}};
            figure = matrixChanger(move);
            pictureBox1.Invalidate();

        }

        private void flipOYbutton_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, -1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,0, 0, 1}};
            figure = matrixChanger(move);
            pictureBox1.Invalidate();
        }

        private void flipOZbutton_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, -1, 0},
                              new double[] {0,0, 0, 1}};
            figure = matrixChanger(move);
            pictureBox1.Invalidate();
        }

        private void turnOXbutton_Click(object sender, EventArgs e)
        {
            double degrees = tryParser();
            double[][] turnMatrix = new double[][] {new double[] {1, 0, 0, 0},
                                                new double[] {0, Math.Cos(degrees), Math.Sin(degrees), 0},
                                                new double[] {0, -Math.Sin(degrees), Math.Cos(degrees), 0},
                                                new double[] {0, 0, 0, 1}};
            figure = matrixChanger(turnMatrix);
            pictureBox1.Invalidate();
        }

        private void turnOYbutton_Click(object sender, EventArgs e)
        {
            double degrees = tryParser();
            double[][] turnMatrix = new double[][] {new double[] {Math.Cos(degrees), 0, -Math.Sin(degrees), 0},
                                               new double[] { 0, 1, 0, 0},
                                               new double[] { Math.Sin(degrees), 0, Math.Cos(degrees), 0},
                                               new double[] { 0, 0, 0, 1}};
            figure = matrixChanger(turnMatrix);
            pictureBox1.Invalidate();
        }

        private void turnOZbutton_Click(object sender, EventArgs e)
        {
            double degrees = tryParser();
            double[][] turnMatrix = new double[][] { new double[] {Math.Cos(degrees), Math.Sin(degrees), 0, 0},
                                              new double[] { -Math.Sin(degrees), Math.Cos(degrees), 0, 0},
                                               new double[]{ 0, 0, 1, 0},
                                              new double[] { 0, 0, 0, 1}};
            figure = matrixChanger(turnMatrix);
            pictureBox1.Invalidate();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            figure = figureSaver;
            pictureBox1.Invalidate();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                upButton_Click(sender, e);
                upButton.Focus();
            }

            if (e.KeyCode == Keys.S)
            {
                downButton_Click(sender, e);
                downButton.Focus();
            }

            if (e.KeyCode == Keys.E)
            {
                forwardButton_Click(sender, e);
                forwardButton.Focus();
            }

            if (e.KeyCode == Keys.Q)
            {
                nearerButton_Click(sender, e);
                nearerButton.Focus();
            }

            if (e.KeyCode == Keys.D)
            {
                rightButton_Click(sender, e);
                rightButton.Focus();
            }

            if (e.KeyCode == Keys.A)
            {
                leftButton_Click(sender, e);
                leftButton.Focus();
            }


            if (e.KeyCode == Keys.Z)
            {
                zoomPlusButton_Click(sender, e);
                zoomPlusButton.Focus();
            }

            if (e.KeyCode == Keys.X)
            {
                zoomMinuseButton_Click(sender, e);
                zoomMinuseButton.Focus();
            }
        }

    }
}

