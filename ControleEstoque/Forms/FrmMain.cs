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
        FrmDeposito depositoForm = new FrmDeposito();
        FrmCargaDevolução cargaDevoluçãoForm = new FrmCargaDevolução();
        FrmImpressão impressãoForm = new FrmImpressão();
        FrmRelatorios relatoriosForm = new FrmRelatorios();

        public Main()
        {
            InitializeComponent();
        }

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

        private void btFrmDepositos_Click(object sender, EventArgs e)
        {
            if (depositoForm.Visible)
            {
                depositoForm.BringToFront();
            }
            else
            {
                depositoForm = new FrmDeposito();
                depositoForm.Show();
            }
        }

        private void btFrmCargaDevolução_Click(object sender, EventArgs e)
        {
            if (cargaDevoluçãoForm.Visible)
            {
                cargaDevoluçãoForm.BringToFront();
            }
            else
            {
                cargaDevoluçãoForm = new FrmCargaDevolução();
                cargaDevoluçãoForm.Show();
            }
        }

        private void btFrmImpressão_Click(object sender, EventArgs e)
        {
            if (impressãoForm.Visible)
            {
                impressãoForm.BringToFront();
            }
            else
            {
                impressãoForm = new FrmImpressão();
                impressãoForm.Show();
            }
        }

        private void btFrmRelatorios_Click(object sender, EventArgs e)
        {
            if (relatoriosForm.Visible)
            {
                relatoriosForm.BringToFront();
            }
            else
            {
                relatoriosForm = new FrmRelatorios();
                relatoriosForm.Show();
            }
        }
    }
}
