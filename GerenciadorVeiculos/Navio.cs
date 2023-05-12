using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    abstract class Navio : Veiculo
    {
        public string Atracar()
        {
            return $"Navio {Identificacao} atracou";
        }
    }
}
