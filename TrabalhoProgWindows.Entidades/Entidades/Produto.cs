using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TrabalhoProgWindows.Entidades.Entidades
{
    public class Produto : Entidade
    {
        public string Descricao { get; set; }

        public double Preco { get; set; }

        public void AdicionarInsumo(ProdutoInsumo insumo)
        {
            insumos.Add(insumo);
        }

        public void ExcluirInsumo(ProdutoInsumo insumo)
        {
            insumos.Remove(insumo);
        }

        public IEnumerable<ProdutoInsumo> Insumos { get => insumos; set => insumos = new ObservableCollection<ProdutoInsumo>(value); }

        private ObservableCollection<ProdutoInsumo> insumos = new ObservableCollection<ProdutoInsumo>();


    }
}
