using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace GerenciadorVeiculos
{
    public partial class Form1 : Form
    {
        static List<Veiculo> veiculos = new List<Veiculo>();
        List<Marca> marcas = new List<Marca>();
        List<Modelo> modelos = new List<Modelo>();
        List<Pedagio> pedagios = new List<Pedagio>();
        Veiculo veiculoSelecionado;
        Pedagio pedagioSelecionado;

        public Form1()
        {
            InitializeComponent();

            AtualizarCbxMarca();
            AtualizarCbxVeiculos();
            AtulizarCbxModelo();
            AtualizarCbxPedagio();
        }

        #region Utils

        private void btnCarregaDados_Click(object sender, EventArgs e)
        {
            veiculos = Helper.CarregaVeiculosJson();
            pedagios = Helper.CarregaPedagioJson();
            marcas = Helper.CarregaMarcasJson();
            modelos = Helper.CarregaModelosJson();

            rtbPedagio.Text = "";
            rtbVeiculos.Text = "";
            ListarPedagios();
            ListarVeiculos();
            AtualizarCbxVeiculos();
            AtualizarCbxPedagio();
            AtualizarCbxMarca();
            AtulizarCbxModelo();
        }
        public void AtualizarCbxVeiculos()
        {
            cbxVeiculos.DataSource = null;
            cbxVeiculos.DataSource = veiculos;
            cbxVeiculos.DisplayMember = "DiplayCombo";

            cbxVeiculoBusca.DataSource = null;
            cbxVeiculoBusca.DataSource = veiculos;
            cbxVeiculoBusca.DisplayMember = "Identificacao";
        }

        public void AtulizarCbxModelo()
        {
            cbxModelo.DataSource = null;
            cbxModelo.DataSource = modelos;
            cbxModelo.DisplayMember = "Descricao";
        }

        public void AtualizarCbxMarca()
        {
            cbxMarca.DataSource = null;
            cbxMarca.DataSource = marcas;
            cbxMarca.DisplayMember = "Descricao";
        }

        public void AtualizarCbxPedagio()
        {
            cbxPedagio.DataSource = null;
            cbxPedagio.DataSource = pedagios;
            cbxPedagio.DisplayMember = "DisplayCombo";

            cbxPedagioBusca.DataSource = null;
            cbxPedagioBusca.DataSource = pedagios;
            cbxPedagioBusca.DisplayMember = "DisplayCombo";
        }

        private void ListarVeiculos()
        {
            foreach (var veiculo in veiculos)
            {
                rtbVeiculos.Text += veiculo.ToString() + "\n ------------------------------------------------------- \n";
            }
        }

        public void ListarPedagios()
        {
            foreach (var pedagio in pedagios)
            {
                rtbPedagio.Text += "Pedágio:" + pedagio.Identificacao + " Localizado em " + pedagio.Localizacao + " Total de R$" + pedagio.TotalRecebido
                                    + "\n ------------------------------------------------------- \n";
            }
        }

        public void LimpaCamposCadatros()
        {
            txtIdentificacao.Clear();
            txtVelocidadeAtual.Clear();
            txtPassageiros.Clear();
            txtPeso.Clear();
            cbxModelo.SelectedIndex = -1;
            txtQtdPorta.Clear();
            ckbOficial.Checked = false;
            txtEixosOnibus.Clear();
            ckbLeito.Checked = false;
            txtVagoes.Clear();
            txtEixosCaminhao.Clear();
            txtCapacidadeCarga.Clear();
            txtEixosOnibus.Clear();
            ckbLeito.Checked = false;
            txtVagoes.Clear();
        }

        public bool VerificaItensVeiculo()
        {
            double i;
            int a, v;

            if (txtIdentificacao.Text.Trim() != "" 
                && double.TryParse(txtPeso.Text, out i)
                && int.TryParse(txtPassageiros.Text, out a)
                && int.TryParse(txtVelocidadeAtual.Text, out v)
                && cbxModelo.SelectedIndex != -1)
                return true;
            else 
            {
                MessageBox.Show("Algum campo do veiculo não foi preenchido corretamente");
                return false;
            } 
                
        }

        private void btnBuscarVeic_Click(object sender, EventArgs e)
        {
            rtbVeiculos.Clear();

            rtbVeiculos.Text = veiculos.Find(v => v.Identificacao == (cbxVeiculoBusca.SelectedItem as Veiculo).Identificacao).ToString();
        }

        #endregion

        #region Listagem
        private void button1_Click(object sender, EventArgs e)
        {
            rtbVeiculos.Text = "";
            ListarVeiculos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Helper.SalvaVeiculosJson(veiculos);
            Helper.SalvaPedagiosJson(pedagios);
            Helper.SalvaMarcasJson(marcas);
            Helper.SalvaModelosJson(modelos);
        }

        #endregion

        #region Ações
        private void cbxVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxVeiculos.SelectedIndex != -1)
                 veiculoSelecionado = veiculos.Find(t => t.Identificacao == (cbxVeiculos.SelectedItem as Veiculo).Identificacao);
        }

        private void cbxPedagio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxPedagio.SelectedIndex != -1)
            {
                pedagioSelecionado = pedagios.Find(p => p.Identificacao == (cbxPedagio.SelectedItem as Pedagio).Identificacao);
            }
        }

        private void btnLimparNoti_Click(object sender, EventArgs e)
        {
            rtbNotifi.Text = "";
        }

        private void btnAcelerar_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else 
            {
                rtbNotifi.Text += veiculoSelecionado.Acelera() + "\n";
            }
        }

        private void btnDesacelerar_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else
            {
                rtbNotifi.Text += veiculoSelecionado.Desacelera() + "\n";
            }
        }

        private void btnLimpadorOn_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else if (veiculoSelecionado is IAdicional)
            {
                rtbNotifi.Text += (veiculoSelecionado as IAdicional).LigaLimpador() + "\n";
            }
            else
            {
                MessageBox.Show("Veiculo selecionado não tem limpador");
            }
        }

        private void btnLimpadorOff_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else if (veiculoSelecionado is IAdicional)
            {
                rtbNotifi.Text += (veiculoSelecionado as IAdicional).DesligaLimpador() + "\n";
            }
            else
            {
                MessageBox.Show("Veiculo selecionado não tem limpador");
            }
        }

        private void btnEmpinar_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else if (veiculoSelecionado is Moto)
            {
                rtbNotifi.Text += (veiculoSelecionado as Moto).Empinar() + "\n";
            }
            else
            {
                MessageBox.Show("Veiculo selecionado não é uma moto");
            }
        }

        private void btnDescarregar_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else if (veiculoSelecionado is Caminhao)
            {
                rtbNotifi.Text += (veiculoSelecionado as Caminhao).Descarregar() + "\n";
            }
            else
            {
                MessageBox.Show("Veiculo selecionado não é um camihão");
            }
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else if (veiculoSelecionado is Caminhao)
            {
                try
                {
                    if (txtPesoCarrega.Text.Trim() != "")
                        rtbNotifi.Text += (veiculoSelecionado as Caminhao).Carregar(int.Parse(txtPesoCarrega.Text)) + "\n";
                    else
                        MessageBox.Show("É preciso informar o peso que será carregado");
                }
                catch
                {
                    MessageBox.Show($"Caminão {veiculoSelecionado.Identificacao} foi sobrecarregado e não pode acelerar mais");
                }
            }
            else
            {
                MessageBox.Show("Veiculo selecionado não é um camihão");
            }
        }

        private void btnDecolar_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else if (veiculoSelecionado is Aviao)
            {
                rtbNotifi.Text += (veiculoSelecionado as Aviao).Decolar() + "\n";
            }
            else
            {
                MessageBox.Show("Veiculo selecionado não é um avião");
            }
        }

        private void btnPousar_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else if (veiculoSelecionado is Aviao)
            {
                rtbNotifi.Text += (veiculoSelecionado as Aviao).Pousar() + "\n";
            }
            else
            {
                MessageBox.Show("Veiculo selecionado não é um avião");
            }
        }

        private void btnArremeter_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else if (veiculoSelecionado is Aviao)
            {
                rtbNotifi.Text += (veiculoSelecionado as Aviao).Arremeter() + "\n";
            }
            else
            {
                MessageBox.Show("Veiculo selecionado não é um avião");
            }
        }

        private void btnEjetar_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else if (veiculoSelecionado is AviaoGuerra)
            {
                rtbNotifi.Text += (veiculoSelecionado as AviaoGuerra).Ejetar() + "\n";
            }
            else
            {
                MessageBox.Show("Veiculo selecionado não é um avião de guerra");
            }
        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else if (veiculoSelecionado is IGuerra)
            {
                rtbNotifi.Text += (veiculoSelecionado as IGuerra).Atacar() + "\n";
            }
            else
            {
                MessageBox.Show("Veiculo selecionado não é um veiculo de guerra");
            }
        }

        private void btnAtracar_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione algum veículo");
            }
            else if (veiculoSelecionado is Navio)
            {
                rtbNotifi.Text += (veiculoSelecionado as Navio).Atracar() + "\n";
            }
            else
            {
                MessageBox.Show("Veiculo selecionado não é um navio");
            }
        }

        private void btnPagarPedagio_Click(object sender, EventArgs e)
        {
            if (cbxVeiculos.SelectedIndex != -1)
            {
                if (cbxPedagio.SelectedIndex != -1)
                {
                    if (veiculoSelecionado is IPaganteDePedagio)
                    {
                        pedagioSelecionado.Receber((IPaganteDePedagio)veiculoSelecionado);
                        rtbNotifi.Text += $"Veiculo {veiculoSelecionado.Identificacao} pagou R$" + (veiculoSelecionado as IPaganteDePedagio).PagarPedagio() 
                                            + $" no pedágio {pedagioSelecionado.DisplayCombo}\n";
                    }
                    else
                    {
                        MessageBox.Show("Veiculo selecionado não é um veiculo que paga pedágio");
                    }
                }
                else
                    MessageBox.Show("Primeiro selecione algum pedágio");
            } 
            else
                MessageBox.Show("Primeiro selecione algum veiculo");

        }
        #endregion

        #region Instâncias Veiculos

        private void btnInstancia_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca(1, "Chevrolet");
            Modelo modelo = new Modelo(1, "Corsa envenenado", marca);
            marcas.Add(marca);
            modelos.Add(modelo);
            AtualizarCbxMarca();
            AtulizarCbxModelo();

            veiculos.Add(new Carro(IdentificadorGen.GerarPlaca(veiculos), modelo, 10, 500.0, 5, 4, false));
            veiculos.Add(new Caminhao(IdentificadorGen.GerarPlaca(veiculos), modelo, 20, 1000, 2, 6, 2000));
            veiculos.Add(new Moto(IdentificadorGen.GerarPlaca(veiculos), modelo, 50, 400, 2));
            veiculos.Add(new Onibus(IdentificadorGen.GerarPlaca(veiculos), modelo, 15, 1200, 35, 4, false));
            veiculos.Add(new NavioPasseio(IdentificadorGen.GerarPlaca(veiculos), modelo, 30, 3000, 500));
            veiculos.Add(new NavioGuerra(IdentificadorGen.GerarPlaca(veiculos), modelo, 35, 4000, 300));
            veiculos.Add(new AviaoPasseio(IdentificadorGen.GerarPlaca(veiculos), modelo, 150, 1300, 50));
            veiculos.Add(new AviaoGuerra(IdentificadorGen.GerarPlaca(veiculos), modelo, 250, 500, 1));
            veiculos.Add(new Trem(IdentificadorGen.GerarPlaca(veiculos), modelo, 160, 3000, 400, 15));
            ListarVeiculos();
            AtualizarCbxVeiculos();

            pedagios.Add(new Pedagio("0", "Allianz Parque"));
            AtualizarCbxPedagio();
            ListarPedagios();
        }

        private void btnCriaCarro_Click(object sender, EventArgs e)
        {
            int p;
            if (txtQtdPorta.Text.Trim() != "" && int.TryParse(txtQtdPorta.Text, out p))
            {
                if (VerificaItensVeiculo())
                {
                    veiculos.Add(new Carro(txtIdentificacao.Text,
                                          (Modelo)cbxModelo.SelectedItem,
                                          int.Parse(txtVelocidadeAtual.Text),
                                          double.Parse(txtPeso.Text),
                                          int.Parse(txtPassageiros.Text),
                                          p,
                                          ckbOficial.Checked));

                    LimpaCamposCadatros();
                    AtualizarCbxVeiculos();
                }
            }
            else
                MessageBox.Show("Quantidade de portas preenchido incorretamente");
            
        }

        private void btnCriaOnibus_Click(object sender, EventArgs e)
        {
            int ex;
            if (txtEixosOnibus.Text.Trim() != "" && int.TryParse(txtEixosOnibus.Text, out ex))
            {
                if (VerificaItensVeiculo())
                {
                    veiculos.Add(new Onibus(txtIdentificacao.Text,
                                          (Modelo)cbxModelo.SelectedItem,
                                          int.Parse(txtVelocidadeAtual.Text),
                                          double.Parse(txtPeso.Text),
                                          int.Parse(txtPassageiros.Text),
                                          ex,
                                          ckbLeito.Checked));

                    LimpaCamposCadatros();
                    AtualizarCbxVeiculos();
                }
            }
            else
                MessageBox.Show("Quantidade de eixos preenchido incorretamente");
        }

        private void btnCriaTrem_Click(object sender, EventArgs e)
        {
            int v;
            if (txtVagoes.Text.Trim() != "" && int.TryParse(txtVagoes.Text, out v))
            {
                if (VerificaItensVeiculo())
                {
                    veiculos.Add(new Trem(txtIdentificacao.Text,
                                          (Modelo)cbxModelo.SelectedItem,
                                          int.Parse(txtVelocidadeAtual.Text),
                                          double.Parse(txtPeso.Text),
                                          int.Parse(txtPassageiros.Text),
                                          v));

                    LimpaCamposCadatros();
                    AtualizarCbxVeiculos();
                }
            }
            else
                MessageBox.Show("Quantidade de vagões preenchido incorretamente");
        }

        private void btnCriaCaminhao_Click(object sender, EventArgs e)
        {
            int ex;
            double cp;
            if (txtEixosCaminhao.Text.Trim() != "" && int.TryParse(txtEixosCaminhao.Text, out ex)
                && txtCapacidadeCarga.Text.Trim() != "" && double.TryParse(txtCapacidadeCarga.Text, out cp))
            {
                if (VerificaItensVeiculo())
                {
                    veiculos.Add(new Caminhao(txtIdentificacao.Text,
                                      (Modelo)cbxModelo.SelectedItem,
                                      int.Parse(txtVelocidadeAtual.Text),
                                      double.Parse(txtPeso.Text),
                                      int.Parse(txtPassageiros.Text),
                                      ex,
                                      double.Parse(txtCapacidadeCarga.Text)));

                    LimpaCamposCadatros();
                    AtualizarCbxVeiculos();
                }
            }
            else
                MessageBox.Show("Atributos de caminão preenchido incorretamente");
        }

        private void btnCriaMoto_Click(object sender, EventArgs e)
        {
            if (VerificaItensVeiculo())
            {
                veiculos.Add(new Moto(txtIdentificacao.Text,
                                  (Modelo)cbxModelo.SelectedItem,
                                  int.Parse(txtVelocidadeAtual.Text),
                                  double.Parse(txtPeso.Text),
                                  int.Parse(txtPassageiros.Text)));

                LimpaCamposCadatros();
                AtualizarCbxVeiculos();
            }
        }

        private void btnCriaNavio_Click(object sender, EventArgs e)
        {
            if (VerificaItensVeiculo())
            {
                veiculos.Add(new NavioPasseio(txtIdentificacao.Text,
                                  (Modelo)cbxModelo.SelectedItem,
                                  int.Parse(txtVelocidadeAtual.Text),
                                  double.Parse(txtPeso.Text),
                                  int.Parse(txtPassageiros.Text)));

                LimpaCamposCadatros();
                AtualizarCbxVeiculos();
            }
        }

        private void btnCriaNavioGuerra_Click(object sender, EventArgs e)
        {
            if (VerificaItensVeiculo())
            {
                veiculos.Add(new NavioGuerra(txtIdentificacao.Text,
                                  (Modelo)cbxModelo.SelectedItem,
                                  int.Parse(txtVelocidadeAtual.Text),
                                  double.Parse(txtPeso.Text),
                                  int.Parse(txtPassageiros.Text)));

                LimpaCamposCadatros();
                AtualizarCbxVeiculos();
            }
        }

        private void btnCriaAviao_Click(object sender, EventArgs e)
        {
            if (VerificaItensVeiculo())
            {
                veiculos.Add(new AviaoPasseio(txtIdentificacao.Text,
                                  (Modelo)cbxModelo.SelectedItem,
                                  int.Parse(txtVelocidadeAtual.Text),
                                  double.Parse(txtPeso.Text),
                                  int.Parse(txtPassageiros.Text)));

                LimpaCamposCadatros();
                AtualizarCbxVeiculos();
            }
        }

        private void btnCriaAviaoGuerra_Click(object sender, EventArgs e)
        {
            if (VerificaItensVeiculo())
            {
                veiculos.Add(new AviaoGuerra(txtIdentificacao.Text,
                                  (Modelo)cbxModelo.SelectedItem,
                                  int.Parse(txtVelocidadeAtual.Text),
                                  double.Parse(txtPeso.Text),
                                  int.Parse(txtPassageiros.Text)));

                LimpaCamposCadatros();
                AtualizarCbxVeiculos();
            }
        }
        #endregion

        #region Instâncias Marca Modelo
        private void btnCriarModelo_Click(object sender, EventArgs e)
        {
            if (txtCodModelo.Text.Trim() != "" && txtDescModelo.Text.Trim() != "" && cbxMarca.SelectedIndex != 1)
            {
                modelos.Add(new Modelo(int.Parse(txtCodModelo.Text),
                                       txtDescModelo.Text,
                                       (Marca)cbxMarca.SelectedItem));

                AtulizarCbxModelo();

                txtCodModelo.Clear();
                txtDescModelo.Clear();
                cbxMarca.SelectedIndex = -1;
            }
            else
                MessageBox.Show("Algum campo de Modelo está incorreto");
        }

        private void btnCriarMarca_Click(object sender, EventArgs e)
        {
            if (txtCodMarca.Text.Trim() != "" && txtDescMarca.Text.Trim() != "")
            {
                marcas.Add(new Marca(int.Parse(txtCodMarca.Text),
                                     txtDescMarca.Text));

                AtualizarCbxMarca();

                txtCodMarca.Clear();
                txtDescMarca.Clear();
            }
            else
                MessageBox.Show("Algum campo de Marca está incorreto");
        }
        #endregion

        #region Pedágios
        private void btnCriaPedagio_Click(object sender, EventArgs e)
        {
            if (txtIdPedagio.Text.Trim() != "" && txtLocalizacaoPedagio.Text.Trim() != "")
            {
                pedagios.Add(new Pedagio(txtIdPedagio.Text, txtLocalizacaoPedagio.Text));
                AtualizarCbxPedagio();

                txtIdPedagio.Clear();
                txtLocalizacaoPedagio.Clear();
            }
            else
                MessageBox.Show("Algum campo de Pedágio está incorreto");
        }

        private void btnListarPedagios_Click(object sender, EventArgs e)
        {
            rtbPedagio.Clear();
            ListarPedagios();
        }

        private void btnHistoricoPedagio_Click(object sender, EventArgs e)
        {
            if (cbxPedagioBusca.SelectedIndex != -1)
            {
                rtbPedagio.Clear();
                rtbPedagio.Text = (cbxPedagioBusca.SelectedItem as Pedagio).Historico;
            }
            else
            {
                MessageBox.Show("Primeiro selecione um pedágio");
            }
        }

        private void btnCobrancaAuto_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            if (pedagios.Count != 0 && veiculos.FindAll(t => t is IPaganteDePedagio).Count != 0)
            {
                int i = 0;
                Pedagio[] p = pedagios.ToArray();
                Veiculo[] v = veiculos.FindAll(t => t is IPaganteDePedagio).ToArray();

                while (i < 9)
                {
                    Pedagio pe = p[random.Next(0, p.Length)];
                    Veiculo ve = v[random.Next(0, v.Length)];
                    pe.Receber((IPaganteDePedagio)ve);
                    i++;
                }
            }
            else
                MessageBox.Show("Não há dados o suficiente para essa operação");
        }

        #endregion

    }
}
