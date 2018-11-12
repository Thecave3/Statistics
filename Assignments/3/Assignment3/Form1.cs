using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class ShowData : Form
    {

        public ShowData(List<Studente> list)
        {
            InitializeComponent(list);
            
        }

    }

}
