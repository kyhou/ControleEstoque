using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoqueLibrary
{
    public class PedidoModelo
    {
        public int Id { get; set; }
        public int PessoaID { get; set; }
        public int VendedorID { get; set; }
        public int PraçaID { get; set; }
        public DateTime DataEmissão { get; set; }
        public int TotalUnidades { get; set; }
        public int TotalItens { get; set; }
        public float Comissão { get; set; }
        public DateTime DataRetorno { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPago { get; set; }
        public bool Finalizado { get; set; }
    }
}
