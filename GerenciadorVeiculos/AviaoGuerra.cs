﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    internal class AviaoGuerra : Aviao
    {
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
