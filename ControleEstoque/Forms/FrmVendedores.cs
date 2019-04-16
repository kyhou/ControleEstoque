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
        public VendedorPraçaModelo ResultadoVendedorPraça { get; set; }
        public List<VendedorPraçaModelo> VendedorPraçaList { get; set; }

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

        static public List<string> VendedorParameters = new List<string>
        {
            "PessoaID", "Placa", "CNH"
        };

        List<string> VendedorPraçaParameters = new List<string>
        {
            "VendedorID", "PraçaID"
        };

        public FrmVendedores()
        {
            InitializeComponent();
            DesativarCampos();
            btPesquisar.Enabled = true;
            btAdd.Enabled = true;

            VendedorPraçaList = new List<VendedorPraçaModelo>();
        }

        private void ShowSelected(VendedorModelo modelo)
        {
            txtID.Text = modelo.Id.ToString();
            txtIdPessoa.Text = modelo.PessoaId.ToString();
            VendedorPraçaList = SqliteAcessoDados.LoadQuery<VendedorPraçaModelo>("select * from VendedorPraça where VendedorPraça.VendedorID == " + modelo.Id.ToString());

            foreach (VendedorPraçaModelo item in VendedorPraçaList)
            {
                BuscaPraçaFK(item.PraçaId, out string praçaNome);
                dgvPraças.Rows.Add(item.PraçaId, praçaNome);
            }
            
            txtPlaca.Text = modelo.Placa;
            txtCNH.Text = modelo.CNH.ToString();    

            BuscaPessoaFK(int.Parse(txtIdPessoa.Text), out string nomePessoa);
            txtNomePessoa.Text = nomePessoa;
        }


        private bool Validation()
        {
            bool result = false;

            errorProvider.Clear();

            //errorProvider.SetIconAlignment(txtPontoReferencia, ErrorIconAlignment.MiddleRight);

            //bool teste = txtPontoReferencia.Text.Any(c => char.IsDigit(c));

            if (txtNomePessoa.Text == "")
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
            }


            /*********************
             * ADD VALIDAÇÂO CNH *
             *********************/

            return result;
        }


        private void DesativarCampos()
        {
            txtPlaca.Enabled = false;
            txtNomePessoa.Enabled = false;
            dgvPraças.Enabled = false;
            txtCNH.Enabled = false;
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
            btAddPraça.Enabled = false;
            btRemoverPraça.Enabled = false;
        }

        private void AtivarCampos()
        {
            txtPlaca.Enabled = true;
            txtCNH.Enabled = true;
            dgvPraças.Enabled = true;
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
            btAddPraça.Enabled = true;
            btRemoverPraça.Enabled = true;
        }

        private void LimparCampos()
        {
            errorProvider.Clear();
            txtID.Text = "";
            txtIdPessoa.Text = "";
            txtNomePessoa.Text = "";
            dgvPraças.Rows.Clear();
            txtPlaca.Text = "";
            txtCNH.Text = "";
        }

        private VendedorModelo AddVendedor()
        {
            VendedorModelo modelo = new VendedorModelo
            {
                PessoaId = int.Parse(txtIdPessoa.Text),
                Placa = txtPlaca.Text,
                CNH = txtCNH.Text
            };

            if (isEditing)
            {
                modelo.Id = int.Parse(txtID.Text);
            }

            return modelo;
        }

        private List<VendedorPraçaModelo> AddVendedorPraça()
        {
            List<VendedorPraçaModelo> vendedorPraças = new List<VendedorPraçaModelo>();

            foreach (DataGridViewRow row in dgvPraças.Rows)
            {
                vendedorPraças.Add(new VendedorPraçaModelo
                {
                    VendedorId = int.Parse(txtID.Text),
                    PraçaId = int.Parse(row.Cells["txtCodigo"].Value.ToString())
                });
            }

            return vendedorPraças;
        }

        private void BuscaPessoaFK(int idPessoa, out string nomePessoa)
        {
            nomePessoa = "";

            nomePessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Nome from Pessoa where ID = " + idPessoa)[0].Nome;
        }

        private void BuscaPraçaFK(int idPraça, out string praça)
        {
            praça = "";

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
                    ShowSelected(Vendedores[AtualID]);
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
                        SqliteAcessoDados.UpdateQuery<VendedorModelo>(AddVendedor(), "Vendedor", VendedorParameters);

                        foreach (VendedorPraçaModelo vendedorPraça in VendedorPraçaList)
                        {
                            SqliteAcessoDados.ExcluirQuery(vendedorPraça.VendedorId, "VendedorPraça", "VendedorID");
                        }

                        VendedorPraçaList = AddVendedorPraça();
                        foreach (VendedorPraçaModelo vendedorPraça in VendedorPraçaList)
                        {
                            SqliteAcessoDados.SaveQuery<VendedorPraçaModelo>(vendedorPraça, "VendedorPraça", VendedorPraçaParameters);
                        }
                    }
                    else
                    {
                        SqliteAcessoDados.SaveQuery<VendedorModelo>(AddVendedor(), "Vendedor", VendedorParameters);

                        VendedorPraçaList = AddVendedorPraça();
                        foreach (VendedorPraçaModelo vendedorPraça in VendedorPraçaList)
                        {
                            SqliteAcessoDados.SaveQuery<VendedorPraçaModelo>(vendedorPraça, "VendedorPraça", VendedorPraçaParameters);
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
            using (var form = new FrmProcura(this.Name, "Vendedor", VendedorParameters))
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
                "PraçaID", "Nome", "Nascimento", "RG", "CPF", "Telefone", "PontoReferencia", "Endereco", "Numero", "Bairro", "Cidade", "Estado", "Cliente", "Ativo"
            };

            using (var form = new FrmProcura(this.Name, "Pessoa", parameters))
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

        private void btAddPraça_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>
            {
                "Nome"
            };

            using (var form = new FrmProcura(this.Name, "Praça", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ResultadoPesquisaPraça = form.TableObjectPraça[form.ResultID];

                    BuscaPraçaFK(ResultadoPesquisaPraça.Id, out string praça);

                    bool praçaRepetida = false;

                    if (dgvPraças.Rows != null) {
                        foreach (DataGridViewRow row in dgvPraças.Rows)
                        {
                            if (row.Cells["txtCodigo"].Value.ToString() == ResultadoPesquisaPraça.Id.ToString())
                            {
                                praçaRepetida = true;
                            }
                        }
                    }

                    if (!praçaRepetida)
                    {
                        dgvPraças.Rows.Add(ResultadoPesquisaPraça.Id, praça);
                    }
                    else
                    {
                        MessageBox.Show("Esta Praça ja está inclusa para este Vendedor.", "Atenção!", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btRemoverPraça_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPraças.SelectedRows)
            {
                dgvPraças.Rows.Remove(row);
            }
            dgvPraças.ClearSelection();
        }
    }
}