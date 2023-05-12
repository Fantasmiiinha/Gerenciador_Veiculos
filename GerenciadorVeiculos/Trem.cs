using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    internal class Trem : Veiculo
    {
        public Trem(string id, Modelo modelo, int veloAtual, int peso, int passageiros, int vagoes) : base(id, modelo, veloAtual, peso, passageiros)
        {
            QtdVagoes = vagoes;
        }

        public int QtdVagoes { get; set; }

        public bool LimpadorSwitch { get; set; }

        public string LigaLimpador()
        {
            if (LimpadorSwitch)
                return $"Limpador do veículo {Identificacao} já está ligado";
            else
            {
                LimpadorSwitch = true;
                return $"Ligando limpador do veículo {Identificacao}";
            }
        }

        public string DesligaLimpador()
        {
            if (LimpadorSwitch == false)
                return $"Limpador do veículo {Identificacao} já está desligado";
            else
            {
                LimpadorSwitch = false;
                return $"Desligando limpador do veículo {Identificacao}";
            }
        }
    }
}
