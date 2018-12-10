using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NegativeExponential
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += new System.EventHandler(Routine);
        }

        private void Routine(object sender, EventArgs e)
        {
            ClearData();
            this.labelN.Text = N.ToString();
            List<double> means = new List<double>();

            for (int i = 0; i < iteration_factor; i++)
            {
                means.Add(GenerateDistributionAndExtractMean(r));
            }
            means.Max();


            Dictionary<double, int> frequencies = new Dictionary<double, int>();
            double standard;
            foreach (double mean in means)
            {
                standard = Math.Floor((mean - (means.Max() - means.Min())) /((means.Max() - means.Min()/50)));
                if (frequencies.ContainsKey(standard))
                    frequencies[standard] += 1;
                else
                    frequencies[standard] = 1;
            }
            AddDataToChart(frequencies);
            N++;
        }


        double lambda = 2.0;
        int iteration_factor = 500;
        int N = 1;
        Random r = new Random();
        Timer timer;

        // Generatore di distribuzione negativa esponenziale
        public static double NextNegativeExpDouble(Random r, double lambda)
        {
            return Math.Log(1 - r.NextDouble()) / (-lambda);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearData();
            timer.Start();
        }

        private void AddDataToChart(Dictionary<double, int> frequencies)
        {
            foreach (double key in frequencies.Keys)
            {
                this.chart1.Series["NegExpAvg"].Points.AddXY(key, frequencies[key]);
            }
        }

        private double GenerateDistributionAndExtractMean(Random r)
        {
            double sum = 0.0;
            for (int i = 0; i < 5000; i++)
            {
                sum += NextNegativeExpDouble(r, lambda);
            }
            return sum / N;
        }



        private void ClearData()
        {
            this.chart1.Series["NegExpAvg"].Points.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}
