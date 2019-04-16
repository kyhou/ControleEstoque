using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoqueLibrary
{
    public class DepositoModelo
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public int PraçaId { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorPepino { get; set; }
    }
}