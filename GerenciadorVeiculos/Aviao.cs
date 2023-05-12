using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    abstract class Aviao : Veiculo
    {

        public string Pousar()
        {
            return $"Avião {Identificacao} pousou";
        }

        public string Arremeter()
        {
            return $"Avião {Identificacao} arremeteu";
        }

        public string Decolar()
        {
            return $"Avião {Identificacao} Decolou";
        }
    }
}
