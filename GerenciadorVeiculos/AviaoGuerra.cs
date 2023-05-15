using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    internal class AviaoGuerra : Aviao, IGuerra
    {
        public AviaoGuerra(string id, Modelo modelo, int veloAtual, double peso, int passageiros) : base(id, modelo, veloAtual, peso, passageiros)
        {
        }

        public string Atacar()
        {
            return $"Avião {Identificacao} atacou";
        }

        public string Ejetar()
        {
            return $"Avião {Identificacao} está ejetou";
        }
    }
}
