using System;
using System.Collections.Generic;
using System.Text;
using TrabalhoProgWindows.Entidades.Entidades;
using TrabalhoProgWindows.Entidades.Interfaces;
using TrabalhoProgWindows.Entidades.Validacoes.Comum;

namespace TrabalhoProgWindows.Entidades.Validacoes
{
    public class ProdutoValidacaoService
    {
        public ProdutoValidacaoService(IProdutoDAO dao)
        {
            validacaoEspecifica = new ProdutoValidacao(dao);
            validacao = new CrudValidacaoService<Produto, IProdutoDAO>(dao, validacaoEspecifica);
        }

        public CrudValidacaoService<Produto, IProdutoDAO> Get()
        {
            return validacao;
        }

        private readonly CrudValidacaoService<Produto, IProdutoDAO> validacao;
        private readonly ProdutoValidacao validacaoEspecifica;
    }
}
