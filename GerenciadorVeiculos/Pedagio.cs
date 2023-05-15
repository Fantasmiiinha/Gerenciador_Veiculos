using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorVeiculos
{
    internal class Pedagio
    {
        public string Identificacao { get; set; }
        public string Localizacao { get; set; }
        public double TotalRecebido { get; set; }
        public string Historico { get; set; }

        public string DisplayCombo 
        {
            get
            {
                return Identificacao + " - " + Localizacao;
            }
        }

        public Pedagio(string id, string loca)
        {
            Identificacao = id;
            Localizacao = loca;
        }

        public string Receber(IPaganteDePedagio pagante)
        {
            TotalRecebido += pagante.PagarPedagio();
            Historico += $"{DateTime.Now} -> veiculo:{(pagante as Veiculo).Identificacao} pagou R${pagante.PagarPedagio()} \n";
            return Historico;
        }
    }
}
