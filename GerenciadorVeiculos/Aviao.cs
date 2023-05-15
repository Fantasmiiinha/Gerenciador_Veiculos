using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    abstract class Aviao : Veiculo
    {
        protected Aviao(string id, Modelo modelo, int veloAtual, double peso, int passageiros) : base(id, modelo, veloAtual, peso, passageiros)
        {
        }

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
            return $"Avião {Identificacao} decolou";
        }
    }
}
