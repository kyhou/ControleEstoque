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
    public partial class FrmDeposito : Form
    {
        public List<DepositoModelo> Depositos { get; set; }
        public VendedorModelo ResultadoPesquisaVendedor { get; set; }
        public PraçaModelo ResultadoPesquisaPraça { get; set; }
        public PessoaModelo ResultadoPesquisaPessoa { get; set; }

        private bool isEditing = false;
        private int _atualID;

        private int AtualID
        {
            get { return _atualID; }
            set
            {
                _atualID = value;
                ShowSelected(Depositos[value]);
            }
        }

        List<string> DepositoParameters = new List<string>
        {
            "VendedorId", "PraçaId", "Data", "Valor", "ValorPepino"
        };

        public FrmDeposito()
        {
            InitializeComponent();
            DesativarCampos();
            btPesquisar.Enabled = true;
            btAdd.Enabled = true;
        }

        private void ShowSelected(DepositoModelo modelo)
        {
            cbbPraça.Items.Clear();

            txtID.Text = modelo.Id.ToString();

            ResultadoPesquisaVendedor = SqliteAcessoDados.LoadQuery<VendedorModelo>("Select * from Vendedor where Vendedor.ID == " + modelo.VendedorId)[0];
            ResultadoPesquisaPessoa = SqliteAcessoDados.GetPesquisarTodos<PessoaModelo>("where Pessoa.ID = " + ResultadoPesquisaVendedor.PessoaId).First();
            txtIdVendedor.Text = ResultadoPesquisaVendedor.Id.ToString();
            txtNomeVendedor.Text = ResultadoPesquisaPessoa.Nome;
            ResultadoPesquisaPraça = SqliteAcessoDados.LoadQuery<PraçaModelo>("Select * from Praça where Praça.ID == " + modelo.PraçaId)[0];

            List<VendedorPraçaModelo> vendedorPraçaList = SqliteAcessoDados.LoadQuery<VendedorPraçaModelo>("select * from VendedorPraça where VendedorPraça.VendedorID == " + ResultadoPesquisaVendedor.Id.ToString());

            foreach (VendedorPraçaModelo vendedorPraça in vendedorPraçaList)
            {
                PraçaModelo praça = SqliteAcessoDados.LoadQuery<PraçaModelo>("select * from Praça where Praça.ID == " + modelo.PraçaId.ToString()).First();
                cbbPraça.Items.Add(praça.Id + " - " + praça.Nome);
                if (praça.Id == modelo.PraçaId)
                {
                    cbbPraça.SelectedIndex = cbbPraça.Items.Count - 1;
                }
            }

            txtData.Text = modelo.Data.ToShortDateString();
            txtTelefoneVendedor.Text = ResultadoPesquisaPessoa.Telefone;

            txtValor.Text = modelo.Valor.ToString();
            txtValor_Leave(null, null);
            txtValorPepino.Text = modelo.ValorPepino.ToString();
            txtValorPepino_Leave(null, null);
        }


        private bool Validation()
        {
            bool result = false;

            errorProvider.Clear();
            
            return result;
        }


        private void DesativarCampos()
        {
            txtIdVendedor.Enabled = false;
            txtNomeVendedor.Enabled = false;
            txtTelefoneVendedor.Enabled = false;
            cbbPraça.Enabled = false;
            txtData.Enabled = false;
            txtValor.Enabled = false;
            txtValorPepino.Enabled = false;

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
        }

        private void AtivarCampos()
        {
            cbbPraça.Enabled = true;
            txtData.Enabled = true;
            txtValor.Enabled = true;
            txtValorPepino.Enabled = true;

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
        }

        private void LimparCampos()
        {
            errorProvider.Clear();
            cbbPraça.Items.Clear();
            txtID.Text = "";
            txtIdVendedor.Text = "";
            txtNomeVendedor.Text = "";
            txtTelefoneVendedor.Text = "";
            cbbPraça.Text = "";
            txtData.Text = "";
            txtValor.Text = "";
            txtValorPepino.Text = "";
        }

        private DepositoModelo AddDeposito()
        {
            DepositoModelo modelo = new DepositoModelo
            {
                VendedorId = int.Parse(txtIdVendedor.Text),
                PraçaId = int.Parse(cbbPraça.SelectedItem.ToString().Split('-').First()),
                Data = DateTime.Parse(txtData.Text),
                Valor = decimal.Parse(txtValor.Text.Replace("R$ ", "")),
                ValorPepino = decimal.Parse(txtValorPepino.Text.Replace("R$ ", "")),
            };

            if (isEditing)
            {
                modelo.Id = int.Parse(txtID.Text);
            }

            return modelo;
        }

        private void BuscaPraçaFK(int idPraça, out string praça)
        {
            praça = "";

            praça = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Nome from Praça where ID = " + idPraça)[0].Nome;
        }

        private void BuscaVendedorFK(int idVendedor, out int vendedor)
        {
            vendedor = 0;

            vendedor = SqliteAcessoDados.LoadQuery<VendedorModelo>("select ID from Praça where ID = " + idVendedor)[0].Id;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            isEditing = false;
            DepositoModelo p = new DepositoModelo();

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

            int ID = SqliteAcessoDados.GetLastID("Deposito");
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
                    ShowSelected(Depositos[AtualID]);
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
                        SqliteAcessoDados.UpdateQuery<DepositoModelo>(AddDeposito(), "Deposito", DepositoParameters);
                    }
                    else
                    {
                        SqliteAcessoDados.SaveQuery<DepositoModelo>(AddDeposito(), "Deposito", DepositoParameters);
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
            using (var form = new FrmProcura(this.Name, "Deposito", DepositoParameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Depositos = form.TableObjectDeposito;
                    AtualID = form.ResultID;

                    btAlterar.Enabled = true;
                    btExcluir.Enabled = true;
                }
            }

            if (Depositos != null && Depositos.Count > 1)
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
                SqliteAcessoDados.ExcluirQuery(int.Parse(txtID.Text), "Deposito");

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
            if (Depositos.Count > (AtualID + 1))
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
            AtualID = Depositos.Count - 1;
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
                    txtTelefoneVendedor.Text = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Telefone from Pessoa where Pessoa.ID == " + ResultadoPesquisaVendedor.PessoaId.ToString())[0].Telefone.ToString();

                    List<VendedorPraçaModelo> vendedorPraça = SqliteAcessoDados.LoadQuery<VendedorPraçaModelo>("select * from VendedorPraça where VendedorPraça.VendedorID == " + ResultadoPesquisaVendedor.Id.ToString());

                    foreach (VendedorPraçaModelo modelo in vendedorPraça)
                    {
                        PraçaModelo praça = SqliteAcessoDados.LoadQuery<PraçaModelo>("select * from Praça where Praça.ID == " + modelo.PraçaId.ToString()).First();
                        cbbPraça.Items.Add(praça.Id + " - " + praça.Nome);
                    }
                }
            }
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            txtValor.Text = txtValor.Text.ToString().Replace("R$ ", "");
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            txtValor.Text = string.Format("{0:C}", decimal.Parse(txtValor.Text));
        }

        private void txtValorPepino_Enter(object sender, EventArgs e)
        {
            txtValorPepino.Text = txtValorPepino.Text.ToString().Replace("R$ ", "");
        }

        private void txtValorPepino_Leave(object sender, EventArgs e)
        {
            txtValorPepino.Text = string.Format("{0:C}", decimal.Parse(txtValorPepino.Text));
        }
    }
}