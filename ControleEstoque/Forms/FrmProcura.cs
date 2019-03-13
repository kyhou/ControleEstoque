using ControleEstoqueLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FrmProcura: Form
    {
        public List<PessoaModelo> TableObjectPessoa { get; set; }
        public List<PraçaModelo> TableObjectPraça { get; set; }
        public List<VendedorModelo> TableObjectVendedor { get; set; }
        public List<ProdutoModelo> TableObjectProduto { get; set; }
        public List<PedidoModelo> TableObjectPedido { get; set; }
        public List<ItemModelo> TableObjectItem { get; set; }

        public int ResultID { get; set; }
        
        private string tableName;

        public FrmProcura(string table, List<string> parameters)
        {
            InitializeComponent();

            btOk.Enabled = false;

            cbbColunaPesquisa.Items.Clear();
            cbbColunaPesquisa.Items.Add("ID");
            for (int i = 0; i < parameters.Count; i++)
            {
                cbbColunaPesquisa.Items.Add(parameters[i]);
            }            
            cbbColunaPesquisa.SelectedIndex = 1;
            cbbQuery.SelectedItem = "Começa com";

            tableName = table;
        }

        private string ReturnQuery()
        {
            string result = "";

            switch (cbbQuery.SelectedItem)
            {
                case "Igual a":
                    result = "where " + cbbColunaPesquisa.SelectedItem + " = '" + txtQuery.Text + "'";
                    break;
                case "Começa com":
                    result = "where " + cbbColunaPesquisa.SelectedItem + " like '" + txtQuery.Text + "%'";
                    break;
                case "Termina com":
                    result = "where " + cbbColunaPesquisa.SelectedItem + " like '%" + txtQuery.Text + "'";
                    break;
                case "Contém":
                    result = "where " + cbbColunaPesquisa.SelectedItem + " like '%" + txtQuery.Text + "%'";
                    break;
                default:
                    result = "";
                    break;
            }

            return result;
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            switch (tableName)
            {
                case "Pessoa":
                    TableObjectPessoa = SqliteAcessoDados.GetPesquisarTodos<PessoaModelo>(ReturnQuery(), tableName);
                    dgvResultados.DataSource = TableObjectPessoa;
                    break;
                case "Praça":
                    TableObjectPraça = SqliteAcessoDados.GetPesquisarTodos<PraçaModelo>(ReturnQuery(), tableName);
                    dgvResultados.DataSource = TableObjectPraça;
                    break;
                case "Vendedor":
                    TableObjectVendedor = SqliteAcessoDados.GetPesquisarTodos<VendedorModelo>(ReturnQuery(), tableName);
                    dgvResultados.DataSource = TableObjectVendedor;
                    dgvResultados.Columns.Add("NomePessoa", "Nome Pessoa");

                    for (int i = 0; i < TableObjectVendedor.Count; i++)
                    {
                        dgvResultados.Rows[i].Cells["NomePessoa"].Value = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Nome from Pessoa where Pessoa.ID == " + TableObjectVendedor[i].PessoaId)[0].Nome;
                    }
                    
                    break;
                case "Produto":
                    TableObjectProduto = SqliteAcessoDados.GetPesquisarTodos<ProdutoModelo>(ReturnQuery(), tableName);
                    dgvResultados.DataSource = TableObjectProduto;
                    break;
                case "Pedido":
                    TableObjectPedido = SqliteAcessoDados.GetPesquisarTodos<PedidoModelo>(ReturnQuery(), tableName);
                    dgvResultados.DataSource = TableObjectPedido;
                    break;
                case "Item":
                    TableObjectItem = SqliteAcessoDados.GetPesquisarTodos<ItemModelo>(ReturnQuery(), tableName);
                    dgvResultados.DataSource = TableObjectItem;
                    break;
                default:
                    break;
            }

            if (dgvResultados.CurrentCell == null)
            {
                btOk.Enabled = false;
            }
            else
            {
                btOk.Enabled = true;
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentCell != null)
            {
                ResultID = dgvResultados.CurrentCell.RowIndex;
            }

            this.Close();
        }
    }
}
