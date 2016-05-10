using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class AddSchedule : Form
    {
        public AddSchedule()
        {
            InitializeComponent();
        }

        public string Nombre
        {
            get { return textBox1.Text; }
            set { textBox1.Text=value; }
        }

        public int Contactos
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = (decimal)value; }
        }
    }
}
