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
    public partial class FrmCargaDevolução : Form
    {
        public List<CargaDevoluçãoModelo> CargaDevoluções { get; set; }
        public CargaDevoluçãoModelo ResultadoPesquisaCargaDevolução { get; set; }
        public VendedorModelo ResultadoPesquisaVendedor { get; set; }
        public ProdutoModelo ResultadoPesquisaProduto { get; set; }
        public PessoaModelo ResultadoPesquisaPessoa { get; set; }
        public ProdutosCargaDevoluçãoModelo ResultadoProdutosCargaDevolução { get; set; }
        public List<ProdutosCargaDevoluçãoModelo> ProdutosCargaDevoluçãoList { get; set; }

        private bool isEditing = false;
        private int _atualID;

        private int AtualID
        {
            get { return _atualID; }
            set
            {
                _atualID = value;
                ShowSelected(CargaDevoluções[value]);
            }
        }

        List<string> CargaDevoluçãoParameters = new List<string>
        {
            "VendedorID", "PraçaID", "Data", "Devolução"
        };

        List<string> ProdutosCargaDevoluçãoParameters = new List<string>
        {
            "CargaDevoluçãoID", "ProdutoID", "Quantidade"
        };

        List<string> VendedorParameters = new List<string>
        {
            "PessoaID", "Placa", "CNH"
        };

        public FrmCargaDevolução()
        {
            InitializeComponent();
            DesativarCampos();
            btPesquisar.Enabled = true;
            btAdd.Enabled = true;

            ProdutosCargaDevoluçãoList = new List<ProdutosCargaDevoluçãoModelo>();
        }

        private void ShowSelected(CargaDevoluçãoModelo modelo)
        {
            dgvProdutos.Rows.Clear();

            txtID.Text = modelo.Id.ToString();
            txtIdVendedor.Text = modelo.VendedorID.ToString();

            VendedorModelo vendedor = SqliteAcessoDados.LoadQuery<VendedorModelo>("select * from Vendedor where Vendedor.ID == " + modelo.VendedorID.ToString())[0];
            PessoaModelo pessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select * from Pessoa where Pessoa.ID == " + vendedor.PessoaId.ToString())[0];
            List<VendedorPraçaModelo> vendedorPraçaList = SqliteAcessoDados.LoadQuery<VendedorPraçaModelo>("select * from VendedorPraça where VendedorPraça.VendedorID == " + modelo.VendedorID.ToString());

            foreach (VendedorPraçaModelo vendedorPraça in vendedorPraçaList)
            {
                PraçaModelo praça = SqliteAcessoDados.LoadQuery<PraçaModelo>("select * from Praça where Praça.ID == " + vendedorPraça.PraçaId.ToString()).First();
                cbbPraça.Items.Add(praça.Id + " - " + praça.Nome);
                if (praça.Id == modelo.PraçaID)
                {
                    cbbPraça.SelectedIndex = cbbPraça.Items.Count - 1;
                }
            }

            txtNomeVendedor.Text = pessoa.Nome;
            txtPlaca.Text = vendedor.Placa;
            cbbDevolução.SelectedIndex = modelo.Devolução ? 0 : 1;
            txtData.Text = modelo.Data.ToShortDateString();

            ProdutosCargaDevoluçãoList = SqliteAcessoDados.LoadQuery<ProdutosCargaDevoluçãoModelo>("select * from ProdutosCargaDevolução where ProdutosCargaDevolução.CargaDevoluçãoID == " + modelo.Id.ToString());

            foreach (ProdutosCargaDevoluçãoModelo item in ProdutosCargaDevoluçãoList)
            {
                BuscaProdutoFK(item.ProdutoID, out string produtoNome);
                dgvProdutos.Rows.Add(item.ProdutoID, produtoNome, item.Quantidade);
            }
        }


        private bool Validation()
        {
            bool result = false;

            errorProvider.Clear();

            //errorProvider.SetIconAlignment(txtPontoReferencia, ErrorIconAlignment.MiddleRight);

            //bool teste = txtPontoReferencia.Text.Any(c => char.IsDigit(c));

            /*if (txtNomePessoa.Text == "")
            {
                errorProvider.SetError(txtNomePessoa, "Campo Obrigatório");
                result = true;
            }

            if (dgvPraças.Rows.Count == 0)
            {
                errorProvider.SetError(dgvPraças, "Campo Obrigatório");
                result = true;
            }

            if (txtPlaca.Text == "")
            {
                errorProvider.SetError(txtPlaca, "Campo Obrigatório");
                result = true;
            }*/


            /*********************
             * ADD VALIDAÇÂO CNH *
             *********************/

            return result;
        }


        private void DesativarCampos()
        {
            txtPlaca.Enabled = false;
            txtNomeVendedor.Enabled = false;
            dgvProdutos.Enabled = false;
            txtData.Enabled = false;
            cbbDevolução.Enabled = false;
            cbbPraça.Enabled = false;
            btPrimeiro.Enabled = false;
            btPesquisar.Enabled = false;
            btUltimo.Enabled = false;
            btProximo.Enabled = false;
            btAnterior.Enabled = false;
            btSalvar.Enabled = false;
            btLimpar.Enabled = false;
            btAdd.Enabled = false;
            btExcluir.Enabled = false;
            btAlterar.Enabled = false;
            btSearchVendedor.Enabled = false;
            btAddItem.Enabled = false;
            btRemoverItem.Enabled = false;
        }

        private void AtivarCampos()
        {
            dgvProdutos.Enabled = true;
            txtData.Enabled = true;
            cbbDevolução.Enabled = true;
            cbbPraça.Enabled = true;
            dgvProdutos.Enabled = true;
            btPrimeiro.Enabled = true;
            btPesquisar.Enabled = true;
            btUltimo.Enabled = true;
            btProximo.Enabled = true;
            btAnterior.Enabled = true;
            btSalvar.Enabled = true;
            btLimpar.Enabled = true;
            btAdd.Enabled = true;
            btExcluir.Enabled = true;
            btAlterar.Enabled = true;
            btSearchVendedor.Enabled = true;
            btAddItem.Enabled = true;
            btRemoverItem.Enabled = true;
        }

        private void LimparCampos()
        {
            errorProvider.Clear();
            txtID.Text = "";
            txtIdVendedor.Text = "";
            txtNomeVendedor.Text = "";
            txtData.Text = "";
            cbbDevolução.Text = "";
            cbbPraça.Items.Clear();
            cbbPraça.Text = "";
            dgvProdutos.Rows.Clear();
            txtPlaca.Text = "";
        }

        private CargaDevoluçãoModelo AddCargaDevolução()
        {
            CargaDevoluçãoModelo modelo = new CargaDevoluçãoModelo
            {
                VendedorID = int.Parse(txtIdVendedor.Text),
                PraçaID = int.Parse(cbbPraça.SelectedItem.ToString().Split('-').First()),
                Data = DateTime.Parse(txtData.Text),
                Devolução = cbbDevolução.SelectedIndex == 1
            };

            if (isEditing)
            {
                modelo.Id = int.Parse(txtID.Text);
            }

            return modelo;
        }

        private List<ProdutosCargaDevoluçãoModelo> AddProdutosCargaDevoluçãoModelo()
        {
            List<ProdutosCargaDevoluçãoModelo> produtosCargaDevoluções = new List<ProdutosCargaDevoluçãoModelo>();

            foreach (DataGridViewRow row in dgvProdutos.Rows)
            {
                produtosCargaDevoluções.Add(new ProdutosCargaDevoluçãoModelo
                {
                    CargaDevoluçãoID = int.Parse(txtID.Text),
                    ProdutoID = int.Parse(row.Cells["txtCodigo"].Value.ToString()),
                    Quantidade = int.Parse(row.Cells["txtQuantidade"].Value.ToString())
                });
            }

            return produtosCargaDevoluções;
        }

        private void BuscaPessoaFK(int idPessoa, out string nomePessoa)
        {
            nomePessoa = "";

            nomePessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Nome from Pessoa where ID = " + idPessoa)[0].Nome;
        }

        private void BuscaProdutoFK(int idProduto, out string descrição)
        {
            descrição = "";

            descrição = SqliteAcessoDados.LoadQuery<ProdutoModelo>("select Descrição from Produto where ID = " + idProduto)[0].Descrição;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            isEditing = false;
            VendedorModelo p = new VendedorModelo();

            AtivarCampos();

            btAlterar.Enabled = false;
            btExcluir.Enabled = false;
            btPesquisar.Enabled = false;
            btAnterior.Enabled = false;
            btAdd.Enabled = false;
            btUltimo.Enabled = false;
            btPrimeiro.Enabled = false;
            btProximo.Enabled = false;

            LimparCampos();

            int ID = SqliteAcessoDados.GetLastID("CargaDevolução");
            txtID.Text = (ID + 1).ToString();
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            string msg;

            if (!isEditing)
            {
                msg = "Deseja limpar todos os campos?";
            }
            else
            {
                msg = "Deseja cancelar a edição do registro?";
            }

            DialogResult result = MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DesativarCampos();
                btPesquisar.Enabled = true;
                btAdd.Enabled = true;

                if (!isEditing)
                {
                    LimparCampos();
                }
                else
                {
                    btAlterar.Enabled = true;
                    btExcluir.Enabled = true;

                    LimparCampos();
                    ShowSelected(CargaDevoluções[AtualID]);
                }

                isEditing = false;
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                string msg = "";
                if (isEditing)
                {
                    msg = "Você confirma a modificação do registro?";
                }
                else
                {
                    msg = "Você confirma a inclusão do registro?";
                }

                DialogResult result = MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (isEditing)
                    {
                        SqliteAcessoDados.UpdateQuery<CargaDevoluçãoModelo>(AddCargaDevolução(), "CargaDevolução", CargaDevoluçãoParameters);

                        ProdutoModelo produto = new ProdutoModelo();

                        foreach (ProdutosCargaDevoluçãoModelo produtosCargaDevolução in ProdutosCargaDevoluçãoList)
                        {
                            produto = SqliteAcessoDados.LoadQuery<ProdutoModelo>("select * from Produto where Produto.ID == " + produtosCargaDevolução.ProdutoID.ToString()).First();

                            if (cbbDevolução.SelectedItem.ToString() == "Carga")
                            {
                                produto.Estoque += produtosCargaDevolução.Quantidade;
                            }
                            else if (cbbDevolução.SelectedItem.ToString() == "Devolução")
                            {
                                produto.Estoque -= produtosCargaDevolução.Quantidade;
                            }

                            SqliteAcessoDados.ExcluirQuery(produtosCargaDevolução.CargaDevoluçãoID, "ProdutosCargaDevolução", "CargaDevoluçãoID");

                            SqliteAcessoDados.UpdateQuery<ProdutoModelo>(produto, "Produto", FrmProdutos.parameters);
                        }

                        ProdutosCargaDevoluçãoList = AddProdutosCargaDevoluçãoModelo();
                        foreach (ProdutosCargaDevoluçãoModelo produtosCargaDevolução in ProdutosCargaDevoluçãoList)
                        {
                            produto = SqliteAcessoDados.LoadQuery<ProdutoModelo>("select * from Produto where Produto.ID == " + produtosCargaDevolução.ProdutoID.ToString()).First();

                            if (cbbDevolução.SelectedItem.ToString() == "Carga")
                            {
                                produto.Estoque -= produtosCargaDevolução.Quantidade;
                            }
                            else if (cbbDevolução.SelectedItem.ToString() == "Devolução")
                            {
                                produto.Estoque += produtosCargaDevolução.Quantidade;
                            }

                            SqliteAcessoDados.SaveQuery<ProdutosCargaDevoluçãoModelo>(produtosCargaDevolução, "ProdutosCargaDevolução", ProdutosCargaDevoluçãoParameters);

                            SqliteAcessoDados.UpdateQuery<ProdutoModelo>(produto, "Produto", FrmProdutos.parameters);
                        }
                    }
                    else
                    {
                        SqliteAcessoDados.SaveQuery<CargaDevoluçãoModelo>(AddCargaDevolução(), "CargaDevolução", CargaDevoluçãoParameters);

                        ProdutosCargaDevoluçãoList = AddProdutosCargaDevoluçãoModelo();

                        ProdutoModelo produto = new ProdutoModelo();

                        foreach (ProdutosCargaDevoluçãoModelo produtosCargaDevolução in ProdutosCargaDevoluçãoList)
                        {
                            produto = SqliteAcessoDados.LoadQuery<ProdutoModelo>("select * from Produto where Produto.ID == " + produtosCargaDevolução.ProdutoID.ToString()).First();

                            if (cbbDevolução.SelectedItem.ToString() == "Carga")
                            {
                                produto.Estoque -= produtosCargaDevolução.Quantidade;
                            }
                            else if (cbbDevolução.SelectedItem.ToString() == "Devolução")
                            {
                                produto.Estoque += produtosCargaDevolução.Quantidade;
                            }

                            SqliteAcessoDados.SaveQuery<ProdutosCargaDevoluçãoModelo>(produtosCargaDevolução, "ProdutosCargaDevolução", ProdutosCargaDevoluçãoParameters);

                            SqliteAcessoDados.UpdateQuery<ProdutoModelo>(produto, "Produto", FrmProdutos.parameters);
                        }
                    }

                    DesativarCampos();
                    btAlterar.Enabled = true;
                    btExcluir.Enabled = true;
                    btPesquisar.Enabled = true;
                    btAdd.Enabled = true;

                    isEditing = false;
                }
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProcura(this.Name, "CargaDevolução", CargaDevoluçãoParameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CargaDevoluções = form.TableObjectCargaDevolução;
                    AtualID = form.ResultID;

                    btAlterar.Enabled = true;
                    btExcluir.Enabled = true;
                }
            }

            if (CargaDevoluções != null && CargaDevoluções.Count > 1)
            {
                btAnterior.Enabled = true;
                btUltimo.Enabled = true;
                btPrimeiro.Enabled = true;
                btProximo.Enabled = true;
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você confirma a exclusão do registro?", "Confirmar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ProdutoModelo produto = new ProdutoModelo();

                foreach (ProdutosCargaDevoluçãoModelo produtosCargaDevolução in ProdutosCargaDevoluçãoList)
                {
                    produto = SqliteAcessoDados.LoadQuery<ProdutoModelo>("select * from Produto where Produto.ID == " + produtosCargaDevolução.ProdutoID.ToString()).First();

                    if (cbbDevolução.SelectedItem.ToString() == "Carga")
                    {
                        produto.Estoque += produtosCargaDevolução.Quantidade;
                    }
                    else if (cbbDevolução.SelectedItem.ToString() == "Devolução")
                    {
                        produto.Estoque -= produtosCargaDevolução.Quantidade;
                    }

                    SqliteAcessoDados.ExcluirQuery(produtosCargaDevolução.CargaDevoluçãoID, "ProdutosCargaDevolução", "CargaDevoluçãoID");

                    SqliteAcessoDados.UpdateQuery<ProdutoModelo>(produto, "Produto", FrmProdutos.parameters);
                }

                SqliteAcessoDados.ExcluirQuery(int.Parse(txtID.Text), "CargaDevolução");

                LimparCampos();

                btAlterar.Enabled = false;
                btExcluir.Enabled = false;
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                isEditing = true;
                AtivarCampos();

                btAlterar.Enabled = false;
                btExcluir.Enabled = false;
                btPesquisar.Enabled = false;
                btAdd.Enabled = false;
                btAnterior.Enabled = false;
                btUltimo.Enabled = false;
                btPrimeiro.Enabled = false;
                btProximo.Enabled = false;
            }
        }

        private void btProximo_Click(object sender, EventArgs e)
        {
            if (CargaDevoluções.Count > (AtualID + 1))
            {
                AtualID++;
            }
        }

        private void btAnterior_Click(object sender, EventArgs e)
        {
            if (AtualID > 0)
            {
                AtualID--;
            }
        }

        private void btPrimeiro_Click(object sender, EventArgs e)
        {
            AtualID = 0;
        }

        private void btUltimo_Click(object sender, EventArgs e)
        {
            AtualID = CargaDevoluções.Count - 1;
        }

        private void btAddItem_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>
            {
                "Descrição", "Unidade", "Estoque", "PreçoCusto", "PreçoVenda"
            };

            using (var form = new FrmProcura(this.Name, "Produto", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ResultadoPesquisaProduto = form.TableObjectProduto[form.ResultID];

                    BuscaProdutoFK(ResultadoPesquisaProduto.Id, out string descrição);

                    bool produtoRepetido = false;

                    if (dgvProdutos.Rows != null)
                    {
                        foreach (DataGridViewRow row in dgvProdutos.Rows)
                        {
                            if (row.Cells["txtCodigo"].Value.ToString() == ResultadoPesquisaProduto.Id.ToString())
                            {
                                produtoRepetido = true;
                            }
                        }
                    }

                    if (!produtoRepetido)
                    {
                        dgvProdutos.Rows.Add(ResultadoPesquisaProduto.Id, descrição);
                    }
                    else
                    {
                        MessageBox.Show("Este Produto ja está incluso para este Registro.", "Atenção!", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btRemoverItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvProdutos.SelectedRows)
            {
                dgvProdutos.Rows.Remove(row);
            }
            dgvProdutos.ClearSelection();
        }

        private void btSearchVendedor_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>
            {
                "PessoaID", "Placa", "CNH"
            };

            using (var form = new FrmProcura(this.Name, "Vendedor", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ResultadoPesquisaVendedor = form.TableObjectVendedor[form.ResultID];

                    txtIdVendedor.Text = ResultadoPesquisaVendedor.Id.ToString();
                    txtNomeVendedor.Text = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Nome from Pessoa where Pessoa.ID == " + ResultadoPesquisaVendedor.PessoaId.ToString())[0].Nome;
                    txtPlaca.Text = ResultadoPesquisaVendedor.Placa;

                    //txtPraçaVendedor.Text = SqliteAcessoDados.LoadQuery<PraçaModelo>("select Nome from Praça where Praça.ID == " + ResultadoPesquisaCargaDevolução.PraçaId.ToString())[0].Nome;
                    //txtTelefoneVendedor.Text = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Telefone from Pessoa where Pessoa.ID == " + ResultadoPesquisaCargaDevolução.PessoaId.ToString())[0].Telefone.ToString();

                    List<VendedorPraçaModelo> vendedorPraça = SqliteAcessoDados.LoadQuery<VendedorPraçaModelo>("select * from VendedorPraça where VendedorPraça.VendedorID == " + ResultadoPesquisaVendedor.Id.ToString());

                    foreach (VendedorPraçaModelo modelo in vendedorPraça)
                    {
                        PraçaModelo praça = SqliteAcessoDados.LoadQuery<PraçaModelo>("select * from Praça where Praça.ID == " + modelo.PraçaId.ToString()).First();
                        cbbPraça.Items.Add(praça.Id + " - " + praça.Nome);
                    }
                }
            }
        }
    }
}