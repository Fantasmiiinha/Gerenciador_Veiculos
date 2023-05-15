using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    internal class Caminhao : Veiculo, IPaganteDePedagio, IAdicional
    {
        public Caminhao(string id, Modelo modelo, int veloAtual, double peso, int passageiros, int eixos, double capacidadeMax) : base(id, modelo, veloAtual, peso, passageiros)
        {
            QtdEixos = eixos;
            CapacidadeMaximaDeCarga = capacidadeMax;
        }

        public double PesoCarregado { get; protected set; }
        public int QtdEixos { get; set; }
        public double CapacidadeMaximaDeCarga { get; set; }
        public bool LimpadorSwitch { get; set; }

        private bool podeAcelerar = true;

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

        public override string Acelera()
        {
            if (podeAcelerar)
                return base.Acelera();
            else
                return $"Caminhão {Identificacao} está sobrecarregado e não pode acelerar para tal descarregue-o";
        }

        public string Carregar(double peso)
        {
            PesoCarregado += peso;

            if (PesoCarregado + peso > CapacidadeMaximaDeCarga)
            {
                podeAcelerar = false;
                throw new SobrePessoException();
            }
            
            return $"Caminhão {Identificacao} foi carregado com {peso}KG e está com {PesoCarregado}";
        }

        public string Descarregar()
        {
            PesoCarregado = 0;
            podeAcelerar = true;
            return $"Caminhão {Identificacao} foi descarregado";
        }

        public override string ToString()
        {
            return base.ToString() + $", carregando:{PesoCarregado}, eixos:{QtdEixos}, Máx de carga:{CapacidadeMaximaDeCarga}";
        }
    }
}
