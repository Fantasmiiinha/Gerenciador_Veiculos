using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    abstract class Veiculo
    {
        private string id;
        private Modelo modelo;
        private int veloAtual;
        private int passageiros;

        protected Veiculo(string id, Modelo modelo, int veloAtual, int peso, int passageiros)
        {
            this.id = id;
            this.modelo = modelo;
            this.veloAtual = veloAtual;
            Peso = peso;
            this.passageiros = passageiros;
        }

        public String Identificacao { get; set; }

        public Modelo ModeloVeic { get; set; }

        public int VelecidadeAtual { get; protected set; }

        public double Peso { get; set; }

        public int CapacidadeDePassageiros { get; set; }

        public string Acelera()
        {
            return $"Veiculo {Identificacao} acelerou para {++VelecidadeAtual}Km/h";
        }

        public string Desacelera()
        {
            return $"Veiculo {Identificacao} freiou para {--VelecidadeAtual}Km/h";
        }

        public override string ToString()
        {
            return $"{Identificacao} - {ModeloVeic.ToString()}, velocidade:{VelecidadeAtual}Km/h" +
                $"peso:{Peso}Kg, capacidade passageiros:{CapacidadeDePassageiros}";
        }
    }
}
