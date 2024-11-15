using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_de_Jogos
{
    internal class Locacao
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdJogo { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
