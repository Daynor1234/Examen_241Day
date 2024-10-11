using System;
using System.Drawing;
using System.Windows.Forms;

namespace DetectarBordes
{
    public partial class AppDetecBord : Form
    {
        public AppDetecBord()
        {
            InitializeComponent();
        }

        // Función personalizada para limitar el valor entre un rango
        private int LimitValue(int value, int min, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        private void CarIma_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos PNG|*.png|Archivos JPG|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImagOrig.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void DecBor_Click(object sender, EventArgs e)
        {
            if (ImagOrig.Image == null) return;

            Bitmap bmp = new Bitmap(ImagOrig.Image);
            Bitmap result = new Bitmap(bmp.Width, bmp.Height);

            int[,] kernelX = new int[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            int[,] kernelY = new int[,]
            {
                { 1, 2, 1 },
                { 0, 0, 0 },
                { -1, -2, -1 }
            };

            const int threshold = 180; // Valor para ajustar la sensibilidad del borde

            for (int x = 1; x < bmp.Width - 1; x++)
            {
                for (int y = 1; y < bmp.Height - 1; y++)
                {
                    int gradX = 0, gradY = 0;

                    for (int kx = -1; kx <= 1; kx++)
                    {
                        for (int ky = -1; ky <= 1; ky++)
                        {
                            Color pixelColor = bmp.GetPixel(x + kx, y + ky);
                            int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                            gradX += grayValue * kernelX[kx + 1, ky + 1];
                            gradY += grayValue * kernelY[kx + 1, ky + 1];
                        }
                    }

                    int magnitude = (int)Math.Sqrt(gradX * gradX + gradY * gradY);

                    if (magnitude > threshold)
                    {
                        magnitude = LimitValue(magnitude, 0, 255);
                        result.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude));
                    }
                    else
                    {
                        result.SetPixel(x, y, Color.Black); // No borde
                    }
                }
            }

            ImagWithoutBord.Image = result;
        }
    }
}
