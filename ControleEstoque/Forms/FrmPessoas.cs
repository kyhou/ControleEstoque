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
    public partial class FrmPessoas : Form
    {
        public List<PessoaModelo> Pessoas { get; set; }
        //public PessoaModelo ResultadoPesquisa { get; set; }

        private bool isEditing = false;
        private int _atualID;

        private int AtualID
        {
            get { return _atualID; }
            set
            {
                _atualID = value;
                ShowSelected(Pessoas[value]);
            }
        }

        static public List<string> parameters = new List<string>
        {
            "PraçaID", "Nome", "Nascimento", "RG", "CPF", "Telefone", "PontoReferencia", "Endereco", "Numero", "Bairro", "Cidade", "Estado", "Cliente", "Ativo"
        };

        public FrmPessoas()
        {
            InitializeComponent();

            DesativarCampos();
            btPesquisar.Enabled = true;
            btAdd.Enabled = true;
        }

        private void DesativarCampos()
        {
            txtName.Enabled = false;
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
            txtIdPraça.Enabled = false;
            txtNomePraça.Enabled = false;
            btSearchPraça.Enabled = false;
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
            cbAtivo.Enabled = false;
            cbCliente.Enabled = false;
        }

        private void AtivarCampos()
        {
            txtName.Enabled = true;
            txtRG.Enabled = true;
            txtCPF.Enabled = true;
            txtDataNascimento.Enabled = true;
            txtTelefone.Enabled = true;
            txtPontoReferencia.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtEstado.Enabled = true;
            btSearchPraça.Enabled = true;
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
            cbAtivo.Enabled = true;
            cbCliente.Enabled = true;
        }

        private void LimparCampos()
        {
            errorProvider.Clear();
            txtID.Text = "";
            txtIdPraça.Text = "";
            txtNomePraça.Text = "";
            txtName.Text = "";
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
            cbAtivo.Checked = false;
            cbCliente.Checked = false;
        }

        private void ShowSelected(PessoaModelo modelo)
        {
            txtID.Text = modelo.Id.ToString();
            txtIdPraça.Text = modelo.PraçaID.ToString();
            txtNomePraça.Text = SqliteAcessoDados.LoadQuery<PraçaModelo>("select Nome from Praça where Praça.ID == " + modelo.PraçaID.ToString()).First().Nome;
            txtName.Text = modelo.Nome;
            txtRG.Text = modelo.RG;
            txtCPF.Text = modelo.CPF;
            txtDataNascimento.Text = modelo.Nascimento.ToShortDateString();
            txtTelefone.Text = modelo.Telefone;
            txtPontoReferencia.Text = modelo.PontoReferencia.ToString();
            txtEndereco.Text = modelo.Endereco;
            txtNumero.Text = modelo.Numero.ToString();
            txtBairro.Text = modelo.Bairro;
            txtCidade.Text = modelo.Cidade;
            txtEstado.Text = modelo.Estado;
            cbAtivo.Checked = modelo.Ativo; //? true : false;
            cbCliente.Checked = modelo.Cliente;
        }

        private bool Validation()
        {
            int resultInt = 0;
            bool result = false;
            
            errorProvider.Clear();

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
                else
                {
                    if (!isEditing)
                    {
                        if (SqliteAcessoDados.RegistroExiste<PessoaModelo>("CPF", txtCPF.Text))
                        {
                            errorProvider.SetError(txtCPF, "CPF já cadastrado");
                            result = true;
                        }
                    }
                }
            }

            if (!DateTime.TryParse(txtDataNascimento.Text, out DateTime resultDate))
            {
                errorProvider.SetError(txtDataNascimento, "Insira uma data válida");
                result = true;
            }

            /*if (!int.TryParse(txtPontoReferencia.Text, out resultInt))
            {
                errorProvider.SetError(txtPontoReferencia, "Somente Números");
                result = true;
            }*/

            if (!int.TryParse(txtNumero.Text, out resultInt))
            {
                errorProvider.SetError(txtNumero, "Somente Números");
                result = true;
            }

            return result;
        }

        private PessoaModelo AddPessoa()
        {
            PessoaModelo modelo = new PessoaModelo
            {
                PraçaID = int.Parse(txtIdPraça.Text),
                Nome = txtName.Text,
                Nascimento = DateTime.Parse(txtDataNascimento.Text),
                RG = txtRG.Text,
                CPF = txtCPF.Text,
                Telefone = txtTelefone.Text,
                PontoReferencia = txtPontoReferencia.Text,
                Endereco = txtEndereco.Text,
                Numero = int.Parse(txtNumero.Text),
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Estado = txtEstado.Text,
                Cliente = cbCliente.Checked,
                Ativo = cbAtivo.Checked //? true : false
            };

            if (isEditing)
            {
                modelo.Id = int.Parse(txtID.Text);
            }

            return modelo;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            isEditing = false;
            PessoaModelo p = new PessoaModelo();

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
            
            int ID = SqliteAcessoDados.GetLastID("Pessoa");
            txtID.Text = (ID + 1).ToString();
            cbAtivo.Checked = true;
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
                        SqliteAcessoDados.UpdateQuery<PessoaModelo>(AddPessoa(), "Pessoa", parameters);
                    }
                    else
                    {
                        SqliteAcessoDados.SaveQuery<PessoaModelo>(AddPessoa(), "Pessoa", parameters);
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

        private void btPesquisa_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProcura(this.Name, "Pessoa", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Pessoas = form.TableObjectPessoa;
                    AtualID = form.ResultID;
                    
                    btAlterar.Enabled = true;
                    btExcluir.Enabled = true;
                }
            }

            if (Pessoas != null && Pessoas.Count > 1)
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
                SqliteAcessoDados.ExcluirQuery(int.Parse(txtID.Text), "Pessoa");

                LimparCampos();

                btAlterar.Enabled = false;
                btExcluir.Enabled = false;
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                isEditing = true;
                AtivarCampos();

                txtCPF.Enabled = false;
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
            if (Pessoas.Count > (AtualID + 1))
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
            AtualID = Pessoas.Count - 1;
        }

        private void btSearchPraça_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>
            {
                "Nome"
            };

            using (var form = new FrmProcura(this.Name, "Praça", parameters))
            {
                var asd = this.Name;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PraçaModelo ResultadoPesquisaPraça = form.TableObjectPraça[form.ResultID];

                    txtIdPraça.Text = ResultadoPesquisaPraça.Id.ToString();
                    txtNomePraça.Text = ResultadoPesquisaPraça.Nome;
                }
            }
        }
    }
}
