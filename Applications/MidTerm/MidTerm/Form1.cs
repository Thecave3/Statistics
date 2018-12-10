using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidTerm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Random r;
        private Timer timer;

        private void Form1_Load(object sender, EventArgs e)
        {
            r = new Random();
            timer = new Timer
            {
                Interval = 300,
                Enabled = true
            };
            timer.Tick += Routine;

        }

        private void Routine(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
