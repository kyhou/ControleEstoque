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
    public partial class FrmVendedores : Form
    {
        public List<VendedorModelo> Vendedores { get; set; }
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
                ShowSelected(Vendedores[value]);
            }
        }

        List<string> parameters = new List<string>
        {
            "Placa", "PessoaID", "PraçaID"
        };

        public FrmVendedores()
        {
            InitializeComponent();
            DesativarCampos();
            btPesquisar.Enabled = true;
            btAdd.Enabled = true;
        }

        private void ShowSelected(VendedorModelo vendedor)
        {
            txtID.Text = vendedor.Id.ToString();
            txtIdPessoa.Text = vendedor.PessoaId.ToString();
            txtIdPraça.Text = vendedor.PraçaId.ToString();
            txtPlaca.Text = vendedor.Placa;

            BuscaFK(int.Parse(txtIdPessoa.Text), int.Parse(txtIdPraça.Text), out string nomePessoa, out string praça);

            txtNomePessoa.Text = nomePessoa;
            txtPraça.Text = praça;
        }


        private bool Validation()
        {
            bool result = false;

            errorProvider.Clear();

            //errorProvider.SetIconAlignment(txtIndicacao, ErrorIconAlignment.MiddleRight);

            //bool teste = txtIndicacao.Text.Any(c => char.IsDigit(c));

            if (txtNomePessoa.Text == "")
            {
                errorProvider.SetError(txtNomePessoa, "Campo Obrigatório");
                result = true;
            }

            if (txtPraça.Text == "")
            {
                errorProvider.SetError(txtPraça, "Campo Obrigatório");
                result = true;
            }

            if (txtPlaca.Text == "")
            {
                errorProvider.SetError(txtPlaca, "Campo Obrigatório");
                result = true;
            }

            return result;
        }


        private void DesativarCampos()
        {
            txtPlaca.Enabled = false;
            txtNomePessoa.Enabled = false;
            txtPraça.Enabled = false;
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
            btSearchPessoa.Enabled = false;
            btSearchPraça.Enabled = false;
        }

        private void AtivarCampos()
        {
            txtPlaca.Enabled = true;
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
            btSearchPessoa.Enabled = true;
            btSearchPraça.Enabled = true;
        }

        private void LimparCampos()
        {
            errorProvider.Clear();
            txtID.Text = "";
            txtIdPessoa.Text = "";
            txtNomePessoa.Text = "";
            txtIdPraça.Text = "";
            txtPraça.Text = "";
            txtPlaca.Text = "";

        }

        private VendedorModelo AddVendedor()
        {
            VendedorModelo modelo = new VendedorModelo
            {
                PessoaId = int.Parse(txtIdPessoa.Text),
                PraçaId = int.Parse(txtIdPraça.Text),
                Placa = txtPlaca.Text
            };

            if (isEditing)
            {
                modelo.Id = int.Parse(txtID.Text);
            }

            return modelo;
        }

        private void BuscaFK(int idPessoa, int idPraça, out string nomePessoa, out string praça)
        {
            nomePessoa = "";
            praça = "";

            nomePessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Nome from Pessoa where ID = " + idPessoa)[0].Nome;
            praça = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Nome from Praça where ID = " + idPraça)[0].Nome;
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

            int ID = SqliteAcessoDados.GetLastID("Vendedor");
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
                        SqliteAcessoDados.UpdateQuery<VendedorModelo>(AddVendedor(), "Vendedor", parameters);
                    }
                    else
                    {
                        SqliteAcessoDados.SaveQuery<VendedorModelo>(AddVendedor(), "Vendedor", parameters);
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
            using (var form = new FrmProcura("Vendedor", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Vendedores = form.TableObjectVendedor;
                    AtualID = form.ResultID;

                    btAlterar.Enabled = true;
                    btExcluir.Enabled = true;
                }
            }

            if (Vendedores != null && Vendedores.Count > 1)
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
                SqliteAcessoDados.ExcluirQuery(int.Parse(txtID.Text), "Vendedor");

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
            if (Vendedores.Count > (AtualID + 1))
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
            AtualID = Vendedores.Count - 1;
        }

        private void btSearchPessoa_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>
            {
                "Nome", "Nascimento", "RG", "CPF", "Telefone", "Indicacao", "Endereco", "Numero", "Bairro", "Cidade"
            };

            using (var form = new FrmProcura("Pessoa", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ResultadoPesquisaPessoa = form.TableObjectPessoa[form.ResultID];

                    txtIdPessoa.Text = ResultadoPesquisaPessoa.Id.ToString();
                    txtNomePessoa.Text = ResultadoPesquisaPessoa.Nome;
                }
            }
        }

        private void btSearchPraça_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>
            {
                "Nome"
            };

            using (var form = new FrmProcura("Praça", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ResultadoPesquisaPraça = form.TableObjectPraça[form.ResultID];

                    txtIdPraça.Text = ResultadoPesquisaPraça.Id.ToString();
                    txtPraça.Text = ResultadoPesquisaPraça.Nome;
                }
            }
        }
    }
}