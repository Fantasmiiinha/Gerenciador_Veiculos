using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    abstract class Veiculo
    {
        public String Identificacao { get; set; }

        public Modelo ModeloVeic { get; set; }

        public int VelecidadeAtual { get; set; }

        public double Peso { get; set; }

        public int CapacidadeDePassageiros { get; set; }

        public int Acelera()
        {
            return VelecidadeAtual++;
        }

        public int Desacelera()
        {
            return VelecidadeAtual--;
        }
    }
}
