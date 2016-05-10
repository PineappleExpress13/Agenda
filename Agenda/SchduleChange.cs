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
{    /*********************************
 Autor: Josue Piña Rodriguez
 Fecha creación: 6/05/2016
 Última modificación: 10/05/2016
 Versión: 1.0
***********************************/
    public partial class SchduleChange : Form
    {
        public SchduleChange()
        {
            InitializeComponent();
        }

        public int Index
        {
            get { return lista.SelectedIndex; }
        }
        public void Lista(string name)
        {
            lista.Items.Add(name);
        }
    }
}
