using System;
using System.Collections.Generic;
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
            terminador = Convert.ToString(terminador[terminador.Length - 1]);
            string aux = StaticTerminador.GetTerminador();
            if (terminador == ""+aux+"")
                retornar = true;
            return retornar;
        }

        bool autenticarVariavel(string variavel)
        {
            bool retornar = false;
            if (AutenticarTamanhoVariavel(variavel, StaticTamanhoVariavel.GetTamanhoVariavel()) && autenticarPalavraDaVariavel(variavel))
                retornar = true;
            return retornar;
        }

        bool AutenticarTamanhoVariavel(string variavel, int tamanho)
        {
            bool retornar = false;
            if (variavel.Length > 0 && variavel.Length < tamanho)
                retornar = true;
            return retornar;
        }

        bool autenticarPalavraDaVariavel(string variavel)
        {
            bool retornar = false;
            Regex var = new Regex(@"[A-Z]+|[a-z]+|[_]");
            string x = Convert.ToString(variavel[0]);
            if (var.IsMatch(x) == true)
                retornar = true;
            return retornar;
        }
        private void Compilar_Click(object sender, EventArgs e)
        {
            dgvResultado.DataSource = null;
            item.Clear();

            string[] aux;
            int i = 1;

            string[] str = richTxtTexto.Text.Split('\n');
            if(str[0] == "var")
            {
                while (str[i] != "begin")
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
                                aux = aux[aux.Length - 1].Split(';');
                                for (int x = 0; x < aux.Length; x++)
                                {
                                    if (aux[x] == "")
                                    {
                                        aux[x] = null;
                                    }
                                }
                                for (int x = 0; x < aux.Length; x++)
                                {
                                    if (aux[x] != null)
                                    {
                                        if (!autenticarVariavel(aux[x]))
                                        {
                                            ItensDataSource Item = new ItensDataSource();
                                            Item.status = "ERRO";
                                            Item.linha = Convert.ToString(i + 1);
                                            Item.tipo = "Erro, variavel inválida";
                                            Item.escrita = str[i] + Environment.NewLine;
                                            item.Add(Item);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ItensDataSource Item = new ItensDataSource();
                                Item.status = "ERRO";
                                Item.linha = Convert.ToString(i + 1);
                                Item.tipo = "Erro, terminador inválido";
                                Item.escrita = str[i] + Environment.NewLine;
                                item.Add(Item);
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
                    }
                    i++;
                }
                if(str[i] == "begin")
                {
                    while (str[i] != "end" | str.Length < i)
                    {
                        if (str[i] != "begin")
                        {
                            Regex ER2 = new Regex(@"[0-9]+");
                            Regex ER = new Regex(@"^(|(\s+))[A-Za-z]{1}[\w]{0,24}(|(\s+))(=){1}(|(\s+))(([A-Za-z]{1}[A-Za-z0-9]{0,24})|[0-9]{1,11}|[0-9]{1,11}\.[0-9]{1,2}){1}(|(\s+))((\|\-|\+|\/){1}(|(\s+))(([A-Za-z]{1}[A-Za-z0-9]{0,24})|[0-9]{1,11}|[0-9]{1,11}\.[0-9]{1,2}){1}(|(\s+)))*(((\W){1})|(\s+(\W){1}))|(\s+)$");
                            str[i] = str[i].Replace("\n", "");
                            str[i] = str[i].Trim();
                            if (ER.IsMatch(str[i]) == true)
                            {
                                aux = str[i].Split(' ');
                                if (autenticarTerminador(aux[aux.Length - 1]))
                                {
                                    char a = Convert.ToChar(StaticTerminador.GetTerminador());
                                    aux = str[i].Split('+', '*', '/', '-', '=', a);
                                    for (int x = 0; x < aux.Length; x++)
                                    {
                                        aux[x].Trim();
                                        if (aux[x] != "" && ER2.IsMatch(aux[x]) == true)
                                        {
                                            if (!autenticarVariavel(aux[x]))
                                            {
                                                ItensDataSource Item = new ItensDataSource();
                                                Item.status = "ERRO";
                                                Item.linha = Convert.ToString(i + 1);
                                                Item.tipo = "Erro, variavel inválida";
                                                Item.escrita = str[i] + Environment.NewLine;
                                                item.Add(Item);
                                            }
                                        }
                                    }
                                    
                                }
                                else
                                {
                                    ItensDataSource Item = new ItensDataSource();
                                    Item.status = "ERRO";
                                    Item.linha = Convert.ToString(i + 1);
                                    Item.tipo = "Erro, terminador inválido";
                                    Item.escrita = str[i] + Environment.NewLine;
                                    item.Add(Item);
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
                            }
                        }
                        i++;
                        if (str[i] == "end")
                            break;
                    }
                }  
            }
            else
            {
                ItensDataSource Item = new ItensDataSource();
                Item.status = "ERRO";
                Item.linha = Convert.ToString(i);
                Item.tipo = "Erro, precisa declarar o inializador das variaveis";
                Item.escrita = str[i-1];
                item.Add(Item);
            }
            if (item.Count <= 0)
            {
                ItensDataSource Item = new ItensDataSource();
                Item.status = "Compilado";
                item.Add(Item);
                dgvResultado.DataSource = item;
            }
            else
                dgvResultado.DataSource = item;
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
            dgvResultado.CurrentRow.Selected = false;
        }

        private void terminador_Click(object sender, EventArgs e)
        {
            FormTerminador form = new FormTerminador();
            form.Show(); 
        }

        private void btnVariavel_Click(object sender, EventArgs e)
        {
            FormVariavel form = new FormVariavel();
            form.Show();
        }
    }
}