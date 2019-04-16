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
    public partial class FrmRelatorioEstoque : Form
    {
        public FrmRelatorioEstoque()
        {
            InitializeComponent();
        }

        private void FrmRelatorioEstoque_Load(object sender, EventArgs e)
        {
            this.rvEstoque.RefreshReport();
        }
    }
}
