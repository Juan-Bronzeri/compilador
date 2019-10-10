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
        Regex ER = new Regex(@"(^(inteiro|decimal|texto|booleano)+(\s)+(([A-Za-z]{1})+[\w]{0,25})+(" + x + ")$)", RegexOptions.None);
        public Analizador()
        {
            this.MinimumSize = new System.Drawing.Size(413, 305);
            InitializeComponent();
        }

        private void Compilar_Click(object sender, EventArgs e)
        {
            dgvResultado.DataSource = null;
            item.Clear();

            int cnt = 0;
            string[] aux;

            string[] str = richTxtTexto.Text.Split('\n');

            Hashtable tipo = new Hashtable();

            for (int i = 0; i < str.Length; i++)
            {

                str[i] = str[i].Replace("\n", "");

                str[i] = Regex.Replace(str[i], " ", "", RegexOptions.IgnoreCase);
                int x = str[i].Length;

                aux = str[i].Replace(";", "").Split(' ');

                if (aux.Length >= 2)
                {
                    if (aux[1] != "booleano" && aux[1] != "texto" && aux[1] != "inteiro" && aux[1] != "decimal")
                    {
                        if (aux.Length == 2)
                        {
                            if (ER.IsMatch(str[i]) != true && aux[1].Length > 10)
                            {
                                ItensDataSource Item = new ItensDataSource();
                                Item.status = "ERRO";
                                Item.linha = Convert.ToString(i + 1);
                                Item.tipo = "Erro de sintáxe e truncamento";
                                Item.escrita = str[i] + Environment.NewLine;
                                item.Add(Item);
                                cnt++;
                            }
                            else if (ER.IsMatch(str[i]) != true)
                            {
                                ItensDataSource Item = new ItensDataSource();
                                Item.status = "ERRO";
                                Item.linha = Convert.ToString(i + 1);
                                Item.tipo = "Erro de sintáxe ";
                                Item.escrita = str[i] + Environment.NewLine;
                                item.Add(Item);
                                cnt++;
                            }
                            else if (aux[1].Length > 10)
                            {
                                ItensDataSource Item = new ItensDataSource();
                                Item.status = "ERRO";
                                Item.linha = Convert.ToString(i + 1);
                                Item.tipo = "Erro de truncamento ";
                                Item.escrita = str[i] + Environment.NewLine;
                                item.Add(Item);
                                cnt++;
                            }
                            else if (ER.IsMatch(str[i]) == true && tipo.ContainsKey(aux[1]))
                            {
                                ItensDataSource Item = new ItensDataSource();
                                Item.status = "ERRO";
                                Item.linha = Convert.ToString(i + 1);
                                Item.tipo = "Erro de variavel já definida ";
                                Item.escrita = str[i] + Environment.NewLine;
                                item.Add(Item);
                                cnt++;
                            }
                            else
                            {
                                tipo[aux[1]] = "";
                            }
                        }
                        else if (aux.Length > 2)
                        {
                            ItensDataSource Item = new ItensDataSource();
                            Item.status = "ERRO";
                            Item.linha = Convert.ToString(i + 1);
                            Item.tipo = "Erro, tentando declarar mais de uma variável na mesma linha";
                            Item.escrita = str[i] + Environment.NewLine;
                            item.Add(Item);
                            cnt++;
                        }
                        else
                        {
                            ItensDataSource Item = new ItensDataSource();
                            Item.status = "ERRO";
                            Item.linha = Convert.ToString(i + 1);
                            Item.tipo = "Erro de sintáxe, não existe um nome para a variavel";
                            Item.escrita = str[i] + Environment.NewLine;
                            item.Add(Item);
                            cnt++;
                        }
                    }
                }
                else
                {
                    ItensDataSource Item = new ItensDataSource();
                    Item.status = "ERRO";
                    Item.linha = Convert.ToString(i + 1);
                    Item.tipo = "Erro, nome da váriavel incorreto";
                    Item.escrita = str[i] + Environment.NewLine;
                    item.Add(Item);
                    cnt++;
                }
                if (cnt == 0)
                {
                    if (str.Length == 1)
                    {
                        dgvResultado.AutoResizeColumns();
                        ItensDataSource Item = new ItensDataSource();
                        Item.status = "Compilado";
                        item.Add(Item);
                        dgvResultado.ForeColor = Color.Black;
                        dgvResultado.DataSource = item;
                    }
                }
                else
                {
                    dgvResultado.AutoResizeColumns();
                    dgvResultado.ForeColor = Color.Red;
                    dgvResultado.DataSource = item;
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