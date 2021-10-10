using System;
using System.Collections.Generic;
using System.Text;
using TrabalhoProgWindows.Entidades.Entidades;
using TrabalhoProgWindows.Entidades.Interfaces;

namespace TrabalhoProgWindows.Entidades.Validacoes.Comum
{
    public class CrudValidacaoService<TEntidade, KDao> : IValidacaoCrud<TEntidade> where TEntidade : Entidade where KDao : IBaseDAO<TEntidade>
    {
        public CrudValidacaoService(KDao dao, IValidacaoObjeto<TEntidade> validacaoObjeto)
        {
            this.dao = dao;
            this.validacaoObjeto = validacaoObjeto;
        }

        public IValidacaoResultado PodeAlterar(TEntidade obj)
        {
            var resultado = new ValidacaoResultado();

            if (obj == null)
                resultado.Erros.Add(new ValidacaoErro($"A entidade {validacaoObjeto.NomeEntidade.ToLower()} não foi informada."));
            else
            {
                validacaoObjeto.ValidarAlteracao(obj, resultado);
            }

            if (resultado.Erros.Count == 0)
            {
                if (!dao.ObjetoExiste(obj.Id))
                    resultado.Erros.Add(new ValidacaoErro($"A entidade {validacaoObjeto.NomeEntidade.ToLower()} informada não existe na base de dados e, por isso, não pode ser alterada."));
            }

            return resultado;
        }

        public IValidacaoResultado PodeExcluir(int id)
        {
            var resultado = new ValidacaoResultado();

            if (id == null)
                resultado.Erros.Add(new ValidacaoErro($"A chave para a entidade {validacaoObjeto.NomeEntidade.ToLower()} não foi informada."));
            else
            {
                validacaoObjeto.ValidarExclusao(id, resultado);
            }

            if (resultado.Erros.Count == 0)
            {
                if (!dao.ObjetoExiste(id))
                    resultado.Erros.Add(new ValidacaoErro($"A entidade {validacaoObjeto.NomeEntidade.ToLower()} informada não existe na base de dados e, por isso, não pode ser excluída."));
            }

            return resultado;
        }

        public IValidacaoResultado PodeInserir(TEntidade obj)
        {
            var resultado = new ValidacaoResultado();

            if (obj == null)
                resultado.Erros.Add(new ValidacaoErro($"A entidade {validacaoObjeto.NomeEntidade.ToLower()} não foi informada."));
            else
            {
                validacaoObjeto.ValidarInclusao(obj, resultado);
            }

            if (resultado.Erros.Count == 0)
            {
                if (obj.Id != null && dao.ObjetoExiste(obj.Id))
                    resultado.Erros.Add(new ValidacaoErro($"A entidade {validacaoObjeto.NomeEntidade.ToLower()} informada já existe na base de dados e, por isso, não pode ser incluída."));
            }

            return resultado;
        }

        private readonly KDao dao;
        private readonly IValidacaoObjeto<TEntidade> validacaoObjeto;
    }
}
