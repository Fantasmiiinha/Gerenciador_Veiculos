using GerenciadorVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorVeiculos
{//Classe responsável por gerar placas aleatórias para os veículos terrestres, que servirão também com identificadores únicos
    public class IdentificadorGen
    {
        private static Random random = new Random();
        private static string[] letras = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public static string GerarPlaca(List<Veiculo> lista)
        {
            while (true)
            {
                string placa = GerarCombinacao();

                if (lista.FindAll(x => x.Identificacao == placa).Count == 0)
                {
                    return placa;
                }
            }
        }

        private static string GerarCombinacao()
        {
            return CombinaLetras() + CombinaNumeros();
        }
        private static string CombinaLetras()
        {
            string combinacao = "";

            for (int i = 0; i < 3; i++)
            {
                int pos = random.Next(0, 26);
                combinacao += letras[pos];
            }

            return combinacao;
        }
        private static string CombinaNumeros()
        {
            string combinacao = "";
            for (int i = 0; i < 4; i++)
            {
                int pos = random.Next(0, 10);
                combinacao += pos.ToString();
            }
            return combinacao;
        }
    }
}
