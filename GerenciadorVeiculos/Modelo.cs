﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    public  class Modelo
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public Marca Marca { get; set; }

        public Modelo(int cod, string desc, Marca marca) 
        {
            Codigo = cod;
            Descricao = desc;
            Marca = marca;
        }

        public override string ToString()
        {
            return Descricao + " - " + Marca.ToString();
        }
    }
}
