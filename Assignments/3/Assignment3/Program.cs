using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<Studente> list = new List<Studente>();
            using (var reader = new StreamReader(@"Student_Survey_Dataset.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(',');
                    list.Add(new Studente(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8]));
                }
            }
       

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ShowData form = new ShowData(list);
            Application.Run(form);

        }
    }
}
