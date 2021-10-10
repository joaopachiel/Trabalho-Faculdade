using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TrabalhoProgWindows.View.Auxiliares
{
    public class MeuComando : ICommand
    {
        public MeuComando(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public MeuComando(Action execute) : this(execute, () => true) { }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => canExecute();

        public void Execute(object parameter) => execute();

        private Func<bool> canExecute = null;
        private Action execute = null;
    }
}
