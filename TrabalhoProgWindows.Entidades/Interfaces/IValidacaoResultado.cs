using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoProgWindows.Entidades.Interfaces
{
    public interface IValidacaoResultado
    {
        bool Ok { get; }
        IList<IValidacaoErro> Erros { get; }
    }
}
