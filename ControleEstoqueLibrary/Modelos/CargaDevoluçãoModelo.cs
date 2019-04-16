using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoqueLibrary
{
    public class CargaDevoluçãoModelo
    {
        public int Id { get; set; }
        public int VendedorID { get; set; }
        public int PraçaID { get; set; }
        public DateTime Data { get; set; }
        public bool Devolução { get; set; }
    }
}