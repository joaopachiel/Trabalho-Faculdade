using System;
using System.Collections.Generic;
using System.Text;
using TrabalhoProgWindows.Entidades.Entidades;

namespace TrabalhoProgWindows.Entidades.Interfaces
{
    public interface IValidacaoObjeto<T> where T : Entidade
    {
        string NomeEntidade { get; }
        void ValidarAlteracao(T obj, IValidacaoResultado resultado);
        void ValidarInclusao(T obj, IValidacaoResultado resultado);
        void ValidarExclusao(int id, IValidacaoResultado resultado);
    }
}
