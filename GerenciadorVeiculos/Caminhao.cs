using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    internal class Caminhao : Veiculo
    {
        public double PesoCarregado { get; set; }
        public int QtdEixos { get; set; }
        public double CapacidadeMaximaDeCarga { get; set; }
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

        public string Carregar(double peso)
        {
            if (PesoCarregado + peso > CapacidadeMaximaDeCarga)
                throw new Exception();
            else
                PesoCarregado += peso;

            return $"Caminhão {Identificacao} foi carregado com {peso}KG";
        }

        public string Descarregar()
        {
            PesoCarregado = 0;

            return $"Caminhão {Identificacao} foi descarregado";
        }
    }
}
