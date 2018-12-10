using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class Form1 : Form
    {
        int[] population;

        int K = 3;

        public Form1(List<int> population)
        {
            this.population = population.ToArray();
            InitializeComponent();
            //     this.chart1.ChartAreas[0].AxisY.Interval = 1;
            GenerateSamples();
            // no smaller than design time size
            this.MinimumSize = new Size(this.Width, this.Height);
            // no larger than screen size
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.populationLabel.Text = "{";
            foreach (int i in population)
            {
                this.populationLabel.Text += " " + i;
            }
            this.populationLabel.Text += " }";
            this.label2.Text = population.Count.ToString();
            this.label7.Text = K.ToString();
        }

        // Subset: Disposizioni
        // Combinations: Combinazioni

        public void GenerateSamples()
        {
            List<string> result = new List<string>();
            Subsets(population, K, 0, 0, "", ref result);
            richTextBox1.Text += "Number of Subsets: " + result.Count() + Environment.NewLine;

            foreach (var item in result)
                richTextBox1.Text += item + Environment.NewLine;

            result.Clear();

            Combinations(population, K, 0, 0, "", ref result);

            richTextBox2.Text += "Number of Combinations: " + resultComb.Count() + Environment.NewLine;

            foreach (var item in resultComb)
                richTextBox2.Text += item + Environment.NewLine;
        }

        // Disposizioni con ripetizione n^k
        void Subsets(int[] population, int n, int j, int k, string appo, ref List<string> result)
        {
            if (j >= n)
                result.Add(appo);
            else
                for (int i = 0; i < population.Length; i++)
                    Subsets(population, n, j + 1, i, appo + population[i] + " ", ref result);
        }

        // Combinazioni senza ripetizione
        List<string> resultComb = new List<string>();
        void Combinations(int[] population, int n, int j, int k, string appo, ref List<string> result)
        {
            if (j == n)
            {
                // richTextBox2.Text += appo + " " + Environment.NewLine;
                resultComb.Add(appo);
            }
            else
                for (int i = k; i < population.Length; i++)
                    Combinations(population, n, j + 1, i + 1, appo + population[i] + " ", ref result);
        }

        /*

        public void AddDistributionToChart()
    {
        // Distribuzione della popolazione

        Dictionary<int, int> distributions = new Dictionary<int, int>();

        this.label4.Text = "{";

        foreach (int i in population)
        {
            if (distributions.ContainsKey(i))
            {
                distributions[i] += 1;
            }
            else
            {
                distributions[i] = 1;
            }

            this.label4.Text += " " + i + " ";
        }

        this.label4.Text += "}";

        this.label2.Text = population.Count.ToString();

        int min = int.MaxValue;

        foreach (int i in distributions.Keys)
        {
            this.chart1.Series["Medie"].Points.AddXY(i, distributions[i]);
            if (i < min)
                min = i;
        }

        this.chart1.ChartAreas[0].AxisX.Minimum = min - 1;
        this.chart1.Invalidate();
    }
    */

    }
}

