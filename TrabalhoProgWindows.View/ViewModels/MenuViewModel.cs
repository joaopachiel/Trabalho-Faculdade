using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TrabalhoProgWindows.View.Auxiliares;
using TrabalhoProgWindows.View.Views;

namespace TrabalhoProgWindows.View.ViewModels
{
    public class MenuViewModel
    {
        public ICommand CrudProduto
        {
            get
            {
                if (crudProduto == null)
                    crudProduto = new MeuComando(ApresentarTela<WProdutoLista>);

                return crudProduto;
            }
        }

        private void ApresentarTela<T>() where T : Window, new()
        {
            var janela = new T();
            janela.ShowDialog();
        }

        private ICommand crudProduto = null;
    }
}
