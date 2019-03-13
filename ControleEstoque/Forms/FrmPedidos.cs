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
    public partial class FrmPedidos : Form
    {
        public List<PedidoModelo> Pedidos { get; set; }
        public PedidoModelo ResultadoPesquisa { get; set; }
        public PessoaModelo ResultadoPesquisaPessoa { get; set; }
        public VendedorModelo ResultadoPesquisaVendedor { get; set; }
        public ProdutoModelo ResultadoPesquisaProduto { get; set; }
        public ItemModelo ResultadoPesquisaItem { get; set; }
        public List<ItemModelo> ItensList { get; set; }

        private bool isEditing = false;
        private int _atualID;

        private int AtualID
        {
            get { return _atualID; }
            set
            {
                _atualID = value;
                ShowSelected(Pedidos[value]);
            }
        }

        List<string> parameters = new List<string>
        {
            "PessoaID", "VendedorID", "PraçaID", "DataEmissão", "TotalUnidades", "TotalItens", "Comissão", "DataRetorno"
        };

        List<string> ItemParameters = new List<string>
        {
            "PedidoId", "ProdutoId", "Entregue", "Devolvido", "Vendido", "PreçoTotal"
        };

        public FrmPedidos()
        {
            InitializeComponent();

            DesativarCampos();
            btPesquisar.Enabled = true;
            btAdd.Enabled = true;
        }

        private void DesativarCampos()
        {
            txtNomePessoa.Enabled = false;
            txtRG.Enabled = false;
            txtCPF.Enabled = false;
            txtDataNascimento.Enabled = false;
            txtTelefone.Enabled = false;
            txtPontoReferencia.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtEstado.Enabled = false;

            dgvItens.Enabled = false;
            txtDataEmissão.Enabled = false;
            txtTotalItens.Enabled = false;
            txtTotalPeças.Enabled = false;
            txtDataRetorno.Enabled = false;
            txtComissão.Enabled = false;
            txtComissãoValor.Enabled = false;
            txtPreçoFinal.Enabled = false;
            btSearchPessoa.Enabled = false;
            btSearchVendedor.Enabled = false;

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
            btConfirmarVenda.Enabled = false;
            cbAtivo.Enabled = false;
            cbPraça.Enabled = false;
        }

        private void AtivarCampos()
        {
            /*txtNomePessoa.Enabled = true;
            txtRG.Enabled = true;
            txtCPF.Enabled = true;
            txtDataNascimento.Enabled = true;
            txtTelefone.Enabled = true;
            txtPontoReferencia.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cbAtivo.Enabled = true;*/

            dgvItens.Enabled = true;
            txtDataEmissão.Enabled = true;
            /*txtTotalItens.Enabled = true;
            txtTotalPeças.Enabled = true;*/
            txtDataRetorno.Enabled = true;
            txtComissão.Enabled = true;
            //txtComissãoValor.Enabled = true;
            //txtPreçoFinal.Enabled = true;
            btSearchPessoa.Enabled = true;
            btSearchVendedor.Enabled = true;

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
            btConfirmarVenda.Enabled = true;
            cbPraça.Enabled = true; 
        }

        private void LimparCampos()
        {
            errorProvider.Clear();
            txtID.Text = "";

            txtIdPessoa.Text = "";
            txtNomePessoa.Text = "";
            txtRG.Text = "";
            txtCPF.Text = "";
            txtDataNascimento.Text = "";
            txtTelefone.Text = "";
            txtPontoReferencia.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";

            dgvItens.Rows.Clear();

            txtDataEmissão.Text = "";
            txtDataRetorno.Text = "";
            txtIdVendedor.Text = "";
            txtNomeVendedor.Text = "";
            txtTelefoneVendedor.Text = "";
            //txtPraçaVendedor.Text = "";
            cbPraça.Items.Clear();
            txtTotalItens.Text = "";
            txtTotalPeças.Text = "";
            txtComissão.Text = "";
            txtComissãoValor.Text = "";
            txtPreçoFinal.Text = "";
            cbAtivo.Checked = false;
            cbPraça.Items.Clear();
        }

        private void ShowSelected(PedidoModelo modelo)
        {
            txtID.Text = modelo.Id.ToString();

            txtIdPessoa.Text = modelo.PessoaID.ToString();

            PessoaModelo pessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select * from Pessoa where Pessoa.ID == " + modelo.PessoaID.ToString())[0];
            txtNomePessoa.Text = pessoa.Nome;
            txtRG.Text = pessoa.RG;
            txtCPF.Text = pessoa.CPF;
            txtDataNascimento.Text = pessoa.Nascimento.ToShortDateString();
            txtTelefone.Text = pessoa.Telefone;
            txtPontoReferencia.Text = pessoa.PontoReferencia.ToString();
            txtEndereco.Text = pessoa.Endereco;
            txtNumero.Text = pessoa.Numero.ToString();
            txtBairro.Text = pessoa.Bairro;
            txtCidade.Text = pessoa.Cidade;
            txtEstado.Text = pessoa.Estado;
            cbAtivo.Checked = pessoa.Ativo;

            ItensList = SqliteAcessoDados.LoadQuery<ItemModelo>("select * from Item where Item.PedidoID == " + modelo.Id.ToString());

            RefreshItensList();

            txtDataEmissão.Text = modelo.DataEmissão.ToShortDateString();
            txtDataRetorno.Text = modelo.DataRetorno.ToShortDateString();
            txtIdVendedor.Text = modelo.VendedorID.ToString();

            VendedorModelo vendedor = SqliteAcessoDados.LoadQuery<VendedorModelo>("select * from Vendedor where Vendedor.ID == " + modelo.VendedorID.ToString())[0];
            pessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select * from Pessoa where Pessoa.ID == " + vendedor.PessoaId.ToString())[0];
            List<VendedorPraçaModelo> vendedorPraçaList = SqliteAcessoDados.LoadQuery<VendedorPraçaModelo>("select * from VendedorPraça where VendedorPraça.VendedorID == " + modelo.VendedorID.ToString());

            txtNomeVendedor.Text = pessoa.Nome;
            txtTelefoneVendedor.Text = pessoa.Telefone;

            foreach (VendedorPraçaModelo vendedorPraça in vendedorPraçaList)
            {
                PraçaModelo praça = SqliteAcessoDados.LoadQuery<PraçaModelo>("select * from Praça where Praça.ID == " + vendedorPraça.PraçaId.ToString()).First();
                cbPraça.Items.Add(praça.Id + " - " + praça.Nome);
                if (praça.Id == modelo.PraçaID)
                {
                    cbPraça.SelectedIndex = cbPraça.Items.Count - 1;
                }
            }

            txtTotalItens.Text = modelo.TotalItens.ToString();
            txtTotalPeças.Text = modelo.TotalUnidades.ToString();
            txtComissão.Text = modelo.Comissão.ToString();
            //txtComissãoValor.Text = "add logica";
        }

        private void RefreshItensList()
        {
            decimal valorTotalFinal = 0;

            ProdutoModelo produto = new ProdutoModelo();

            dgvItens.Rows.Clear();

            for (int i = 0; i < ItensList.Count; i++)
            {
                dgvItens.Rows.Add();
                dgvItens.Rows[i].Cells["txtIdProduto"].Value = ItensList[i].ProdutoId;

                produto = SqliteAcessoDados.LoadQuery<ProdutoModelo>("select * from Produto where Produto.ID == " + ItensList[i].ProdutoId)[0];

                dgvItens.Rows[i].Cells["txtDescrição"].Value = produto.Descrição;
                dgvItens.Rows[i].Cells["txtUnidade"].Value = produto.Unidade;
                dgvItens.Rows[i].Cells["txtEntregue"].Value = ItensList[i].Entregue;
                dgvItens.Rows[i].Cells["txtDevolvido"].Value = ItensList[i].Devolvido;
                dgvItens.Rows[i].Cells["txtVendido"].Value = ItensList[i].Vendido;
                dgvItens.Rows[i].Cells["txtPreçoVenda"].Value = string.Format("{0:C}", produto.PreçoVenda);
                dgvItens.Rows[i].Cells["txtPreçoTotalItem"].Value = string.Format("{0:C}", ItensList[i].PreçoTotal);

                valorTotalFinal += ItensList[i].PreçoTotal;
            }

            txtPreçoFinal.Text = string.Format("{0:C}", valorTotalFinal);
        }

        private bool Validation()
        {
            //int resultInt = 0;
            bool result = false;

            errorProvider.Clear();

            /*List<ItemModelo> Itens = new List<ItemModelo>();

            for (int i = 0; i < dgvItens.Rows.Count - 1; i++)
            {
                if (dgvItens.Rows[i].Cells["txtEntregue"].Value.ToString() == "")
                {
                    errorProvider.SetError(dgvItens, "");
                    result = true;
                }
            }*/
            /*
            

            //errorProvider.SetIconAlignment(txtPontoReferencia, ErrorIconAlignment.MiddleRight);

            //bool teste = txtPontoReferencia.Text.Any(c => char.IsDigit(c));

            if (txtCPF.Text.Length != 11)
            {
                errorProvider.SetError(txtCPF, "Valor informado não possui 11 caracteres");
                result = true;
            }
            else
            {
                if (FuncoesAuxiliares.ValidarCPF(txtCPF.Text))
                {
                    errorProvider.SetError(txtCPF, "Insira um CPF válido");
                    result = true;
                }
            }

            if (!DateTime.TryParse(txtDataNascimento.Text, out DateTime resultDate))
            {
                errorProvider.SetError(txtDataNascimento, "Insira uma data válida");
                result = true;
            }

            if (!int.TryParse(txtPontoReferencia.Text, out resultInt))
            {
                errorProvider.SetError(txtPontoReferencia, "Somente Números");
                result = true;
            }

            if (!int.TryParse(txtNumero.Text, out resultInt))
            {
                errorProvider.SetError(txtNumero, "Somente Números");
                result = true;
            }*/

            return result;
        }

        private PedidoModelo AddPedido()
        {
            PedidoModelo modelo = new PedidoModelo
            {
                Id = int.Parse(txtID.Text),
                PessoaID = int.Parse(txtIdPessoa.Text),
                VendedorID = int.Parse(txtIdVendedor.Text),
                PraçaID = int.Parse(cbPraça.SelectedItem.ToString().Split('-').First()),
                DataEmissão = DateTime.Parse(txtDataEmissão.Text),
                TotalUnidades = int.Parse(txtTotalPeças.Text),
                TotalItens = int.Parse(txtTotalItens.Text),
                Comissão = float.Parse(txtComissão.Text),
                DataRetorno = DateTime.Parse(txtDataRetorno.Text)
            };

            if (isEditing)
            {
                modelo.Id = int.Parse(txtID.Text);
            }

            return modelo;
        }

        private List<ItemModelo> AddItens()
        {
            List<ItemModelo> Itens = new List<ItemModelo>();

            for (int i = 0; i < dgvItens.Rows.Count - 1; i++)
            {
                Itens.Add(new ItemModelo()
                {
                    PedidoId = int.Parse(txtID.Text),
                    ProdutoId = int.Parse(dgvItens.Rows[i].Cells["txtIdProduto"].Value.ToString()),
                    Entregue = int.Parse(dgvItens.Rows[i].Cells["txtEntregue"].Value.ToString()),   
                    Devolvido = int.Parse(dgvItens.Rows[i].Cells["txtDevolvido"].Value.ToString()),
                    Vendido = int.Parse(dgvItens.Rows[i].Cells["txtVendido"].Value.ToString()),
                    PreçoTotal = decimal.Parse(dgvItens.Rows[i].Cells["txtPreçoTotalItem"].Value.ToString().Replace("R$ ", ""))
                });
            }

            return Itens;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            isEditing = false;
            PedidoModelo p = new PedidoModelo();

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

            int ID = SqliteAcessoDados.GetLastID("Pedido");
            txtID.Text = (ID + 1).ToString();

            txtDataEmissão.Text = DateTime.Now.Date.ToShortDateString();
            txtComissão.Text = "20";
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
                    LimparCampos();
                    ShowSelected(Pedidos[AtualID]);
                    btAlterar.Enabled = true;
                    btExcluir.Enabled = true;
                }

                isEditing = false;
            }

            if (Pedidos != null && Pedidos.Count > 1)
            {
                btAnterior.Enabled = true;
                btUltimo.Enabled = true;
                btPrimeiro.Enabled = true;
                btProximo.Enabled = true;
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
                        SqliteAcessoDados.UpdateQuery<PedidoModelo>(AddPedido(), "Pedido", parameters);

                        foreach (ItemModelo item in ItensList)
                        {
                            SqliteAcessoDados.ExcluirQuery(item.PedidoId, "Item", "PedidoId");
                        }

                        ItensList = AddItens();
                        foreach (ItemModelo item in ItensList)
                        {
                            SqliteAcessoDados.SaveQuery<ItemModelo>(item, "Item", ItemParameters);
                        }
                    }
                    else
                    {
                        SqliteAcessoDados.SaveQuery<PedidoModelo>(AddPedido(), "Pedido", parameters);

                        ItensList = AddItens();
                        foreach (ItemModelo item in ItensList)
                        {
                            SqliteAcessoDados.SaveQuery<ItemModelo>(item, "Item", ItemParameters);
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

            if (Pedidos != null && Pedidos.Count > 1)
            {
                btAnterior.Enabled = true;
                btUltimo.Enabled = true;
                btPrimeiro.Enabled = true;
                btProximo.Enabled = true;
            }
        }

        private void btPesquisa_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProcura("Pedido", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Pedidos = form.TableObjectPedido;
                    AtualID = form.ResultID;

                    btAlterar.Enabled = true;
                    btExcluir.Enabled = true;
                }
            }

            if (Pedidos != null && Pedidos.Count > 1)
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
                SqliteAcessoDados.ExcluirQuery(int.Parse(txtID.Text), "Pedido");

                foreach (DataGridViewRow row in dgvItens.Rows)
                {
                    SqliteAcessoDados.ExcluirQuery(int.Parse(txtID.Text), "Item", "PedidoId");
                }

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
            if (Pedidos.Count > (AtualID + 1))
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
            AtualID = Pedidos.Count - 1;
        }

        private void btSearchVendedor_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>
            {
                "PessoaID", "Placa", "CNH"
            };

            using (var form = new FrmProcura("Vendedor", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ResultadoPesquisaVendedor = form.TableObjectVendedor[form.ResultID];

                    txtIdVendedor.Text = ResultadoPesquisaVendedor.Id.ToString();
                    txtNomeVendedor.Text = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Nome from Pessoa where Pessoa.ID == " + ResultadoPesquisaVendedor.PessoaId.ToString())[0].Nome;
                    //txtPraçaVendedor.Text = SqliteAcessoDados.LoadQuery<PraçaModelo>("select Nome from Praça where Praça.ID == " + ResultadoPesquisaVendedor.PraçaId.ToString())[0].Nome;
                    txtTelefoneVendedor.Text = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Telefone from Pessoa where Pessoa.ID == " + ResultadoPesquisaVendedor.PessoaId.ToString())[0].Telefone.ToString();

                    List<VendedorPraçaModelo> vendedorPraça = SqliteAcessoDados.LoadQuery<VendedorPraçaModelo>("select * from VendedorPraça where VendedorPraça.VendedorID == " + ResultadoPesquisaVendedor.Id.ToString());

                    foreach (VendedorPraçaModelo modelo in vendedorPraça)
                    {
                        PraçaModelo praça = SqliteAcessoDados.LoadQuery<PraçaModelo>("select * from Praça where Praça.ID == " + modelo.PraçaId.ToString()).First();
                        cbPraça.Items.Add(praça.Id + " - " + praça.Nome);
                    }
                }
            }
        }

        private void btSearchPessoa_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>
            {
                "Nome", "Nascimento", "RG", "CPF", "Telefone", "PontoReferencia", "Endereco", "Numero", "Bairro", "Cidade", "Estado", "Ativo"
            };

            using (var form = new FrmProcura("Pessoa", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ResultadoPesquisaPessoa = form.TableObjectPessoa[form.ResultID];

                    txtIdPessoa.Text = ResultadoPesquisaPessoa.Id.ToString();
                    txtNomePessoa.Text = ResultadoPesquisaPessoa.Nome;
                    txtRG.Text = ResultadoPesquisaPessoa.RG;
                    txtCPF.Text = ResultadoPesquisaPessoa.CPF;
                    txtDataNascimento.Text = ResultadoPesquisaPessoa.Nascimento.ToShortDateString();
                    txtTelefone.Text = ResultadoPesquisaPessoa.Telefone;
                    txtPontoReferencia.Text = ResultadoPesquisaPessoa.PontoReferencia;
                    txtEndereco.Text = ResultadoPesquisaPessoa.Endereco;
                    txtNumero.Text = ResultadoPesquisaPessoa.Numero.ToString();
                    txtBairro.Text = ResultadoPesquisaPessoa.Bairro;
                    txtCidade.Text = ResultadoPesquisaPessoa.Cidade;
                    txtEstado.Text = ResultadoPesquisaPessoa.Estado;
                    cbAtivo.Checked = ResultadoPesquisaPessoa.Ativo;
                }
            }
        }

        private void DgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                List<string> parameters = new List<string>
                {
                    "Descrição", "Unidade", "Estoque", "PreçoCusto", "PreçoVenda"
                };

                using (var form = new FrmProcura("Produto", parameters))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        ResultadoPesquisaProduto = form.TableObjectProduto[form.ResultID];

                        //List<ProdutoModelo> produtoTemp = SqliteAcessoDados.LoadQuery<ProdutoModelo>("select Descrição from Produto where Produto.ID == " + ResultadoPesquisaProduto.ProdutoId);

                        senderGrid.Rows[e.RowIndex].Cells["txtIdProduto"].Value = ResultadoPesquisaProduto.Id;
                        senderGrid.Rows[e.RowIndex].Cells["txtDescrição"].Value = ResultadoPesquisaProduto.Descrição;
                        senderGrid.Rows[e.RowIndex].Cells["txtUnidade"].Value = ResultadoPesquisaProduto.Unidade;
                        //senderGrid.Rows[e.RowIndex].Cells["txtQuantidade"].Value = 
                        senderGrid.Rows[e.RowIndex].Cells["txtPreçoVenda"].Value = /*string.Format("{0:C}",*/ ResultadoPesquisaProduto.PreçoVenda/*)*/;
                        //senderGrid.Rows[e.RowIndex].Cells["txtPreçoTotalItem"].Value = ;
                        //senderGrid.Rows[e.RowIndex].Cells["txtComissão"].Value = ;

                        //senderGrid.Rows.Add();
                    }
                }
            }
        }

        private void btConfirmarVenda_Click(object sender, EventArgs e)
        {

        }

        private void DgvItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            DataGridViewCell preçoVendaCell = senderGrid.Rows[e.RowIndex].Cells["txtPreçoVenda"];
            DataGridViewCell preçoTotalCell = senderGrid.Rows[e.RowIndex].Cells["txtPreçoTotalItem"];
            DataGridViewCell vendidoCell = senderGrid.Rows[e.RowIndex].Cells["txtVendido"];

            if (senderGrid.Columns[e.ColumnIndex].Name == "txtPreçoVenda" && preçoVendaCell.Value != null)
            {
                if (decimal.TryParse(preçoVendaCell.Value.ToString().Replace("R$ ", ""), out decimal preçoVenda))
                {
                    preçoVendaCell.Value = string.Format("{0:C}", preçoVenda);

                    if (vendidoCell.Value != null) {
                        if (int.TryParse(vendidoCell.Value.ToString().Replace("R$ ", ""), out int vendido))
                        {
                            preçoTotalCell.Value = vendido * preçoVenda;
                        }
                    }
                }
                else
                {
                    preçoVendaCell.Value = "";
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex].Name == "txtVendido" && vendidoCell.Value != null)
            {
                if (int.TryParse(vendidoCell.Value.ToString().Replace("R$ ", ""), out int vendido))
                {
                    if (preçoVendaCell.Value != null)
                    {
                        if (decimal.TryParse(preçoVendaCell.Value.ToString().Replace("R$ ", ""), out decimal preçoVenda))
                        {
                            preçoTotalCell.Value = vendido * preçoVenda;
                        }
                    }
                }
            }

            int vendidoTemp = 0;
            decimal preçoTotalFinal = 0;

            foreach (DataGridViewRow row in senderGrid.Rows)
            {
                if (row.Cells["txtVendido"].Value != null)
                {
                    vendidoTemp += int.Parse(row.Cells["txtVendido"].Value.ToString());
                    preçoTotalFinal += decimal.Parse(row.Cells["txtPreçoTotalItem"].Value.ToString().Replace("R$ ", ""));
                }
            }

            txtPreçoFinal.Text = string.Format("{0:C}", preçoTotalFinal);
            txtTotalPeças.Text = vendidoTemp.ToString();
        }

        private void DgvItem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            DataGridViewCell cellObject = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (senderGrid.Columns[e.ColumnIndex].Name == "txtPreçoVenda" && cellObject.Value != null)
            {
                cellObject.Value = cellObject.Value.ToString().Replace("R$ ", "");
            }
        }

        private void DgvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn && e.RowIndex >= 0)
            {
                DataGridViewCell cellObject = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (senderGrid.Columns[e.ColumnIndex].Name == "txtPreçoTotalItem" && cellObject.Value != null)
                {
                    cellObject.Value = string.Format("{0:C}", cellObject.Value);
                }
            }*/
        }

        private void DgvItem_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            
            DataGridViewRow rowObject = senderGrid.Rows[e.RowIndex];

            int totalItensTemp = 0;

            foreach (DataGridViewRow row in senderGrid.Rows)
            {
                if (row.Cells["txtIdProduto"].Value != null)
                {
                    totalItensTemp++;
                }

                if (row.Cells["txtEntregue"].Value == null)
                {
                    row.Cells["txtEntregue"].Value = 0;
                }

                if (row.Cells["txtDevolvido"].Value == null)
                {
                    row.Cells["txtDevolvido"].Value = 0;
                }

                if (row.Cells["txtVendido"].Value == null)
                {
                    row.Cells["txtVendido"].Value = 0;
                }

                if(row.Cells["txtPreçoTotalItem"].Value == null)
                {
                    row.Cells["txtPreçoTotalItem"].Value = 0;
                }
            }

            txtTotalItens.Text = totalItensTemp.ToString();
        }

        private void DgvItem_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            /*var senderGrid = (DataGridView)sender;

            DataGridViewRow rowObject = e.Row;

            txtTotalPeças.Text = rowObject.Cells["txtQuantidade"].Value.ToString();
            txtTotalItens.Text = senderGrid.Rows.Count.ToString();*/
        }

        private void DgvItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            int vendidoTemp = 0;
            decimal preçoTotalFinal = 0;

            foreach (DataGridViewRow row in senderGrid.Rows)
            {
                if (row.Cells["txtVendido"].Value != null)
                {
                    vendidoTemp += int.Parse(row.Cells["txtVendido"].Value.ToString());
                    preçoTotalFinal += decimal.Parse(row.Cells["txtPreçoTotalItem"].Value.ToString().Replace("R$ ", ""));
                }
            }

            txtPreçoFinal.Text = string.Format("{0:C}", preçoTotalFinal);
            txtTotalPeças.Text = vendidoTemp.ToString();
        }

        private void TxtComissão_Leave(object sender, EventArgs e)
        {
            if (txtComissão.Text != "" && txtPreçoFinal.Text != "")
            {
                txtComissãoValor.Text = string.Format("{0:C}", decimal.Parse(txtPreçoFinal.Text.Replace("R$ ", "")) * (decimal.Parse(txtComissão.Text) / 100));
            }
        }

        private void txtPreçoFinal_TextChanged(object sender, EventArgs e)
        {
            decimal preçoFinal = 0;
            if (decimal.TryParse(txtPreçoFinal.Text.Replace("R$ ", ""), out preçoFinal))
            {

                if (preçoFinal <= (decimal)89.99)
                {
                    txtComissão.Text = "20";
                }
                else if (preçoFinal > (decimal)89.99 && preçoFinal <= (decimal)169.99)
                {
                    txtComissão.Text = "25";
                }
                else if (preçoFinal > (decimal)169.99 && preçoFinal <= 600)
                {
                    txtComissão.Text = "30";
                }
                else if (preçoFinal > 600 && preçoFinal < 990)
                {
                    txtComissão.Text = "35";
                }
                else if (preçoFinal > 990)
                {
                    txtComissão.Text = "40";
                }
            }

            TxtComissão_Leave(null, null);
        }
    }
}
