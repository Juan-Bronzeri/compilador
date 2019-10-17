using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    public partial class FormTerminador : Form
    {
        public FormTerminador()
        {
            InitializeComponent();
        }

        private void PontoVirgula_Click(object sender, EventArgs e)
        {
            StaticTerminador.SetTerminador(";");
        }

        private void btnSemTerminador_Click(object sender, EventArgs e)
        {
            StaticTerminador.SetTerminador("");
        }

        private void btnOutro_Click(object sender, EventArgs e)
        {
            string aux = txtOutro.Text;
            StaticTerminador.SetTerminador(""+aux+"");
        }
    }
}
