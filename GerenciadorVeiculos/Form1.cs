using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace GerenciadorVeiculos
{
    public partial class Form1 : Form
    {
        List<Veiculo> veiculos = new List<Veiculo>();
        List<Marca> marcas = new List<Marca>();
        List<Modelo> modelos = new List<Modelo>();

        public Form1()
        {
            InitializeComponent();
        }

        private void ListarVeiculos()
        {
            foreach (var veiculo in veiculos)
            {
                rtbTeste.Text += veiculo.ToString() + "\n";
            }
        }

        private void btnInstancia_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca(1, "BMW");
            Modelo modelo = new Modelo(1, "Super modelo", marca);
            marcas.Add(marca);
            modelos.Add(modelo);

            veiculos.Add(new Carro("bbb-bbb", modelo, 10, 500, 5, 4, false));

            ListarVeiculos();
        }
    }
}
