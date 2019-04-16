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
    public partial class FrmProdutos : Form
    {
        public List<ProdutoModelo> Produtos { get; set; }
        public ProdutoModelo ResultadoPesquisa { get; set; }

        private bool isEditing = false;
        private int _atualID;

        private int AtualID
        {
            get { return _atualID; }
            set
            {
                _atualID = value;
                ShowSelected(Produtos[value]);
            }
        }

        public static List<string> parameters = new List<string>
        {
            "Descrição", "Unidade", "Estoque", "PreçoCusto", "PreçoVenda"
        };

        public FrmProdutos()
        {
            InitializeComponent();
            DesativarCampos();
            btPesquisar.Enabled = true;
            btAdd.Enabled = true;
        }

        private void ShowSelected(ProdutoModelo modelo)
        {
            txtID.Text = modelo.Id.ToString();
            txtDescrição.Text = modelo.Descrição;
            cbbUnidade.SelectedItem = modelo.Unidade;
            txtEstoque.Text = modelo.Estoque.ToString();
            txtPreçoCusto.Text = modelo.PreçoCusto.ToString();
            txtPreçoVenda.Text = modelo.PreçoVenda.ToString();

            TxtPreçoCusto_Leave(null, null);
            TxtPreçoVenda_Leave(null, null);
        }

        private void DesativarCampos()
        {
            txtDescrição.Enabled = false;
            cbbUnidade.Enabled = false;
            txtEstoque.Enabled = false;
            txtPreçoCusto.Enabled = false;
            txtPreçoVenda.Enabled = false;
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
            txtDescrição.Enabled = true;
            cbbUnidade.Enabled = true;
            txtEstoque.Enabled = true;
            txtPreçoCusto.Enabled = true;
            txtPreçoVenda.Enabled = true;
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
            txtDescrição.Text = "";
            cbbUnidade.SelectedItem = "";
            txtEstoque.Text = "";
            txtPreçoCusto.Text = "";
            txtPreçoVenda.Text = "";
        }

        private ProdutoModelo AddProduto()
        {
            ProdutoModelo modelo = new ProdutoModelo
            {
                Descrição = txtDescrição.Text,
                Unidade = cbbUnidade.SelectedItem.ToString(),
                Estoque = int.Parse(txtEstoque.Text),
                PreçoCusto = decimal.Parse(txtPreçoCusto.Text.Replace("R$ ", "")),
                PreçoVenda = decimal.Parse(txtPreçoVenda.Text.Replace("R$ ", ""))
            };

            if (isEditing)
            {
                modelo.Id = int.Parse(txtID.Text);
            }

            return modelo;
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            isEditing = false;
            ProdutoModelo p = new ProdutoModelo();

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

            int ID = SqliteAcessoDados.GetLastID("Produto");
            txtID.Text = (ID + 1).ToString();
        }

        private void BtLimpar_Click(object sender, EventArgs e)
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

        private void BtSalvar_Click(object sender, EventArgs e)
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
                    SqliteAcessoDados.UpdateQuery<ProdutoModelo>(AddProduto(), "Produto", parameters);
                }
                else
                {
                    SqliteAcessoDados.SaveQuery<ProdutoModelo>(AddProduto(), "Produto", parameters);
                }

                DesativarCampos();
                btAlterar.Enabled = true;
                btExcluir.Enabled = true;
                btPesquisar.Enabled = true;
                btAdd.Enabled = true;

                isEditing = false;
            }
        }

        private void BtPesquisar_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProcura(this.Name, "Produto", parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Produtos = form.TableObjectProduto;
                    AtualID = form.ResultID;

                    btAlterar.Enabled = true;
                    btExcluir.Enabled = true;
                }
            }

            if (Produtos != null && Produtos.Count > 1)
            {
                btAnterior.Enabled = true;
                btUltimo.Enabled = true;
                btPrimeiro.Enabled = true;
                btProximo.Enabled = true;
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você confirma a exclusão do registro?", "Confirmar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqliteAcessoDados.ExcluirQuery(int.Parse(txtID.Text), "Produto");

                LimparCampos();

                btAlterar.Enabled = false;
                btExcluir.Enabled = false;
            }
        }

        private void BtAlterar_Click(object sender, EventArgs e)
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

        private void BtProximo_Click(object sender, EventArgs e)
        {
            if (Produtos.Count > (AtualID + 1))
            {
                AtualID++;
            }
        }

        private void BtAnterior_Click(object sender, EventArgs e)
        {
            if (AtualID > 0)
            {
                AtualID--;
            }
        }

        private void BtPrimeiro_Click(object sender, EventArgs e)
        {
            AtualID = 0;
        }

        private void BtUltimo_Click(object sender, EventArgs e)
        {
            AtualID = Produtos.Count - 1;
        }

        private void TxtPreçoCusto_Leave(object sender, EventArgs e)
        {
            if (txtPreçoCusto.Text != "")
            {
                txtPreçoCusto.Text = string.Format("{0:C}", decimal.Parse(txtPreçoCusto.Text.Replace("R$ ", "")));
            }
        }

        private void TxtPreçoVenda_Leave(object sender, EventArgs e)
        {
            if (txtPreçoVenda.Text != "")
            {
                txtPreçoVenda.Text = string.Format("{0:C}", decimal.Parse(txtPreçoVenda.Text.Replace("R$ ", "")));
            }
        }

        private void TxtPreçoCusto_Enter(object sender, EventArgs e)
        {
            txtPreçoCusto.Text = txtPreçoCusto.Text.Replace("R$ ", "");
        }

        private void TxtPreçoVenda_Enter(object sender, EventArgs e)
        {
            txtPreçoVenda.Text = txtPreçoVenda.Text.Replace("R$ ", "");
        }
    }
}
