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
    public partial class FrmPraças : Form
    {
        public List<PraçaModelo> Praças { get; set; }
        public PraçaModelo ResultadoPesquisa { get; set; }

        private bool isEditing = false;
        private int _atualID;

        private int AtualID
        {
            get { return _atualID; }
            set
            {
                _atualID = value;
                ShowSelected(Praças[value]);
            }
        }

        List<string> parameters = new List<string>
        {
            "Nome"
        };

        public FrmPraças()
        {
            InitializeComponent();
            DesativarCampos();
            btPesquisar.Enabled = true;
            btAdd.Enabled = true;
        }

        private void ShowSelected(PraçaModelo modelo)
        {
            txtID.Text = modelo.Id.ToString();
            txtName.Text = modelo.Nome;
        }

        private void DesativarCampos()
        {
            txtName.Enabled = false;
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
        }

        private PraçaModelo AddPraça()
        {
            PraçaModelo modelo = new PraçaModelo
            {
                Nome = txtName.Text
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
            PraçaModelo p = new PraçaModelo();

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

            int ID = SqliteAcessoDados.GetLastID("Praça");
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
                    SqliteAcessoDados.UpdateQuery<PraçaModelo>(AddPraça(), "Praça", parameters);
                }
                else
                {
                    SqliteAcessoDados.SaveQuery<PraçaModelo>(AddPraça(), "Praça", parameters);
                }

                DesativarCampos();
                btAlterar.Enabled = true;
                btExcluir.Enabled = true;
                btPesquisar.Enabled = true;
                btAdd.Enabled = true;

                isEditing = false;
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProcura(this.Name, "Praça", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Praças = form.TableObjectPraça;
                    AtualID = form.ResultID;

                    btAlterar.Enabled = true;
                    btExcluir.Enabled = true;
                }
            }

            if (Praças != null && Praças.Count > 1)
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
                SqliteAcessoDados.ExcluirQuery(int.Parse(txtID.Text), "Praça");

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
            if (Praças.Count > (AtualID + 1))
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
            AtualID = Praças.Count - 1;
        }
    }
}
