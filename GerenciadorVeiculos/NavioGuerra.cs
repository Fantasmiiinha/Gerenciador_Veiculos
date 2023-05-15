using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    internal class NavioGuerra : Navio, IGuerra
    {
        public NavioGuerra(string id, Modelo modelo, int veloAtual, double peso, int passageiros) : base(id, modelo, veloAtual, peso, passageiros)
        {
        }

        public string Atacar()
        {
            return $"Navio {Identificacao} atacou";
        }
    }
}
