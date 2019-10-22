using System;
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
            StaticTerminador.SetTerminador(';');
            Close();
        }

        private void btnOutro_Click(object sender, EventArgs e)
        {
            char aux = Convert.ToChar(txtOutro.Text);
            StaticTerminador.SetTerminador(aux);
            Close();
        }
    }
}
