using System;
using System.Collections.Generic;
using System.Text;
using TrabalhoProgWindows.Entidades.Interfaces;

namespace TrabalhoProgWindows.Entidades.Validacoes.Comum
{
    public class ValidacaoErro : IValidacaoErro
    {
        public ValidacaoErro(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }

        public ValidacaoErro(string mensagem)
        {
            Propriedade = "";
            Mensagem = mensagem;
        }

        public string Propriedade { get; set; }
        public string Mensagem { get; set; }
    }
}
