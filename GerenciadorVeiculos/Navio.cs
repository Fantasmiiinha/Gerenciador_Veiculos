using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    abstract class Navio : Veiculo
    {
        protected Navio(string id, Modelo modelo, int veloAtual, double peso, int passageiros) : base(id, modelo, veloAtual, peso, passageiros)
        {
        }

        public string Atracar()
        {
            return $"Navio {Identificacao} atracou";
        }
    }
}
