using System;
using System.Collections.Generic;
using System.Linq;
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
            MinimumSize = new System.Drawing.Size(413, 305);
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
            char aux = StaticTerminador.GetTerminador();
            if (terminador == ""+aux+"")
                retornar = true;
            return retornar;
        }

        bool autenticarVariavel(string variavel)
        {
            bool retornar = false;
            if (AutenticarTamanhoVariavel(variavel, StaticTamanhoVariavel.GetTamanhoVariavel()) & autenticarPalavraDaVariavel(variavel))
                retornar = true;
            return retornar;
        }

        bool AutenticarTamanhoVariavel(string variavel, int tamanho)
        {
            bool retornar = false;
            if (variavel.Length > 0 && variavel.Length <= tamanho)
                retornar = true;
            return retornar;
        }

        bool autenticarPalavraDaVariavel(string variavel)
        {
            bool retornar = false;
            Regex var = new Regex(@"[A-Z]+|[a-z]+|[_]");
            if(variavel != "")
            {
                string x = Convert.ToString(variavel[0]);
                if (var.IsMatch(x) == true)
                    retornar = true;
            }
            else
                retornar = true;
            return retornar;
        }

        public bool verifica(string texto)
        { 
            if (contemNumeros(texto))
                return true;
            return false;
        }

        public bool contemNumeros(string texto)
        {
            if (texto.Where(c => char.IsNumber(c)).Count() > 0)
                return true;
            else
                return false;
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
                while (str.Length > i && str[i] != "begin")
                {
                    str[i] = str[i].Replace("\n", "");
                    str[i] = str[i].Trim();
                    if (ER.IsMatch(str[i]) == true)
                    {
                        ItensDataSource Item = new ItensDataSource();
                        aux = str[i].Split(' ');
                        if (autenticarTipoVariavel(aux[0]))
                        {
                            if (autenticarTerminador(aux[aux.Length - 1]))
                            {
                                aux = aux[aux.Length - 1].Split(StaticTerminador.GetTerminador());
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
                                        if(!AutenticarTamanhoVariavel(aux[x], StaticTamanhoVariavel.GetTamanhoVariavel()))
                                        {
                                            Item.status = "ERRO";
                                            Item.linha = Convert.ToString(i + 1);
                                            Item.tipo = "Erro, variável muito grande";
                                            Item.escrita = str[i] + Environment.NewLine;
                                            item.Add(Item);
                                        }
                                        else if (!autenticarPalavraDaVariavel(aux[x]))
                                        {
                                            Item.status = "ERRO";
                                            Item.linha = Convert.ToString(i + 1);
                                            Item.tipo = "Erro, variável precisa começar com caractere";
                                            Item.escrita = str[i] + Environment.NewLine;
                                            item.Add(Item);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Item.status = "ERRO";
                                Item.linha = Convert.ToString(i + 1);
                                Item.tipo = "Erro, terminador inválido";
                                Item.escrita = str[i] + Environment.NewLine;
                                item.Add(Item);
                            }
                        }
                        else
                        {
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
                if(str.Length > i && str[i] == "begin")
                {
                    while (str.Length > i && str[i] != "end")
                    {
                        if (str[i] != "begin")
                        {
                            ItensDataSource Item = new ItensDataSource();
                            char terminador = StaticTerminador.GetTerminador();
                            Regex ER = new Regex(@"^(|(\s+))[A-Za-z]{1}[\w]{0,24}(|(\s+))(=){1}(|(\s+))(([A-Za-z]{1}[A-Za-z0-9]{0,24})|[0-9]{1,11}|[0-9]{1,11}\.[0-9]{1,2}){1}(|(\s+))((\\|\-|\+|\/){1}(|(\s+))(([A-Za-z]{1}[A-Za-z0-9]{0,24})|[0-9]{1,11}|[0-9]{1,11}\.[0-9]{1,2}){1}(|(\s+)))*((("+terminador+@"){1})|(\s+("+terminador+@"){1}))|(\s+)$");
                            str[i] = str[i].Replace("\n", "");
                            str[i] = str[i].Trim();
                            str[i] = str[i].Replace("(", "");
                            str[i] = str[i].Replace(")", "");
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
                                        if (!verifica(aux[x]) & aux[x] != "" & autenticarVariavel(aux[x]))
                                        {
                                            Item.status = "ERRO";
                                            Item.linha = Convert.ToString(i + 1);
                                            Item.tipo = "Erro, variavel inválida";
                                            Item.escrita = str[i] + Environment.NewLine;
                                            item.Add(Item);
                                        }
                                    }
                                }
                                else
                                {
                                    Item.status = "ERRO";
                                    Item.linha = Convert.ToString(i + 1);
                                    Item.tipo = "Erro, terminador inválido";
                                    Item.escrita = str[i] + Environment.NewLine;
                                    item.Add(Item);
                                }
                            }
                            else
                            {
                                if (str.Length == i+1)
                                {
                                    Item.status = "ERRO";
                                    Item.linha = Convert.ToString(i + 1);
                                    Item.tipo = "Erro de terminador 'end'";
                                    Item.escrita = str[i] + Environment.NewLine;
                                    item.Add(Item);
                                }
                                else
                                {
                                    Item.status = "ERRO";
                                    Item.linha = Convert.ToString(i + 1);
                                    Item.tipo = "Erro de sintáxe";
                                    Item.escrita = str[i] + Environment.NewLine;
                                    item.Add(Item);
                                }
                            }
                        }
                        i++;
                        if (str.Length < i)
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