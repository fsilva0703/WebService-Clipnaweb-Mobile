using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class TipoSolicitacaoResult
    {
        /// <summary>
        /// Id do Tipo de Solicitação
        /// </summary>
        public Int32 IdTipoSolicitacao { get; set; }

        /// <summary>
        /// Tipo de Solicitação
        /// </summary>
        public String TipoSolicitacao { get; set; }
    }
}
