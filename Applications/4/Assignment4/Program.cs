using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        /*
         * Given a population A = {25,27,29,28,30,30,18,25,25}
         * generate by computer all possibles samples of size N 
         * 
         * Represent with a histogram the sampling distribution of the mean
         * 
         * 
         */

        static void Main()
        {
            List<int> population = new List<int>
            {
                25,
                27,
                29,
                28,
                30,
                30,
                18,
                25,
                25
            };



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1(population);
           
            Application.Run(form);
            
        }
    }
}
