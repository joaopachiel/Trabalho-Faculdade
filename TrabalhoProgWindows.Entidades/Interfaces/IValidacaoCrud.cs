using System;
using System.Collections.Generic;
using System.Text;
using TrabalhoProgWindows.Entidades.Entidades;

namespace TrabalhoProgWindows.Entidades.Interfaces
{
    public interface IValidacaoCrud<T> where T : Entidade
    {
        IValidacaoResultado PodeInserir(T obj);
        IValidacaoResultado PodeAlterar(T obj);
        IValidacaoResultado PodeExcluir(int id);
    }
}
