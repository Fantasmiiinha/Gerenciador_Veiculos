using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    public abstract class Veiculo
    {

        protected Veiculo(string id, Modelo modelo, int veloAtual, double peso, int passageiros)
        {
            Identificacao = id;
            ModeloVeic = modelo;
            VelocidadeAtual = veloAtual;
            Peso = peso;
            CapacidadeDePassageiros = passageiros;
        }

        public string Identificacao { get; set; }

        public Modelo ModeloVeic { get; set; }

        public int VelocidadeAtual { get; protected set; }

        public double Peso { get; set; }

        public int CapacidadeDePassageiros { get; set; }

        public string TipoVeic 
        {
            get 
            {
                return this.GetType().Name;
            }
        }

        public string DiplayCombo
        {
            get
            {
                return TipoVeic + " - " + Identificacao;
            }
        }

        public virtual string Acelera()
        {
            return $"{TipoVeic}: {Identificacao} acelerou para {++VelocidadeAtual}Km/h";
        }

        public string Desacelera()
        {
            return $"{TipoVeic}: {Identificacao} freiou para {--VelocidadeAtual}Km/h";
        }

        public override string ToString()
        {
            return $"{TipoVeic}: {Identificacao} - {ModeloVeic.ToString()}, velocidade:{VelocidadeAtual}Km/h, " +
                $"peso:{Peso}Kg, capacidade de passageiros:{CapacidadeDePassageiros}";
        }
    }
}
