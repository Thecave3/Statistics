using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void StartDistribution_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Distributions"].Points.Clear();
            this.outputLabel.Text = "";
            Random random = new Random();
            double n = double.Parse(this.inputSampleSize.Text);
            double p = double.Parse(this.inputProb.Text);
            double successes;
            for (int i = 0; i <= n; i++)
            {
                successes = 0;

                for (int j = 1; j <= n; j++)
                {

                    if (random.NextDouble() < 0.5)
                        successes++;

                }

                double result = probBinomiale(successes, n, p);
                this.chart1.Series["Distributions"].Points.AddXY(successes, result);
                this.outputLabel.Text += "X = " + successes + " , Y = " + result + "\n";
            }

        }

        private double probBinomiale(double x, double n, double prob)
        {
            double cBino = BinomCoefficient(n, x);
            double pow1 = Math.Pow(prob, x);
            double pow2 = Math.Pow(1 - prob, n - x);
            this.outputLabel.Text += "pow1 = " + pow1 + " , pow2 = " + pow2 + "\n";

            return cBino * pow1 * pow2;
        }

        public static double BinomCoefficient(double n, double x)
        {
            if (x > n) { return 0; }
            if (n == x) { return 1; } // only one way to chose when n == k
            if (x > n - x) { x = n - x; } // Everything is symmetric around n-k, so it is quicker to iterate over a smaller k than a larger one.
            double c = 1;
            for (double i = 1; i <= x; i++)
            {
                c *= n--;
                c /= i;
            }
            return c;
        }
    }
}
