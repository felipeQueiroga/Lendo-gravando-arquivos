using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Aula_arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Temp\itens.txt";
            string targetFolderPath = Path.GetDirectoryName(sourcePath) + "\\out";
            string targetPath = "";
            string outFileName = "summary.csv";

            List<Produto> lista = new List<Produto>();

            try
            {
                //lendo as linhas
                string[] linhas = File.ReadAllLines(sourcePath);
                foreach (string l in linhas)
                {
                    string[] dados = l.Split(",");
                    string nome = dados[0];
                    double preco = double.Parse(dados[1], CultureInfo.InvariantCulture);
                    int qtd = int.Parse(dados[2]);

                    Produto aux = new Produto(nome, preco, qtd);

                    lista.Add(aux);
                }

                //gera sub diretorio
                Directory.CreateDirectory(targetFolderPath);
                targetPath = targetFolderPath + "\\" + outFileName;

                using (StreamWriter sw = File.AppendText(targetPath))
                {

                    //grava arquivo no subDiretorio
                    {
                        foreach (Produto p in lista)
                        {
                            sw.WriteLine(p);
                        }
                    }

                }

            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);

            }
        }
    }
}