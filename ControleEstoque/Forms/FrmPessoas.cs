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
        public PessoaModelo ResultadoPesquisa { get; set; }

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

        List<string> parameters = new List<string>
        {
            "Nome", "Nascimento", "RG", "CPF", "Telefone", "Indicacao", "Endereco", "Numero", "Bairro", "Cidade"
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
            txtIndicacao.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
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
        }

        private void AtivarCampos()
        {
            txtName.Enabled = true;
            txtRG.Enabled = true;
            txtCPF.Enabled = true;
            txtDataNascimento.Enabled = true;
            txtTelefone.Enabled = true;
            txtIndicacao.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
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
        }

        private void LimparCampos()
        {
            errorProvider.Clear();
            txtID.Text = "";
            txtName.Text = "";
            txtRG.Text = "";
            txtCPF.Text = "";
            txtDataNascimento.Text = "";
            txtTelefone.Text = "";
            txtIndicacao.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
        }

        private void ShowSelected(PessoaModelo modelo)
        {
            txtID.Text = modelo.Id.ToString();
            txtName.Text = modelo.Nome;
            txtRG.Text = modelo.RG;
            txtCPF.Text = modelo.CPF;
            txtDataNascimento.Text = modelo.Nascimento.ToShortDateString();
            txtTelefone.Text = modelo.Telefone;
            txtIndicacao.Text = modelo.Indicacao.ToString();
            txtEndereco.Text = modelo.Endereco;
            txtNumero.Text = modelo.Numero.ToString();
            txtBairro.Text = modelo.Bairro;
            txtCidade.Text = modelo.Cidade;
        }

        private bool Validation()
        {
            int resultInt = 0;
            bool result = false;
            
            errorProvider.Clear();

            //errorProvider.SetIconAlignment(txtIndicacao, ErrorIconAlignment.MiddleRight);

            //bool teste = txtIndicacao.Text.Any(c => char.IsDigit(c));

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

            if (!int.TryParse(txtIndicacao.Text, out resultInt))
            {
                errorProvider.SetError(txtIndicacao, "Somente Números");
                result = true;
            }

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
                Nome = txtName.Text,
                Nascimento = DateTime.Parse(txtDataNascimento.Text),
                RG = txtRG.Text,
                CPF = txtCPF.Text,
                Telefone = txtTelefone.Text,
                Indicacao = int.Parse(txtIndicacao.Text),
                Endereco = txtEndereco.Text,
                Numero = int.Parse(txtNumero.Text),
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text
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
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Limpar todos os campos?", "Confirmar", MessageBoxButtons.YesNo);
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
            using (var form = new FrmProcura("Pessoa", parameters))
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
    }
}
