using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDPrimaryNumbers.Base;
using PDPrimaryNumbers;

/* Урок "Распределение простых чисел. Полотно Улама."
 * Все уроки на http://digitalmodels.ru
 * 
 */

namespace PrimaryCover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region === private ===

        int CellSize => (comboBox1.Items.Count > 0) ? Convert.ToInt32(comboBox1.SelectedItem) : 0;

        IPrimary PrimaryInterface => new PrimaryNum();

        Bitmap GenerateBitmap(int width, int height, IPrimary iprimary, int size)
        {
            if (width < 1 || height < 1)
                return null;
            
            Bitmap bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int stride = bmpData.Stride;
            int bytes = Math.Abs(stride) * bitmap.Height;
            byte[] rgbValues = new byte[bytes];    

            for (int i = 0; i < rgbValues.Length; i++)
            {
                rgbValues[i] = 255;
            }

            int xCur = width / 2;
            int yCur = height / 2;
            int N = 1;
            int direction = 0;
            int curLenght = 0;
            int lenght = 1;
            bool bXOut = false;
            bool bYOut = false;
            int shift = 2 * size + 1;

            while (true)
            {
                if (iprimary.IsPrimary(N))
                {
                    for (int x = xCur - size; x <= xCur + size; x++)
                    {
                        if (x < 0 || x >= width)
                        {
                            bXOut = true;
                            continue;
                        }

                        for (int y = yCur - size; y <= yCur + size; y++)
                        {
                            if (y < 0 || y >= height)
                            {
                                bYOut = true;
                                continue;
                            }

                            Array.Clear(rgbValues, y * stride + x * 3, 3);
                        }
                    }

                    if (bXOut && bYOut)
                        break;
                }

                N++;

                if (direction == 0)
                {
                    xCur += shift;
                }
                else if (direction == 1)
                {
                    yCur -= shift;
                }
                else if (direction == 2)
                {
                    xCur -= shift;
                }
                else
                {
                    yCur += shift;
                }

                curLenght++;

                if (curLenght == lenght)
                {
                    curLenght = 0;
                    direction = (direction + 1) % 4;

                    if (direction % 2 == 0)
                    {
                        lenght++;
                    }
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, bmpData.Scan0, bytes);
            bitmap.UnlockBits(bmpData);

            return bitmap;
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;            

            for (int i = 0; i < 16; i++)
            {
                comboBox1.Items.Add(i);
            }

            comboBox1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = GenerateBitmap(pictureBox1.Width, pictureBox1.Height, PrimaryInterface, CellSize);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                Filter = "PNG files (*.png)|*.png",
                FilterIndex = 0,
                RestoreDirectory = true
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Image image = GenerateBitmap(1024, 1024, PrimaryInterface, CellSize);
                image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
