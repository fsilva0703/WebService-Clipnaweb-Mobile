using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class RecursoResult
    {
        /// <summary>
        /// Id do Sistema
        /// </summary>
        public Int32 IdSistema { get; set; }

        /// <summary>
        /// Nome do Sistema
        /// </summary>
        public String NomeSistema { get; set; }

        /// <summary>
        /// Id do Recurso
        /// </summary>
        public Int32 IdRecurso { get; set; }

        /// <summary>
        /// Nome do Módulo
        /// </summary>
        public String NomeModulo { get; set; }

        /// <summary>
        /// Descrição do Recurso
        /// </summary>
        public String DescricaoRecurso { get; set; }

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
