using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class RecursoListParameter
    {
        
        /// <summary>
        /// Nome do Módulo
        /// </summary>
        public String NomeModulo { get; set; }

        /// <summary>
        /// Nome do Módulo
        /// </summary>
        public String DescricaoRecurso { get; set; }

        /// <summary>
        /// ID do Tipo de Solicitação
        /// </summary>
        public Int32 IdTipoSolicitacao { get; set; }
    }
}
