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
        List<int> population;

        public Form1(List<int> population)
        {
            this.population = population;
            InitializeComponent();
            this.chart1.ChartAreas[0].AxisY.Interval = 1;
            GenerateSamples();
            // no smaller than design time size
            this.MinimumSize = new Size(this.Width, this.Height);
            // no larger than screen size
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.AddDistributionToChart();

        }

        public void GenerateSamples()
        {

            List<List<int[]>> combinations = new List<List<int[]>>();

            for (int n = 2; n < population.Count; n++)
            {
               // combinations.Add();
                
               
            }

            AddDataToChart(combinations);
        }

       
    

    public void AddDataToChart(List<List<int[]>> comb)
    {
          
        }


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


}
}

