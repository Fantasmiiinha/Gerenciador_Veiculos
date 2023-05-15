using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    internal class Onibus : Veiculo, IPaganteDePedagio, IAdicional
    {
        public Onibus(string id, Modelo modelo, int veloAtual, double peso, int passageiros, int eixos, bool leito) : base(id, modelo, veloAtual, peso, passageiros)
        {
            QtdEixos = eixos;
            Leito = leito;
        }

        public int QtdEixos { get; set; }
        public bool Leito { get; set; }
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

        public double PagarPedagio()
        {
            return 8.50 * QtdEixos;
        }

        public override string ToString()
        {
            string isLeito = Leito ? "sim" : "não";
            return base.ToString() + $"eixos:{QtdEixos}, Leito:{isLeito}";
        }
    }
}
