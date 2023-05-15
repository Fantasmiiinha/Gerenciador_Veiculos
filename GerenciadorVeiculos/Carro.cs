using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    internal class Carro : Veiculo, IPaganteDePedagio, IAdicional
    {
        public int QuantidadePortas { get; set; }

        public bool LimpadorSwitch { get; set; }

        public bool VeiculoOficial { get; set; }

        public Carro(string id, Modelo modelo, int veloAtual, double peso, int passageiros, int portas, bool oficial) : base(id, modelo, veloAtual, peso, passageiros) 
        {
            QuantidadePortas = portas;
            VeiculoOficial = oficial;
        }

        public double PagarPedagio()
        {
            if (VeiculoOficial)
                return 0;
            else
                return 7.00;
        }

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

        public override string ToString()
        {
            string isOficial = VeiculoOficial ? "sim" : "não";
            return base.ToString() + $", portas:{QuantidadePortas}, oficial:{isOficial}";
        }
    }
}
