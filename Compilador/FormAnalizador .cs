using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Compilador
{
    public partial class Analizador : Form
    {
        IList<ItensDataSource> item = new List<ItensDataSource>();

        Regex ER = new Regex(@"\w+\s+[\w]+((\s+.)|(.))");
        public Analizador()
        {
            this.MinimumSize = new System.Drawing.Size(413, 305);
            InitializeComponent();
        }

        bool autenticarTipoVariavel(string tipo)
        {
            bool retorno = false;
            if (tipo == "int" || tipo == "string" || tipo == "bool" || tipo == "float")
                retorno = true;
            return retorno;
        }

        bool autenticarTerminador(string terminador)
        {
            bool retornar = false;
            if (terminador == ";")
                retornar = true;
            return retornar;
        }

        bool autenticarVariavel(string variavel)
        {
            bool retornar = false;

            autenticarTamanhoVariavel();

            return true;
        }

        bool autenticarTamanhoVariavel(string variavel)
        {
            bool retornar = false;
            if (variavel.Length > 0 && variavel.Length < 10)
                retornar = true;
            return retornar;
        }

        bool autenticarPalavraDaVariavel()
        {
            bool retornar = false;
        }

        private void Compilar_Click(object sender, EventArgs e)
        {
            dgvResultado.DataSource = null;
            item.Clear();

            int cnt = 0;
            string[] aux;

            string[] str = richTxtTexto.Text.Split('\n');
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i].Replace("\n", "");
                str[i] = str[i].Trim();
                if (ER.IsMatch(str[i]) == true)
                {
                    aux = str[i].Split(' ');
                    if (autenticarTipoVariavel(aux[0]))
                    {
                        if (autenticarTerminador(aux[aux.Length - 1]))
                        {
                            for (int x = 0; x < aux.Length; x++)
                            {
                                if (aux[x] != " " && x != 0 && x != aux.Length - 1)
                                {
                                    aux[x] = null;
                                }
                            }
                            for (int x = 0; x < aux.Length; x++)
                            {
                                if (aux[x] != null)
                                {
                                    if ()
                                }
                            }
                        }
                    }
                    else
                    {
                        ItensDataSource Item = new ItensDataSource();
                        Item.status = "ERRO";
                        Item.linha = Convert.ToString(i + 1);
                        Item.tipo = "Erro, tipo inválido";
                        Item.escrita = str[i] + Environment.NewLine;
                        item.Add(Item);
                        cnt++;
                    }
                }
                else
                {
                    ItensDataSource Item = new ItensDataSource();
                    Item.status = "ERRO";
                    Item.linha = Convert.ToString(i + 1);
                    Item.tipo = "Erro de sintáxe";
                    Item.escrita = str[i] + Environment.NewLine;
                    item.Add(Item);
                    cnt++;
                }
            }
            dataGridView1_MouseHover();
        }
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            richTxtTexto.Text = "";
            dgvResultado.DataSource = null;
        }

        //bloqueia a seleção na posição 0 do datagridview
        private void dataGridView1_MouseHover()
        {
            this.dgvResultado.CurrentRow.Selected = false;
        }
    }
}