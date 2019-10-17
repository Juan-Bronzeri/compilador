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
    public partial class FormVariavel : Form
    {
        public FormVariavel()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int aux = Convert.ToInt32(txtTamanho.Text);
            StaticTamanhoVariavel.SetTamanhoVariavel(aux);
        }
    }
}
