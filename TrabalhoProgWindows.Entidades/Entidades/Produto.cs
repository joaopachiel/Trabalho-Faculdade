using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoProgWindows.Entidades.Entidades
{
    public class Produto : Entidade
    {
        public string Descricao { get; set; }

        public double Preco { get; set; }

        public IEnumerable<ProdutoInsumo> Insumos { get; set; }


    }
}
