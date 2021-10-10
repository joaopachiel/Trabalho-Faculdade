using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TrabalhoProgWindows.Entidades.Interfaces
{
    public interface IBaseDAO<T>
    {
        void Inserir(T obj);
        void Excluir(int id);
        void Alterar(T obj);
        T RetornarPorId(int id);
        void RealizarCargaTardia(T obj);
        IEnumerable<T> Filtrar(Expression<Func<T, bool>> expressao);
        bool ObjetoExiste(int id);
        void DescartarAlteracao(T obj);
    }
}
