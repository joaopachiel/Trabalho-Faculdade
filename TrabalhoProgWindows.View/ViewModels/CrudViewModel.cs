using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TrabalhoProgWindows.Entidades.Entidades;
using TrabalhoProgWindows.View.Auxiliares;

namespace TrabalhoProgWindows.View.ViewModels
{
    public abstract class CrudViewModel<TObj, TWindow> : BaseViewModel where TObj : Entidade, new() where TWindow : Window, new()
    {
        public bool SalvarHabilitado => TipoAcao == ETipoAcaoCrud.Incluindo || TipoAcao == ETipoAcaoCrud.Alterando;
        public bool Consultando => TipoAcao == ETipoAcaoCrud.Consultando || TipoAcao == ETipoAcaoCrud.Listando;

        public TObj ObjetoSelecionado
        {
            get => objetoSelecionado;
            set
            {
                Notificar(objetoSelecionado = value);
                ObjetoSelecionadoAlterado();
            }
        }

        public ObservableCollection<TObj> Lista
        {
            get => lista;
            set => Notificar(lista = value);
        }

        public ICommand Incluir
            => Comando(ref incluir, () => MostrarJanela(ETipoAcaoCrud.Incluindo));

        public ICommand Alterar
            => Comando(ref alterar, () => MostrarJanela(ETipoAcaoCrud.Alterando));

        public ICommand Consultar
            => Comando(ref consultar, () => MostrarJanela(ETipoAcaoCrud.Consultando));

        public ICommand Excluir
            => Comando(ref excluir, TratarExclusao);

        public ICommand Salvar
            => Comando(ref salvar, SalvarObjeto);

        public ICommand Sair
            => Comando(ref sair, FecharJanela);

        public ETipoAcaoCrud TipoAcao
        {
            get
            {
                return tipoAcao;
            }

            set
            {
                Notificar(tipoAcao = value);
                Notificar(null, nameof(SalvarHabilitado));
                Notificar(null, nameof(Consultando));
            }
        }

        protected virtual void ObjetoSelecionadoAlterado()
        {

        }

        protected abstract void Filtrar();
        protected abstract void InserirObjeto(TObj obj);
        protected abstract void AlterarObjeto(TObj obj);
        protected abstract void ExcluirObjeto(TObj obj);
        protected abstract void DescartarAlteracao(TObj obj);
        protected abstract void RealizarCargaTardia(TObj obj);

        private void FecharJanela()
        {
            if (tipoAcao == ETipoAcaoCrud.Alterando)
                DescartarAlteracao(objetoSelecionado);

            if (janela != null)
                janela.Close();
        }

        private void SalvarObjeto()
        {
            if (TipoAcao == ETipoAcaoCrud.Incluindo)
                InserirObjeto(objetoSelecionado);
            else if (TipoAcao == ETipoAcaoCrud.Alterando)
                AlterarObjeto(objetoSelecionado);

            janela.Close();
        }

        private void MostrarJanela(ETipoAcaoCrud tipoAcao)
        {
            this.TipoAcao = tipoAcao;

            if (tipoAcao == ETipoAcaoCrud.Incluindo)
                ObjetoSelecionado = new TObj();
            else
                RealizarCargaTardia(objetoSelecionado);

            janela = new TWindow();
            janela.DataContext = this;
            janela.ShowDialog();

            this.TipoAcao = ETipoAcaoCrud.Listando;
            Filtrar();
        }

        private ICommand Comando(ref ICommand comando, Action acao)
        {
            if (comando == null)
                comando = new MeuComando(acao);

            return comando;
        }

        private void TratarExclusao()
        {
            ExcluirObjeto(objetoSelecionado);

            this.TipoAcao = ETipoAcaoCrud.Listando;
            Filtrar();
        }

        private ObservableCollection<TObj> lista;
        private Window janela = null;
        private ETipoAcaoCrud tipoAcao;
        private TObj objetoSelecionado = null;
        private ICommand consultar = null;
        private ICommand incluir = null;
        private ICommand alterar = null;
        private ICommand excluir = null;
        private ICommand salvar = null;
        private ICommand sair = null;
    }
}
