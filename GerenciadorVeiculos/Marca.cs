using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    public class Marca
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public Marca(int cod, string desc) 
        {
            Codigo = cod;
            Descricao = desc;
        }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
