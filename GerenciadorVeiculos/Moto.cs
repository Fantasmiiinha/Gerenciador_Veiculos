using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    internal class Moto : Veiculo, PaganteDePedagio
    {
        public string Empinar()
        {
            return $"Moto {Identificacao} está empinando";
        }

        public double PagarPedagio()
        {
            return 3.00;
        }
    }
}
