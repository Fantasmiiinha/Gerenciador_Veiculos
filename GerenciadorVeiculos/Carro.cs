﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    internal class Carro : Veiculo
    {
        public int QuantidadePortas { get; set; }

        public bool LimpadorSwitch { get; set; }

        public bool VeiculoOficial { get; set; }

        public double PagarPedagio()
        {
            return 7.00;
        }

    }
}
