using System;
using System.Collections.Generic;
using System.Linq;
using TrabalhoProgWindows.Entidades.Entidades;
using TrabalhoProgWindows.Entidades.Validacoes;
using TrabalhoProgWindows.Infra.DAO;
using TrabalhoProgWindows.Infra.Data;

namespace TrabalhoProgWindowsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var contexto = new Contexto();
            var dao = new ProdutoDAO(contexto);
            var validacao = new ProdutoValidacaoService(dao);

            

            var p1 = dao.Filtrar(x => x.Descricao.Equals("Pão")).FirstOrDefault();

            
            var produtos = dao.Filtrar(x => x.Descricao.Contains("a"));

            foreach (var p in produtos)
            {
                dao.RealizarCargaTardia(p);
            }

            Imprimir(produtos);

            Console.WriteLine();

            Excluir(p1.Id, validacao, dao);

            produtos = dao.Filtrar(x => x.Descricao.Length > 1);

            foreach (var p in produtos)
            {
                dao.RealizarCargaTardia(p);
            }

            Imprimir(produtos);
        }

        private static void Imprimir(IEnumerable<Produto> produtos)
        {
            Console.WriteLine("Produtos:");

            foreach (var item in produtos)
            {
                Console.WriteLine(item.Descricao);

                foreach (var contato in item.Insumos)
                {
                    Console.WriteLine(contato.Insumo);
                }
            }
        }

        private static void Excluir(int id, ProdutoValidacaoService validacao, ProdutoDAO dao)
        {
            var result = validacao.Get().PodeExcluir(id);

            if (result.Erros.Count == 0)
                dao.Excluir(id);
        }

        private static void Alterar(Produto p, ProdutoValidacaoService validacao, ProdutoDAO dao)
        {
            var result = validacao.Get().PodeInserir(p);

            if (result.Erros.Count == 0)
                dao.Alterar(p);
        }

        private static void Inserir(Produto p, ProdutoValidacaoService validacao, ProdutoDAO dao)
        {
            var result = validacao.Get().PodeInserir(p);

            if (result.Erros.Count == 0)
                dao.Inserir(p);
            
        }
    }
}
