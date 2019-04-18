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
        public List<DepositoModelo> TableObjectDeposito { get; set; }
        public List<CargaDevoluçãoModelo> TableObjectCargaDevolução { get; set; }

        public int ResultID { get; set; }
        
        private string tableName;
        private string formName;

        private List<VendedorModelo> Vendedores { get; set; }
        private List<PessoaModelo> Pessoas { get; set; }
        private List<PraçaModelo> Praças { get; set; }

        public FrmProcura(string form, string table, List<string> parameters)
        {
            InitializeComponent();

            btOk.Enabled = false;

            cbbColunaPesquisa.Items.Clear();
            cbbColunaPesquisa.Items.Add("ID");
            for (int i = 0; i < parameters.Count; i++)
            {
                if (table == "Deposito")
                {
                    if(parameters[i] == "VendedorId")
                    {
                        cbbColunaPesquisa.Items.Add("Nome");
                    }
                }

                if (table == "CargaDevolução")
                {
                    if (parameters[i] == "VendedorID")
                    {
                        cbbColunaPesquisa.Items.Add("Nome");
                    }
                    else
                    {
                        if (parameters[i] == "PraçaID")
                        {
                            cbbColunaPesquisa.Items.Add("Praça");
                        }
                    }
                }
                cbbColunaPesquisa.Items.Add(parameters[i]);
            }

            cbbColunaPesquisa.SelectedIndex = 1;
            if(table == "Pessoa")
            {
                cbbColunaPesquisa.SelectedIndex = 2;
            }

            cbbQuery.SelectedItem = "Começa com";

            tableName = table;
            formName = form;
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

        private string ReturnQuery(string parameter)
        {
            string result = "";

            switch (cbbQuery.SelectedItem)
            {
                case "Igual a":
                    result = "where " + parameter + " = '" + txtQuery.Text + "'";
                    break;
                case "Começa com":
                    result = "where " + parameter + " like '" + txtQuery.Text + "%'";
                    break;
                case "Termina com":
                    result = "where " + parameter + " like '%" + txtQuery.Text + "'";
                    break;
                case "Contém":
                    result = "where " + parameter + " like '%" + txtQuery.Text + "%'";
                    break;
                default:
                    result = "";
                    break;
            }

            return result;
        }

        private string ReturnQuery(string parameter, string query)
        {
            string result = "";

            switch (cbbQuery.SelectedItem)
            {
                case "Igual a":
                    result = "where " + parameter + " = '" + query + "'";
                    break;
                case "Começa com":
                    result = "where " + parameter + " like '" + query + "%'";
                    break;
                case "Termina com":
                    result = "where " + parameter + " like '%" + query + "'";
                    break;
                case "Contém":
                    result = "where " + parameter + " like '%" + query + "%'";
                    break;
                default:
                    result = "";
                    break;
            }

            return result;
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            string query = "";
            switch (tableName)
            {
                case "Pessoa":
                    query = ReturnQuery();
                    if (formName == "FrmPedidos")
                    {
                        query += " and Ativo == 1 and Cliente == 1";
                    }
                    else if (formName == "FrmVendedores")
                    {
                        query += " and Ativo == 1 and Cliente == 0";
                    }

                    TableObjectPessoa = SqliteAcessoDados.GetPesquisarTodos<PessoaModelo>(query, tableName);
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
                case "Deposito":
                    dgvResultados.Columns.Clear();

                    TableObjectDeposito = new List<DepositoModelo>();
                    Pessoas = new List<PessoaModelo>();
                    Vendedores = new List<VendedorModelo>();

                    dgvResultados.Columns.Add("Nome", "Nome");

                    if (cbbColunaPesquisa.SelectedItem.ToString() == "Nome")
                    {

                        Pessoas = SqliteAcessoDados.GetPesquisarTodos<PessoaModelo>(ReturnQuery(), "Pessoa");

                        foreach (PessoaModelo pessoa in Pessoas)
                        {
                            if (SqliteAcessoDados.RegistroExiste<VendedorModelo>("PessoaID", pessoa.Id.ToString()))
                            {
                                Vendedores.Add(SqliteAcessoDados.LoadQuery<VendedorModelo>("select * from Vendedor where Vendedor.PessoaID == " + pessoa.Id).First());
                            }
                        }

                        List<DepositoModelo> depositos = new List<DepositoModelo>();

                        foreach (VendedorModelo vendedor in Vendedores)
                        {
                            depositos = SqliteAcessoDados.LoadQuery<DepositoModelo>("select * from Deposito where Deposito.VendedorID == " + vendedor.Id);

                            foreach (DepositoModelo deposito in depositos)
                            {
                                TableObjectDeposito.Add(deposito);
                            }
                        }
                    }
                    else
                    {
                        TableObjectDeposito = SqliteAcessoDados.GetPesquisarTodos<DepositoModelo>(ReturnQuery(), tableName);
                    }

                    dgvResultados.DataSource = TableObjectDeposito;

                    for (int i = 0; i < TableObjectDeposito.Count; i++)
                    {
                        foreach (VendedorModelo vendedor in Vendedores)
                        {
                            if (dgvResultados.Rows[i].Cells["VendedorId"].Value.ToString() == vendedor.Id.ToString())
                            {
                                foreach (PessoaModelo pessoa in Pessoas)
                                {
                                    if (pessoa.Id == vendedor.PessoaId)
                                    {
                                        dgvResultados.Rows[i].Cells["Nome"].Value = pessoa.Nome;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }

                    break;
                case "CargaDevolução":
                    dgvResultados.Columns.Clear();

                    TableObjectCargaDevolução = new List<CargaDevoluçãoModelo>();
                    Pessoas = new List<PessoaModelo>();
                    Vendedores = new List<VendedorModelo>();
                    Praças = new List<PraçaModelo>();

                    dgvResultados.Columns.Add("Nome", "Nome");
                    dgvResultados.Columns.Add("Praça", "Praça");

                    if (cbbColunaPesquisa.SelectedItem.ToString() == "Nome")
                    {
                        Pessoas = SqliteAcessoDados.GetPesquisarTodos<PessoaModelo>(ReturnQuery(), "Pessoa");

                        foreach (PessoaModelo pessoa in Pessoas)
                        {
                            if (SqliteAcessoDados.RegistroExiste<VendedorModelo>("PessoaID", pessoa.Id.ToString()))
                            {
                                Vendedores.Add(SqliteAcessoDados.LoadQuery<VendedorModelo>("select * from Vendedor where Vendedor.PessoaID == " + pessoa.Id).First());
                            }
                        }

                        List<CargaDevoluçãoModelo> cargaDevoluçãoList = new List<CargaDevoluçãoModelo>();

                        foreach (VendedorModelo vendedor in Vendedores)
                        {
                            cargaDevoluçãoList = SqliteAcessoDados.LoadQuery<CargaDevoluçãoModelo>("select * from CargaDevolução where CargaDevolução.VendedorID == " + vendedor.Id);

                            foreach (CargaDevoluçãoModelo cargaDevolução in cargaDevoluçãoList)
                            {
                                TableObjectCargaDevolução.Add(cargaDevolução);
                            }
                        }

                        Praças = SqliteAcessoDados.GetPesquisarTodos<PraçaModelo>(ReturnQuery("ID", ""));
                    }
                    else
                    {
                        if (cbbColunaPesquisa.SelectedItem.ToString() == "Praça")
                        {

                            Praças = SqliteAcessoDados.GetPesquisarTodos<PraçaModelo>(ReturnQuery("Nome"), "Praça");

                            List<VendedorPraçaModelo> vendedorPraçaList = new List<VendedorPraçaModelo>();

                            foreach (PraçaModelo praça in Praças)
                            {
                                vendedorPraçaList = SqliteAcessoDados.LoadQuery<VendedorPraçaModelo>("select * from VendedorPraça where VendedorPraça.PraçaID == " + praça.Id);

                                foreach (VendedorPraçaModelo vendedorPraça in vendedorPraçaList)
                                {
                                    if (Vendedores.Find(r => r.Id == vendedorPraça.VendedorId) == null) {
                                        Vendedores.Add(SqliteAcessoDados.LoadQuery<VendedorModelo>("select * from Vendedor where Vendedor.ID == " + vendedorPraça.VendedorId).First());
                                    }
                                }
                            }

                            List<CargaDevoluçãoModelo> cargaDevoluçãoList = new List<CargaDevoluçãoModelo>();

                            foreach (PraçaModelo praça in Praças)
                            {
                                cargaDevoluçãoList = SqliteAcessoDados.LoadQuery<CargaDevoluçãoModelo>("select * from CargaDevolução where CargaDevolução.PraçaID == " + praça.Id);

                                foreach (CargaDevoluçãoModelo cargaDevolução in cargaDevoluçãoList)
                                {
                                    TableObjectCargaDevolução.Add(cargaDevolução);
                                }
                            }

                            Pessoas = SqliteAcessoDados.GetPesquisarTodos<PessoaModelo>(ReturnQuery("ID", ""));
                        }
                        else
                        {
                            TableObjectCargaDevolução = SqliteAcessoDados.GetPesquisarTodos<CargaDevoluçãoModelo>(ReturnQuery(), tableName);
                        }
                    }

                    dgvResultados.DataSource = TableObjectCargaDevolução;

                    for (int i = 0; i < TableObjectCargaDevolução.Count; i++)
                    {
                        foreach (VendedorModelo vendedor in Vendedores)
                        {
                            if (dgvResultados.Rows[i].Cells["VendedorId"].Value.ToString() == vendedor.Id.ToString())
                            {
                                foreach (PessoaModelo pessoa in Pessoas)
                                {
                                    if (pessoa.Id == vendedor.PessoaId)
                                    {
                                        dgvResultados.Rows[i].Cells["Nome"].Value = pessoa.Nome;
                                        break;
                                    }
                                }
                                break;
                            }
                        }

                        foreach (PraçaModelo praça in Praças)
                        {
                            if(dgvResultados.Rows[i].Cells["PraçaID"].Value.ToString() == praça.Id.ToString())
                            {
                                dgvResultados.Rows[i].Cells["Praça"].Value = praça.Nome;
                            }
                        }
                    }

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
