using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoqueLibrary
{
    public class ProdutoModelo
    {
        public int Id { get; set; }
        public string Descrição { get; set; }
        public string Unidade { get; set; }
        public int Estoque { get; set; }
        public decimal PreçoCusto { get; set; }
        public decimal PreçoVenda { get; set; }
    }
}
