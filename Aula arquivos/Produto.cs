using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Aula_arquivos
{
    class Produto
    {
        public string nome { get; set; }
        public double preco { get; set; }
        public int qtd { get; set; }

        public Produto(string nome, double preco, int qtd)
        {
            this.nome = nome;
            this.preco = preco;
            this.qtd = qtd;
        }

        public double valorTotal()
        {
            return preco * qtd;
        }

        public override string ToString()
        {
            return nome
                + ","
                + valorTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
        
    }
}
