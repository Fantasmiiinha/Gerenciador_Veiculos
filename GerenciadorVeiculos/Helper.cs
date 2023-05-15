using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections;

namespace GerenciadorVeiculos
{
    internal class Helper
    {
        public static void SalvaVeiculosJson(List<Veiculo> veiculos)
        {
            JsonSerializerSettings cfg = new JsonSerializerSettings();
            cfg.TypeNameHandling = TypeNameHandling.All;

            string dados = JsonConvert.SerializeObject(veiculos, cfg);

            File.WriteAllText("veiculos.txt", dados);
        }

        public static List<Veiculo> CarregaVeiculosJson()
        {
            if (File.Exists("veiculos.txt"))
            {
                JsonSerializerSettings cfg = new JsonSerializerSettings();
                cfg.TypeNameHandling = TypeNameHandling.All;

                string json = File.ReadAllText("veiculos.txt");
                List<Veiculo> veics = JsonConvert.DeserializeObject<List<Veiculo>>(json, cfg);

                return veics;
            }
            else
                return new List<Veiculo>(); 
        }

        public static void SalvaPedagiosJson(List<Pedagio> pedagios)
        {
            string dados = JsonConvert.SerializeObject(pedagios);

            File.WriteAllText("pedagios.txt", dados);
        }

        public static List<Pedagio> CarregaPedagioJson()
        {
            if (File.Exists("pedagios.txt"))
            {
                string json = File.ReadAllText("pedagios.txt");
                List<Pedagio> pedagios = JsonConvert.DeserializeObject<List<Pedagio>>(json);

                return pedagios;
            }
            else
                return new List<Pedagio>();
        }

        public static void SalvaMarcasJson(List<Marca> marcas)
        {
            string dados = JsonConvert.SerializeObject(marcas);

            File.WriteAllText("marcas.txt", dados);
        }

        public static List<Marca> CarregaMarcasJson()
        {
            if (File.Exists("marcas.txt"))
            {
                string json = File.ReadAllText("marcas.txt");
                List<Marca> marcas = JsonConvert.DeserializeObject<List<Marca>>(json);

                return marcas;
            }
            else 
                return new List<Marca>(); 
        }

        public static void SalvaModelosJson(List<Modelo> modelo)
        {
            JsonSerializerSettings cfg = new JsonSerializerSettings();
            cfg.TypeNameHandling = TypeNameHandling.All;

            string dados = JsonConvert.SerializeObject(modelo, cfg);

            File.WriteAllText("modelos.txt", dados);
        }

        public static List<Modelo> CarregaModelosJson()
        {
            if (File.Exists("modelos.txt"))
            {
                JsonSerializerSettings cfg = new JsonSerializerSettings();
                cfg.TypeNameHandling = TypeNameHandling.All;
                string json = File.ReadAllText("modelos.txt");
                List<Modelo> modelos = JsonConvert.DeserializeObject<List<Modelo>>(json, cfg);

                return modelos;
            }
            else
                return new List<Modelo>();
        }
    }
}
