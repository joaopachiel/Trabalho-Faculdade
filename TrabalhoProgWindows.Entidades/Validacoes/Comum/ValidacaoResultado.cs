using System;
using System.Collections.Generic;
using System.Text;
using TrabalhoProgWindows.Entidades.Interfaces;

namespace TrabalhoProgWindows.Entidades.Validacoes.Comum
{
    public class ValidacaoResultado : IValidacaoResultado
    {
        public bool Ok => erros.Count == 0;
        public IList<IValidacaoErro> Erros => erros;

        private IList<IValidacaoErro> erros = new List<IValidacaoErro>();
    }
}
