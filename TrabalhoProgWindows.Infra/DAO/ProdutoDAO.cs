using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TrabalhoProgWindows.Entidades.Entidades;
using TrabalhoProgWindows.Entidades.Interfaces;
using TrabalhoProgWindows.Infra.Data;

namespace TrabalhoProgWindows.Infra.DAO
{
    public class ProdutoDAO : IProdutoDAO
    {
        public ProdutoDAO(Contexto contexto) => this.contexto = contexto;

        public void Alterar(Produto obj)
        {
            contexto.Produto.Update(obj);
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            var obj = contexto.Produto.Where(x => x.Id.Equals(id)).FirstOrDefault();

            if (obj != null)
            {
                contexto.Produto.Remove(obj);
                contexto.SaveChanges();
            }
        }

        public void Inserir(Produto obj)
        {
            contexto.Produto.Add(obj);
            contexto.SaveChanges();
        }

        public bool ObjetoExiste(int id)
        {
            return contexto.Produto.Where(x => x.Id.Equals(id)).Count() > 0;
        }

        public void RealizarCargaTardia(Produto obj)
        {
            if (obj != null)
                obj.Insumos = contexto.ProdutoInsumo.Where(x => x.ProdutoId.Equals(obj.Id)).ToList();
        }

        public Produto RetornarPorId(int id)
        {
            return contexto.Produto.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Produto> Filtrar(Expression<Func<Produto, bool>> expressao)
        {
            return contexto.Produto.Where(expressao).ToList();
        }

        public void DescartarAlteracao(Produto obj)
        {
            if (obj != null)
                contexto.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        private readonly Contexto contexto;
    }
}
