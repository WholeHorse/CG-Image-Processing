﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ComputerGraphics_Lab1
{
    public partial class MainForm : Form
    {
        Bitmap image;
        public MainForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(openFileDialog1.FileName);
            }
            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPeg Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";
            saveFileDialog.Title = "Сохранить изображение как...";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                // Сохраняет изображение через FileStream созданный по выбранному пути
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();

                // Сохраняет изображение в выбранном формате
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;

                    case 3:
                        pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }

                fs.Close();
            }
        }

        private void оттенкиСерогоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayscaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void бинаризацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BinarizationFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void добавитьЯркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BrightFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void негативToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /*Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;*/
            Bitmap newImage = image;
            Filters[] filters = e.Argument as Filters[];
            if (filters == null)
            {
                filters = new Filters[] { e.Argument as Filters };
            }
            foreach (Filters filter in filters)
            {
                newImage = filter.processImage(newImage, backgroundWorker1);
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
            image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void фильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void добавитьРезкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpenFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new EmbossingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double centerX = 200;
            double centerY = 200;
            double angle = 45;
            Filters filter = new RotateFilter(centerX, centerY, angle);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new WavesFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new TranspositionFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрЩарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ScharrFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void светящиесяКраяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters[] filters = new Filters[] { new MedianFilter(), new SobelFilter(), new MaximumFilter() };
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void серыиМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayWorldFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void идеальныиОтражательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new PerfectReflectorFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void коррекцияСОпорнымЦветомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color refColor = Color.FromArgb(128, 128, 0);
            Filters filter = new ReferenceColorCorrectionFilter(refColor);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void линейноеРастяжениеГистограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new HistogramStretchingFilter(image);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void dilationрасширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] structElem = new bool[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            };
            Filters filter = new DilationFilter(structElem);
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void erosionэрозияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] structElem = new bool[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            };
            Filters filter = new ErosionFilter(structElem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] structElem = new bool[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            };
            Filters[] filters = new Filters[] { new ErosionFilter(structElem), new DilationFilter(structElem) };
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] structElem = new bool[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            };
            Filters[] filters = new Filters[] { new DilationFilter(structElem), new ErosionFilter(structElem) };
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] structElem = new bool[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            };
            Bitmap originalImage = image;
            Filters[] filters = new Filters[] { new ErosionFilter(structElem), new DilationFilter(structElem), new SubtractFilter(originalImage) };
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void blackHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] structElem = new bool[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            };
            Bitmap originalImage = image;
            Filters[] filters = new Filters[] { new DilationFilter(structElem), new ErosionFilter(structElem), new SubtractFilter(originalImage) };
            backgroundWorker1.RunWorkerAsync(filters);
        }

        private void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool[,] structElem = new bool[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            };
            Bitmap originalImage = image;
            Filters erosionFilter = new ErosionFilter(structElem);
            Bitmap erosionImage = erosionFilter.processImage(originalImage, backgroundWorker1);

            Filters[] filters = new Filters[] { new DilationFilter(structElem), new SubtractFilter(erosionImage) };
            backgroundWorker1.RunWorkerAsync(filters);
        }
    }
}
