using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_de_Jogos
{
    internal class Jogo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Plataforma { get; set; }
        public int AnoLancamento { get; set; }
        public decimal PrecoDiaria { get; set; }
    }
}
