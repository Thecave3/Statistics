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

        // aggiungi i dati alla normale pdf
        public void AddDataSubNormalPDF(double x, double y)
        {
            this.chart1.Series["SubNormalPDF"].Points.AddXY(x, y);
        }

        // aggiungi i dati alla normale cdf
        public void AddDataSubNormalCDF(double x, double y)
        {
            this.chart1.Series["SubNormalCDF"].Points.AddXY(x, y);
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
            ClearSubData();
        }

        private void ClearSubData()
        {
            this.chart1.Series["SubNormalPDF"].Points.Clear();
            this.chart1.Series["SubNormalCDF"].Points.Clear();
        }

        double[] samples;

        private void Button1_Click(object sender, EventArgs e)
        {
            ClearData();
            int N = int.Parse(this.textBox3.Text);
            Random rN = new Random();
            double a;
            samples = new double[N];
            // Genero la distribuzione completa di N elementi e la plotto
            for (int i = 0; i < N; i++)
            {
                a = NextGaussianDouble(rN);
                //b = NextNegativeExpDouble(rE, lambda);
                samples[i] = a;
                AddDataNormalPDF(a, Normal_func_PDF(a, 0, 1));
                AddDataNormalCDF(a, Normal_func_CDF(a, 0, 1));
                //AddDataNegExpPDF(b, Neg_Exp_func_PDF(b, lambda));
                //AddDataNegExpCDF(b, Neg_Exp_func_CDF(b, lambda));
            }

        }

        // Genero la distribuzione del 10% degli elementi costruiti prima, ci calcolo media e varianza e li plotto
        private void Button2_Click(object sender, EventArgs e)
        {
            if (samples is null)
            {
                MessageBox.Show("Premi Generate prima");
                return;
            }
            ClearSubData();
            double percentage = double.Parse(this.textBox5.Text) / 100;
            double[] subSamples = new double[(int)(samples.Length * percentage)];
            Random r = new Random();

            // popolo subSamples
            // OVVIAMENTE QUESTA FUNZIONE DI POPOLAMENTO NON è AL 100% CORRETTA, 
            // può capitare che alcuni dati vengano riproposti una migliore implementazione prevede
            // un uso di liste, ma sinceramente pish
            for (int i = 0; i < subSamples.Length; i++)
            {
                subSamples[i] = samples[r.Next(0, samples.Length - 1)];
            }

            // calcolo media e varianza ridotti
            double subMu;
            double subSigmaQ = 0.0;
            double sumSamples = 0.0;
            for (int i = 0; i < subSamples.Length; i++)
            {
                sumSamples += subSamples[i];
            }
            subMu = sumSamples / subSamples.Length;

            double differences = 0.0;
            for (int i = 0; i < subSamples.Length; i++)
            {
                differences += Math.Pow(subSamples[i] - subMu, 2);
            }

            subSigmaQ = differences / subSamples.Length;

            // plot distribuzione campione ridotto
            for (int i = 0; i < subSamples.Length; i++)
            {
                AddDataSubNormalPDF(subSamples[i], Normal_func_PDF(subSamples[i], subMu, subSigmaQ));
                AddDataSubNormalCDF(subSamples[i], Normal_func_CDF(subSamples[i], subMu, subSigmaQ));
            }

        }


        static double Neg_Exp_func_PDF(double b, double lambda)
        {

            return (b < 0) ? 0.0 : Math.Pow(Math.E, -(lambda * b));
        }

        static double Neg_Exp_func_CDF(double b, double lambda)
        {

            return (b < 0) ? 0.0 : 1 - Math.Pow(Math.E, (-(b * lambda)));
        }

        static double Normal_func_PDF(double i, double mu, double sigmaQ)
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

        private void Button3_Click(object sender, EventArgs e)
        {
            if (samples is null)
            {
                MessageBox.Show("Premi Generate prima");
                return;
            }

            double lambda = double.Parse(this.textBox4.Text);
            Random rE = new Random();
            double b;
            int N = int.Parse(this.textBox3.Text);

            for (int i = 0; i < N; i++)
            {
                b = NextNegativeExpDouble(rE, lambda);
                AddDataNegExpPDF(b, Neg_Exp_func_PDF(b, lambda));
                AddDataNegExpCDF(b, Neg_Exp_func_CDF(b, lambda));
            }
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
    }
}
