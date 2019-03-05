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
    public partial class Main : Form
    {
        FrmPessoas pessoasForm = new FrmPessoas();
        FrmPraças pracasForm = new FrmPraças();
        FrmVendedores vendedoresForm = new FrmVendedores();
        FrmProdutos produtosForm = new FrmProdutos();
        FrmPedidos pedidosForm = new FrmPedidos();

        public Main()
        {
            InitializeComponent();
        }

        /*private void ShowForm<T>(T formObject)
        {
            if (formObject.Visible)
            {
                formObject.BringToFront();
            }
            else
            {
                formObject = new Form();
                formObject.Show();
            }
        }*/

        private void BtFrmPessoas_Click(object sender, EventArgs e)
        {
            if (pessoasForm.Visible)
            {
                pessoasForm.BringToFront();
            }
            else
            {
                pessoasForm = new FrmPessoas();
                pessoasForm.Show();
            }
        }

        private void BtFrmPraças_Click(object sender, EventArgs e)
        {
            if (pracasForm.Visible)
            {
                pracasForm.BringToFront();
            }
            else
            {
                pracasForm = new FrmPraças();
                pracasForm.Show();
            }
        }

        private void BtFrmVendedores_Click(object sender, EventArgs e)
        {
            if (vendedoresForm.Visible)
            {
                vendedoresForm.BringToFront();
            }
            else
            {
                vendedoresForm = new FrmVendedores();
                vendedoresForm.Show();
            }
        }

        private void BtFrmProdutos_Click(object sender, EventArgs e)
        {
            if (produtosForm.Visible)
            {
                produtosForm.BringToFront();
            }
            else
            {
                produtosForm = new FrmProdutos();
                produtosForm.Show();
            }
        }

        private void BtFrmPedidos_Click(object sender, EventArgs e)
        {
            if (pedidosForm.Visible)
            {
                pedidosForm.BringToFront();
            }
            else
            {
                pedidosForm = new FrmPedidos();
                pedidosForm.Show();
            }
        }
    }
}
