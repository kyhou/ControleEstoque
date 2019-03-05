using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoqueLibrary
{
    public class ItemModelo
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        //public float Comissão { get; set; }
        public int Entregue { get; set; }
        public int Devolvido { get; set; }
        public int Vendido { get; set; }
        //public decimal PreçoUnitario { get; set; }
        public decimal PreçoTotal { get; set; }
    }
}
