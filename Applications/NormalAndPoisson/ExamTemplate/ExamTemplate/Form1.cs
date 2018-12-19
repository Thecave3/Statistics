using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTemplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // variabile aleatoria distribuzione normale
        public static double NextGaussianDouble(Random r)
        {
            double u, v, S;

            do
            {
                u = 2.0 * r.NextDouble() - 1.0;
                v = 2.0 * r.NextDouble() - 1.0;
                S = u * u + v * v;
            }
            while (S >= 1.0);

            double fac = Math.Sqrt(-2.0 * Math.Log(S) / S);
            return u * fac;
        }

        // variabile aleatoria distribuzione negativa exonenziale
        public static double NextNegativeExpDouble(Random r, double lambda)
        {

            return Math.Log(1 - r.NextDouble()) / (-lambda);
        }

        // aggiungi i dati alla normale pdf
        public void AddDataNormalPDF(double x, double y)
        {
            this.chart1.Series["NormalPDF"].Points.AddXY(x, y);
        }

        // aggiungi i dati alla normale cdf
        public void AddDataNormalCDF(double x, double y)
        {
            this.chart1.Series["NormalCDF"].Points.AddXY(x, y);
        }

        // aggiungi i dati alla negativa exponenziale
        public void AddDataNegExpPDF(double x, double y)
        {
            this.chart1.Series["NegExpPDF"].Points.AddXY(x, y);
        }

        public void AddDataNegExpCDF(double x, double y)
        {
            this.chart1.Series["NegExpCDF"].Points.AddXY(x, y);
        }

        private void ClearData()
        {
            this.chart1.Series["NormalPDF"].Points.Clear();
            this.chart1.Series["NormalCDF"].Points.Clear();
            this.chart1.Series["NegExpPDF"].Points.Clear();
            this.chart1.Series["NegExpCDF"].Points.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearData();
            int N = int.Parse(this.textBox3.Text);
            double mu = double.Parse(this.textBox1.Text);
            double sigmaQ = double.Parse(this.textBox2.Text);
            double lambda = double.Parse(this.textBox4.Text);
            Random rN = new Random();
            Random rE = new Random();
            double a, b;
            for (int i = 0; i < N; i++)
            {
                a = NextGaussianDouble(rN);
                b = NextNegativeExpDouble(rE, lambda);
                AddDataNormalPDF(a, Normal_func_PDF(a, mu, sigmaQ));
                AddDataNormalCDF(a, Normal_func_CDF(a, mu, sigmaQ));
                AddDataNegExpPDF(b, Neg_Exp_func_PDF(b, lambda));
                AddDataNegExpCDF(b, Neg_Exp_func_CDF(b, lambda));
            }

        }

        private double Neg_Exp_func_PDF(double b, double lambda)
        {

            return (b < 0) ? 0.0 : Math.Pow(Math.E, -(lambda * b));
        }

        private double Neg_Exp_func_CDF(double b, double lambda)
        {

            return (b < 0) ? 0.0 : 1 - Math.Pow(Math.E, (-(b * lambda)));
        }

        /*
        AddDataUBounds(a, nfPDF, sigmaQ);
        AddDataLBounds(a, nfPDF, sigmaQ);
        public void AddDataUBounds(double x, double nfPDF, double sigmaQ)
        {
            this.chart1.Series["upperBBands"].Points.AddXY(x, nfPDF + sigmaQ);
        }

        public void AddDataLBounds(double x, double nfPDF, double sigmaQ)
        {
            this.chart1.Series["lowerBBands"].Points.AddXY(x, nfPDF - sigmaQ);
        }
        */


        private static double Normal_func_PDF(double i, double mu, double sigmaQ)
        {
            return (1 / Math.Sqrt(2 * Math.PI * sigmaQ)) * Math.Pow(Math.E, -(Math.Pow(i - mu, 2) / (2 * sigmaQ)));
        }

        static double Normal_func_CDF(double z, double mu, double sigmaQ)
        {
            double sigma = Math.Sqrt(sigmaQ);

            double p = 0.3275911;
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;

            int sign;
            if ((z - mu) < 0.0)
                sign = -1;
            else
                sign = 1;

            double x = (Math.Abs(z - mu)) / (Math.Sqrt(2.0) * sigma);
            double t = 1.0 / (1.0 + p * x);
            double erf = 1.0 - (((((a5 * t + a4) * t) + a3)
              * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * erf);
        }
    }
}
